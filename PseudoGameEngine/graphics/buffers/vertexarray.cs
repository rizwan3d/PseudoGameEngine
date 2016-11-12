using System;
using SharpGL;
using SharpGL.VertexBuffers;

namespace PseudoGameEngine.graphics
{
    public class VertexArray
    {
        OpenGL gl = new OpenGL();        
       
        uint ArrayID;
        //List<buffer> Buffers = new List<buffer>();
        VertexBufferArray vbr = new VertexBufferArray();

        public VertexArray()
        {
            vbr.Create(gl);
            ArrayID = vbr.VertexBufferArrayObject;

        }

        public void AddBuffer(buffer _buffer, uint index)
        {
             Bind();
            _buffer.bind();

            gl.EnableVertexAttribArray(index);
            gl.VertexAttribPointer(index, (int)_buffer.GetComponentCount(), OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);

            _buffer.unbind();
            Unbind();
        }
        public void Bind()
        {
            vbr.Bind(gl);
        }
        public void Unbind()
        {
            vbr.Unbind(gl);
        }

        //public void RemoveAll()
        //{
        //    foreach(buffer b in Buffers)
        //    {
        //        Buffers.Remove(b);
        //    }
        //}


    }
}
