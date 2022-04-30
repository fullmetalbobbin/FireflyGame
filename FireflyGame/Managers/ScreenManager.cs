using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using FireflyGame.Screens;

namespace FireflyGame.Managers
{
    public class ScreenManager
    {
        private IScreen _currentScreen;
        private IScreen _nextScreen;

        internal void Update(float timeElapsed)
        {
            _currentScreen?.Update(timeElapsed); 
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen?.Draw(spriteBatch);
        }

        public void SetScreen(IScreen screen)
        {
            _nextScreen = screen;
        }

        public void SwitchScreen()
        {
            if (_nextScreen != null)
            {
                _currentScreen = _nextScreen;
            }
            _nextScreen = null;
        }

    }
}
