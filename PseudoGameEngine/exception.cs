﻿using System;

namespace PseudoGameEngine
{
    public class initializing_SDL : Exception{
        public initializing_SDL(string message) : base(message) { } }

    public class initializing_Window : Exception{
        public initializing_Window(string message) : base(message) {}}

    public class initializing_OpenGL_context : Exception{
        public initializing_OpenGL_context(string message) : base(message) {}}
    public class initializing_vertex_Shader : Exception  {
        public initializing_vertex_Shader(string message) : base(message) { } }
    public class initializing_fragment_Shader : Exception  {
        public initializing_fragment_Shader(string message) : base(message) { } }
    public class fragment_Shader_file_not_found : Exception
    {
        public fragment_Shader_file_not_found(string message) : base(message) { }
    }
     public class vertex_Shader_file_not_found : Exception
    {
        public vertex_Shader_file_not_found(string message) : base(message) { }
    }
}
