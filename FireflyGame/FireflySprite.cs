using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FireflyGame
{
    public class FireflySprite //: IPixieDustEmitter
    {
        const float LINEAR_ACCELERATION = 2.5f;
        const float ANGULAR_ACCELERATION = 0.05f;
        //MouseState previousMouse;

        //public Vector2 Position { get; set; }
        //public Vector2 Velocity { get; set; }

        //private Rectangle firelyBounds = new Rectangle(0,0, 64,64);

        private BoundingCircle fireflyBounds = new BoundingCircle(new Vector2(250, 250), 32);


        public BoundingCircle FireflyBounds => fireflyBounds;


        public Color FireflyColor = Color.White;

        Microsoft.Xna.Framework.Game game;
        Texture2D fireflyTexture;

        public Vector2 FireflyPosition;
        Vector2 fireflyDirection;
        public Vector2 FireflyVelocity; 
        Vector2 fireflyVelocity;

        float fireflyAngle;
        float fireflyAngularVelocity;

        BlendState BlendState;

        public FireflySprite(Microsoft.Xna.Framework.Game game)
        {
            this.game = game;
            this.FireflyPosition = new Vector2(250, 250);
            //this.FireflyPosition = Mouse.GetState();
            this.fireflyDirection = -Vector2.UnitY;
            this.fireflyBounds.Center = FireflyPosition;
            BlendState = BlendState.Additive;
        }


        public void LoadContent(ContentManager content)
        {
            fireflyTexture = content.Load<Texture2D>("firefly");
        }

        public void Update(GameTime gameTime)
        {
            /*
            MouseState currentMouse = Mouse.GetState();
            Vector2 mousePosition = new Vector2(currentMouse.X, currentMouse.Y);

            fireflyVelocity = mousePosition - FireflyPosition;
            FireflyPosition = mousePosition;
            */
            
            var keyboardState = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 fireflyAcceleration = new Vector2(0, 0);
            float fireflyAngularAcceleration = 0;

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) FireflyPosition -= Vector2.UnitY * time * 150;
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) FireflyPosition += Vector2.UnitY * time * 150;

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                FireflyPosition -= Vector2.UnitX * time * 130;
                fireflyAcceleration += fireflyDirection * LINEAR_ACCELERATION;
                fireflyAngularAcceleration += ANGULAR_ACCELERATION;
            }

            //fireflyPosition -= Vector2.UnitX * time * 100;

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                FireflyPosition += Vector2.UnitX * time * 130;
                fireflyAcceleration += fireflyDirection * LINEAR_ACCELERATION;
                fireflyAngularAcceleration -= ANGULAR_ACCELERATION;
            }

            //fireflyPosition += Vector2.UnitX * time * 100;

            fireflyAngularVelocity += fireflyAngularAcceleration * time;
            fireflyAngle += fireflyAngularVelocity * time;
            fireflyDirection.X = (float)Math.Sin(fireflyAngle);
            fireflyDirection.Y = (float)-Math.Cos(fireflyAngle);

            fireflyVelocity += fireflyAcceleration * time;
            FireflyPosition += fireflyVelocity * time;

            fireflyBounds.Center = FireflyPosition;

            var viewport = game.GraphicsDevice.Viewport;
            if (FireflyPosition.X < 0 ) FireflyPosition.X = viewport.Width;
            if (FireflyPosition.X > 500) FireflyPosition.X = 0;


            //Velocity -= Vector2.UnitY;
            //Position = FireflyPosition;

            //Velocity = new Vector2(0,0);
            //Position = new Vector2(FireflyPosition.X - 32,FireflyPosition.Y - 80);
            


        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fireflyTexture, FireflyPosition, null, FireflyColor, fireflyAngle, new Vector2(64, 64), 1f, SpriteEffects.FlipVertically, 0);
        }
    }
}
