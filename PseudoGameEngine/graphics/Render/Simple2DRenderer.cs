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

        private Queue<Renderable2d> _RedererQueue = new Queue<Renderable2d>(); 
        public override void submit(Renderable2d Renderable) {

            _RedererQueue.Enqueue(Renderable);

        }


        public override void flush() {

            while(_RedererQueue.Count != 0) {

                Renderable2d renerable = _RedererQueue.First();

                renerable.GetVertexArray().Bind();
                renerable.GetIndexBuffer().bind();

                renerable.GetShader().SetUniformMatrix("ml_matrix", Matrix.CreateTranslation(renerable.GetPosition()));
                gl.DrawElements(OpenGL.GL_TRIANGLES, (int)renerable.GetIndexBuffer().GetCount(), OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);

                renerable.GetIndexBuffer().unbind();
                renerable.GetVertexArray().Unbind();

                _RedererQueue.Dequeue();

            }

        }
    }
}
