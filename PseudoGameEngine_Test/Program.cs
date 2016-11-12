using System;
using PseudoGameEngine;
using PseudoGameEngine.graphics;
using PseudoGameEngine.input;
using PseudoGameEngine.math;
using SharpGL;

namespace PseudoGameEngine_Test
{
    class Program
    {
        static OpenGL gl = new OpenGL();
        static Window window;

        static shader s;

        static indexbuffer ibo;
        static VertexArray sprite1,sprite2;

        static Renderable2d sprite;
        static Simple2DRenderer render;

        static void Main(string[] args)
        {
            try
            {
                window = new Window("Text", 960, 540, false);
                
                Console.WriteLine("Vendor {0}", sysinfo.Vendor());
                Console.WriteLine("Render {0}", sysinfo.Render());
                Console.WriteLine("OpenGLVersion {0}", sysinfo.OpenGLVersion());
                Console.WriteLine("ShadingLanguageVersion {0}", sysinfo.ShadingLanguageVersion());
                
                s = new shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");

                sprite = new Renderable2d(new Vector3(5,5,0), new Vector2(4,4) ,new  Vector4(1,0,1,1),s);
                render = new Simple2DRenderer();     
                           
                s.enable();
                s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(0.0, 16.0, 0.0,9.0,-1.0, 1.0));
                               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            window.SetUpdate(EventUpdate, update);

            window.Quit();   
        }

        static int EventUpdate(Event _event)
        {
            
            if (_event == Event.QUIT || window.isKeyPresed(KeyCode.ESCAPE)) {window.Quit(); }      
            
           
            int x = window.MousePositionX();
            int y = window.MousePositionY();
            s.SetUniform("light_pos", new Vector2(x * 16.0f / 960.0f, 9.0f - y * 9.0f / 540.0f));          

            return 0;
        }

        static void update()
        {
            gl.ClearColor(0, 0, 0,0);

            render.submit(sprite);
            render.flush();
                                   
        }
    }
}
 