using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewKillingStory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.Controller
{
    class MenuController
    {
        Texture2D startMenuBackground;
        Texture2D playButton;

        MenuView menuView;
        Camera camera;

        Vector2 position;
        Rectangle rectangle;

        Color color = new Color(255, 255, 255, 255);
        
        public bool isClicked;

        public MenuController()
        {
        }
        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport,Texture2D Background, Texture2D Play)
        {
            camera = new Camera(viewport);

            //sprites
            startMenuBackground = Background;
            playButton = Play;

            menuView = new MenuView(camera);
        }
        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Update(float elapsedSeconds, MouseState mousePosition)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 80, 50);//, (int)size.X, (int)size.Y //storleken på playknappen avgörs här!
            Rectangle mouseRectangle = new Rectangle(mousePosition.X, mousePosition.Y, 1, 1);//en rektangel på musen!

            if (mouseRectangle.Intersects(rectangle))
            {
                //if (color.A == 255)
                //    down = false;
                //if (color.A == 0)
                //    down = true;
                //if (down)
                //    color.A += 3;
                //else color.A -= 3;

                if (mousePosition.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            }
            else if (color.A < 255)
            {
            //    color.A += 3;
                isClicked = false;
            }
            menuView.Update(elapsedSeconds);
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedSeconds)
        {
            menuView.Draw(spriteBatch, elapsedSeconds, startMenuBackground, playButton, rectangle, color);
        }
    }
}
