using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;
using SharpGL;
using PseudoGameEngine.input;

namespace PseudoGameEngine.graphics
{
    public class Window
    {
        //create a instance of OpenGl
        OpenGL gl = new OpenGL();

        //pointer for Window
        public IntPtr win;     

        //Window Information
        int Weight, Height;
        string Title;
        bool isFullScreen;
        SDL_WindowFlags Flags;
             
        //Creat Context Pointer for OpenGl 
        IntPtr glContext;

        //SDL Event var
        SDL_Event _event;

        // store information of window
        bool isWindowOpened;

        public Window(string title, int weight, int height, bool fullscreen = true)
        {
            //Set windows information to private var
            Title = title;
            Weight = weight;
            Height = height;
            isFullScreen = fullscreen;
            // Alow SDL to use OpenGL and Window RESIZABLE
            Flags =  SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
            // Insert flag to make window FullSceen 
            if (fullscreen)
                Flags |= SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;

            Init();
        }
        void Init()
        {
            //initializing SDL
            if (SDL_Init(SDL_INIT_VIDEO) < 0)
            // return error is unable to initializing SDL
            {
                throw (new initializing_SDL("Error occurred initializing SDL"));               
            }
            // Create Window with given Information
            win = SDL.SDL_CreateWindow(Title, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, Weight, Height, Flags);
            // return error is unable to Create Window
            if (win == null || win == IntPtr.Zero)
            {
                throw (new initializing_Window("Error occurred initializing Window"));               
            }
            initgl();
            isWindowOpened = true;           
        }
        void initgl()
        {
            // SDL_GL_CONTEXT_CORE gives us only the newer version, deprecated functions are disabled
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, (int)SDL_GLattr.SDL_GL_CONTEXT_PROFILE_CORE);


            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_RED_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_GREEN_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_BLUE_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ALPHA_SIZE, 8);

            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DEPTH_SIZE, 16);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_BUFFER_SIZE, 32);

            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ACCUM_RED_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ACCUM_GREEN_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ACCUM_BLUE_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ACCUM_ALPHA_SIZE, 8);


            // Turn on double buffering with a 24bit Z buffer.
            // You may need to change this to 16 or 32 for your system 
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DOUBLEBUFFER, 1);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DEPTH_SIZE, 16);

            glContext = SDL_GL_CreateContext(win);

            // return error is unable to Create Window
            if (glContext == null || glContext == IntPtr.Zero)  
            {
                throw (new initializing_OpenGL_context("Error occurred creating OpenGL context"));               
            }


            // Set background color as cornflower blue
            gl.ClearColor(0.39f, 0.58f, 0.93f, 1.0f);
            


            Clear();
            update();
        }

        #region Input

        //create a instance of InputInit 
        InputInit II = new InputInit();

        public bool isKeyPresed(KeyCode keycode)
        {
            // if event is related to key down
            if (_event.type == SDL_EventType.SDL_KEYDOWN)
                // return true if event key is same as input key
                if (_event.key.keysym.sym == II.kecodefinder[keycode])
                    return true;
            // same as up but if key up and return false
            if(_event.type == SDL_EventType.SDL_KEYUP)
                if (_event.key.keysym.sym == II.kecodefinder[keycode])
                    return false;
            return false;
        }

        public bool isMouseButtonPressed(input.MouseButton code)
        {
            // if event related to mouse button doen
            if (_event.type == SDL_EventType.SDL_MOUSEBUTTONDOWN)
            {
                // button is Right and return true
                if (code == input.MouseButton.RIGHT)
                {
                    if (_event.button.button == SDL_BUTTON_RIGHT)
                        return true;
                }
                // same as up but for left
                else if(code == input.MouseButton.LEFT)
                {
                    if (_event.button.button == SDL_BUTTON_LEFT)
                        return true;
                }
            }
            // same up but return false if event is relater to button up
            if (_event.type == SDL_EventType.SDL_MOUSEBUTTONUP)
            {
                if (code == input.MouseButton.RIGHT)
                {
                    if (_event.button.button == SDL_BUTTON_RIGHT)
                        return false;
                }
                else if (code == input.MouseButton.LEFT)
                {
                    if (_event.button.button == SDL_BUTTON_LEFT)
                        return false;
                }
            }
            return false;
        }

        // var to store mouse positions
        int x, y;

        public int MousePositionX()
        {
            // get postion and store to x and y
            SDL_GetMouseState(out x, out y);
            //return x postion
            return x;
        }
        public int MousePositionY()
        {
            // get postion and store to x and y
            SDL_GetMouseState(out x, out y);
            //return x postion
            return y;
        }

        #endregion

        #region Event and Updates

        eventInit ei = new eventInit();

        // call Funtion on event and without event update
        public void SetUpdate(Func<Event, int> EventUpdateFunction,Action Update)
        {
            // if window is open
            while (isWindowOpened)
            {
                /* Check for new events */
                while (SDL_PollEvent(out _event) == 1)
                {
                    //if event is related to Window
                    if (_event.type == SDL_EventType.SDL_WINDOWEVENT)
                        //if Window resized call  resetSize()
                        if (_event.window.windowEvent == SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED)
                            resetSize();
                    // call give function on new event
                    Event e = ei.eventfinder[_event.type];                    
                    EventUpdateFunction(e);                             
                }
                //call other update function
                Clear();
                Update();//input function
                update();//update gl port
            }
        }
        public void SetUpdate(Func<SDL_EventType, int> EventUpdateFunction)
        {
            // if window is open
            while (isWindowOpened)
                /* Check for new events */
                while (SDL_PollEvent(out _event) == 1)
                {
                    //if event is related to Window
                    if (_event.type == SDL_EventType.SDL_WINDOWEVENT)
                        //if Window resized call  resetSize()
                        if (_event.window.windowEvent == SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED)
                            resetSize();
                    // call give function on new event
                    EventUpdateFunction(_event.type);
                }
        }
        public void SetUpdate(Action Update)
        {
            // if window is open
            while (isWindowOpened)
            {
                // call give function on new event        
                Clear();
                Update();//input function
                update();//update gl port
            }
        }

        void resetSize()
        {
            int w, h;
            SDL_GetWindowSize(win,
                        out w,
                        out h);

            Clear();
            gl.Viewport(0, 0, w, h);
            update();
        }

        #endregion

        #region Other Funtions
        // Clear color buffer
        public void Clear() { gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); }

        // Update window with OpenGL rendering
        public void update() { SDL_GL_SwapWindow(win); }

        //Creat delay of Time
        public void Delay(uint Time)
        {
            SDL_Delay(Time);
        }

        public void Quit()
        {
            isWindowOpened = false;
            // Delete our OpengL context
            SDL_GL_DeleteContext(glContext);
            //Destroy window
            SDL_DestroyWindow(win);
            win = IntPtr.Zero;
            //Quit SDL subsystems
            SDL_Quit();
        }
        #endregion
    }
}
