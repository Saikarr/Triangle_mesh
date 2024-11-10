using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_mesh
{
    public class Vertex
    {
        public float U { get; set; }
        public float V { get; set; }
        public Vector3 OriginalPosition { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 OriginalNormal { get; set; }
        public Vector3 NormalizedNormal { get; set; }
        public Vector3 UTangent { get; set; }
        public Vector3 OriginalUTangent { get; set; }
        public Vector3 VTangent { get; set; }
        public Vector3 OriginalVTangent { get; set; }
        public Vertex(Vector3 position, Vector3 utangent, Vector3 vtangent, float u, float v)
        {
            OriginalPosition = position;
            Position = new Vector3(position.X, position.Y, position.Z);
            UTangent = new Vector3(utangent.X, utangent.Y, utangent.Z);
            OriginalUTangent = utangent;
            VTangent = new Vector3(vtangent.X, vtangent.Y, vtangent.Z);
            OriginalVTangent = vtangent;
            Vector3 normal = Vector3.Cross(utangent, vtangent);
            Normal = new Vector3(normal.X, normal.Y, normal.Z); ;
            OriginalNormal = normal;
            NormalizedNormal = Vector3.Normalize(normal);
            U = u;
            V = v;
        }

        public void Rotate(int alpha, int beta, bool IsNormalMap, Bitmap NormalMap)
        {
            double alphaRad = alpha * Math.PI / 180;
            double betaRad = beta * Math.PI / 180;

            double x = OriginalPosition.X;
            double y = OriginalPosition.Y;
            double z = OriginalPosition.Z;
            Position = new Vector3(
                (float)(x * Math.Cos(alphaRad) - y * Math.Sin(alphaRad)),
                (float)((x * Math.Sin(alphaRad) + y * Math.Cos(alphaRad)) * Math.Cos(betaRad) - z * Math.Sin(betaRad)),
                (float)((x * Math.Sin(alphaRad) + y * Math.Cos(alphaRad)) * Math.Sin(betaRad) + z * Math.Cos(betaRad))
            );

            double xo = OriginalNormal.X;
            double yo = OriginalNormal.Y;
            double zo = OriginalNormal.Z;
            Normal = new Vector3(
                (float)(xo * Math.Cos(alphaRad) - yo * Math.Sin(alphaRad)),
                (float)((xo * Math.Sin(alphaRad) + yo * Math.Cos(alphaRad)) * Math.Cos(betaRad) - zo * Math.Sin(betaRad)),
                (float)((xo * Math.Sin(alphaRad) + yo * Math.Cos(alphaRad)) * Math.Sin(betaRad) + zo * Math.Cos(betaRad))
            );

            double xu = OriginalUTangent.X;
            double yu = OriginalUTangent.Y;
            double zu = OriginalUTangent.Z;
            UTangent = new Vector3(
                (float)(xu * Math.Cos(alphaRad) - yu * Math.Sin(alphaRad)),
                (float)((xu * Math.Sin(alphaRad) + yu * Math.Cos(alphaRad)) * Math.Cos(betaRad) - zu * Math.Sin(betaRad)),
                (float)((xu * Math.Sin(alphaRad) + yu * Math.Cos(alphaRad)) * Math.Sin(betaRad) + zu * Math.Cos(betaRad))
            );

            double xv = OriginalVTangent.X;
            double yv = OriginalVTangent.Y;
            double zv = OriginalVTangent.Z;
            VTangent = new Vector3(
                (float)(xv * Math.Cos(alphaRad) - yv * Math.Sin(alphaRad)),
                (float)((xv * Math.Sin(alphaRad) + yv * Math.Cos(alphaRad)) * Math.Cos(betaRad) - zv * Math.Sin(betaRad)),
                (float)((xv * Math.Sin(alphaRad) + yv * Math.Cos(alphaRad)) * Math.Sin(betaRad) + zv * Math.Cos(betaRad))
            );

            if (IsNormalMap)
            {
                float xn = Normal.X;
                float yn = Normal.Y;
                float zn = Normal.Z;

                Color normalcolor = NormalMap.GetPixel((int)(U * (NormalMap.Width - 1)), (int)(V * (NormalMap.Height - 1)));
                Vector3 normalcolorvector = new Vector3(2 * (float)normalcolor.R / 255 - 1,
                    2 * (float)normalcolor.G / 255 - 1, 2 * (float)normalcolor.B / 255);//(float)normalcolor.B / 255 - 1);

                float n1 = normalcolorvector.X * UTangent.X + normalcolorvector.Y * VTangent.X
                    + normalcolorvector.Z * xn;
                float n2 = normalcolorvector.X * UTangent.Y + normalcolorvector.Y * VTangent.Y
                    + normalcolorvector.Z * yn;
                float n3 = normalcolorvector.X * UTangent.Z + normalcolorvector.Y * VTangent.Z
                    + normalcolorvector.Z * zn;

                Normal = new Vector3(n1, n2, n3);
            }

            NormalizedNormal = Vector3.Normalize(Normal);
        }
    }
}
