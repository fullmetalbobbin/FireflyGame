using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace FireflyGame.Screens
{
    public interface IScreen
    {
        ScreenType ScreenType { get; }
        void Update(float timeElapsed);

        void Draw(SpriteBatch spriteBatch);

    }
}
