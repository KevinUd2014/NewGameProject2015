using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.View
{
    class MenuView
    {
        int alphaValue = 1;
        int fadeIncrement = 3;
        double fadeDelay = 0.010;

        Texture2D playText;

        Camera camera;
        //Vector2 playButtonPos;

        public MenuView(Camera camera)
        {
            this.camera = camera;

            //playButtonPos = new Vector2(0.4f, 0.4f);

            //size = new Vector2(graphics.GraphicsDevice.Viewport.Width / 20, graphics.GraphicsDevice.Viewport.Height / 20);

        }

        public void Update(float elapsedSeconds)
        {
            //fade effekt på meny namnet!
            fadeDelay -= elapsedSeconds;

            if (fadeDelay <= 0)//denna if sats kommer att fixa fade på titel texten!
            {
                fadeDelay = 0.010;
                alphaValue += fadeIncrement;

                if (alphaValue >= 255 || alphaValue <= 2)
                {
                    fadeIncrement *= -1;
                }
            }

            //this.playButton = playButton;

            //Vector2 mouseModelPosition = camera.convertToLogicalCoords(mousePosition);
           
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedSeconds, Texture2D menuBackground, Texture2D Playbutton, Rectangle rectangle, Color color)
        {


            float scale = camera.getScaleForView(menuBackground.Width);
            float scaleButton = camera.getScaleForView(Playbutton.Width);

            //spriteBatch.Draw(menuBackground, Vector2.Zero, menuBackground.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            //spriteBatch.Draw(menuBackground,Vector2.Zero, menuBackground.Bounds, new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));
            //spriteBatch.Draw(menuBackground,Vector2.Zero, camera.getScaleForView(menuBackground.Width), new Color((byte)MathHelper.Clamp(mAlphaValue, 22, 255), 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 22, 255)));
            //spriteBatch.Draw(playButton, camera.convertToVisualCoords(playButtonPos, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, buttonScale, SpriteEffects.None, 0);
            spriteBatch.Draw(menuBackground,
                    Vector2.Zero,
                    menuBackground.Bounds, 
                    new Color((byte)MathHelper.Clamp(alphaValue, 22, 255), 255, 255, (byte)MathHelper.Clamp(alphaValue, 22, 255)),
                    0f,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0f);

            spriteBatch.Draw(Playbutton, rectangle, color);
            //spriteBatch.Draw(Playbutton,
            //        Vector2.Zero,
            //        rectangle,
            //        color,
            //        0f,
            //        Vector2.Zero,
            //        scaleButton,
            //        SpriteEffects.None,
            //        0f);
        }

    }
}
