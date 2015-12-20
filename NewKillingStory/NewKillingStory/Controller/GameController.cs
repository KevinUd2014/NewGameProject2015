using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NewKillingStory.Model;
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
        private Player player;
        public List<AnimatedSprites> AnimatedSprites;

        public GameController()
        {

        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport)
        {
            AnimatedSprites = new List<Model.AnimatedSprites>(); 
            map = new Map();
            player = new Player(new Vector2(340, 220), map, AnimatedSprites);// start positionen för player!
            var character = Content.Load<Texture2D>("imp");
            player.LoadContent(character);

            Flame.SetTexture(Content.Load<Texture2D>("flame_sprite"));

            Tiles.Content = Content;

            Level1();


            //map.Generate(new int[,]{//skapar här ett till lager med nya tiles t.ex. så kan man lägga in träd i denna vilket kanske gör det lättare att ksapa kollisioner med dom!
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,3,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,4,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            //}, 64);//med 64 så menar jag 64 pixlar!

        }
        public void Level1()
        {
            map.Generate(new int[,]{//denna sätter hur många tiles jag vill ha och vart jag vill ha dem på skärmen!
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 4,4,4,4,4,1,1,1,1,1,1,1,1,1},
                { 4,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 4,1,4,4,4,1,1,1,1,1,4,4,1,1},
                { 4,1,4,1,1,1,1,1,1,1,4,4,1,1},
                { 4,1,4,1,1,1,1,1,1,1,1,1,1,1},
                { 4,1,4,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,6,6},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
        }
        public void Level2()
        {
            map.Generate(new int[,]{//denna sätter hur många tiles jag vill ha och vart jag vill ha dem på skärmen!
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 4,4,4,4,4,1,1,1,1,1,1,1,1,1},
                { 4,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 4,1,4,4,4,1,1,1,1,1,4,4,1,1},
                { 4,1,4,1,1,1,1,1,1,1,4,4,1,1},
                { 4,1,4,1,1,1,1,1,1,1,1,1,1,1},
                { 4,1,4,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,6,6},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            for (int i = AnimatedSprites.Count - 1; i >= 0; i--)
            {
                if (AnimatedSprites[i].Alive)
                    AnimatedSprites[i].Update(gameTime);
                else
                    AnimatedSprites.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)//, Camera camera)
        {
            map.Draw(spriteBatch);//, camera);
            player.Draw(spriteBatch);

            for (int i = AnimatedSprites.Count - 1; i >= 0; i--)
            {
                if (AnimatedSprites[i].Alive)
                    AnimatedSprites[i].Draw(spriteBatch);
            }
        }
    }
}
