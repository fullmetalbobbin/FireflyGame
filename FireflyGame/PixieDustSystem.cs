using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FireflyGame
{
    public class PixieDustSystem : BaseDustSystem
    {

        public IPixieDustEmitter PixieDustEmitter;


        public PixieDustSystem(Game game, IPixieDustEmitter pixieDustEmitter) : base(game, 600)
        {
            PixieDustEmitter = pixieDustEmitter;
        }


        protected override void InitializePixieDust(Vector2 location, ref PixieDustParticle pixieDustParticle)
        {
            
            var velocity = PixieDustEmitter.Velocity /16;
            //var acceleration = Vector2.UnitY * 20;
            //var acceleration = Vector2.UnitY / 20;
            //var acceleration = Vector2.Zero;          
            var scale = BaseDustSystem.NextFloat(0.07f, 0.7f);
            var lifetime = BaseDustSystem.NextFloat(0.1f, 1.5f);
            var acceleration = -velocity / lifetime;


            pixieDustParticle.Initialize(Color.DarkSalmon, location, velocity, acceleration, scale: scale, lifetime: lifetime);

           pixieDustParticle.Acceleration.Y -= NextFloat(30,900);
           //pixieDustParticle.Position.X = location.X;
           //pixieDustParticle.Position.Y = location.Y;
            
        }


        protected override void InitializeConstants()
        {
            textureFileName = "particle";

            minPixieDusts = 2;
            maxPixieDusts = 5;

            blendState = BlendState.Additive;
            DrawOrder = AdditiveBlendDrawOrder;


        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            AddPixieDusts(PixieDustEmitter.Position);          
        }
        
        /*
        public override void UpdatePixieParticle(ref PixieDustParticle pixieDustParticle, float time)
        {
            base.UpdatePixieParticle(ref pixieDustParticle, time);
        }
        */


        protected override Vector2 NextDirection()
        {
            float radians = NextFloat(MathHelper.ToRadians(80), MathHelper.ToRadians(100));
            Vector2 direction = Vector2.Zero;
            direction.X = (float)Math.Cos(radians);
            direction.Y = (float)Math.Sin(radians);
            return direction;
        }


    }
}
