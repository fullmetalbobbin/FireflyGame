using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FireflyGame
{
    public struct PixieDustParticle
    {

        //Particle
        public Vector2 Position;
        public Vector2 Velocity;
        public float AngularVelocity;
        public Vector2 Acceleration;
        public float AngularAcceleration;
        public float Rotation;
        public float Scale;
        public float Lifetime;
        public float TimeExisted;
        public Color Color;
        //public BoundingCircle PixieBind;

        public bool Live => TimeExisted < Lifetime;


        public void Initialize(Vector2 position, float angularVelocity = 0, float angularAcceleration = 0, float rotation = 0, float scale = 1, float lifetime = 1)
        {
            //this.PixieBind = pixieBind;
            this.Position = position;
            this.Velocity = Vector2.Zero; 
            this.AngularVelocity = angularVelocity;
            this.Acceleration = Vector2.Zero;
            this.AngularAcceleration = angularAcceleration;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Lifetime = lifetime;
            this.TimeExisted = 0f;
            this.Color = Color.HotPink;        
        }


        public void Initialize(Vector2 position, Vector2 velocity, float angularVelocity = 0, float angularAcceleration = 0, float rotation = 0, float scale = 1, float lifetime = 1)
        {
            //this.PixieBind = pixieBind;
            this.Position = position;
            this.Velocity = velocity;
            this.AngularVelocity = angularVelocity;
            this.Acceleration = Vector2.Zero;
            this.AngularAcceleration = angularAcceleration;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Lifetime = lifetime;
            this.TimeExisted = 0f;
            this.Color = Color.HotPink;
        }

        public void Initialize(Vector2 position, Vector2 velocity, Vector2 acceleration, float angularVelocity = 0, float angularAcceleration = 0, float rotation = 0, float scale = 1, float lifetime = 1)
        {
            //this.PixieBind = pixieBind;
            this.Position = position;
            this.Velocity = velocity;
            this.AngularVelocity = angularVelocity;
            this.Acceleration = acceleration;
            this.AngularAcceleration = angularAcceleration;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Lifetime = lifetime;
            this.TimeExisted = 0f;
            this.Color = Color.HotPink;
        }

        
        public void Initialize( Color color, Vector2 position, Vector2 velocity, Vector2 acceleration, float angularVelocity = 0, float angularAcceleration = 0, float rotation = 0, float scale = 1, float lifetime = 1)
        {
            //this.PixieBind = pixieBind;
            this.Position = position;
            this.Velocity = velocity;
            this.AngularVelocity = angularVelocity;
            this.Acceleration = acceleration;
            this.AngularAcceleration = angularAcceleration;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Lifetime = lifetime;
            this.TimeExisted = 0f;
            this.Color = color;
        }

    }
}
