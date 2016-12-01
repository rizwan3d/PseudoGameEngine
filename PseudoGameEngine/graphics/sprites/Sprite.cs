﻿using PseudoGameEngine.Math;

namespace PseudoGameEngine.Graphics { 
    public class Sprite : Renderable2D
    {
        public Sprite(float x, float y, float width, float height, Vector4 color) 
            : base(new Vector3(x, y, 0), new Vector2(width, height), color)
        {
        }
       
    }
}
