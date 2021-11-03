using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Proiect
{
    class Punct
    {
            public double x, y, z;
            public bool verif;
            public Color culoare;
            public void change_verif()
            {
                if (verif)
                    verif = false;
                else
                    verif = true;
            }
            public Punct(double x, double y, double z)
            {
                this.x = x;
                this.y = y; this.z = z;

            }
            public Punct(int x, int y, int z, Color cul)
            {
                this.x = x;
                this.y = y; this.z = z;
                this.culoare = cul;
            }
            public void setX(int x)
            {
                this.x = x;
            }
            public void setY(int y)
            {
                this.y = y;
            }

            public void setZ(int z)
            {
                this.z = z;
            }
        }
}
