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
        //static shader s2;
        //static shader s3;



        //static List<Renderable2d> sprites = new List<Renderable2d>();

        static Timer t  = new Timer();
        static float tf = 0;
        static uint frame = 0;

        static TileLayer layer;
        //static TileLayer layer2;
        //static TileLayer layer3;


        static int x = 0, y = 0;

        static void Main(string[] args)
        {
                window = new Window("Text", 960, 540, false);

                Debue.Log("Vendor " + sysinfo.Vendor());
                Debue.Error("Render " + sysinfo.Render());
                Debue.Warning("OpenGLVersion "+ sysinfo.OpenGLVersion());
                Debue.Log("ShadingLanguageVersion " + sysinfo.ShadingLanguageVersion());

                s = new shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");
            //s2 = new shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");
            //s3 = new shader("../../shaders/minimal.vert", "../../shaders/minimal.frag");

            s.enable();
            //s2.enable();
            //s3.enable();
            s.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
            //s2.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
            //s3.SetUniform("light_pos", new Vector2(4.0f, 1.5f));
            

            layer = new TileLayer(s);

            ///Random r = new Random();
            // int range = 1;

            //for (float y = -9; y < 9.0f; y += 0.1f)
            //{
            //    for (float x = -16.0f; x < 16.0; x += 0.1f)
            //    {
                    layer.add(new Sprite(-8, -8, 2,2 /*0.09f, 0.09f*/, new Vector4(Random.Get(0f,1f), 0, 1, 1)));
                    layer.add(new Sprite(-6, -6, 2, 2 /*0.09f, 0.09f*/, new Vector4(Random.Get(0f,1f), 0, (float)(.5), 1)));
            //    }
            // }



            //layer2 = new TileLayer(s2);
            //layer2.add(new Sprite(-2, -2, 4, 4, new Vector4(1, 0, 1, 1)));

            //layer3 = new TileLayer(s2);
            //layer3.add(new Sprite(2, 2, 4, 4, new Vector4(1, 0, 1, 1)));



            // layer.add(new Sprite(0, 0, 2, 2, new Vector4(0.8f, 0.2f, 0.8f, 1)));

            //window.SetUpdate(EventUpdate, update);

            window.Update += new Updatedelegate(update);
            window.onEvent += new EventUpdatedelegate(EventUpdate);

            window.Start();

            window.Quit();   
        }
        
        static void EventUpdate(Event _event)
        {
            if (_event == Event.QUIT || window.isKeyPresed(KeyCode.ESCAPE)) { window.Quit(); }
            if(_event == Event.MOUSEBUTTONDOWN)
            {
                window.Quit();
            }
             x = window.MousePositionX();
             y = window.MousePositionY();
          
          //  return 0;
        }

        static void update()
        {
            window.ClearColor(new Vector4(0, 0, 0, 0));


            s.enable();
            s.SetUniform("light_pos", new Vector2(x * 32.0f / 960.0f - 16.0f, 9.0f - y * 18.0f / 540.0f));            
            //s2.enable();
            //s2.SetUniform("light_pos", new Vector2(x * 32.0f / 960.0f - 16.0f, 9.0f - y * 18.0f / 540.0f));


            layer.render();
           //layer2.render();
           // layer3.render();

            

            //Thread.Sleep(Randome.Get(600,1010));

            frame++;
            if (t.DurationSeconds - tf > 1.0f)
            {
                tf += 1;
                Debue.Log(frame + " fps");
                frame = 0;
            }

            s.delete();
        }
    }
}




















//s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(0.0f, 16.0f, 0.0f, 9.0f, -1.0f, 1.0f));
////s.SetUniformMatrix("pr_matrix", Matrix.CreateOrthographicOffCenter(-1.0f, 17.0f, -1.0f, 10.0f, -1.0f, 1.0f));      




//    Console.WriteLine("Sprites are {0}" ,sprites.Count);
//    s.SetUniform("color", new Vector4(0.2f, 0.3f, 0.8f, 1.0f));