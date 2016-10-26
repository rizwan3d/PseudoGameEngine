using System;
using PseudoGameEngine;
using PseudoGameEngine.graphics;
using PseudoGameEngine.input;
using PseudoGameEngine.math;
using SharpGL;
using static SDL2.SDL;
using SDL2;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PseudoGameEngine_Test
{
    class Program
    {

        
        static OpenGL gl = new OpenGL();
        static Window window;
        
        static void Main(string[] args)
        {
            try
            {
                window = new Window("Text", 800, 600, false);
                

                float[] vert = new float[]{
                    -0.5f,-0.5f,0.0f,
                    -0.5f, 0.5f,0.0f,
                     0.5f, 0.5f,0.0f,
                     0.5f, 0.5f,0.0f,
                     0.5f,-0.5f,0.0f,
                    -0.5f,-0.5f,0.0f,
                };

                
                UInt32[] vbo = new UInt32[2];

               
                gl.GenVertexArrays(1, vbo);
                gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, vbo[0]);
                //           
                gl.BufferData(OpenGL.GL_ARRAY_BUFFER, vert, OpenGL.GL_STATIC_DRAW);
               
                gl.VertexAttribPointer(0, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.EnableVertexAttribArray(0);

               
                shader s = new shader("minimal.vert", "minimal.frag");
                
                s.enable();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

           window.SetUpdate(EventUpdate, update);         
        }

        static int EventUpdate(Event _event)
        {
            /* If a quit event has been sent */
            if (_event == Event.QUIT) {window.Quit(); }      
            //if(window.isKeyPresed(KeyCode.ESCAPE))
                
            //if (window.isKeyPresed(KeyCode.a))
            //    Console.WriteLine("PRESED!");
            //if (window.isMouseButtonPressed(MouseButton.RIGHT))
            //    Console.WriteLine("PRESED!");
            //int x = window.MousePositionX();
            //int y = window.MousePositionY();
            //Console.WriteLine("{0},{1}", x, y);

            return 0;
        }

        static void update()
        {
            window.Clear();

            gl.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);

            //gl.LoadIdentity();

            //gl.Begin(OpenGL.GL_QUADS);
            //gl.Color(1, 0, 0); gl.Vertex(0, 0, 0);
            //gl.Color(1, 1, 0); gl.Vertex(100, 0, 0);
            //gl.Color(1, 0, 1); gl.Vertex(100, 100, 0);
            //gl.Color(1, 1, 1); gl.Vertex(0, 100, 0);
            //gl.End();
            
            
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.Vertex(0, 0.5f);
            //gl.Vertex(-0.5f, -0.5f);
            //gl.Vertex(0.5, -0.5f); 
            //gl.End();

            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Vertex(0, 0);
            //gl.Vertex(1, 1);
            //gl.Vertex(-1, 1);
            //gl.Vertex(1, -1);
            //gl.End();

            window.update();
        }
        

}
}
 