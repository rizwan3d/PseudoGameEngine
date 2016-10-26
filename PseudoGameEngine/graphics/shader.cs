using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using SharpGL.Shaders;
using SDL2;
using static SDL2.SDL;

namespace PseudoGameEngine.graphics
{
    public class shader
    {
        OpenGL gl = new OpenGL();

        public UInt32 m_shaderID;

        string m_vertPath, m_fragPath;
        public shader(string vertPath, string fragPath)
        {
            m_vertPath = vertPath;
            m_fragPath = fragPath;
            m_shaderID = load();
        }

        public UInt32 load()
        {
            UInt32 program = gl.CreateProgram();
            UInt32 vertex = gl.CreateShader(OpenGL.GL_VERTEX_SHADER);
            UInt32 fragment = gl.CreateShader(OpenGL.GL_FRAGMENT_SHADER);

            string vertsorce = System.IO.File.ReadAllText(m_vertPath);
            string fragsorce = System.IO.File.ReadAllText(m_fragPath);

            gl.ShaderSource(vertex, vertsorce);
            gl.CompileShader(vertex);

            int[] result = new int[1];
            gl.GetShader(vertex, OpenGL.GL_COMPILE_STATUS, result);

            if (result[0] == OpenGL.GL_FALSE)
            {
                gl.DeleteShader(vertex);
                throw (new initializing_vertex_Shader("Failed to Compile Vertex Shader"));

            }

            gl.ShaderSource(fragment, fragsorce);
            gl.CompileShader(fragment);

            int[] resultF = new int[1];
            gl.GetShader(fragment, OpenGL.GL_COMPILE_STATUS, resultF);

            if (result[0] == OpenGL.GL_FALSE)
            {
                gl.DeleteShader(fragment);
                throw (new initializing_fragment_Shader("Failed to Compile fragment Shader"));
            }

            gl.AttachShader(program, vertex);
            gl.AttachShader(program, fragment);

            gl.LinkProgram(program);
            gl.ValidateProgram(program);

            gl.DeleteShader(vertex);
            gl.DeleteShader(fragment);

            return program;

        }

        public void enable()
        {
            gl.UseProgram(m_shaderID);
        }

        public void disable()
        {
            gl.UseProgram(0);
        }



    }
}
