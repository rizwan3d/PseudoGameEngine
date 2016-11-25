using System;
using SharpGL;
using SharpGL.Shaders;
using PseudoGameEngine.math;
using System.IO;

namespace PseudoGameEngine.graphics
{
    public class shader
    {
        OpenGL gl = new OpenGL();

        //store int id of shader
        UInt32 m_shaderID;
        //input path of shaders
        string m_vertPath, m_fragPath;
        public shader(string vertPath, string fragPath)
        {
            //assign input paths to global var
            m_vertPath = vertPath;
            m_fragPath = fragPath;

            //get shader id form load func
            m_shaderID = load();
        }

        public UInt32 load()
        {
            #region old code
            ////opengl program for shaders
            //UInt32 program = gl.CreateProgram();
            ////var for vertex shader
            //UInt32 vertex = gl.CreateShader(OpenGL.GL_VERTEX_SHADER);
            ////var for fragment shader
            //UInt32 fragment = gl.CreateShader(OpenGL.GL_FRAGMENT_SHADER);

            ////read shaders sorce
            //string vertsorce = System.IO.File.ReadAllText(m_vertPath);
            //string fragsorce = System.IO.File.ReadAllText(m_fragPath);
            #endregion


            if (!File.Exists(m_vertPath))
                throw (new vertex_Shader_file_not_found("vertex Shader file not found."));
            if (!File.Exists(m_fragPath))
                throw (new fragment_Shader_file_not_found("fragment Shader file not found."));

            //read shaders sorce
            string vertsorce = System.IO.File.ReadAllText(m_vertPath);
            string fragsorce = System.IO.File.ReadAllText(m_fragPath);

            
            Shader vs = new Shader();
            Shader fs = new Shader();

            vs.Create(gl, OpenGL.GL_VERTEX_SHADER, vertsorce);
            fs.Create(gl, OpenGL.GL_FRAGMENT_SHADER, fragsorce);

            if (vs.GetCompileStatus(gl) == false)
            {
                vs.Delete(gl);
                throw (new initializing_vertex_Shader("Failed to Compile Vertex Shader"));               
            }

            if (fs.GetCompileStatus(gl) == false)
            {
                fs.Delete(gl);
                throw (new initializing_fragment_Shader("Failed to Compile fragment Shader"));
            }
            uint shaderProgramObject = gl.CreateProgram();
            gl.AttachShader(shaderProgramObject, vs.ShaderObject);
            gl.AttachShader(shaderProgramObject, fs.ShaderObject);

            gl.LinkProgram(shaderProgramObject);
            gl.ValidateProgram(shaderProgramObject);



            #region old code
            ////compile vertex shader
            //gl.ShaderSource(vertex, vertsorce);
            //gl.CompileShader(vertex);

            ////store error
            //int[] result = new int[1];
            ////get information oof compiled shader
            //gl.GetShader(vertex, OpenGL.GL_COMPILE_STATUS, result);

            ////if compilation gives error delete shader and throw error
            //if (result[0] == OpenGL.GL_FALSE)
            //{

            //    gl.DeleteShader(vertex);
            //    throw (new initializing_vertex_Shader("Failed to Compile Vertex Shader"));
            //}

            ////same as up but for fragment shader
            //gl.ShaderSource(fragment, fragsorce);
            //gl.CompileShader(fragment);

            //int[] resultF = new int[1];
            //gl.GetShader(fragment, OpenGL.GL_COMPILE_STATUS, resultF);

            //if (result[0] == OpenGL.GL_FALSE)
            //{
            //    gl.DeleteShader(fragment);
            //    throw (new initializing_fragment_Shader("Failed to Compile fragment Shader"));
            //}

            ////attach vetex shader to opengl program
            //gl.AttachShader(program, vertex);
            //gl.AttachShader(program, fragment);

            ////link and validate program
            //gl.LinkProgram(program);
            //gl.ValidateProgram(program);

            ////free space form unuseable shaders
            // gl.DeleteShader(vertex);
            // gl.DeleteShader(fragment);

            #endregion

            //return shader id
            return shaderProgramObject;

        }
        
        public void delete()
        {
            gl.DeleteProgram(m_shaderID);
        }
        public void enable()
        {
            //enable shaders           
            gl.UseProgram(m_shaderID);
        }

        public void disable()
        {
            //disable shaders
            gl.UseProgram(0);
        }
        
        Int32 GetUniformLoacation(string name)
        {
            return gl.GetUniformLocation(m_shaderID, name);
        }

        public void SetUnifrom(string name, float val)
        {
            gl.Uniform1(GetUniformLoacation(name), val);
        }
        public void SetUniform(string name, int val)
        {
            gl.Uniform1(GetUniformLoacation(name), val);
        }
        public void SetUniform(string name, Vector2 val)
        {
            gl.Uniform2(GetUniformLoacation(name), (float)val.X, (float)val.Y);
        }
        public void SetUniform(string name, Vector3 val)
        {
            gl.Uniform3(GetUniformLoacation(name), (float)val.X, (float)val.Y, (float)val.Z);
            
        }
        public void SetUniform(string name, Vector4 val)
        {
            gl.Uniform4(GetUniformLoacation(name), (float)val.W, (float)val.X, (float)val.Y, (float)val.Z);
        }
        public void SetUniformMatrix(string name, Matrix mat)
        {
            gl.UniformMatrix4(GetUniformLoacation(name), 1, false, mat.toFloat());
        }



    }
}
