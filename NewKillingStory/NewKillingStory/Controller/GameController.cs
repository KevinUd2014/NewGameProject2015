using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Texture2D enemyText;
        public List<AnimatedSprites> AnimatedSprites;
        Texture2D character;
        ContentManager _content;

        SoundEffect fireballSound;
        SoundEffect backgroundMusic;
        SoundEffectInstance soundEffectInstance;

        public bool onFirstLevel;
        public bool onSecondLevel;
        public bool onThirdLevel;

        GameController gameController;

        public GameController()
        {
        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport, Camera camera, Texture2D enemyTexture, GraphicsDeviceManager graphics, SoundEffect _backgroundMusic, GameController _gameController, SoundEffect _fireballSound)
        {
            _enemyTexture = enemyTexture;
            this.camera = camera;
            _graphics = graphics;

            backgroundMusic = _backgroundMusic;
            fireballSound = _fireballSound;

            _content = Content;
            gameController = _gameController;
            //AnimatedSprites = new List<Model.AnimatedSprites>(); 
            //map = new Map(camera);
            //player = new Player(new Vector2(340, 220), map, AnimatedSprites, camera);// start positionen för player!
            //enemy = new Enemy(new Vector2(0,0), camera, graphics, enemyTexture);
            character = Content.Load<Texture2D>("imp");
            //player.LoadContent(character);
            //enemy.LoadContent(enemyTexture);

            //Enemy.SetTexture(Content.Load<Texture2D>("Bat"));
            Flame.SetTexture(Content.Load<Texture2D>("flame_sprite"));
            //backgroundMusic.Play(0.1f, 0.0f, 0.0f);
            //Tiles.Content = Content;
            soundEffectInstance = backgroundMusic.CreateInstance();

            onFirstLevel = false;
            onSecondLevel = false;
            onThirdLevel = false;

            StartGame();
            Level1();

        }
        public void StartGame()
        { 
            AnimatedSprites = new List<Model.AnimatedSprites>();
            map = new Map(camera);
            player = new Player(new Vector2(340, 220), map, AnimatedSprites, camera, gameController);// start positionen för player!
            enemy = new Enemy(new Vector2(0, 0), camera, _graphics, _enemyTexture);
            player.LoadContent(character);
            enemy.LoadContent(_enemyTexture);
            //Flame.SetTexture(_content.Load<Texture2D>("flame_sprite"));

            soundEffectInstance.Play();

            soundEffectInstance.Volume = 0.1f;
            soundEffectInstance.Pan = -0.0f;
            soundEffectInstance.Pitch = 0.0f;

            Tiles.Content = _content;
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
                { 4,1,4,1,1,1,1,8,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,6,6},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
            onFirstLevel = true;
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
                { 1,1,1,1,1,4,1,1,8,1,1,1,1,1},
                { 1,1,1,1,1,4,1,1,1,1,1,1,6,6},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
            onSecondLevel = true;
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
                { 1,1,1,1,1,1,6,1,8,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,6,1,1,1,1,1,1,1},
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);//med 64 så menar jag 64 pixlar!
            onThirdLevel = true;
        }

        public void Update(GameTime gameTime)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    fireballSound.Play();
            //}
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                StartGame();
                Level2();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                StartGame();
                Level3();
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
