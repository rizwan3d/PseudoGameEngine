using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGameEngine.graphics
{
    public class Renderer2D
    {
        public virtual void submit(Renderable2d Renderable) { }


        public virtual void flush() { }
    }
}
