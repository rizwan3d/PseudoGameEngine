using System;

namespace PseudoGameEngine
{
    public class Initializing_SDL : Exception{
        public Initializing_SDL(string message) : base(message) { } }

    public class Initializing_Window : Exception{
        public Initializing_Window(string message) : base(message) {}}

    public class Initializing_OpenGL_Context : Exception{
        public Initializing_OpenGL_Context(string message) : base(message) {}}
    public class Initializing_Vertex_Shader : Exception  {
        public Initializing_Vertex_Shader(string message) : base(message) { } }
    public class Initializing_Fragment_Shader : Exception  {
        public Initializing_Fragment_Shader(string message) : base(message) { } }
    public class Fragment_Shader_File_Not_Found : Exception
    {
        public Fragment_Shader_File_Not_Found(string message) : base(message) { }
    }
     public class Vertex_Shader_File_Not_Found : Exception
    {
        public Vertex_Shader_File_Not_Found(string message) : base(message) { }
    }
}
