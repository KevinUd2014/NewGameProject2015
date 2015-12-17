using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NewKillingStory.Model
{
    class Flame : AnimatedSprites
    {
        private Vector2 velocity;
        private static Texture2D texture;
        private float age;
        private float range;

        public Flame(Vector2 position, Vector2 velocity, float range = 2f) : base(position)
        {
            this.velocity = velocity;
            this.range = range;

            character = texture;
            FramesPerSecond = 18;
            AddAnimation(6, 0, 0, "fire", 32, 32);
            PlayAnimation("fire");
        }
        public override void Update(GameTime gameTime)
        {
            position += velocity;
            age += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (age > range)
                Alive = false;

            base.Update(gameTime);
        }

        public static void SetTexture(Texture2D tex)
        {
            texture = tex;
        }
    }
}
