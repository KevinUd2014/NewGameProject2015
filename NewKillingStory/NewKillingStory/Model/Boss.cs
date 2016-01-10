using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.Model
{
    class Boss : AnimatedSprites
    {
        Map map;

        Vector4 hitbox;
        public float enemySpeed = 0.8f * 2f;
        const int maxEnemies = 1;// Maximum amount of enemies to be shown at a time.

        Random random = new Random();// An instance of the Random object that will be used to calculate random coordinates to position the enemy.

        List<Rectangle> enemies = new List<Rectangle>();// lista med fiender

        int enemyWidth, enemyHeight;// fiende info

        GraphicsDeviceManager graphics;

        Vector2 veclocity = Vector2.Zero;
        Player player;

        const float enemyCreationTimer = 1.5f;//Hur länge en fiende ska vänta innan spawn igen

        private List<AnimatedSprites> animatedSprites;

        public Boss(Vector2 position, Map map, List<AnimatedSprites> animatedSprites, Camera camera, GraphicsDeviceManager graphics, Texture2D texture, Player _player) : base(position, camera)
        {
            this.map = map;
            hitbox = new Vector4(15, 40, 49, 66); // bästa raden gällande karaktären!
            this.animatedSprites = animatedSprites;
            this.life = 2;
            this.giveDamage = 5;
            //velocity = new Vector2(2,2);//speed later
            this.position = position;
            this.graphics = graphics;

            character = texture;

            player = _player;

            enemyWidth = character.Width;
            enemyHeight = character.Height;

            FramesPerSecond = 14;
            AddAnimation(3, 0, 0, "Enemy", 43, 43);
            PlayAnimation("Enemy");
        }
        public void LoadContent(Texture2D character)
        {
            this.character = character;//laddar in charactern!
        }

        public Vector2 GetPositionForEnemy()// gets the enemy position!
        {
            return position;
        }
        public override void Update(GameTime gameTime)
        {
            direction = Vector2.Zero; //Makes the player stop moving when no key is pressed

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;//Calculates how many seconds since last Update//Is not based on fps!

            direction *= enemySpeed;//Applies the speed speed

            Vector2 playerPosition = player.GetPositionForPlayer();
            Vector2 targetVector = playerPosition - position;
            targetVector.Normalize();

            Vector2 col = checkForCollision(position + targetVector * enemySpeed);
            targetVector = targetVector * (Vector2.One - col);
            position += targetVector * enemySpeed;

            foreach (AnimatedSprites sprite in animatedSprites)
            {
                if (sprite.GetType() == typeof(Flame) && sprite.Alive)
                {
                    Flame flame = sprite as Flame;
                    if ((flame.GetPosition() - position).Length() <= 30)
                    {
                        flame.Alive = false;
                        life -= flame.giveDamage;
                    }
                }
            }
            base.Update(gameTime);
        }

        public Vector2 checkForCollision(Vector2 pos)//denna funktion fick jag hjälp med då den är ganska komplex och avancerad!
        {
            pos.X += hitbox.X;
            pos.Y += hitbox.Y;

            Vector2 size = new Vector2(hitbox.Z - hitbox.X, hitbox.W - hitbox.Y);
            try
            {
                bool tileNW = map.tilemap[(int)(pos.Y / map.Height * map.tilemap.GetLength(0)), (int)(pos.X / map.Width * map.tilemap.GetLength(1))] % 2 == 0;
                bool tileNE = map.tilemap[(int)(pos.Y / map.Height * map.tilemap.GetLength(0)), (int)((pos.X + size.X) / map.Width * map.tilemap.GetLength(1))] % 2 == 0;
                bool tileSW = map.tilemap[(int)((pos.Y + size.Y) / map.Height * map.tilemap.GetLength(0)), (int)(pos.X / map.Width * map.tilemap.GetLength(1))] % 2 == 0;
                bool tileSE = map.tilemap[(int)((pos.Y + size.Y) / map.Height * map.tilemap.GetLength(0)), (int)((pos.X + size.X) / map.Width * map.tilemap.GetLength(1))] % 2 == 0;

                float x = (tileSW && tileNW) ? 1 : 0;
                x += (tileSE && tileNE) ? 1 : 0;
                float y = (tileNW && tileNE) ? 1 : 0;
                y += (tileSW && tileSE) ? 1 : 0;

                return new Vector2(x, y);
            }
            catch (IndexOutOfRangeException e)
            {
                return Vector2.Zero;
            }
            //bool outside = pos.X < 0 || pos.X + hitbox.Z > map.Width || pos.Y < 0 || pos.Y + hitbox.W > map.Height;

        }
    }
}
