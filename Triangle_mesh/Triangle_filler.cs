using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_mesh
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Numerics;
    using System.Security.Cryptography;

    public class TriangleFiller
    {
        private struct Edge
        {
            public int yMax;
            public float xMin;
            public float slopeInverse;
        }

        private List<List<Edge>> edgeTable;
        private List<Edge> activeEdgeTable;

        public TriangleFiller()
        {
            edgeTable = new List<List<Edge>>();
            activeEdgeTable = new List<Edge>();
        }

        private void InitializeEdgeTable(Point[] vertices)
        {
            // Find the maximum y-value to determine the height of the edge table
            int yMax = 0;
            foreach (var vertex in vertices)
            {
                if (vertex.Y > yMax)
                    yMax = vertex.Y;
            }

            // Initialize edge table with empty lists for each y-coordinate
            edgeTable = new List<List<Edge>>(new List<Edge>[yMax + 1]);

            // Build edges and add them to the edge table
            for (int i = 0; i < vertices.Length; i++)
            {
                Point start = vertices[i];
                Point end = vertices[(i + 1) % vertices.Length];

                if (start.Y == end.Y) // Ignore horizontal edges
                    continue;

                if (start.Y > end.Y)
                {
                    var temp = start;
                    start = end;
                    end = temp;
                }

                Edge edge = new Edge
                {
                    yMax = end.Y - 1, //  maybe change
                    xMin = start.X,
                    slopeInverse = (float)(end.X - start.X) / (end.Y - start.Y)
                };

                if (edgeTable[start.Y] == null)
                {
                    edgeTable[start.Y] = new List<Edge>();
                }
                edgeTable[start.Y].Add(edge);
            }
        }

        private void InsertEdgesToAET(int scanline)
        {
            if (edgeTable[scanline] != null)
            {
                foreach (var edge in edgeTable[scanline])
                {
                    activeEdgeTable.Add(edge);
                }
            }
        }

        private void RemoveEdgesFromAET(int scanline)
        {
            activeEdgeTable.RemoveAll(edge => edge.yMax <= scanline);
        }

        private void UpdateXInAET()
        {
            for (int i = 0; i < activeEdgeTable.Count; i++)
            {
                var edge = activeEdgeTable[i];
                edge.xMin += edge.slopeInverse;
                activeEdgeTable[i] = edge;
            }
        }

        public void FillPolygon(Graphics graphics, Point[] vertices, Triangle triangle, int m, float kd, float ks, 
            Bitmap BM, Vector3 LightColor, Vector3 ObjectColor, Vector3 light)
        {
            InitializeEdgeTable(vertices);

            // Determine the starting and ending scanlines for the polygon
            int yMin = int.MaxValue;
            int yMax = int.MinValue;

            foreach (var vertex in vertices)
            {
                if (vertex.Y < yMin)
                    yMin = vertex.Y;
                if (vertex.Y > yMax)
                    yMax = vertex.Y;
            }

            Vector3 V = new Vector3(0, 0, 1);
            //Vector3 LightColor = new Vector3(1, 1, 1);
            //Vector3 ObjectColor = new Vector3(1, 0, 0);
            //Vector3 light = new Vector3(200, 0, -200);

            // Scan through each scanline
            for (int scanline = yMin; scanline <= yMax; scanline++)
            {
                // 1. Add edges to AET where yMin == scanline
                InsertEdgesToAET(scanline);

                // 2. Sort AET by xMin (using Bubble Sort or any stable sort for simplicity)
                activeEdgeTable.Sort((a, b) => a.xMin.CompareTo(b.xMin));

                int fixedscanline = scanline - 250;
                // 3. Fill between pairs of x-coordinates in the AET
                for (int i = 0; i < activeEdgeTable.Count; i += 2)
                {
                    if (i + 1 < activeEdgeTable.Count)
                    {
                        int xStart = (int)Math.Round(activeEdgeTable[i].xMin);
                        int xEnd = (int)Math.Round(activeEdgeTable[i + 1].xMin);
                        for (int j = xStart; j <= xEnd; j++)
                        {
                            //Vector2 v0 = new Vector2(vertices[1].X - vertices[0].X, vertices[1].Y - vertices[0].Y),
                            //    v1 = new Vector2(vertices[2].X - vertices[0].X, vertices[2].Y - vertices[0].Y),
                            //    v2 = new Vector2(j - vertices[0].X, scanline - vertices[0].Y);

                            Vector2 v0 = new Vector2(vertices[0].X - vertices[2].X, vertices[0].Y - vertices[2].Y),
                                v1 = new Vector2(vertices[1].X - vertices[2].X, vertices[1].Y - vertices[2].Y),
                                v2 = new Vector2(j - vertices[2].X, scanline - vertices[2].Y);
                            float d00 = Vector2.Dot(v0, v0);
                            float d01 = Vector2.Dot(v0, v1);
                            float d11 = Vector2.Dot(v1, v1);
                            float d20 = Vector2.Dot(v2, v0);
                            float d21 = Vector2.Dot(v2, v1);
                            float denom = d00 * d11 - d01 * d01;
                            float w1 = (d11 * d20 - d01 * d21) / denom;
                            float w2 = (d00 * d21 - d01 * d20) / denom;
                            float w3 = 1.0f - w1 - w2;

                            Vector3 position = new Vector3(j, scanline, w1 * triangle.Vertices[0].Position.Z +
                                w2 * triangle.Vertices[1].Position.Z + w3 * triangle.Vertices[2].Position.Z);
                            Vector3 lightvector = Vector3.Normalize(position - light);
                            Vector3 interpolatedNormal = w1 * triangle.Vertices[0].NormalizedNormal
                                + w2 * triangle.Vertices[1].NormalizedNormal + w3 * triangle.Vertices[2].NormalizedNormal;

                            Vector3 R = 2 * interpolatedNormal * Vector3.Dot(interpolatedNormal, lightvector) - lightvector;
                            float cosnl = Vector3.Dot(interpolatedNormal, lightvector);
                            if (cosnl < 0) cosnl = 0;
                            float cosvr = Vector3.Dot(V, Vector3.Normalize(R));
                            if (cosvr < 0) cosvr = 0;
                            Vector3 color = kd * LightColor * ObjectColor * cosnl +
                                ks * LightColor * ObjectColor * (float)Math.Pow(cosvr, m);
                            Color c = Color.FromArgb((int)(color.X * 255) > 255 ? 255 : (int)(color.X * 255),
                                (int)(color.Y * 255) > 255 ? 255 : (int)(color.Y * 255), (int)(color.Z * 255) > 255 ? 255 : (int)(color.Z * 255));
                            
                            BM.SetPixel(j + 250, scanline, c);
                            //BM.SetPixel(j + 250, scanline + 1, c); // maybe change
                        }
                        // Draw a horizontal line between xStart and xEnd on the current scanline
                        //graphics.DrawLine(new Pen(brush), xStart, scanline - 250, xEnd, scanline - 250);
                    }
                }

                // 4. Remove edges where yMax == scanline from AET
                RemoveEdgesFromAET(scanline);

                // 5. Update xMin for each edge in AET for the next scanline
                UpdateXInAET();
            }
        }
    }

}
