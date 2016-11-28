using PseudoGameEngine.graphics;

namespace PseudoGameEngine.graphics
{
    public  class Renderer2D
    {
        public virtual  void begin() { }
        public virtual void end() { }
        public virtual void submit(Renderable2d Renderable) { }
        public virtual void delete() { }
        public virtual void flush() { }
    }
}
