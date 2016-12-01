using PseudoGameEngine;
using PseudoGameEngine.Graphics;
using PseudoGameEngine.Input;
using PseudoGameEngine.Math;

namespace PseudoGameEngine_Test
{
    class Program
    {
        static Shader s;
        static Shader s2;
        //static shader s3;
        
        //static List<Renderable2d> sprites = new List<Renderable2d>();

        static Timer t  = new Timer();
        static float tf = 0;
        static uint frame = 0;

        static TileLayer layer;
        static TileLayer layer2;
        //static TileLayer layer3;


        static int x = 0, y = 0;

        static void Main(string[] args)
        {
             Window window = new Window("Text", 960, 540, false);

                Debue.Log("Vendor " + Sysinfo.Vendor());
                Debue.Error("Render " + Sysinfo.Render());
                Debue.Warning("OpenGLVersion "+ Sysinfo.OpenGLVersion());
                Debue.Log("ShadingLanguageVersion " + Sysinfo.ShadingLanguageVersion());

                s = new Shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");
            s2 = new Shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");
            //s3 = new shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");

            s.Enable();
            s2.Enable();
            //s3.enable();            
            s.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
            s2.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
            //s3.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
            

            layer = new TileLayer(s);

            ///Random r = new Random();
            // int range = 1;

            for (float y = 0; y < 9.0f; y += 0.1f)
            {
                for (float x = 0; x < 16.0; x += 0.1f)
                {
                    layer.Add(new Sprite(x,y, 0.9f, 0.9f, new Vector4(Random.Get(0f, 1f), 0, 1, 1)));
                    //layer.Add(new Sprite(x, y, 0.09f, 0.09f, new Vector4(Random.Get(0f,1f), 0, (float)(.5), 1)));
                }
            }



            layer2 = new TileLayer(s2);
            layer2.Add(new Sprite(2, 2, 2, 2, new Vector4(1, 0, 1, 1)));

            //layer3 = new TileLayer(s2);
            //layer3.add(new Sprite(2, 2, 4, 4, new Vector4(1, 0, 1, 1)));



            // layer.add(new Sprite(0, 0, 2, 2, new Vector4(0.8f, 0.2f, 0.8f, 1)));

            //window.SetUpdate(EventUpdate, update);

            window.Update += Window_Update;
            window.onEvent += Window_onEvent;

            window.Start();

            window.Quit();   
        }

        private static void Window_Update(Window sender)
        {

            sender.ClearColor(new Vector4(0, 0, 0, 0));

            s.Enable();
            s.SetUniform("light_pos", new Vector2(x * 32.0f / 960.0f - 16.0f, 9.0f - y * 18.0f / 540.0f));
            s2.Enable();
            s2.SetUniform("light_pos", new Vector2(x * 32.0f / 960.0f - 16.0f, 9.0f - y * 18.0f / 540.0f));
            
            layer.Render();
            layer2.Render();
            // layer3.render();
            
            //Thread.Sleep(Randome.Get(600,1010));

            frame++;
            if (t.DurationSeconds - tf > 1.0f)
            {
                tf += 1;
                Debue.Log(frame + " fps");
                frame = 0;
            }

            //s.Delete();
        }

        private static void Window_onEvent(Window sender,Event e)
        {
            if (e == Event.QUIT || sender.IsKeyPresed(KeyCode.ESCAPE)) { sender.Quit(); }
            if (e == Event.MOUSEBUTTONDOWN){ sender.Quit(); }
            x = sender.MousePositionX();
            y = sender.MousePositionY();
        }
    }
}




















//s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(0.0f, 16.0f, 0.0f, 9.0f, -1.0f, 1.0f));
////s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(-1.0f, 17.0f, -1.0f, 10.0f, -1.0f, 1.0f));      




//    Console.WriteLine("Sprites are {0}" ,sprites.Count);
//    s.SetUniform("color", new Vector4(0.2f, 0.3f, 0.8f, 1.0f));