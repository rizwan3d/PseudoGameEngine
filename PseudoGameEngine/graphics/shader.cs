using System;
using SharpGL;
using SharpGL.Shaders;
using PseudoGameEngine.Math;
using System.IO;

namespace PseudoGameEngine.Graphics
{
    public class Shader
    {
        OpenGL gl = new OpenGL();

        //store int id of shader
        UInt32 _shaderID;
        //input path of shaders
        string _vertPath, _fragPath;
        public Shader(string vertPath, string fragPath)
        {
            //assign input paths to global var
            _vertPath = vertPath;
            _fragPath = fragPath;

            //get shader id form load func
            _shaderID = Load();
        }

        public UInt32 Load()
        {
            #region old code
            ////opengl program for shaders
            //UInt32 program = gl.CreateProgram();
            ////var for vertex shader
            //UInt32 vertex = gl.CreateShader(OpenGL.GL_VERTEX_SHADER);
            ////var for fragment shader
            //UInt32 fragment = gl.CreateShader(OpenGL.GL_FRAGMENT_SHADER);

            ////read shaders sorce
            //string vertsorce = System.IO.File.ReadAllText(_vertPath);
            //string fragsorce = System.IO.File.ReadAllText(_fragPath);
            #endregion


            if (!File.Exists(_vertPath))
                throw (new Vertex_Shader_File_Not_Found("vertex Shader file not found."));
            if (!File.Exists(_fragPath))
                throw (new Fragment_Shader_File_Not_Found("fragment Shader file not found."));

            //read shaders sorce
            string vertsorce = System.IO.File.ReadAllText(_vertPath);
            string fragsorce = System.IO.File.ReadAllText(_fragPath);


            SharpGL.Shaders.Shader vs = new SharpGL.Shaders.Shader();
            SharpGL.Shaders.Shader fs = new SharpGL.Shaders.Shader();

            vs.Create(gl, OpenGL.GL_VERTEX_SHADER, vertsorce);
            fs.Create(gl, OpenGL.GL_FRAGMENT_SHADER, fragsorce);

            if (vs.GetCompileStatus(gl) == false)
            {
                vs.Delete(gl);
                throw (new Initializing_Vertex_Shader("Failed to Compile Vertex Shader"));               
            }

            if (fs.GetCompileStatus(gl) == false)
            {
                fs.Delete(gl);
                throw (new Initializing_Fragment_Shader("Failed to Compile fragment Shader"));
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
        
        public void Delete()
        {
            gl.DeleteProgram(_shaderID);
        }
        ~Shader()
        {
            Delete();
        }

        public void Enable()
        {
            //enable shaders           
            gl.UseProgram(_shaderID);
        }

        public void Disable()
        {
            //disable shaders
            gl.UseProgram(0);
        }

        Int32 UniformLoacation(string name)
        {
            return gl.GetUniformLocation(_shaderID, name);
        }

        public void Unifrom(string name, float val)
        {
            gl.Uniform1(UniformLoacation(name), val);
        }
        public void Uniform(string name, int val)
        {
            gl.Uniform1(UniformLoacation(name), val);
        }
        public void Uniform(string name, Vector2 val)
        {
            gl.Uniform2(UniformLoacation(name), (float)val.X, (float)val.Y);
        }
        public void Uniform(string name, Vector3 val)
        {
            gl.Uniform3(UniformLoacation(name), (float)val.X, (float)val.Y, (float)val.Z);
            
        }
        public void Uniform(string name, Vector4 val)
        {
            gl.Uniform4(UniformLoacation(name), (float)val.W, (float)val.X, (float)val.Y, (float)val.Z);
        }
        public void Uniform(string name, Matrix mat)
        {
            gl.UniformMatrix4(UniformLoacation(name), 1, false, mat.toFloat());
        }
    }
}
