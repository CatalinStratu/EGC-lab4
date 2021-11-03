using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Collections.Generic;

namespace Proiect
{
    class Cub_CitireFisier_
    {
        private const String FILENAME = "assets/cub.txt";
        private const int FACTOR_SCALARE_IMPORT = 1;
        private List<Vector3> coordsList;
        private bool visibility;
        private Color color1,color2;
        private float maxColor = 1.0f;
        private float minColor = 0.0f;
        private float R = 0, G = 0, B = 0;
       

        public Cub_CitireFisier_(Color color)
        {
            color1 = color;
            
            visibility = true;
        }

        public void ChangeColor(float r, float g, float b)
        {
            if (R < maxColor)
                R += r;
            if (B < maxColor)
                B += b;
            if (R < maxColor)
                G += g;

        }
        private List<Vector3> LoadFromObjFile(string fname)
        {
            List<Vector3> vlc3 = new List<Vector3>();


            var lines = File.ReadLines(fname);
            foreach (var line in lines)
            {
                string[] block = line.Trim().Split(' ');
                float xval = float.Parse(block[0].Trim()) * FACTOR_SCALARE_IMPORT;
                float yval = float.Parse(block[1].Trim()) * FACTOR_SCALARE_IMPORT;
                float zval = float.Parse(block[2].Trim()) * FACTOR_SCALARE_IMPORT;
                vlc3.Add(new Vector3((int)xval, (int)yval, (int)zval));
            }

          return vlc3;
        }
        public void Draw()
        {
            if (visibility == true)
            {
                coordsList = LoadFromObjFile(FILENAME);
                GL.Color3(color1);
                GL.Begin(PrimitiveType.Quads);
                foreach (var vert in coordsList)
                {
                    GL.Vertex3(vert);
                }
                GL.End();
            }
        }
        public void ModificaValoareaFetei()
        {
            coordsList = LoadFromObjFile(FILENAME);
            if (visibility == true)
            {
                int i=0;
                GL.Color3(color1);
                GL.Begin(PrimitiveType.Quads);
                foreach (var vert in coordsList)
                {
               
                    if (i==20) 
                    {
                        GL.Color3(minColor + R, minColor + G, minColor + B);
                    }
                   
                    GL.Vertex3(vert);
                    i++;
                }
                GL.End();
            }
        }

    }
}
