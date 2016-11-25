using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PseudoGameEngine.math;

namespace PseudoGameEngine.graphics
{ 
    public class Simple2DRenderer : Renderer2D
    {
        OpenGL gl = new OpenGL();

        private Queue<StaticSprite> _RedererQueue = new Queue<StaticSprite>(); 
        public override void submit(Renderable2d Renderable) {

            _RedererQueue.Enqueue((StaticSprite)Renderable);

        }

        public void delete()
        {
            while (_RedererQueue.Count != 0)
            {
                StaticSprite sprite = _RedererQueue.First();
                sprite.delete();
            }
        }

        public override void flush() {

            while(_RedererQueue.Count != 0) {
            //foreach(StaticSprite sprite in _RedererQueue) { 
                StaticSprite sprite = _RedererQueue.First();

                sprite.GetVertexArray().Bind();
                sprite.GetIndexBuffer().bind();

                sprite.GetShader().SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(sprite.GetPosition()));
                gl.DrawElements(OpenGL.GL_TRIANGLES, (int)sprite.GetIndexBuffer().GetCount(), OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);

                sprite.GetIndexBuffer().unbind();
                sprite.GetVertexArray().Unbind();

                _RedererQueue.Dequeue();

            }

        }
    }
}
