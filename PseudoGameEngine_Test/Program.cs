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
using SharpGL.Shaders;


namespace PseudoGameEngine_Test
{
    class Program
    {

        
        static OpenGL gl = new OpenGL();
        static Window window;

        static shader s;

        static indexbuffer ibo;
        static VertexArray sprite1,sprite2;

        static void Main(string[] args)
        {
            try
            {
                window = new Window("Text", 960, 540, false);



                //SharpGL.Shaders.Shader s = new Shader("a.vert", "a.frag");
                //float[] vert = new float[]{
                //    -0.5f,-0.5f,0.0f,
                //    -0.5f, 0.5f,0.0f,
                //     0.5f, 0.5f,0.0f,
                //     0.5f, 0.5f,0.0f,
                //     0.5f,-0.5f,0.0f,
                //    -0.5f,-0.5f,0.0f,
                //};
                //float[] vert = new float[]{
                //    -0.5f,0.5f,0.0f,
                //    -0.5f, -0.5f,0.0f,
                //     0.5f, -0.5f,0.0f,
                //     0.5f, 0.5f,0.0f,
                //};

                //ushort[] ind = {
                //    0,1,3,
                //    3,1,2,
                //};
                float[] vert = new float[]{
                    0,0,0,
                    0,3,0,
                    8,3,0,
                    8,0,0

                };

                ushort[] ind = {
                    0,1,2,
                    2,3,0,
                };

                float[] colorA = {
                    1,0,1,1,
                    1,0,1,1,
                    1,0,1,1,
                    1,0,1,1
                };

                float[] colorB = {
                    0.2f,0.3f,0.8f,1,
                    0.2f,0.3f,0.8f,1,
                    0.2f,0.3f,0.8f,1,
                    0.2f,0.3f,0.8f,1
                };

                Console.WriteLine("Vendor {0}", sysinfo.Vendor());
                Console.WriteLine("Render {0}", sysinfo.Render());
                Console.WriteLine("OpenGLVersion {0}", sysinfo.OpenGLVersion());
                Console.WriteLine("ShadingLanguageVersion {0}", sysinfo.ShadingLanguageVersion());


                sprite1 = new VertexArray();
                sprite2 = new VertexArray();
                ibo = new indexbuffer(ind, 6);

                sprite1.AddBuffer(new buffer(vert, 4 * 3, 3), 0);
                sprite1.AddBuffer(new buffer(colorA, 4 * 4, 4), 1);

                sprite2.AddBuffer(new buffer(vert, 4 * 3, 3), 0);
                sprite2.AddBuffer(new buffer(colorB, 4 * 4, 4), 1);


                //UInt32[] vbo = new UInt32[2];
                //gl.GenBuffers(1, vbo);
                //gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, vbo[0]);
                //gl.BufferData(OpenGL.GL_ARRAY_BUFFER, vert, OpenGL.GL_STATIC_DRAW);
                //gl.VertexAttribPointer(0, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
                //gl.EnableVertexAttribArray(0);


                s = new shader("minimal.vert", "minimal.frag");

                //shader s = new shader("a.vert", "a.frag");

                s.enable();
                s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(0.0, 16.0, 0.0,9.0,-1.0, 1.0));
                s.SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(new Vector3(4, 3, 0)));
                s.SetUniform("light_pos", new Vector2(8.0f, 4.5f));
                s.SetUniform("colour", new Vector4(0.2f,0.3f, 0.8f, 1.0f));
                //s.SetUniform("colour", new Vector4(0.0f, 0.0f, 1f, 1.0f));



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
            int x = window.MousePositionX();
            int y = window.MousePositionY();
            s.SetUniform("light_pos", new Vector2(x * 16.0f / 960.0f, 9.0f - y * 9.0f / 540.0f));
            //s.SetUniform("light_pos", new Vector2(x, y));
            //Console.WriteLine("{0},{1}", x, y);

            return 0;
        }

        static void update()
        {
            gl.ClearColor(0, 0, 0,0);
            // gl.DrawArrays(OpenGL.GL_TRIANGLES, 0, 6);


            sprite1.Bind();
            ibo.bind();
            s.SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(new Vector3(4, 3, 0)));
            gl.DrawElements(OpenGL.GL_TRIANGLES, (int)ibo.GetCount(), OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);
            ibo.bind();
            sprite1.Unbind();

            sprite2.Bind();
            ibo.bind();
            s.SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(new Vector3(0, 0, 0)));
            gl.DrawElements(OpenGL.GL_TRIANGLES, (int)ibo.GetCount(), OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);
            ibo.bind();
            sprite2.Unbind();


            //gl.LoadIdentity();




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

        }


    }
}
 