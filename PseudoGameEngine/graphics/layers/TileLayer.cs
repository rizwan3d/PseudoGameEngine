using PseudoGameEngine.math;

namespace PseudoGameEngine.graphics
{
    public class TileLayer : Layer
    {
        public TileLayer(shader shader)
            : base(new BatchRenderer2D(), shader,Matrix.CreateOrthographicOffCenter(-16.0f, 16.0f, -9.0f, 9.0f, -1.0f, 1.0f))
        {
           
        }

    }
}
