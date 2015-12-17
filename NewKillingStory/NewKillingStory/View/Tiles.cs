using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory
{
    class Tiles
    {
        protected Texture2D texture;
        //protected Texture2D trees;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)//, Camera camera)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            //spriteBatch.Draw(texture,
            //        Vector2.Zero,
            //        rectangle, Color.White,
            //        0f,
            //        Vector2.Zero,
            //        camera,
            //        SpriteEffects.None,
            //        0f);
        }
    }
    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Tiles" + i);
            //trees = Content.Load<Texture2D>("Tree" + i);

            Rectangle = newRectangle;
        }
    }
}
