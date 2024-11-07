using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_mesh
{
    public class Triangle
    {
        public Vertex[] Vertices { get; set; }
        public Triangle(Vertex[] vertices)
        {
            Vertices = new Vertex[3];
            for (int i = 0; i < 3; i++)
            {
                Vertices[i] = vertices[i];
            }
        }

        public void Draw(System.Drawing.Graphics g)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);
            g.DrawLine(pen, Vertices[0].Position.X, Vertices[0].Position.Y, Vertices[1].Position.X, Vertices[1].Position.Y);
            g.DrawLine(pen, Vertices[1].Position.X, Vertices[1].Position.Y, Vertices[2].Position.X, Vertices[2].Position.Y);
            g.DrawLine(pen, Vertices[2].Position.X, Vertices[2].Position.Y, Vertices[0].Position.X, Vertices[0].Position.Y);
        }

        public void Rotate(int alpha, int beta)
        {
            for (int i = 0; i < 3; i++)
            {
                Vertices[i].Rotate(alpha, beta);
            }
        }
    }
}
