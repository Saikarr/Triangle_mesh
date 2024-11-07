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
        public float U {  get; set; }
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
            Position = position;
            UTangent = utangent;
            OriginalUTangent = utangent;
            VTangent = vtangent;
            OriginalVTangent = vtangent;
            Vector3 normal = Vector3.Cross(utangent, vtangent);
            Normal = normal;
            OriginalNormal = normal;
            NormalizedNormal = Vector3.Normalize(normal);
            U = u;
            V = v;
        }

        public void Rotate(int alpha, int beta)
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
            NormalizedNormal = Vector3.Normalize(Normal);
        }
    }
}
