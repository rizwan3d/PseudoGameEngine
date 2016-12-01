using System;
using SharpGL;
using SharpGL.VertexBuffers;
using System.Collections.Generic;

namespace PseudoGameEngine.Graphics
{
    public class VertexArray
    {
        OpenGL gl = new OpenGL();        
       
        uint ArrayID;
        List<VertexBufferArray> Buffers = new List<VertexBufferArray>();
        VertexBufferArray vbr = new VertexBufferArray();

        public VertexArray()
        {
            vbr.Create(gl);
            ArrayID = vbr.VertexBufferArrayObject;

        }

        public void AddBuffer(Buffer _buffer, uint index)
        {
             Bind();
            _buffer.Bind();

            gl.EnableVertexAttribArray(index);
            gl.VertexAttribPointer(index, (int)_buffer.GetComponentCount(), OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);

            _buffer.Unbind();
            Unbind();

            Buffers.Add(vbr);
        }
        public void Bind()
        {
            vbr.Bind(gl);
        }
        public void Unbind()
        {
            vbr.Unbind(gl);
        }

        public void Delete()
        {
            foreach(VertexBufferArray b in Buffers)
            {
               Buffers.Remove(b);
                b.Delete(gl);             
            }
            
            uint[] c = new uint[2];
            c[0] = ArrayID;
            gl.DeleteVertexArrays(1, c);
        }

        ~VertexArray()
       {
           Delete();
       }
        

    }
}
