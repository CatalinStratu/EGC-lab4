using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;


namespace Proiect
{
    class Triangle3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color1,color2,color3;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private Randomizer localRando;
        private PolygonMode polMode;

        public Triangle3D(Randomizer _r)
        {
            localRando = _r;
            pointA = _r.Generate3DPoint();
            pointB = _r.Generate3DPoint();
            pointC = _r.Generate3DPoint();
            color1 = _r.RandomColor();
            color2 = _r.RandomColor();
            color3 = _r.RandomColor();

            Inits();
        }

        private void Inits()
        {
            visibility = true;
            linewidth = 3.0f;
            pointsize = 3.0f;
            polMode = PolygonMode.Fill;
        }

        public void Draw()
        {
            if (visibility)
            {
                
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(color1);
                GL.Vertex3(pointA);
                GL.Color3(color2);
                GL.Vertex3(pointB);
                GL.Color3(color3);
                GL.Vertex3(pointC);
                GL.End();
            }
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

    
        public void DiscoMode1()
        {
            color1 = localRando.RandomColor();
            color2 = localRando.RandomColor();
            color3 = localRando.RandomColor();
        }

    }
}
