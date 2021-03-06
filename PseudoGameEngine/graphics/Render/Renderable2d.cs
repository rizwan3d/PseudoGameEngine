﻿using PseudoGameEngine.Math;

namespace PseudoGameEngine.Graphics
{

    public struct VertexData{
        public Vector3 vertex;
        //public Vector4 color;
        public uint color;
        

    }

    public class Renderable2D
    {
        public Vector3 _position;
        public Vector2 _size;
        public Vector4 _color;

#pragma warning disable CS0169 // The field 'Renderable2D._shader' is never used
        Shader _shader;
#pragma warning restore CS0169 // The field 'Renderable2D._shader' is never used
#pragma warning disable CS0649 // Field 'Renderable2D._vertexarray' is never assigned to, and will always have its default value null
        VertexArray _vertexarray;
#pragma warning restore CS0649 // Field 'Renderable2D._vertexarray' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'Renderable2D._indexbuffer' is never assigned to, and will always have its default value null
        IndexBuffer _indexbuffer;
#pragma warning restore CS0649 // Field 'Renderable2D._indexbuffer' is never assigned to, and will always have its default value null

        public Renderable2D(Vector3 position, Vector2 size, Vector4 color)
        {
            _position = position;
            _size = size;
            _color = color;
            //_shader = shader;

            //float[] vertices = {
            //    0,0,0,
            //    0,(float)size.Y,0,
            //    (float)size.X,(float)size.Y,0,
            //    (float)size.Y,0,0
            //};

            //float[] colour = {
            //    (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,          
            //    (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,          
            //    (float)color.X,(float)color.Y,(float)color.Z,(float)color.W,          
            //    (float)color.X,(float)color.Y,(float)color.Z,(float)color.W
            //};


            //_vertexarray = new VertexArray();

            //_vertexarray.AddBuffer(new buffer(vertices, 4 * 3, 3),0);
            //_vertexarray.AddBuffer(new buffer(colour, 4 * 4, 4), 1);


            //ushort[] indices = { 0, 1, 2, 2, 3, 0 };
            //_indexbuffer = new indexbuffer(indices, 6);
        }

        //public VertexArray GetVertexArray() { return _vertexarray; }
        //public indexbuffer GetIndexBuffer() { return _indexbuffer; }

        //public shader GetShader() { return _shader; }

        public Vector3 GetPosition() { return _position; }
        public Vector2 GetSize() { return _size; }
        public Vector4 GetColor() { return _color; }

        ~Renderable2D()
        {
            delete();
        }

        public void delete()
        {
            _vertexarray.Delete();
            _indexbuffer.Delete();            
        }
        public void submit(Renderer2D renderer)
        {
            renderer.Submit(this);
        }
    }
}
