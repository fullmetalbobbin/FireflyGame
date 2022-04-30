using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireflyGame.Screens
{
    class MainMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.MainMenu;

        private Texture2D _mainMenuImage;

        public MainMenuScreen(Texture2D mainMenuImage)
        {
            _mainMenuImage = mainMenuImage;
        }

        public void Update(float timeElapsed)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var centerOrigin = new Vector2(_mainMenuImage.Width / 2f, _mainMenuImage.Height / 2f);
            spriteBatch.Begin();
            spriteBatch.Draw(_mainMenuImage, new Vector2(FireflyGameBase.ScreenWidth / 2f, FireflyGameBase.ScreenHeigth / 2f), null, Color.White, 0f, centerOrigin, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
