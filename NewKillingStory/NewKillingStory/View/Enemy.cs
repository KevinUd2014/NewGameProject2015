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
        // Maximum amount of enemies to be shown at a time.
        const int maxEnemies = 2;

        // An instance of the Random object that will be used to calculate random coordinates to position the enemy.
        Random random = new Random();

        // A list that will store the rectangles containing the enemies.
        List<Rectangle> enemies = new List<Rectangle>();

        // Enemy texture values.
        int enemyWidth, enemyHeight;

        GraphicsDeviceManager graphics;

        private static Texture2D texture;

        // Amount in seconds to wait between the creation of enemies.
        const float enemyCreationTimer = 1.5f;

        // Elapsed time since the last creation of an enemy.
        double elapsedTime = 0;

        public Enemy(Vector2 position, Camera camera, GraphicsDeviceManager graphics, Texture2D texture) : base(position, camera)
        {
            //velocity = new Vector2(2,2);//speed later

            this.graphics = graphics;

            character = texture;

            enemyWidth = character.Width;
            enemyHeight = character.Height;

            FramesPerSecond = 18;
            AddAnimation(4, 0, 0, "Enemy", 30, 30);
            //AddAnimation(4, 132, 0, "EnemyUp", 30, 30);
            //AddAnimation(4, 49, 0, "EnemyLeft", 30, 30);
            //AddAnimation(4, 95, 0, "EnemyRight", 30, 30);
            //AddAnimation(6, 0, 0, "Enemy", 32, 32);
            PlayAnimation("Enemy");
        }
        public override void Update(GameTime gameTime)
        {
            // Calculates the amount of time, in seconds, that passed between the previous call to the Update method and this one.
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            // Creates a new enemy everytime the current amount of enemies is less than the max allowed and the minimum amount of time between creations has been reached.
            if (elapsedTime >= enemyCreationTimer && enemies.Count < maxEnemies)
            {
                enemies.Add(// The random instance is used to calculate a position between 0 and the max width/height that can be used in order to show the enemy texture inside the game window.
                new Rectangle(
                random.Next(0, (graphics.PreferredBackBufferWidth - enemyWidth)),
                random.Next(0, (graphics.PreferredBackBufferHeight - enemyHeight)),
                enemyWidth,
                enemyHeight));
                // Reset the elapsed time for new enemy
                elapsedTime = 0;
            }

            HandleEnenmy(gameTime);

            base.Update(gameTime);
        }
        public void HandleEnenmy(GameTime gameTime)
        {
            //direction += new Vector2(0, -1.5f);
            PlayAnimation("Enemy");
            currentDirection = myDirection.none;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle rectangle in enemies)
            {
                spriteBatch.Draw(character, rectangle, Color.White);
            }
        }
        public static void SetTexture(Texture2D tex)
        {
            texture = tex;
        }
    }
}
