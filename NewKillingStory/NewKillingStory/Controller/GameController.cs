using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Enemy enemy;
        GraphicsDeviceManager _graphics;
        Texture2D _enemyTexture;
        Camera camera;
        public List<AnimatedSprites> AnimatedSprites;
        Texture2D character;
        ContentManager _content;
        public GameController()
        {
        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport, Camera camera, Texture2D enemyTexture, GraphicsDeviceManager graphics)
        {
            _enemyTexture = enemyTexture;
            this.camera = camera;
            _graphics = graphics;
            _content = Content;
            AnimatedSprites = new List<Model.AnimatedSprites>(); 
            map = new Map(camera);
            player = new Player(new Vector2(340, 220), map, AnimatedSprites, camera);// start positionen för player!
            enemy = new Enemy(new Vector2(0,0), camera, graphics, enemyTexture);
            character = Content.Load<Texture2D>("imp");
            player.LoadContent(character);
            enemy.LoadContent(enemyTexture);

            //Enemy.SetTexture(Content.Load<Texture2D>("Bat"));
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
        public void changeLevel1()
        { 
            AnimatedSprites = new List<Model.AnimatedSprites>();
            map = new Map(camera);
            player = new Player(new Vector2(340, 220), map, AnimatedSprites, camera);// start positionen för player!
            enemy = new Enemy(new Vector2(0, 0), camera, _graphics, _enemyTexture);
            player.LoadContent(character);
            //Flame.SetTexture(_content.Load<Texture2D>("flame_sprite"));

            Tiles.Content = _content;

            Level1();
        }
        public void changeLevel2()
        {
            AnimatedSprites = new List<Model.AnimatedSprites>();
            map = new Map(camera);
            player = new Player(new Vector2(340, 220), map, AnimatedSprites, camera);// start positionen för player!
            enemy = new Enemy(new Vector2(0, 0), camera, _graphics, _enemyTexture);
            player.LoadContent(character);
            //Flame.SetTexture(_content.Load<Texture2D>("flame_sprite"));

            Tiles.Content = _content;

            Level2();
        }
        public void changeLevel3()
        {
            AnimatedSprites = new List<Model.AnimatedSprites>();
            map = new Map(camera);
            player = new Player(new Vector2(340, 220), map, AnimatedSprites, camera);// start positionen för player!
            enemy = new Enemy(new Vector2(0, 0), camera, _graphics, _enemyTexture);
            player.LoadContent(character);
            //Flame.SetTexture(_content.Load<Texture2D>("flame_sprite"));

            Tiles.Content = _content;

            Level3();
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
                { 4,1,4,1,1,1,1,1,1,1,1,1,1,8},
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
                { 4,1,4,1,1,4,1,1,1,1,1,1,1,1},
                { 4,1,4,1,1,4,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,4,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,4,1,1,1,1,1,1,6,6},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
        }
        public void Level3()
        {
            map.Generate(new int[,]{//denna sätter hur många tiles jag vill ha och vart jag vill ha dem på skärmen!
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                changeLevel1();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                changeLevel2();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                changeLevel3();
            }

            player.Update(gameTime);
            enemy.Update(gameTime);
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
            enemy.Draw(spriteBatch);

            for (int i = AnimatedSprites.Count - 1; i >= 0; i--)
            {
                if (AnimatedSprites[i].Alive)
                    AnimatedSprites[i].Draw(spriteBatch);
            }
        }
    }
}
