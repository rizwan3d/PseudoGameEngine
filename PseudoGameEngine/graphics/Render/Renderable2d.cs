using PseudoGameEngine.math;

namespace PseudoGameEngine.graphics
{
    public class Renderable2d
    {
        public Vector3 _position;
        public Vector2 _size;
        public Vector4 _color;

        public VertexArray _vertexarray;
        public indexbuffer _indexbuffer;

        public shader _shader;

        public Renderable2d(Vector3 position, Vector2 size, Vector4 color, shader shader)
        {
            _position = position;
            _size = size;
            _color = color;
            _shader = shader;

            float[] vertices = {
                0,0,0,
                0,(float)size.Y,0,
                (float)size.X,(float)size.Y,0,
                (float)size.Y,0,0
            };

            float[] colour = {
                (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,          
                (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,          
                (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,          
                (float)color.X,(float)color.Y,(float)color.Z,(float)color.W
            };


            _vertexarray = new VertexArray();

            _vertexarray.AddBuffer(new buffer(vertices, 4 * 3, 3),0);
            _vertexarray.AddBuffer(new buffer(colour, 4 * 4, 4), 1);


            ushort[] indices = { 0, 1, 2, 2, 3, 0 };
            _indexbuffer = new indexbuffer(indices, 6);
        }

        public VertexArray GetVertexArray() { return _vertexarray; }
        public indexbuffer GetIndexBuffer() { return _indexbuffer; }

        public shader GetShader() { return _shader; }

        public Vector3 GetPosition() { return _position; }
        public Vector2 GetSize() { return _size; }
        public Vector4 GetColor() { return _color; }


    }
}
