using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Proiect.asstest;

namespace Proiect
{
    class Window3D:GameWindow

    {
        KeyboardState previousKeybord;
        double xrot, yrot, zrot = 0;
        Randomizer random;
        Cub cub;


        //Cream constructorul si dam dimeniunea ferestrei cheman constructorul implicit

        public Window3D() : base(800, 600,new GraphicsMode(32,24,0,8))
        {
            VSync = VSyncMode.On;
            random = new Randomizer();
            cub = new Cub(random);
            
            DisplayHelp();
        }

        //Aici ne vom ocupa de bafferul de adancime si de anti alazing
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);//stabileste ordinea elementelor pe care le va afisa

            GL.Hint(HintTarget.PolygonSmoothHint,HintMode.Nicest);//activeaza anti alizing pentru forme

        }
        //specifica viwportul.Cum vad eu lumea 3D si cum vede camera lumea 3D
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //set Background
            GL.ClearColor(Color.LightPink);

            //set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //set perspectiv
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4,(float)this.Width/(float)this.Height,1,250);//factorul de deschidere a maticei prima valoare,raportul de aspect
            GL.MatrixMode(MatrixMode.Projection);//incarca proiectia
            GL.LoadMatrix(ref perspectiva);// activeaza

            //set camera
            Matrix4 eye = Matrix4.LookAt(30,30,30,0,0,0,0,1,0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //LOGIC Code
            KeyboardState currentkeyboard = Keyboard.GetState();
            MouseState currentmouse = Mouse.GetState();
            int x_click = currentmouse.X;
            int y_click = currentmouse.Y;

            if (currentkeyboard[Key.Escape]) 
            {
                Exit();
            }

            if (currentkeyboard[Key.H] && !previousKeybord[Key.H])
            {
                DisplayHelp();
            }
            
            if (currentkeyboard[Key.W] && !previousKeybord[Key.W])
            {
                cub.Move(true, false,false,false);
            }
            if (currentkeyboard[Key.S] && !previousKeybord[Key.S])
            {
                cub.Move(false, true,false,false);
            }
            if (currentkeyboard[Key.A] && !previousKeybord[Key.A])
            {
                cub.Move(false, false, true, false);
            }
            if (currentkeyboard[Key.D] && !previousKeybord[Key.D])
            {
                cub.Move(false,false, false, true);
            }


            if (currentkeyboard[OpenTK.Input.Key.X])
            {
                GL.Rotate(-1, 1, 1, 1);
            }
            else if ((x_click != X || y_click != Y) && currentmouse[MouseButton.Left])
            {
                GL.Viewport(x_click, -y_click, Width, Height);
            }


            if (currentkeyboard[Key.L] && !previousKeybord[Key.L])
            {
                cub.DiscoMode1();
            }

            previousKeybord = currentkeyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //renedr code
            
            DrawAxes();
            cub.Draw();
            //end render code
            SwapBuffers();
        }
        public void DrawAxes()
        {

            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(25, 0, 0);
            GL.End();

            GL.Color3(Color.Green);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 25, 0);
            GL.End();

            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 25);
            GL.End();
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n Meniu");
            Console.WriteLine(" H- meniul");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" X - rotesete scena pe axa X");
            Console.WriteLine("L-schimba culorile cubului");
            Console.WriteLine("(W,D)-muta pozitia cubului");
          

        }
    }
}
