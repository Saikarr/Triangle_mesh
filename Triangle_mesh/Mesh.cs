using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_mesh
{
    class Mesh
    {
        //private Vector3 light = Vector3.Normalize(new Vector3(0, 0, 100));
        public Vector3[,] OriginalControlPoints { get; set; }
        public Vector3[,] ControlPoints { get; set; }
        public Triangle[,] Triangles { get; set; }
        public Mesh(Vector3[,] controlPoints)
        {
            OriginalControlPoints = new Vector3[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    OriginalControlPoints[i, j] = controlPoints[i, j];
                }
            }
            ControlPoints = new Vector3[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ControlPoints[i, j] = controlPoints[i, j];
                }
            }
            CalculateTriangles(10);
        }


        public Vector3 BezierPoint(float u, float v)
        {
            Vector3 point = new Vector3(0, 0, 0);
            int n = 3; // Since we have 4 control points in each direction

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    float bernsteinU = Bernstein(n, i, u);
                    float bernsteinV = Bernstein(n, j, v);
                    point += bernsteinU * bernsteinV * OriginalControlPoints[i, j]; //ControlPoints[i, j];
                }
            }
            return point;
        }

        private float Bernstein(int n, int i, float t)
        {
            return (float)(BinomialCoefficient(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i));
        }

        private int BinomialCoefficient(int n, int k)
        {
            int result = 1;
            for (int i = 0; i < k; i++)
            {
                result = (result * (n - i)) / (i + 1);
                //result *= (n - (k - i));
                //result /= i;
            }
            return result;
        }
        public void Draw(Bitmap BM, PaintEventArgs e, int m, float kd, float ks, Color lightcolor, Color objectcolor,
            Vector3 light, bool IsOnlyMesh, bool IsOnlyFill, bool IsTexture, Bitmap texture)
        {
            //int m = 10;
            //float kd = 0.5F;
            //float ks = 0.5F;
            //Vector3 V = new Vector3(0, 0, 1);
            //Vector3 LightColor = new Vector3(1, 1, 1);
            //Vector3 ObjectColor = new Vector3(1, 0, 0);

            Vector3 LightColorV = Vector3.Normalize(new Vector3(lightcolor.R, lightcolor.G, lightcolor.B));
            if (lightcolor == Color.Black)
                LightColorV = Vector3.Zero;

            Vector3 ObjectColorV = Vector3.Normalize(new Vector3(objectcolor.R, objectcolor.G, objectcolor.B));
            if (objectcolor == Color.Black)
                ObjectColorV = Vector3.Zero;

            if (!IsOnlyMesh)
            {
                foreach (Triangle triangle in Triangles)
                {
                    //e.Graphics.DrawLine(Pens.Black, triangle.Vertices[0].Position.X, triangle.Vertices[0].Position.Y, triangle.Vertices[1].Position.X, triangle.Vertices[1].Position.Y);
                    //e.Graphics.DrawLine(Pens.Black, triangle.Vertices[1].Position.X, triangle.Vertices[1].Position.Y, triangle.Vertices[2].Position.X, triangle.Vertices[2].Position.Y);
                    //e.Graphics.DrawLine(Pens.Black, triangle.Vertices[2].Position.X, triangle.Vertices[2].Position.Y, triangle.Vertices[0].Position.X, triangle.Vertices[0].Position.Y);
                    //Vector3 R = 2 * triangle.Vertices[0].NormalizedNormal * Vector3.Dot(triangle.Vertices[0].NormalizedNormal, light) - light;
                    //float cosnl = Vector3.Dot(triangle.Vertices[0].NormalizedNormal, light);
                    //if (cosnl < 0) cosnl = 0;
                    //float cosvr = Vector3.Dot(V, Vector3.Normalize(R));
                    //if (cosvr < 0) cosvr = 0;
                    //Vector3 color = kd * LightColor * ObjectColor * cosnl +
                    //    ks * LightColor * ObjectColor * (float)Math.Pow(cosvr, m);
                    //Color c = Color.FromArgb((int)(color.X * 255) > 255 ? 255 : (int)(color.X * 255),
                    //    (int)(color.Y * 255) > 255 ? 255 : (int)(color.Y * 255), (int)(color.Z * 255) > 255 ? 255 : (int)(color.Z * 255));
                    //Brush brush = new SolidBrush(c);

                    Point[] triangleVertices = new Point[] { new Point((int)triangle.Vertices[0].Position.X, (int)triangle.Vertices[0].Position.Y + 250),
                    new Point((int)triangle.Vertices[1].Position.X, (int)triangle.Vertices[1].Position.Y + 250),
                    new Point((int)triangle.Vertices[2].Position.X, (int)triangle.Vertices[2].Position.Y + 250)};

                    TriangleFiller filler = new TriangleFiller();
                    lock (triangle)
                    {
                        filler.FillPolygon(e.Graphics, triangleVertices, triangle, m, kd, ks, BM, LightColorV, ObjectColorV, light, IsTexture, texture);
                    }
                    //e.Graphics.FillPolygon(brush, new PointF[] { new PointF(triangle.Vertices[0].Position.X, triangle.Vertices[0].Position.Y),
                    //    new PointF(triangle.Vertices[1].Position.X, triangle.Vertices[1].Position.Y),
                    //    new PointF(triangle.Vertices[2].Position.X, triangle.Vertices[2].Position.Y)});

                }
            }
            if (!IsOnlyMesh && !IsOnlyFill)
            {
                lock (ControlPoints)
                {
                    Vector3[,] controlPoints = ControlPoints;
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            e.Graphics.FillEllipse(Brushes.Black, controlPoints[i, j].X - 2, controlPoints[i, j].Y - 2, 4, 4);
                            if (j != 3)
                            {
                                e.Graphics.DrawLine(Pens.Black, controlPoints[i, j].X, controlPoints[i, j].Y, controlPoints[i, j + 1].X, controlPoints[i, j + 1].Y);
                            }
                            if (i != 3)
                            {
                                e.Graphics.DrawLine(Pens.Black, controlPoints[i, j].X, controlPoints[i, j].Y, controlPoints[i + 1, j].X, controlPoints[i + 1, j].Y);
                            }
                        }
                    }
                }
            }
            if (!IsOnlyFill)
            {
                foreach (Triangle triangle in Triangles)
                {
                    e.Graphics.DrawLine(Pens.Black, triangle.Vertices[0].Position.X, triangle.Vertices[0].Position.Y, triangle.Vertices[1].Position.X, triangle.Vertices[1].Position.Y);
                    e.Graphics.DrawLine(Pens.Black, triangle.Vertices[1].Position.X, triangle.Vertices[1].Position.Y, triangle.Vertices[2].Position.X, triangle.Vertices[2].Position.Y);
                    e.Graphics.DrawLine(Pens.Black, triangle.Vertices[2].Position.X, triangle.Vertices[2].Position.Y, triangle.Vertices[0].Position.X, triangle.Vertices[0].Position.Y);
                }
            }
        }

        public void CalculateTriangles(int size)
        {
            Triangles = new Triangle[size * 2, size];
            for (int i = 0; i < size * 2; i = i + 2)
            {
                for (int j = 0; j < size; j++)
                {
                    float u1 = i / 2 / (float)size;
                    float u2 = (i / 2 + 1) / (float)size;

                    float v1 = j / (float)size;
                    float v2 = (j + 1) / (float)size;

                    Vector3 p1 = BezierPoint(u1, v1);
                    Vector3 p2 = BezierPoint(u1, v2);
                    Vector3 p3 = BezierPoint(u2, v1);
                    Vector3 p4 = BezierPoint(u2, v2);

                    Vector3 utan1 = UTangent(u1, v1);
                    Vector3 utan2 = UTangent(u1, v2);
                    Vector3 utan3 = UTangent(u2, v1);
                    Vector3 utan4 = UTangent(u2, v2);

                    Vector3 vtan1 = VTangent(u1, v1);
                    Vector3 vtan2 = VTangent(u1, v2);
                    Vector3 vtan3 = VTangent(u2, v1);
                    Vector3 vtan4 = VTangent(u2, v2);

                    Triangles[i, j] = new Triangle([new Vertex(p1, utan1, vtan1, u1, v1),
                        new Vertex(p2, utan2, vtan2, u1, v2),
                        new Vertex(p3, utan3, vtan3, u2, v1)]);
                    Triangles[i + 1, j] = new Triangle([new Vertex(p4, utan4, vtan4, u2, v2),
                        new Vertex(p2, utan2, vtan2, u1, v2),
                        new Vertex(p3, utan3, vtan3, u2, v1)]);

                    //Triangles[i, j] = new Triangle([new Vertex(p1),
                    //    new Vertex(p2),
                    //    new Vertex(p3)]);
                    //Triangles[i + 1, j] = new Triangle([new Vertex(p4),
                    //    new Vertex(p2),
                    //    new Vertex(p3)]);
                }
            }
        }

        public Vector3 UTangent(float u, float v)
        {
            Vector3 tangent = new Vector3(0, 0, 0);
            int n = 3; // Since we have 4 control points in each direction

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    float bernsteinU = Bernstein(n - 1, i, u);
                    float bernsteinV = Bernstein(n, j, v);
                    tangent += bernsteinU * bernsteinV * (OriginalControlPoints[i + 1, j] - OriginalControlPoints[i, j]); //ControlPoints[i, j];
                }
            }
            return tangent;
        }
        public Vector3 VTangent(float u, float v)
        {
            Vector3 tangent = new Vector3(0, 0, 0);
            int n = 3; // Since we have 4 control points in each direction

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    float bernsteinU = Bernstein(n, i, u);
                    float bernsteinV = Bernstein(n - 1, j, v);
                    tangent += bernsteinU * bernsteinV * (OriginalControlPoints[i, j + 1] - OriginalControlPoints[i, j]); //ControlPoints[i, j];
                }
            }
            return tangent;
        }

        public void Rotate(int alpha, int beta, bool IsNormalMap, Bitmap NormalMap)
        {
            double alphaRad = alpha * Math.PI / 180;
            double betaRad = beta * Math.PI / 180;
            lock (ControlPoints)
            {
                Vector3[,] controlPoints = ControlPoints;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        float x = OriginalControlPoints[i, j].X;
                        float y = OriginalControlPoints[i, j].Y;
                        float z = OriginalControlPoints[i, j].Z;

                        controlPoints[i, j] = new Vector3(
                            (float)(x * Math.Cos(alphaRad) - y * Math.Sin(alphaRad)),
                            (float)((x * Math.Sin(alphaRad) + y * Math.Cos(alphaRad)) * Math.Cos(betaRad) - z * Math.Sin(betaRad)),
                            (float)((x * Math.Sin(alphaRad) + y * Math.Cos(alphaRad)) * Math.Sin(betaRad) + z * Math.Cos(betaRad))
                        );
                    }
                }
            }
            lock (Triangles)
            {
                foreach (Triangle triangle in Triangles)
                {
                    lock (triangle)
                    {
                        triangle.Rotate(alpha, beta, IsNormalMap, NormalMap);
                    }
                }
            }
        }

        public static Vector3[,] ReadControlPoints(string path)
        {
            Vector3[,] points = new Vector3[4, 4];
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string[] line = lines[i * 4 + j].Split(' ');
                    points[i, j] = new Vector3(float.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
                }
            }
            return points;
        }
    }
}
