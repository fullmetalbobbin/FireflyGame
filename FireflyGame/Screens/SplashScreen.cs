using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireflyGame.Screens
{
    public class SplashScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Splash;

        private Texture2D _splashImage;

        public SplashScreen(Texture2D splashImage)
        {
            _splashImage = splashImage;
        }

        public void Update(float timeElapsed)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var centerOrigin = new Vector2(_splashImage.Width/2f, _splashImage.Height/2f);
            spriteBatch.Begin();
            spriteBatch.Draw(_splashImage, new Vector2(FireflyGameBase.ScreenWidth/2f, FireflyGameBase.ScreenHeigth/2f), null, Color.White, 0f, centerOrigin, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }


    }
}
