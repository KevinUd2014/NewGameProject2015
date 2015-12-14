using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewKillingStory.Controller;
using NewKillingStory.Model;

namespace NewKillingStory
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class KillingStory : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D character;
        Player player;

        GameController gameController;
        MenuController menuController;

        /// http://gamedev.stackexchange.com/questions/108518/monogame-screen-transition-with-fading
        enum Gamestate//vet inte om denna!Lånade från filip!
        {
            Menu,//we have a menu
            Play,//and a play
        }


        public KillingStory()
        {
            graphics = new GraphicsDeviceManager(this);

            //Puts the size of the window!
            graphics.PreferredBackBufferHeight = 840;
            graphics.PreferredBackBufferWidth = 840;
            
            Content.RootDirectory = "Content";
        }
        
        Gamestate ScreenState = Gamestate.Menu;//menu will be the deffault!
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //create all the necessary classes!
            menuController = new MenuController();
            gameController = new GameController();
            
            player = new Player(new Vector2(340, 220));// start positionen för player!

            //Load all the textures here and sound as well!
            Texture2D startMenuBackground = Content.Load<Texture2D>("KillerStory");
            Texture2D playButton = Content.Load<Texture2D>("playButton");
            character = Content.Load<Texture2D>("imp");
            //character = Content.Load<Texture2D>("Fox");

            //load all the classes and give them all the necessary parameters!

            player.LoadContent(character);
            menuController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport, startMenuBackground, playButton);
            gameController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (ScreenState)//creats a Switch with all the diffrent screens!
            {
                case Gamestate.Menu:
                    IsMouseVisible = true;
                    menuController.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    player.Update(gameTime);
                    break;

                case Gamestate.Play:
                    break;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch (ScreenState)//got this from a classmate! //really smart and inovative idéa
            {
                case Gamestate.Menu:
                    menuController.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
                    player.Draw(spriteBatch, character);
                    break;

                case Gamestate.Play:
                    break;
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
