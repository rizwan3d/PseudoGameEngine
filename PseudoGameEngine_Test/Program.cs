using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoGameEngine;
using PseudoGameEngine.graphics;
using PseudoGameEngine.input;
using SharpGL;


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
            }
            catch(initializing_SDL e)
            {
                Console.WriteLine(e.ToString());
            }
            window.SetUpdate(EventUpdate, update);         
        }

        static int EventUpdate(Event _event)
        {
            /* If a quit event has been sent */
            if (_event == Event.QUIT) window.Quit();           
            if (window.isKeyPresed(KeyCode.a))
                Console.WriteLine("PRESED!");
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

            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.Vertex(0, 0.5f);
            gl.Vertex(-0.5f, -0.5f);
            gl.Vertex(0.5, -0.5f); 
            gl.End();

            window.update();
        }
    
    }
}
 