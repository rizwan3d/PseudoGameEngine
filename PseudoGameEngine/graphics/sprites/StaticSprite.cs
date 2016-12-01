using PseudoGameEngine.Math;

namespace PseudoGameEngine.Graphics
{
    public class StaticSprite : Renderable2D
    {
        public VertexArray _vertexarray;
        public IndexBuffer _indexbuffer;

        public Shader _shader;

        public StaticSprite(float x ,float y , float width, float height , Vector4 color, Shader shader) 
            : base(new Vector3(x, y, 0), new Vector2(width, height), color)
        {
            _shader = shader;

            float[] vertices = {
                 0,0,0,
                 0,height,0,
                 width,height,0,
                 width,0,0
            };

            float[] colour = {
            (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,
            (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,
            (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,
            (float)color.X,(float)color.Y,(float)color.Z,(float)color.W
        };


            _vertexarray = new VertexArray();

            _vertexarray.AddBuffer(new Buffer(vertices, 4 * 3, 3), 0);
            _vertexarray.AddBuffer(new Buffer(colour, 4 * 4, 4), 1);


            ushort[] indices = { 0, 1, 2, 2, 3, 0 };
            _indexbuffer = new IndexBuffer(indices, 6);
        }
        public VertexArray GetVertexArray() { return _vertexarray; }
        public IndexBuffer GetIndexBuffer() { return _indexbuffer; }
        public Shader GetShader() { return _shader; }

#pragma warning disable CS0108 // 'StaticSprite.delete()' hides inherited member 'Renderable2D.delete()'. Use the new keyword if hiding was intended.
        public void delete()
#pragma warning restore CS0108 // 'StaticSprite.delete()' hides inherited member 'Renderable2D.delete()'. Use the new keyword if hiding was intended.
        {
            _vertexarray.Delete();
            _indexbuffer.Delete();
        }
        //~StaticSprite()
        //{
        //    delete();
        //}


    }
}
