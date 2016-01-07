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
        float enemySpeed = 0.8f;
        const int maxEnemies = 2;// Maximum amount of enemies to be shown at a time.

        Random random = new Random();// An instance of the Random object that will be used to calculate random coordinates to position the enemy.

        List<Rectangle> enemies = new List<Rectangle>();// lista med fiender
        
        int enemyWidth, enemyHeight;// fiende info

        GraphicsDeviceManager graphics;

        Vector2 veclocity = Vector2.Zero;
        Player player;
        //Vector2 position;
        int life = 2;
        
        const float enemyCreationTimer = 1.5f;//Hur länge en fiende ska vänta innan spawn igen

        // Elapsed time since the last creation of an enemy.
        double elapsedTime = 0;

        public Enemy(Vector2 position, Camera camera, GraphicsDeviceManager graphics, Texture2D texture, Player _player) : base(position, camera)
        {
            //velocity = new Vector2(2,2);//speed later
            this.position = position;
            this.graphics = graphics;

            character = texture;

            player = _player;

            enemyWidth = character.Width;
            enemyHeight = character.Height;

            FramesPerSecond = 14;
            AddAnimation(4, 0, 0, "Enemy", 32, 30);
            //AddAnimation(4, 132, 0, "EnemyUp", 30, 30);
            //AddAnimation(4, 49, 0, "EnemyLeft", 30, 30);
            //AddAnimation(4, 95, 0, "EnemyRight", 30, 30);
            //AddAnimation(6, 0, 0, "Enemy", 32, 32);
            PlayAnimation("Enemy");
        }

        public Vector2 GetPosition()// gets the player position!
        {
            return position;
        }
        public void LoadContent(Texture2D character)
        {
            this.character = character;//laddar in character!
        }
        public override void Update(GameTime gameTime)
        {
            // Calculates the amount of time, in seconds, that passed between the previous call to the Update method and this one.
            //elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            //veclocity += new Vector2(0, 1.5f);

            direction = Vector2.Zero; //Makes the player stop moving when no key is pressed

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;//Calculates how many seconds since last Update//Is not based on fps!

            direction *= enemySpeed;//Applies the speed speed

            //Console.WriteLine(player.GetPosition());//

            Vector2 playerPos = player.GetPosition();

            if (position.X < player.GetPosition().X)
            {
                position.X += enemySpeed;
            }
            else if (position.X > player.GetPosition().X)
            {
                position.X -= enemySpeed;
            }

            if (position.Y < player.GetPosition().Y)
            {
                position.Y += enemySpeed;
            }
            else if(position.Y > player.GetPosition().Y)
            {
                position.Y -= enemySpeed;
            }
            HandleEnenmy(gameTime);

            base.Update(gameTime);
        }
        public void HandleEnenmy(GameTime gameTime)
        {
            direction += new Vector2(0, -1.5f);
            PlayAnimation("Enemy");
            currentDirection = myDirection.down;
        }
    }
}
