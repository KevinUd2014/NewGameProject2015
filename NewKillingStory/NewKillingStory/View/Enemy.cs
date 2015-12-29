using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.View
{
    class Enemy// : AnimatedSprites
    {
        //public Vector2 velocity;
        //public float life;
        ////private static Texture2D character;
        //Camera camera;

        // Maximum amount of enemies to be shown at a time.
        const int maxEnemies = 2;

        // An instance of the Random object that will be used to calculate random coordinates to position the enemy.
        Random random = new Random();

        // A list that will store the rectangles containing the enemies.
        List<Rectangle> enemies = new List<Rectangle>();

        // Enemy texture values.
        int enemyWidth, enemyHeight;

        GraphicsDeviceManager graphics;

        public Texture2D character;

        // Amount in seconds to wait between the creation of enemies.
        const float enemyCreationTimer = 1.5f;

        // Elapsed time since the last creation of an enemy.
        double elapsedTime = 0;
        Vector2 velocity;

        public Enemy(Texture2D texture, Camera camera, GraphicsDeviceManager graphics)// : base(position, camera)
        {
            velocity = new Vector2(2,2);//speed later

            this.graphics = graphics;

            character = texture;

            enemyWidth = character.Width;
            enemyHeight = character.Height;

            //FramesPerSecond = 18;
            //AddAnimation(3, 0, 0, "EnemyDown", 40, 45);
            //AddAnimation(3, 132, 0, "EnemyUp", 40, 45);
            //AddAnimation(3, 49, 0, "EnemyLeft", 40, 45);
            //AddAnimation(3, 95, 0, "EnemyRight", 40, 45);
            ////AddAnimation(6, 0, 0, "Enemy", 32, 32);
            //PlayAnimation("EnemyDown");
        }
        public void Update(GameTime gameTime)
        {
            // Calculates the amount of time, in seconds, that passed between the previous call to the Update method and this one.
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            // Creates a new enemy everytime the current amount of enemies is less than the max allowed and the minimum amount of time between creations has been reached.
            if (elapsedTime >= enemyCreationTimer && enemies.Count < maxEnemies)
            {
                // The random instance is used to calculate a position between 0 and the max width/height that can be used in order to show the enemy texture inside the game window.
                enemies.Add(
                new Rectangle(
                random.Next(0, (graphics.PreferredBackBufferWidth - enemyWidth)),
                random.Next(0, (graphics.PreferredBackBufferHeight - enemyHeight)),
                enemyWidth,
                enemyHeight));
                // Reset the elapsed time so it is ready to create a new enemy.
                elapsedTime = 0;
            }

            //base.Update(gameTime);
        }
        public void HandleEnenmy()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle rectangle in enemies)
            {
                spriteBatch.Draw(character, rectangle, Color.White);
            }
        }
    }
}
