﻿using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using PseudoGameEngine.Math;

namespace PseudoGameEngine.Graphics
{ 
    public class Simple2DRenderer : Renderer2D
    {
        OpenGL gl = new OpenGL();

        private Queue<StaticSprite> _RedererQueue = new Queue<StaticSprite>(); 
        public override void Submit(Renderable2D Renderable) {

            _RedererQueue.Enqueue((StaticSprite)Renderable);

        }

        public override void Delete()
        {
            while (_RedererQueue.Count != 0)
            {
                StaticSprite sprite = _RedererQueue.First();
                sprite.delete();
            }
        }

        ~Simple2DRenderer()
        {
            Delete();
        }

        public override void Flush() {

            while(_RedererQueue.Count != 0) {
            //foreach(StaticSprite sprite in _RedererQueue) { 
                StaticSprite sprite = _RedererQueue.First();

                sprite.GetVertexArray().Bind();
                sprite.GetIndexBuffer().Bind();

                sprite.GetShader().SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(sprite.GetPosition()));
                gl.DrawElements(OpenGL.GL_TRIANGLES, (int)sprite.GetIndexBuffer().GetCount(), OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);

                sprite.GetIndexBuffer().Unbind();
                sprite.GetVertexArray().Unbind();

                _RedererQueue.Dequeue();

            }

        }
    }
}
