using PseudoGameEngine.math;

namespace PseudoGameEngine.graphics
{
    public class StaticSprite : Renderable2d
    {
        public VertexArray _vertexarray;
        public indexbuffer _indexbuffer;

        public shader _shader;

        public StaticSprite(float x ,float y , float width, float height , Vector4 color, shader shader) 
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

            _vertexarray.AddBuffer(new buffer(vertices, 4 * 3, 3), 0);
            _vertexarray.AddBuffer(new buffer(colour, 4 * 4, 4), 1);


            ushort[] indices = { 0, 1, 2, 2, 3, 0 };
            _indexbuffer = new indexbuffer(indices, 6);
        }
        public VertexArray GetVertexArray() { return _vertexarray; }
        public indexbuffer GetIndexBuffer() { return _indexbuffer; }
        public shader GetShader() { return _shader; }

#pragma warning disable CS0108 // 'StaticSprite.delete()' hides inherited member 'Renderable2d.delete()'. Use the new keyword if hiding was intended.
        public void delete()
#pragma warning restore CS0108 // 'StaticSprite.delete()' hides inherited member 'Renderable2d.delete()'. Use the new keyword if hiding was intended.
        {
            _vertexarray.delete();
            _indexbuffer.delete();
        }
        //~StaticSprite()
        //{
        //    delete();
        //}


    }
}
