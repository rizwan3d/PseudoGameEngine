using SharpGL;

namespace PseudoGameEngine.Graphics
{
    public class Buffer
    {
        uint[] bufferID;
        uint ComponentCount;

        OpenGL gl = new OpenGL();
        

        public Buffer(float[] data,int count,uint componentCount)
        {
            bufferID = new uint[2];
            this.ComponentCount = componentCount;
            gl.GenBuffers(1, bufferID);
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, bufferID[0]);            
            gl.BufferData(OpenGL.GL_ARRAY_BUFFER, data, OpenGL.GL_STATIC_DRAW);
            //IntPtr p = IntPtr.Zero;
            //Marshal.Copy(data, 0, p, data.Length);
            //gl.BufferData(OpenGL.GL_ARRAY_BUFFER, count, p, OpenGL.GL_STATIC_DRAW);
            
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }
        
        public void Bind()
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, bufferID[0]);
        }

        public void Unbind()
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }
        public uint GetComponentCount()
        {
            return this.ComponentCount;
        }

        public void Delete() {
            gl.DeleteBuffers(0,bufferID);
        }

        ~Buffer()
        {
            Delete();
        }

    }
}
