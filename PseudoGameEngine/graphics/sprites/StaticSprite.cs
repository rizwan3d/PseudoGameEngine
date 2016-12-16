using PseudoGameEngine.Math;

namespace PseudoGameEngine.Graphics
{
    public class StaticSprite : Renderable2D
    {
        public VertexArray VertexArray { get; }
        public IndexBuffer IndexBuffer { get; }

        public Shader Shader { get; }

        public StaticSprite(float x ,float y , float width, float height , Vector4 color, Shader shader) 
            : base(new Vector3(x, y, 0), new Vector2(width, height), color)
        {
            Shader = shader;

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


            VertexArray = new VertexArray();

            VertexArray.AddBuffer(new Buffer(vertices, 4 * 3, 3), 0);
            VertexArray.AddBuffer(new Buffer(colour, 4 * 4, 4), 1);


            ushort[] indices = { 0, 1, 2, 2, 3, 0 };
            IndexBuffer = new IndexBuffer(indices, 6);
        }

#pragma warning disable CS0108 // 'StaticSprite.delete()' hides inherited member 'Renderable2D.delete()'. Use the new keyword if hiding was intended.
        public void delete()
#pragma warning restore CS0108 // 'StaticSprite.delete()' hides inherited member 'Renderable2D.delete()'. Use the new keyword if hiding was intended.
        {
            VertexArray.Delete();
            IndexBuffer.Delete();
        }
        //~StaticSprite()
        //{
        //    delete();
        //}


    }
}
