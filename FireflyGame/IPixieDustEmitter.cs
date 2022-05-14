using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FireflyGame
{
    public interface IPixieDustEmitter
    {
        public Vector2 Position { get; }
        public Vector2 Velocity { get; }
    }
}
