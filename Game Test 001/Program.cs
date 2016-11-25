using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoGameEngine.graphics;
using PseudoGameEngine.Input;
using static SDL2.SDL;
using SharpGL;
using static SharpGL.OpenGL;
using System.Runtime.InteropServices;
using PseudoGameEngine;
using System.Drawing;
using System.Drawing.Imaging;

namespace Game_Test_001
{
    class Program
    {
        static OpenGL gl = new OpenGL();
        static Window w;

       

        static void Main(string[] args)
        {
            w = new Window("game test", 800, 600, false);
          
            w.SetUpdate(EventUpdate, update);
        }
        static int EventUpdate(Event _event)
        {
            /* If a quit event has been sent */
            if (_event == Event.QUIT) { w.Quit(); }           

            return 0;
        }

        static void update()
        {
           
           
        }
    }
}



//static IntPtr Surface, gScreenSurface;
//static uint[] TextureID = new uint[2





//gl.BindTexture(GL_TEXTURE_2D, TextureID[0]);

//            // For Ortho mode, of course
//            int X = 0;
//int Y = 0;
//int Width = 100;
//int Height = 100;

//gl.Begin(GL_QUADS);
//            gl.TexCoord(0, 0); gl.Vertex(X, Y);
//            gl.TexCoord(1, 0); gl.Vertex(X + Width, Y);
//            gl.TexCoord(1, 1); gl.Vertex(X + Width, Y + Height);
//            gl.TexCoord(0, 1); gl.Vertex(X, Y + Height);
//            //SDL_UpdateWindowSurface(Surface);


//            gl.End();






// //gScreenSurface = SDL_GetWindowSurface(w.win);


//            //Surface = SDL_LoadBMP("1.bmp");
//            SDL_BlitSurface(Surface, IntPtr.Zero, gScreenSurface, IntPtr.Zero);
//gl.GenTextures(1, TextureID);
//            gl.BindTexture(GL_TEXTURE_2D, TextureID[0]);

//            //SDL_Surface s = Marshal.PtrToStructure<SDL_Surface>(Surface);


//            Bitmap myImage = new Bitmap("1.jpg");
//byte[] rgbValues = null;

//BitmapData data = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.ReadOnly, myImage.PixelFormat);

//            try
//            {
//                IntPtr ptr = data.Scan0;
//int bytes = Math.Abs(data.Stride) * myImage.Height;
//rgbValues = new byte[bytes];
//                Marshal.Copy(ptr, rgbValues, 0, bytes);
//            }
//            finally
//            {
//                myImage.UnlockBits(data);
//            }

//            uint Mode = GL_RGB;

//gl.Enable(GL_TEXTURE_2D);


//            gl.TexImage2D(GL_TEXTURE_2D, 0, GL_RGB, data.Width, data.Height, 0, Mode, GL_UNSIGNED_BYTE, rgbValues);

//            gl.TexParameter(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
//            gl.TexParameter(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
