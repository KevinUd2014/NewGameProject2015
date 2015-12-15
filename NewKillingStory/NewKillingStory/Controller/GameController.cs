using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewKillingStory.Controller
{
    class GameController
    {
        Map map;

        public GameController()
        {

        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport)
        {

            map = new Map();

            Tiles.Content = Content;

            map.Generate(new int[,]{//denna sätter hur många tiles jag vill ha och vart jag vill ha dem på skärmen!
                { 1,1,1,1,1,1,1,1,3,4,4,4,4,4},
                { 1,1,1,1,1,1,1,1,3,1,1,1,4,4},
                { 1,1,1,1,1,1,1,1,3,1,1,1,4,4},
                { 1,1,1,1,1,1,1,1,3,3,3,3,4,4},
                { 1,1,1,1,1,1,1,1,1,1,1,3,3,3},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)//, Camera camera)
        {
            map.Draw(spriteBatch);//, camera);
        }
    }
}
