using PseudoGameEngine.graphics;
using PseudoGameEngine.math;
using SharpGL.SceneGraph.Shaders;

using System.Collections.Generic;


namespace PseudoGameEngine.graphics
{
    public class Layer
    {
        protected Renderer2D _Renderer = new Renderer2D();
        protected List<Renderable2d> _Renderables = new List<Renderable2d>();
        protected shader _Shader;
        protected Matrix _ProjectionMatrix;

        protected Layer(Renderer2D renderer, shader s, Matrix projectionMatrix)
        {
            _Renderer = renderer;            
            _Shader = s;
            _ProjectionMatrix = projectionMatrix;
            
            _Shader.enable();
            _Shader.SetUniformMatrix("pr_matrix", _ProjectionMatrix);
            _Shader.disable();
        }

        public void delete()
        {
            _Shader.delete();
            _Renderer.delete();
            foreach (Renderable2d renderable in _Renderables)
            {
                renderable.delete();
            }
        }

        public void add(Renderable2d renderable)
        {
            _Renderables.Add(renderable);
        }

        public void render()
        {
            _Shader.enable();

            _Renderer.begin();
            foreach (Renderable2d renderable in _Renderables)
            {
                renderable.submit(_Renderer);
            }
            _Renderer.end();
            _Renderer.flush();
        }

        ~Layer(){
            delete();
        }

    }
}
