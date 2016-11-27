using System;
using PseudoGameEngine;
using PseudoGameEngine.graphics;
using PseudoGameEngine.Input;
using PseudoGameEngine.math;
using System.Collections.Generic;
using System.Threading;

namespace PseudoGameEngine_Test
{
    class Program
    {
        static Window window;

        static shader s;

        static BatchRenderer2D render;

        static List<Renderable2d> sprites = new List<Renderable2d>();

        static PseudoGameEngine.Timer t  = new PseudoGameEngine.Timer();
        static float tf = 0;
        static uint frame = 0;

        static void Main(string[] args)
        {
                window = new Window("Text", 960, 540, false);

                Console.WriteLine("Vendor {0}", sysinfo.Vendor());
                Console.WriteLine("Render {0}", sysinfo.Render());
                Console.WriteLine("OpenGLVersion {0}", sysinfo.OpenGLVersion());
                Console.WriteLine("ShadingLanguageVersion {0}", sysinfo.ShadingLanguageVersion());

                s = new shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");
                
                s.enable();
            s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(0.0f, 16.0f, 0.0f, 9.0f, -1.0f, 1.0f));
            //s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(-1.0f, 17.0f, -1.0f, 10.0f, -1.0f, 1.0f));      

            Random r = new Random();
                int range = 1;

                for (float y = 0; y < 9.0f; y += 0.1f) 
                {
                    for (float x = 0; x < 16.0f; x += 0.1f)
                    {
                        sprites.Add(new Sprite(x, y, 0.08f, 0.08f, new Vector4((float)(r.NextDouble() * range), 0, 1, 1)));
                    }
                }
                Console.WriteLine("Sprites are {0}" ,sprites.Count);
                render = new BatchRenderer2D();

                s.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
                s.SetUniform("color", new Vector4(0.2f, 0.3f, 0.8f, 1.0f));
           


            window.SetUpdate(EventUpdate, update);


            window.Quit();   
        }

        static int EventUpdate(Event _event)
        {
            if (_event == Event.QUIT || window.isKeyPresed(KeyCode.ESCAPE)) { window.Quit(); }
            if(_event == Event.MOUSEBUTTONDOWN)
            {
                window.Quit();
            }
            int x = window.MousePositionX();
            int y = window.MousePositionY();
            s.SetUniform("light_pos", new Vector2(x * 16.0f / 960.0f, 9.0f - y * 9.0f / 540.0f));
            return 0;
        }

        static void update()
        {
            window.ClearColor(new Vector4(0, 0, 0, 0));

            render.begin();
            foreach(Renderable2d s in sprites)
            {
                render.submit(s);
            }
            render.end();
            render.flush();

            Random r = new Random();

            Thread.Sleep(r.Next(600,1010));

            frame++;
            if (t.DurationSeconds - tf > 1.0f)
            {
                tf += 1;
                Console.WriteLine("{0} fps", frame);
                frame = 0;
            }
        }
    }
}
 