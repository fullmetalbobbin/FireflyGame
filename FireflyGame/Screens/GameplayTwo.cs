using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FireflyGame.Screens
{
    class GameplayTwo : IScreen
    {
        public ScreenType ScreenType => ScreenType.LevelTwo;

        private Texture2D _levelTwoImage;

        public GameplayTwo(Texture2D levelTwoImage)
        {
            _levelTwoImage = levelTwoImage;
        }

        public void Update(float timeElapsed)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var centerOrigin = new Vector2(_levelTwoImage.Width / 2f, _levelTwoImage.Height / 2f);
            spriteBatch.Begin();
            spriteBatch.Draw(_levelTwoImage, new Vector2(FireflyGameBase.ScreenWidth / 2f, FireflyGameBase.ScreenHeigth / 2f), null, Color.White, 0f, centerOrigin, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
