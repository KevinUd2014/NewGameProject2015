using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.View
{
    class Particle
    {
        private int seed;
        private Vector2 systemStartPosition;
        private Vector2 position;
        private Vector2 velocity;
        //Vector2 resetPosition;
        private Vector2 acceleration = new Vector2(0f, 100f);
        private float scale;
        Vector2 randomDirection;
        private float size = 5f;

        public Particle(int seed, Vector2 systemStartPosition)
        {
            Random rand = new Random(seed);//slumpar ut alla partiklar
            scale = (float)rand.NextDouble();
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.10f) * 2f;// denna sätter snabheten på partiklarna!
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * 30f);// denna sätter vilken spridning partiklarna får 2f är ganska bra!
            this.seed = seed;
            this.systemStartPosition = systemStartPosition;
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);//sätter start positionen
            velocity = randomDirection;
        }
        public void Update(float elapsedTimeInSeconds)//updaterar varje frame med en position
        {
            position = position + velocity * elapsedTimeInSeconds;
            velocity = velocity + acceleration * elapsedTimeInSeconds;
        }
        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)//ritar ut texturen med farten och en färg!
        {
            spriteBatch.Draw(texture, 
                camera.convertToVisualCoords(position),
                null,
                Color.White,
                0f,
                new Vector2(texture.Width, texture.Height) / 2,
                new Vector2(20, 20),//scale
                SpriteEffects.None,
                0f);
        }
    }
}
