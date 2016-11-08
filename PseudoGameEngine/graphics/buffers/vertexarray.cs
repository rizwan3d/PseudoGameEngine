using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace PseudoGameEngine.graphics
{
    public class VertexArray
    {
        OpenGL gl = new OpenGL();        
       
        uint[] ArrayID = new uint[2];
        List<buffer> Buffers = new List<buffer>();

        public VertexArray()
        {
            gl.GenVertexArrays(1, ArrayID);

        }

        public void AddBuffer(buffer _buffer, uint index)
        {
            Bind();
            _buffer.bind();

            gl.EnableVertexAttribArray(index);
            gl.VertexAttribPointer(index, (int)_buffer.GetComponentCount(), OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);

            _buffer.unbind();
            unbind();
        }
        public void Bind()
        {
            gl.BindVertexArray(ArrayID[0]);
        }
        public void unbind()
        {
            gl.BindVertexArray(0);
        }

        public void delete()
        {
            foreach(buffer b in Buffers)
            {
                Buffers.Remove(b);
            }
        }


    }
}
