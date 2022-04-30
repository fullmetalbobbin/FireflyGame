using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FireflyGame
{
    public class FireflyGameBase : Game
    {
            private GraphicsDeviceManager _graphics;
            private SpriteBatch _spriteBatch;
            private Song backgroundMusic;

            private Texture2D background;
            private Texture2D midground;
            private Texture2D foreground;
            private Texture2D superground;

            private FireflySprite firefly;
            private Starlight[] starlights;
            private int starlightLeft;



            public FireflyGameBase()
            {
                _graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;
                _graphics.PreferredBackBufferHeight = 1500;
                _graphics.PreferredBackBufferWidth = 500;
                _graphics.GraphicsProfile = GraphicsProfile.HiDef;

            }

            protected override void Initialize()
            {
                // TODO: Add your initialization logic here
                firefly = new FireflySprite(this);

                //Components.Add("firefly");
                Color color = Color.Fuchsia;
                System.Random chaos = new System.Random();
                starlights = new Starlight[]
                    {
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                    new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color)
                    };
                starlightLeft = starlights.Length;

                base.Initialize();
            }

            protected override void LoadContent()
            {
                _spriteBatch = new SpriteBatch(GraphicsDevice);
                firefly.LoadContent(Content);
                backgroundMusic = Content.Load<Song>("Firefly4");
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(backgroundMusic);

                // TODO: use this.Content to load your game content here
                background = Content.Load<Texture2D>("background");
                midground = Content.Load<Texture2D>("midground");
                foreground = Content.Load<Texture2D>("foreground");
                superground = Content.Load<Texture2D>("superground");

                foreach (var star in starlights) star.LoadContent(Content);
            }

            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here
                firefly.Update(gameTime);

                //firefly.FireflyColor = Color.White;
                foreach (var star in starlights)
                {
                    if (!star.Collected && star.StarlightBounds.WhenStarsCollide(firefly.FireflyBounds))
                    {
                        //firefly.FireflyColor = Color.Fuchsia;
                        star.Collected = true;
                        starlightLeft--;
                    }
                }

                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.DimGray);

                float fireflyY = MathHelper.Clamp(firefly.FireflyPosition.Y, 500, 135000);
                float offsetY = 500 - fireflyY;

                // TODO: Add your drawing code here
                Matrix transform;

                transform = Matrix.CreateTranslation(0, offsetY * 0.1f, 0);
                _spriteBatch.Begin(transformMatrix: transform);
                _spriteBatch.Draw(background, Vector2.Zero, Color.White);
                _spriteBatch.End();

                transform = Matrix.CreateTranslation(0, offsetY * 0.5f, 0);
                _spriteBatch.Begin(transformMatrix: transform);
                _spriteBatch.Draw(midground, Vector2.Zero, Color.White);
                _spriteBatch.End();

                transform = Matrix.CreateTranslation(0, offsetY, 0);
                _spriteBatch.Begin(transformMatrix: transform);
                foreach (var star in starlights) star.Draw(gameTime, _spriteBatch);
                firefly.Draw(gameTime, _spriteBatch);
                _spriteBatch.Draw(foreground, Vector2.Zero, Color.White);
                _spriteBatch.End();

                transform = Matrix.CreateTranslation(0, offsetY * 1.25f, 0);
                _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, transformMatrix: transform);
                _spriteBatch.Draw(superground, Vector2.Zero, Color.YellowGreen);
                _spriteBatch.End();

                base.Draw(gameTime);
            }
        }
    }

