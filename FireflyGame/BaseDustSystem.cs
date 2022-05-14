using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FireflyGame
{
    public abstract class BaseDustSystem: DrawableGameComponent
    {
        protected static SpriteBatch spriteBatch;
        protected static ContentManager contentManager;

        private Vector2 origin;
        private Texture2D texture;
        protected string textureFileName;
        protected int minPixieDusts;
        protected int maxPixieDusts;
        private PixieDustParticle[] pixieDusts;
        private Queue<int> freePixieDusts;


        public const int AlphaBlendDrawOrder = 100;
        public const int AdditiveBlendDrawOrder = 200;
        protected BlendState blendState = BlendState.AlphaBlend;

        public int FreePixieDustsCount => freePixieDusts.Count;

        protected float minSpeed;
        protected float maxSpeed;
        protected float minAcceleration;
        protected float maxAcceleration;
        protected float minRotation;
        protected float maxRotation;
        protected float minLifetime;
        protected float maxLifetime;
        protected float minScale;
        protected float maxScale;



        protected abstract void InitializeConstants();

        public BaseDustSystem(Game game, int maxPixieDusts) : base(game)
        {
            pixieDusts = new PixieDustParticle[maxPixieDusts];
            freePixieDusts = new Queue<int>(maxPixieDusts);

            for (int i = 0; i < pixieDusts.Length; i++)
            {
                
                pixieDusts[i].Initialize(Vector2.Zero);
                freePixieDusts.Enqueue(i);
            }
            InitializeConstants();
        }


        protected virtual void InitializePixieDust(Vector2 location, ref PixieDustParticle pixieDustParticle)
        {
            pixieDustParticle.Initialize(location);


            float velocity = NextFloat(minSpeed, maxSpeed);
            float acceleration = NextFloat(minAcceleration, maxAcceleration);
            float lifetime = NextFloat(minLifetime, maxLifetime);
            float scale = NextFloat(minScale, maxScale);
            float rotationSpeed = NextFloat(minRotation, maxRotation);

        }


        public virtual void UpdatePixieParticle(ref PixieDustParticle pixieDustParticle, float time)
        {
            
            pixieDustParticle.Velocity += pixieDustParticle.Acceleration * time;
            pixieDustParticle.Position += pixieDustParticle.Velocity * time;
            pixieDustParticle.AngularVelocity += pixieDustParticle.AngularVelocity * time;
            pixieDustParticle.Rotation += pixieDustParticle.Rotation * time;
            pixieDustParticle.TimeExisted += time;
            
            //pixieDustParticle.Velocity = ;
            //pixieDustParticle.Position = new Vector2(firefly.FireflyPosition.X - 32, firefly.FireflyPosition.Y - 80);

        }


        protected override void LoadContent()
        {
            if (contentManager == null)
            { contentManager = new ContentManager(Game.Services, "Content"); }
            if (spriteBatch == null)
            { spriteBatch = new SpriteBatch(Game.GraphicsDevice); }
            if (string.IsNullOrEmpty(textureFileName))
            { throw new InvalidOperationException();}

            texture = contentManager.Load<Texture2D>(textureFileName);
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < pixieDusts.Length; i++)
            {
                if (pixieDusts[i].Live)
                {
                    UpdatePixieParticle(ref pixieDusts[i], time);

                    if (!pixieDusts[i].Live)  //if the pixie dust is done dusting
                    { freePixieDusts.Enqueue(i); }
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(blendState: blendState);
            foreach (PixieDustParticle pdp in pixieDusts)
            {
                if (!pdp.Live) continue;

                spriteBatch.Draw(texture, pdp.Position, null, pdp.Color, pdp.Rotation, origin, pdp.Scale, SpriteEffects.None, 0.0f);

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected virtual Vector2 NextDirection()
        {
            float angle = NextFloat(0, MathHelper.Pi);
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            return direction;         
        }

        public static float NextFloat(float min, float max)
        {
            float nextFloat = min + (float)(new Random().NextDouble()*(max-min));
            return nextFloat;
        }

        protected void AddPixieDusts(Vector2 loc)
        {
            int numPixieDusts = new Random().Next(minPixieDusts, maxPixieDusts);

            for (int i = 0; i < numPixieDusts && freePixieDusts.Count > 0; i++)
            {
                int j = freePixieDusts.Dequeue();
                InitializePixieDust(loc, ref pixieDusts[j]);
            }
        }

        protected void AddPixieDusts(Rectangle loc)
        {
            int numPixieDusts = new Random().Next(minPixieDusts, maxPixieDusts);

            for (int i = 0; i < numPixieDusts && freePixieDusts.Count > 0; i++)
            {
                int j = freePixieDusts.Dequeue();
                InitializePixieDust(new Vector2(NextFloat(loc.X, loc.X + loc.Width), NextFloat(loc.Y, loc.Y + loc.Height)), ref pixieDusts[j]);
            }

        }

    }
}
