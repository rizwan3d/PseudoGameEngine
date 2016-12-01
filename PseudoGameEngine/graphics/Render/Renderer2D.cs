using PseudoGameEngine.Graphics;

namespace PseudoGameEngine.Graphics
{
    public  class Renderer2D
    {
        public virtual  void Begin() { }
        public virtual void End() { }
        public virtual void Submit(Renderable2D Renderable) { }
        public virtual void Delete() { }
        public virtual void Flush() { }
    }
}
