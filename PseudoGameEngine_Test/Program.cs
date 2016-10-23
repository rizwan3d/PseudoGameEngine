using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoGameEngine.graphics;
using static SDL2.SDL;
using SharpGL;

namespace PseudoGameEngine_Test
{
    class Program
    {
        static OpenGL gl = new OpenGL();
        static Window window;
        static void Main(string[] args)
        {
            window = new Window("Text",800,600,false);
            window.SetUpdate(EventUpdate, update);         
            window.Quit();
        }

        static int EventUpdate(SDL_EventType _event)
        {
            /* If a quit event has been sent */
            if (_event == SDL_EventType.SDL_QUIT) window.Quit();
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
 