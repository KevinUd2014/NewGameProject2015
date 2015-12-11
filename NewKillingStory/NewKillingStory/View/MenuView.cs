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
        Camera camera;
        Vector2 playButtonPos;
        Texture2D playButton;
        float buttonScale = 1f;
        float minButtonscale = 1f;
        float maxButtonscale = 1.2f;



        public MenuView(Camera camera)
        {
            this.camera = camera;


            playButtonPos = new Vector2(0.4f, 0.4f);

        }

        public void Update(Vector2 mousePosition, Texture2D playButton)
        {
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

        public void Draw(SpriteBatch sBatch, float elapsedSeconds, Texture2D menuBackground)
        {


            float scale = camera.getScaleForView((float)menuBackground.Width);

            sBatch.Begin();
            sBatch.Draw(menuBackground, Vector2.Zero, menuBackground.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            //sBatch.Draw(playButton, camera.convertToVisualCoords(playButtonPos, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, buttonScale, SpriteEffects.None, 0);
            sBatch.End();
        }

    }
}
