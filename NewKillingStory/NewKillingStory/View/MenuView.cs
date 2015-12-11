using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        Camera camera;
        Vector2 playButtonPos;
        Texture2D playButton;
        float sclaeButton = 1f;
        float minimumButton = 1f;
        float maxButton = 1.2f;



        public MenuView(Camera camera)
        {
            this.camera = camera;


            playButtonPos = new Vector2(0.4f, 0.4f);

        }

        public void Update(Vector2 mousePosition, Texture2D playButton, float elapsedSeconds)
        {
            fadeDelay -= elapsedSeconds;

            if (fadeDelay <= 0)
            {
                fadeDelay = 0.010;
                alphaValue += fadeIncrement;

                if (alphaValue >= 255 || alphaValue <= 2)
                {
                    fadeIncrement *= -1;
                }
            }

            this.playButton = playButton;

            Vector2 mouseModelPosition = camera.convertToLogicalCoords(mousePosition);
            Console.WriteLine(mouseModelPosition.X);

            //TODO: FIX PLAYBUTTON FOR FULLSCREEN

            //if (mouseModelPosition.X >= playButtonPos.X - playButton.Width && mouseModelPosition.X < playButtonPos.X + playButton.Width
            //&& mouseModelPosition.Y >= playButtonPos.Y - playButton.Height && mouseModelPosition.Y < playButtonPos.Y + playButton.Height)
            //{
            //    if (buttonScale < maxButtonscale)
            //    {
            //        buttonScale += 0.01f;
            //    }
            //}

            //else
            //{
            //    if (buttonScale > minButtonscale)
            //    {
            //        buttonScale -= 0.01f;
            //    }
            //}
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedSeconds, Texture2D menuBackground)
        {


            float scale = camera.getScaleForView(menuBackground.Width);

            //spriteBatch.Draw(menuBackground, Vector2.Zero, menuBackground.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            //spriteBatch.Draw(menuBackground,Vector2.Zero, menuBackground.Bounds, new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));
            //spriteBatch.Draw(menuBackground,Vector2.Zero, camera.getScaleForView(menuBackground.Width), new Color((byte)MathHelper.Clamp(mAlphaValue, 22, 255), 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 22, 255)));
            //spriteBatch.Draw(playButton, camera.convertToVisualCoords(playButtonPos, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, buttonScale, SpriteEffects.None, 0);
            spriteBatch.Draw(menuBackground,
                    Vector2.Zero,
                    menuBackground.Bounds, new Color((byte)MathHelper.Clamp(alphaValue, 22, 255), 255, 255, (byte)MathHelper.Clamp(alphaValue, 22, 255)),
                    0f,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0f);
        }

    }
}
