using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewKillingStory.View;
using NewKillingStory.Controller;
using System.Threading;
using Microsoft.Xna.Framework.Audio;

namespace NewKillingStory.Model
{
    class Player : AnimatedSprites
    {
        float mySpeed = 100;
        Map map;

        Vector4 hitbox;

        private float lastShot = 0;
        private float fireRate = 0.2f;
        Camera camera;
        private List<AnimatedSprites> animatedSprites;
        SoundEffect fireballSound;
        //Texture2D character;
        //bool attacking = false;
        GameController gameController;
       // Vector2 position;

        /// The constructor of the Player class//
        public Player(Vector2 position, Map map, List<AnimatedSprites> animatedSprites, Camera camera, GameController _gameController, SoundEffect _fireballSound) : base(position, camera)//this position is handled through the base class
        {
            this.position = position;
            this.camera = camera;
            this.map = map;
            this.animatedSprites = animatedSprites;

            fireballSound = _fireballSound;

            hitbox = new Vector4(15, 40, 49, 66); // bästa raden gällande karaktären!
            gameController = _gameController;
            FramesPerSecond = 6;

            //Adds all the players animations
            AddAnimation(3, 1, 0, "Down", 64, 64);
            AddAnimation(3, 65, 0, "Left", 64, 64);
            AddAnimation(3, 129, 0, "Right", 64, 64);
            AddAnimation(3, 193, 0, "Up", 64, 64);
            PlayAnimation("Down");
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        // Loads content specific to the player class
        public void LoadContent(Texture2D character)
        {
            this.character = character;//laddar in charactern!
        }

        public override void Update(GameTime gameTime)
        {
           
            direction = Vector2.Zero; //Makes the player stop moving when no key is pressed

            HandleKeyboardInput(Keyboard.GetState(), gameTime);//Handles the users keyboard input

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;//Calculates how many seconds since last Update//Is not based on fps!
            
            direction *= mySpeed;//Applies the speed speed
            
            position += (direction * deltaTime);//Makes the movement framerate independent by multiplying with deltaTime
            
            base.Update(gameTime);
        }
        public void HandleKeyboardInput(KeyboardState keyState, GameTime gameTime)
        {
            if (keyState.IsKeyDown(Keys.W) && !checkForCollision(position + new Vector2(0, -2.5f)))
            {
                //Move char Up
                direction += new Vector2(0, -1.5f);
                PlayAnimation("Up");
                currentDirection = myDirection.up;
            }
            if (keyState.IsKeyDown(Keys.A) && !checkForCollision(position + new Vector2(-2.5f, 0)))
            {
                //Move char Left
                direction += new Vector2(-1.5f, 0);
                PlayAnimation("Left");
                currentDirection = myDirection.left;
            }
            if (keyState.IsKeyDown(Keys.S) && !checkForCollision(position + new Vector2(0, 2.5f)))
            {
                //Move char Down
                direction += new Vector2(0, 1.5f);
                PlayAnimation("Down");
                currentDirection = myDirection.down;
            }
            if (keyState.IsKeyDown(Keys.D) && !checkForCollision(position + new Vector2(2.5f, 0)))
            {
                //Move char Right
                direction += new Vector2(1.5f, 0);
                PlayAnimation("Right");
                currentDirection = myDirection.right;
            }
            //denna är för flame!
            if (keyState.IsKeyDown(Keys.Up)) //&& !checkForCollision(position + new Vector2(0, 0)))
            {
                PlayAnimation("Up");
                currentDirection = myDirection.up;
                if (gameTime.TotalGameTime.TotalSeconds - lastShot > fireRate)
                {
                    fireballSound.Play();
                    attack(new Vector2(0, -5));
                    lastShot = (float)gameTime.TotalGameTime.TotalSeconds;
                }

            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                PlayAnimation("Down");
                currentDirection = myDirection.down;
                if (gameTime.TotalGameTime.TotalSeconds - lastShot > fireRate)
                {
                    fireballSound.Play();
                    attack(new Vector2(0, 5));
                    lastShot = (float)gameTime.TotalGameTime.TotalSeconds;
                }

            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                PlayAnimation("Right");
                currentDirection = myDirection.right;
                if (gameTime.TotalGameTime.TotalSeconds - lastShot > fireRate)
                {
                    fireballSound.Play();
                    attack(new Vector2(5, 0));
                    lastShot = (float)gameTime.TotalGameTime.TotalSeconds;
                }

            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                PlayAnimation("Left");
                currentDirection = myDirection.left;
                if (gameTime.TotalGameTime.TotalSeconds - lastShot > fireRate)
                {
                    fireballSound.Play();
                    attack(new Vector2(-5, 0));
                    lastShot = (float)gameTime.TotalGameTime.TotalSeconds;
                }
            }
            currentDirection = myDirection.none;
        }

        private void attack(Vector2 V)
        {
            animatedSprites.Add(new Flame(position,V, camera));
        }
      

        public bool checkForCollision(Vector2 pos)//denna funktion fick jag hjälp med då den är ganska komplex och avancerad!
        {
            pos.X += hitbox.X;
            pos.Y += hitbox.Y;

            Vector2 size = new Vector2( hitbox.Z - hitbox.X , hitbox.W - hitbox.Y);

            bool tileNW = map.tilemap[(int)(pos.Y / map.Height * map.tilemap.GetLength(0)), (int)(pos.X / map.Width * map.tilemap.GetLength(1))] % 2 == 0;
            bool tileNE = map.tilemap[(int)(pos.Y / map.Height * map.tilemap.GetLength(0)), (int)((pos.X + size.X) / map.Width * map.tilemap.GetLength(1))] % 2 == 0;
            bool tileSW = map.tilemap[(int)((pos.Y + size.Y) / map.Height * map.tilemap.GetLength(0)), (int)(pos.X / map.Width * map.tilemap.GetLength(1))] % 2 == 0;
            bool tileSE = map.tilemap[(int)((pos.Y + size.Y) / map.Height * map.tilemap.GetLength(0)), (int)((pos.X + size.X) / map.Width * map.tilemap.GetLength(1))] % 2 == 0;

            bool tileChangeWorld = map.tilemap[(int)((pos.Y + size.Y) / map.Height * map.tilemap.GetLength(0)), (int)(pos.X / map.Width * map.tilemap.GetLength(1))] == 8;

            if (tileChangeWorld && gameController.onFirstLevel == true )//&& gameController.onSecondLevel == false && gameController.onThirdLevel == false)
            {
                gameController.StartGame();
                gameController.Level2();
                gameController.onFirstLevel = false;
                tileChangeWorld = false;             
            }
            if (tileChangeWorld && gameController.onSecondLevel == true && gameController.onFirstLevel == false && gameController.onThirdLevel == false)
            {
                gameController.StartGame();
                gameController.Level3();
                gameController.onSecondLevel = false;
                tileChangeWorld = false;
            }
            if (tileChangeWorld && gameController.onThirdLevel == true)
            {
                gameController.StartGame();
                gameController.Level1();
                gameController.onThirdLevel = false;
                gameController.onSecondLevel = false;
                tileChangeWorld = false;
            }
            bool outside = pos.X < 0 || pos.X + hitbox.Z > map.Width || pos.Y < 0 || pos.Y + hitbox.W > map.Height;

            if (tileNW || tileNE || tileSW || tileSE || outside)
            {
                return true;
            }
            return false;
        }
    }
}