using PseudoGameEngine.Math;
using System.Collections.Generic;

namespace PseudoGameEngine.Graphics
{
    public class Layer
    {
        protected Renderer2D _Renderer = new Renderer2D();
        protected List<Renderable2D> _Renderables = new List<Renderable2D>();
        protected Shader _Shader;
        protected Matrix _ProjectionMatrix;

        protected Layer(Renderer2D renderer, Shader s, Matrix projectionMatrix)
        {
            _Renderer = renderer;            
            _Shader = s;
            _ProjectionMatrix = projectionMatrix;
            
            _Shader.Enable();
            _Shader.Uniform("pr_matrix", _ProjectionMatrix);
            _Shader.Disable();
        }

        public void Delete()
        {
            _Shader.Delete();
            _Renderer.Delete();
            foreach (Renderable2D renderable in _Renderables)
            {
                renderable.delete();
            }
        }

        public void Add(Renderable2D renderable)
        {
            _Renderables.Add(renderable);
        }

        public void Render()
        {
            _Shader.Enable();

            _Renderer.Begin();
            foreach (Renderable2D renderable in _Renderables)
            {
                renderable.submit(_Renderer);
            }
            _Renderer.End();
            _Renderer.Flush();           
            //_Shader.Disable();
        }

        ~Layer(){
            Delete();
        }

    }
}
