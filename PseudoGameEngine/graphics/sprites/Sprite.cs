using PseudoGameEngine.math;

namespace PseudoGameEngine.graphics { 
    public class Sprite : Renderable2d
    {
        public Sprite(float x, float y, float width, float height, Vector4 color) 
            : base(new Vector3(x, y, 0), new Vector2(width, height), color)
        {
        }
       
    }
}
