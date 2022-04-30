using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FireflyGame.Screens
{
    class GameplayOne : IScreen
    {
        public ScreenType ScreenType => ScreenType.LevelOne;

        private Texture2D _levelOneImage;

        public GameplayOne(Texture2D levelOneImage)
        {
            _levelOneImage = levelOneImage;
        }

        public void Update(float timeElapsed)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var centerOrigin = new Vector2(_levelOneImage.Width / 2f, _levelOneImage.Height / 2f);
            spriteBatch.Begin();
            spriteBatch.Draw(_levelOneImage, new Vector2(FireflyGameBase.ScreenWidth / 2f, FireflyGameBase.ScreenHeigth / 2f), null, Color.White, 0f, centerOrigin, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

    }
}
