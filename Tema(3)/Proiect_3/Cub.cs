using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Proiect.asstest
{
    class Cub
    {
        public Punct A, B, C, D, E,F,R,G,K;
        public bool verif;
        private Color color1, color2, color3,color4,color5,color6;
        private Randomizer localRando;
        public int offset = 1;
        public bool vazut;
        public void change_verif()
        {
            if (verif)
                verif = true;
            else
                verif = false;
        }
        public void change_color()
        {
            if (vazut)
                vazut = true;
            else
                vazut = false;
        }
        
        public Cub(Randomizer _r)
        {
            verif = true;
            localRando = _r;
            color1 = _r.RandomColor();
            color2 = _r.RandomColor();
            color3 = _r.RandomColor();
            color4 = _r.RandomColor();
            color5 = _r.RandomColor();
            color6 = _r.RandomColor();

            A = new Punct(-5,-5,-5);
            B = new Punct(-5,5,-5);
            C = new Punct(5,5,-5);
            D = new Punct(5,-5,-5);
            E = new Punct(-5, -5, 5);
            F = new Punct(5, -5, 5);
            R = new Punct(-5,-5,5);
            G = new Punct(-5, 5, 5);
            K = new Punct(5, 5, 5);
        }
        public void Move(bool sus, bool jos,bool stanga,bool dreapta)

        {
            {
                if (sus == true)
                {
                    A.y += offset;
                    B.y += offset;
                    C.y += offset;
                    D.y += offset;
                    E.y += offset;
                    F.y += offset;
                    R.y += offset;
                    G.y += offset;
                    K.y += offset;
                }
                if (jos == true)
                {
                    A.y -= offset;
                    B.y -= offset;
                    C.y -= offset;
                    D.y -= offset;
                    E.y -= offset;
                    F.y -= offset;
                    R.y -= offset;
                    G.y -= offset;
                    K.y -= offset;
                }
                if (stanga == true)
                {
                    A.y -= offset;
                    B.y -= offset;
                    C.y -= offset;
                    D.y -= offset;
                    E.y -= offset;
                    F.y -= offset;
                    R.y -= offset;
                    G.y -= offset;
                    K.y -= offset;
                }
                if (dreapta == true)
                {
                    A.y += offset;
                    B.y += offset;
                    C.y += offset;
                    D.y += offset;
                    E.y += offset;
                    F.y += offset;
                    R.y += offset;
                    G.y += offset;
                    K.y += offset;
                }
                
            }
        }
        public void DiscoMode1()
        {
            color1 = localRando.RandomColor();
            color2= localRando.RandomColor();
            color3 = localRando.RandomColor();
            color4 = localRando.RandomColor();
            color5 = localRando.RandomColor();
            color6 = localRando.RandomColor();
        }
        public void Draw()
        {
            if (!verif)
                return;
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color1);
            GL.Vertex3(A.x, A.y, A.z);
            GL.Vertex3(B.x, B.y, B.z);
            GL.Vertex3(C.x, C.y, C.z);
            GL.Vertex3(D.x, D.y, D.z);


            GL.Color3(color2);
            GL.Vertex3(A.x, A.y, A.z);
            GL.Vertex3(D.x, D.y, D.z);
            GL.Vertex3(F.x, F.y, F.z);
            GL.Vertex3(E.x, E.y, E.z);

            GL.Color3(color3);
            GL.Vertex3(A.x, A.y, A.z);
            GL.Vertex3(R.x, R.y, R.z);
            GL.Vertex3(G.x, G.y, G.z);
            GL.Vertex3(B.x, B.y, B.z);


            GL.Color3(color4);
            GL.Vertex3(E.x, E.y, E.z);
            GL.Vertex3(F.x, F.y, F.z);
            GL.Vertex3(K.x, K.y, K.z);
            GL.Vertex3(G.x, G.y, G.z);
           


            GL.Color3(color5);

            GL.Vertex3(B.x, B.y, B.z);
            GL.Vertex3(G.x, G.y, G.z);
            GL.Vertex3(K.x, K.y, K.z);
            GL.Vertex3(C.x, C.y, C.z);


            GL.Color3(color6);
            GL.Vertex3(D.x, D.y, D.z);
            GL.Vertex3(C.x, C.y, C.z);
            GL.Vertex3(K.x, K.y, K.z);
            GL.Vertex3(F.x, F.y, F.z);


            GL.End();

      

        }

    }
}
