using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using static SDL2.SDL;
using SharpGL;

namespace PseudoGameEngine.graphics
{
    public class buffer
    {
        uint[] bufferID;
        uint ComponentCount;

        OpenGL gl = new OpenGL();
        

        public buffer(float[] data,int count,uint componentCount)
        {
            this.ComponentCount = componentCount;
            gl.GenBuffers(1, bufferID);
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, bufferID[0]);
            gl.BufferData(OpenGL.GL_ARRAY_BUFFER, data, OpenGL.GL_STATIC_DRAW);
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }
        
        public void bind()
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, bufferID[0]);
        }

        public void unbind()
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }
        public uint GetComponentCount()
        {
            return this.ComponentCount;
        }
    }
}
