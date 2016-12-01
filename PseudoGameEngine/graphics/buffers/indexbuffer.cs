using SharpGL;

namespace PseudoGameEngine.Graphics
{
    public class IndexBuffer
    {
        SharpGL.VertexBuffers.IndexBuffer _indexbuffer;

        uint Count;
        OpenGL gl = new OpenGL();      

        public IndexBuffer(ushort[] data,  uint Count)
        {
            _indexbuffer = new SharpGL.VertexBuffers.IndexBuffer();
            this.Count = Count;
            _indexbuffer.Create(gl);
            _indexbuffer.Bind(gl);
            _indexbuffer.SetData(gl, data);
            _indexbuffer.Unbind(gl);           
           
        }
        public IndexBuffer(int[] data, int Count)
        {
            _indexbuffer = new SharpGL.VertexBuffers.IndexBuffer();
            this.Count = (uint)Count;
            _indexbuffer.Create(gl);
            _indexbuffer.Bind(gl);
            _indexbuffer.SetData(gl, data,Count);
            _indexbuffer.Unbind(gl);

        }

        public void Bind()
        {
            _indexbuffer.Bind(gl);
        }

        public void Unbind()
        {
            _indexbuffer.Unbind(gl);
        }
        public uint GetCount()
        {
            return this.Count;
        }
        public void Delete()
        {
            uint[] a = new uint[2];
            a[0] = _indexbuffer.IndexBufferObject;
            gl.DeleteBuffers(0, a);
        }

        ~IndexBuffer()
        { 
           Delete();
        }
    }
}
