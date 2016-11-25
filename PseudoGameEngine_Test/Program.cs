using System;
using PseudoGameEngine;
using PseudoGameEngine.graphics;
using PseudoGameEngine.Input;
using PseudoGameEngine.math;

namespace PseudoGameEngine_Test
{
    class Program
    {
        static Window window;

        static shader s;

        //static Renderable2d sprite;
        //static Renderable2d sprite2;
        //static Renderable2d sprite3;

        static Sprite sprite;
        static Sprite sprite2;

       // static StaticSprite sprite;
        //static StaticSprite sprite2;

        //static Simple2DRenderer render;
        static BatchRenderer2D render;

        static int x, y;

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

               

                //br2d= new BatchRenderer2D();

                //sprite = new Sprite(5, 5,4, 4, new Vector4(1, 0, 1, 1));                

                //sprite2 = new Sprite(7,1,2,3, new Vector4(0.2, 0.3, 0.8, 1));
      
                
                //sprite = new Renderable2d(new Vector3(5,2.5,0), new Vector2(4,4) ,new  Vector4(1,1,0,1),s);
                // render = new Simple2DRenderer();

                //sprite2 = new Renderable2d(new Vector3(10, 0, 0), new Vector2(7, 10), new Vector4(0.4, 0.7, 0.2, 1), s);

                //sprite3 = new Renderable2d(new Vector3(0, 0, 0), new Vector2(10,10), new Vector4(1, 0, 1, 1), s);

                s.enable();
                s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(0.0, 16.0, 0.0,9.0,-1.0, 1.0));
                s.SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(0.5, 3, 0));


                //sprite = new StaticSprite(5, 5, 4, 4, new Vector4(1, 0, 1, 1), s);
                //sprite2 = new StaticSprite(7, 1, 2, 3, new Vector4(0.2, 0.3, 0.8, 1), s);

                sprite = new Sprite(5, 5, 4, 4, new Vector4(1, 0, 1, 1));
                sprite2 = new Sprite(7, 1, 2, 3, new Vector4(0.2, 0.3, 0.8, 1));


                //render = new Simple2DRenderer();
                render = new BatchRenderer2D();

                s.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
                s.SetUniform("color", new Vector4(0.2, 0.3, 0.8, 1.0));

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            window.SetUpdate(EventUpdate, update);

            window.Quit();   
        }

        static int EventUpdate(Event _event)
        {
            
            if (_event == Event.QUIT || window.isKeyPresed(KeyCode.ESCAPE)) {window.Quit(); }
             x = window.MousePositionX();
             y = window.MousePositionY();
            s.SetUniform("light_pos", new Vector2(x * 16.0f / 960.0f, 9.0f - y * 9.0f / 540.0f));
            return 0;
        }

        static void update()
        {
           // window.ClearColor(new Vector4(0, 0, 0, 0));


            //render.submit(sprite);
            //render.submit(sprite2);
            //render.flush();          
            render.begin();
            render.submit(sprite);

            render.submit(sprite2);

            //render.submit(sprite);
           render.end();
            render.flush();
        }
    }
}
 