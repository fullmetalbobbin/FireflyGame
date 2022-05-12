﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using FireflyGame.Screens;
using FireflyGame.Managers;


    namespace FireflyGame
    {
    public class FireflyGameBase : Game
    {
        public static int ScreenWidth = 500;
        public static int ScreenHeigth = 1000;

        //private IScreen screen;
        private ScreenManager _screenManager;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Song backgroundMusic;
        private SoundEffect soundEffect;

        private Texture2D background;
        private Texture2D midground;
        private Texture2D foreground;
        private Texture2D superground;
        private SpriteFont spriteFont;

        public Texture2D splashImage;

        private FireflySprite firefly;
        private Starlight[] starlights;
        private int starlightLeft;
        private int starlightCollected;

        //private float scrollOffset;

        Cube cube;



        public FireflyGameBase()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeigth;
            _graphics.ApplyChanges();



            firefly = new FireflySprite(this);

            //Components.Add("firefly");
            Color color = Color.HotPink;
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
                new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color),
                new Starlight(new Vector2((float)chaos.NextDouble() * 500, (float)chaos.NextDouble() * 9000), color)
                };
            starlightLeft = starlights.Length;
            starlightCollected = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            firefly.LoadContent(Content);
            soundEffect = Content.Load<SoundEffect>("PowerupSoft");
            backgroundMusic = Content.Load<Song>("Firefly4");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
                

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("background");
            midground = Content.Load<Texture2D>("midground");
            foreground = Content.Load<Texture2D>("foreground");
            superground = Content.Load<Texture2D>("superground");
            spriteFont = Content.Load<SpriteFont>("akshar");

            var splashImage = Content.Load<Texture2D>("background");

            foreach (var star in starlights) star.LoadContent(Content);

            cube = new Cube(this);

            //screen = new SplashScreen(splashImage);

            _screenManager = new ScreenManager(new IScreen[] {new SplashScreen(splashImage)});
            _screenManager.SetScreen(ScreenType.Splash);
            _screenManager.SwitchScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //scrollOffset += (float)gameTime.ElapsedGameTime.TotalSeconds * -250f;
              

            // TODO: Add your update logic here
            var timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //screen.Update(timeElapsed);
            _screenManager.Update(timeElapsed);

            firefly.Update(gameTime);

            //firefly.FireflyColor = Color.White;
            foreach (var star in starlights)
            {
                if (!star.Collected && star.StarlightBounds.WhenStarsCollide(firefly.FireflyBounds))
                {
                    soundEffect.Play();
                    //firefly.FireflyColor = Color.Fuchsia;
                    star.Collected = true;
                    starlightLeft--;
                    starlightCollected++;
                }
            }
            cube.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            float fireflyY = MathHelper.Clamp(firefly.FireflyPosition.Y, 500, 8000);
            float offsetY = 500 - fireflyY;

            // TODO: Add your drawing code here
            

            Matrix transform;

            // Background y(t) = 0.25t
            //transform = Matrix.CreateTranslation(0, scrollOffset * 0.156f, 0);
            transform = Matrix.CreateTranslation(0, offsetY * 0.156f, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            _spriteBatch.Draw(background, Vector2.Zero, Color.White);
                
            _spriteBatch.End();

            //transform = Matrix.CreateTranslation(0, scrollOffset * 0.438f, 0);
            transform = Matrix.CreateTranslation(0, offsetY * 0.438f, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            _spriteBatch.Draw(midground, Vector2.Zero, Color.White);
           // cube.Draw();

            _spriteBatch.End();

            //transform = Matrix.CreateTranslation(0, scrollOffset, 0); // add scrolloset to y player
            transform = Matrix.CreateTranslation(0, offsetY, 0);
            _spriteBatch.Begin(transformMatrix: transform);
            foreach (var star in starlights) star.Draw(gameTime, _spriteBatch);
            firefly.Draw(gameTime, _spriteBatch);
            _spriteBatch.Draw(foreground, Vector2.Zero, Color.White);
            _spriteBatch.End();

            //transform = Matrix.CreateTranslation(0, scrollOffset * 1.375f , 0);
            transform = Matrix.CreateTranslation(0, offsetY * 1.375f, 0);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, transformMatrix: transform);
            _spriteBatch.Draw(superground, Vector2.Zero, Color.YellowGreen);
            _spriteBatch.End();

            _spriteBatch.Begin();
            _spriteBatch.DrawString(spriteFont, $"starlight - {starlightCollected}", new Vector2(170, 5), Color.Salmon);
            _spriteBatch.End();

            //screen.Draw(_spriteBatch);
            //_screenManager.Draw(_spriteBatch); //comment out for gameplay working 

            base.Draw(gameTime);
        }

        public void SwitchScreen()
        {
        }

    }
}

