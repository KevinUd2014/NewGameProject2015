using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NewKillingStory.Model
{
    class Player : AnimatedSprites
    {
        float mySpeed = 100;

        //Texture2D character;
        //bool attacking = false;
        
        /// The constructor of the Player class
        public Player(Vector2 position) : base(position)//this position is handled through the base class
        {
            FramesPerSecond = 5;

            //Adds all the players animations
            //AddAnimation(12, 0, 0, "Down", 50, 50, new Vector2(0, 0));
            //AddAnimation(1, 0, 0, "IdleDown", 50, 50, new Vector2(0, 0));
            //AddAnimation(12, 50, 0, "Up", 50, 50, new Vector2(0, 0));
            //AddAnimation(1, 50, 0, "IdleUp", 50, 50, new Vector2(0, 0));
            //AddAnimation(8, 100, 0, "Left", 50, 50, new Vector2(0, 0));
            //AddAnimation(1, 100, 0, "IdleLeft", 50, 50, new Vector2(0, 0));
            //AddAnimation(8, 100, 8, "Right", 50, 50, new Vector2(0, 0));
            //AddAnimation(1, 100, 8, "IdleRight", 50, 50, new Vector2(0, 0));
            //AddAnimation(9, 150, 0, "AttackDown", 70, 80, new Vector2(0, 0));
            //AddAnimation(9, 230, 0, "AttackUp", 70, 80, new Vector2(-13, -27));
            //AddAnimation(9, 310, 0, "AttackLeft", 70, 70, new Vector2(-30, -5));
            //AddAnimation(9, 380, 0, "AttackRight", 70, 70, new Vector2(+15, -5));
            //Plays our start animation
            //PlayAnimation("IdleDown");
        }
        /// Loads content specific to the player class
        public void LoadContent(Texture2D character)
        {
            this.character = character;//laddar in charactern!
            AddAnimation(3);
        }

        public override void Update(GameTime gameTime)
        {
           
            direction = Vector2.Zero; //Makes the player stop moving when no key is pressed

            HandleKeyboardInput(Keyboard.GetState());//Handles the users keyboard input

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;//Calculates how many seconds since last Update//Is not based on fps!
            
            direction *= mySpeed;//Applies the speed speed

            
            postion += (direction * deltaTime);//Makes the movement framerate independent by multiplying with deltaTime

            base.Update(gameTime);
        }

        private void HandleKeyboardInput(KeyboardState keyState)
        {
            //if (!attacking)
            //{
            if (keyState.IsKeyDown(Keys.W))
            {
                //Move char Up
                direction += new Vector2(0, -1.5f);
                //PlayAnimation("Up");
                //currentDir = myDirection.up;

            }
            if (keyState.IsKeyDown(Keys.A))
            {
                //Move char Left
                direction += new Vector2(-1.5f, 0);
                //PlayAnimation("Left");
                //currentDir = myDirection.left;

            }
            if (keyState.IsKeyDown(Keys.S))
            {
                //Move char Down
                direction += new Vector2(0, 1.5f);
                //PlayAnimation("Down");
                //currentDir = myDirection.down;

            }
            if (keyState.IsKeyDown(Keys.D))
            {
                //Move char Right
                direction += new Vector2(1.5f, 0);
                //PlayAnimation("Right");
                //currentDir = myDirection.right;

            }

            //currentDir = myDirection.none;

        }

    }
}
        //}
        //if (keyState.IsKeyDown(Keys.Space))
        //{
        //    if (currentAnimation.Contains("Down"))
        //    {
        //        PlayAnimation("AttackDown");
        //        attacking = true;
        //        currentDir = myDirection.down;
        //    }
        //    if (currentAnimation.Contains("Left"))
        //    {
        //        PlayAnimation("AttackLeft");
        //        attacking = true;
        //        currentDir = myDirection.left;
        //    }
        //    if (currentAnimation.Contains("Right"))
        //    {
        //        PlayAnimation("AttackRight");
        //        attacking = true;
        //        currentDir = myDirection.right;
        //    }
        //    if (currentAnimation.Contains("Up"))
        //    {
        //        PlayAnimation("AttackUp");
        //        attacking = true;
        //        currentDir = myDirection.up;
        //    }
        //}
        //else if (!attacking)
        //{
        //    if (currentAnimation.Contains("Left"))
        //    {
        //        PlayAnimation("IdleLeft");
        //    }
        //    if (currentAnimation.Contains("Right"))
        //    {
        //        PlayAnimation("IdleRight");
        //    }
        //    if (currentAnimation.Contains("Up"))
        //    {
        //        PlayAnimation("IdleUp");
        //    }
        //    if (currentAnimation.Contains("Down"))
        //    {
        //        PlayAnimation("IdleDown");
        //    }
        //}

        /// Runs every time an animation has finished playing
        //public override void AnimationDone(string animation)
        //{
        //    if (animation.Contains("Attack"))
        //    {
        //        attacking = false;
        //    }
        //}
