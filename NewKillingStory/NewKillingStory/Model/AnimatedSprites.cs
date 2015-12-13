using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.Model
{
    abstract class AnimatedSprites
    {


        ///// Enum used to keep track of the animation's direction
        //public enum myDirection { none, left, right, up, down };
        ///// Determines the direction of the current animation
        //protected myDirection currentDir = myDirection.none;
        ///// The texture of the sprite
        protected Texture2D character;
        ///// The position of the SpriteObject
        protected Vector2 postion;
        ///// Number of frames in the animation
        private int frameIndex;
        private Rectangle[] rectangle;


        ///// Time that has passed since last frame change 
        private double timeElapsed;
        ///// Time it takes to update a frame
        private double timeToUpdate;
        //private Rectangle[] rectangle;
        ///// Keeps track of the current animation
        //protected string currentAnimation;
        ///// The velocity of the SpriteObject
        protected Vector2 direction = Vector2.Zero;

        ///// Our time per frame is equal to 1 divided by frames per second(we are deciding FPS)
        public int FramesPerSecond
        {
            set
            {
                timeToUpdate = (1f / value);//denna höjer farten på animationen eller sänker den m,ellan 1 och 2 är bra!
            }
        }

        ///// Dictionary that contains all animations
        //private Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();

        ///// Dictionary that contains all animation offsets
        //private Dictionary<string, Vector2> sOffsets = new Dictionary<string, Vector2>();

        ///// Constructor of the AnimatedSprite
        public AnimatedSprites(Vector2 position)
        {
            this.postion = position;
        }

        ///// <summary>
        ///// Adds an animation to the AnimatedSprite
        ///// </summary>
        public void AddAnimation(int frames)//, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        {
            int width = character.Width / frames;
            rectangle = new Rectangle[frames];

            for (int i = 0; i < frames; i++)////Fills up the array of rectangles
            {
                rectangle[i] = new Rectangle(i * width, 0, width, character.Height);
                //Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            //sAnimations.Add(name, Rectangles);
            //sOffsets.Add(name, offset);
        }
        ///// Determines when we have to change frames
        public virtual void Update(GameTime gameTime)
        {
            //Adds time that has elapsed since our last draw
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            //We need to change our image if our timeElapsed is greater than our timeToUpdate(calculated by our framerate)
            if (timeElapsed > timeToUpdate)
            {
                //Resets the timer in a way, so that we keep our desired FPS
                timeElapsed -= timeToUpdate;

                //Adds one to our frameIndex
                if (frameIndex < rectangle.Length - 1)//sAnimations[currentAnimation].Length - 1)
                {
                    frameIndex++;
                }
                else //Restarts the animation
                {
                    //AnimationDone(currentAnimation);
                    frameIndex = 0;
                }
            }
        }

        ///// Draws the sprite on the screen
        public void Draw(SpriteBatch spriteBatch, Texture2D character)
        {
            spriteBatch.Draw(character, postion, rectangle[frameIndex], Color.White);
        }
        ///// Plays an animation
        //public void PlayAnimation(string name)
        //{
        //    //Makes sure we won't start a new annimation unless it differs from our current animation
        //    if (currentAnimation != name && currentDir == myDirection.none)
        //    {
        //        currentAnimation = name;
        //        frameIndex = 0;
        //    }
        //}

        ///// Method that is called every time an animation finishes
        //public abstract void AnimationDone(string animation);
    }
}
