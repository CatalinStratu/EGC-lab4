using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Proiect.asstest
{
    class Cub
    {
        private Color color1, color2, color3;
        private Randomizer localRando;

        private int[,] objVertices = {
            {5, 10, 5,
                10, 5, 10,
                5, 10, 5,
                10, 5, 10,
                5, 5, 5,
                5, 5, 5,
                5, 10, 5,
                10, 10, 5,
                10, 10, 10,
                10, 10, 10,
                5, 10, 5,
                10, 10, 5},
            {5, 5, 12,
                5, 12, 12,
                5, 5, 5,
                5, 5, 5,
                5, 12, 5,
                12, 5, 12,
                12, 12, 12,
                12, 12, 12,
                5, 12, 5,
                12, 5, 12,
                5, 5, 12,
                5, 12, 12},
            {6, 6, 6,
                6, 6, 6,
                6, 6, 12,
                6, 12, 12,
                6, 6, 12,
                6, 12, 12,
                6, 6, 12,
                6, 12, 12,
                6, 6, 12,
                6, 12, 12,
                12, 12, 12,
                12, 12, 12}};

        public Cub(Randomizer _r)
        {
            localRando = _r;
            color1 = _r.RandomColor();
            color2 = _r.RandomColor();
            color3 = _r.RandomColor();

            
        }
        public void DrawCube()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 35; i = i + 3)
            {
                //For i As Integer = 0 To 35 Step 3
                GL.Color3(color1);
                GL.Vertex3(objVertices[0, i], objVertices[1, i], objVertices[2, i]);
                GL.Color3(color2);
                GL.Vertex3(objVertices[0, i + 1], objVertices[1, i + 1], objVertices[2, i + 1]);
                GL.Color3(color3);
                GL.Vertex3(objVertices[0, i + 2], objVertices[1, i + 2], objVertices[2, i + 2]);
            }
            GL.End();
        }

    }
}
