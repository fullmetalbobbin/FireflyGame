using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using FireflyGame.Screens;

namespace FireflyGame.Managers
{
    public class ScreenManager
    {
        private IReadOnlyCollection<IScreen> _screens;
        private IScreen _currentScreen;
        private IScreen _nextScreen;

        public ScreenManager(IReadOnlyCollection<IScreen> screens)
        {
            _screens = screens;
        }

        internal void Update(float timeElapsed)
        {
            _currentScreen?.Update(timeElapsed); 
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen?.Draw(spriteBatch);
        }

        public void SetScreen(ScreenType screenType)
        {
            foreach (var screen in _screens)
            {
                if (screen.ScreenType == screenType)
                {
                    _nextScreen = screen;
                    return;
                }
            }
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
