using SharpGL;

namespace PseudoGameEngine.graphics
{
    public class indexbuffer
    {
        SharpGL.VertexBuffers.IndexBuffer _indexbuffer;

        uint Count;
        OpenGL gl = new OpenGL();      

        public indexbuffer(ushort[] data,  uint Count)
        {
            _indexbuffer = new SharpGL.VertexBuffers.IndexBuffer();
            this.Count = Count;
            _indexbuffer.Create(gl);
            _indexbuffer.Bind(gl);
            _indexbuffer.SetData(gl, data);
            _indexbuffer.Unbind(gl);           
           
        }

        public void bind()
        {
            _indexbuffer.Bind(gl);
        }

        public void unbind()
        {
            _indexbuffer.Unbind(gl);
        }
        public uint GetCount()
        {
            return this.Count;
        }
    }
}
