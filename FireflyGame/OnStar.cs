using System;
using System.Collections.Generic;
using System.Text;

namespace FireflyGame
{
    public static class OnStar
    {
        public static bool CollisionDetection(BoundingCircle boop, BoundingCircle beep)
        {
            return Math.Pow(boop.Radius + beep.Radius, 2) >=
                Math.Pow(boop.Center.X - beep.Center.X, 2) +
                Math.Pow(boop.Center.Y - beep.Center.Y, 2);
        }
    }
}
