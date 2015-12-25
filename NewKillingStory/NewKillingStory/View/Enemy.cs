using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.View
{
    class Enemy : AnimatedSprites
    {
        public Vector2 velocity;
        public float life;
        //private static Texture2D character;
        Camera camera;

        public Enemy(Vector2 velocity,Texture2D texture, Vector2 position, Camera camera) : base(position, camera)
        {
            this.velocity = velocity;

            character = texture;
            FramesPerSecond = 18;
            AddAnimation(3, 0, 0, "EnemyDown", 40, 45);
            AddAnimation(3, 132, 0, "EnemyUp", 40, 45);
            AddAnimation(3, 49, 0, "EnemyLeft", 40, 45);
            AddAnimation(3, 95, 0, "EnemyRight", 40, 45);
            //AddAnimation(6, 0, 0, "Enemy", 32, 32);
            PlayAnimation("EnemyDown");
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public void HandleEnenmy()
        {

        }
        public void Draw()
        {

        }
    }
}
