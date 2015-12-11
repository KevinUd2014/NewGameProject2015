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
        MouseState oldMouseState;
        MouseState newMouseState;

        public MenuController()
        {

        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport,Texture2D Background, Texture2D Play)
        {
            camera = new Camera(viewport);

            startMenuBackground = Background;
            playButton = Play;

            menuView = new MenuView(camera);
        }

        public void Update(float elapsedSeconds)
        {
            oldMouseState = newMouseState;

            newMouseState = Mouse.GetState();
            var mousePosition = new Vector2(newMouseState.X, newMouseState.Y);

            menuView.Update(mousePosition, playButton);

            if (oldMouseState.LeftButton == ButtonState.Released && newMouseState.LeftButton == ButtonState.Pressed)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedSeconds)
        {
            menuView.Draw(spriteBatch, elapsedSeconds, startMenuBackground);
        }
    }
}
