using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FireflyGame
{
    public class BoundingCircle
    {
        public Vector2 Center;
        public float Radius;

        public BoundingCircle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool WhenStarsCollide(BoundingCircle stardust)
        {
            return OnStar.CollisionDetection(this, stardust);
        }
    }
}
