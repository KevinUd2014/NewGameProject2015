using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewKillingStory.Controller;
using NewKillingStory.Model;
using NewKillingStory.View;

namespace NewKillingStory
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class KillingStory : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        GameController gameController;
        MenuController menuController;
        Camera camera;

        //pause funktionen
        Texture2D pauseTexture;
        Rectangle pausedRectangle;
        PauseButton buttonPlay, buttonQuit, buttonMainMenu;

        /// http://gamedev.stackexchange.com/questions/108518/monogame-screen-transition-with-fading
        enum Gamestate//vet inte om denna!Lånade från filip!
        {
            Menu,//we have a menu
            Play,//and a play
            Pause,
            GameOver,
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
            camera = new Camera(GraphicsDevice.Viewport);


            //Load all the textures here and sound as well!
            Texture2D startMenuBackground = Content.Load<Texture2D>("KillerStory");
            Texture2D playButton = Content.Load<Texture2D>("playButton");
            //character = Content.Load<Texture2D>("Fox");

            //pause saker
            pauseTexture = Content.Load<Texture2D>("PauseMenu");
            pausedRectangle = new Rectangle(0, 0, pauseTexture.Width, pauseTexture.Height);

            buttonPlay = new PauseButton();
            buttonPlay.Load(Content.Load<Texture2D>("ResumeButton"), new Vector2(400, 400));
            buttonQuit = new PauseButton();
            buttonQuit.Load(Content.Load<Texture2D>("QuitButton"), new Vector2(400, 450));
            buttonMainMenu = new PauseButton();
            buttonMainMenu.Load(Content.Load<Texture2D>("MenuButton"), new Vector2(400, 500));

            //menuView = new MenuView();

            //load all the classes and give them all the necessary parameters!
            menuController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport, startMenuBackground, playButton);
            gameController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport);

            menuController.setPosition(new Vector2(400, 400));// sätter positionen för knappen!
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
            MouseState mouse = Mouse.GetState();
            switch (ScreenState)//creats a Switch with all the diffrent screens!
            {
                case Gamestate.Menu:
                    IsMouseVisible = true;
                    menuController.Update((float)gameTime.ElapsedGameTime.TotalSeconds, mouse);
                    //player.Update(gameTime);
                    if (menuController.isClicked == true)
                    {
                        ScreenState = Gamestate.Play;
                        IsMouseVisible = true;
                        menuController.isClicked = false;
                    }
                    break;
                case Gamestate.Play:

                    IsMouseVisible = false;

                    //if (menuController.isClicked == false)
                    //    menuController.isClicked = true;

                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        ScreenState = Gamestate.Pause;
                        buttonPlay.isClicked = false;//vet inte om denna behövs!
                        //menuController.isClicked = true;
                    }
                    //menuController.isClicked = true;
                    gameController.Update(gameTime);

                    break;
                case Gamestate.Pause:
                    IsMouseVisible = true;
                    
                    if (buttonPlay.isClicked)
                    {
                        ScreenState = Gamestate.Play;
                    }
                    if (buttonQuit.isClicked)
                        Exit();
                    if (buttonMainMenu.isClicked)
                    {
                        ScreenState = Gamestate.Menu;
                        buttonPlay.isClicked = false;//vet inte om denna behövs!

                        //menuController.isClicked = false;
                        //menuController.isClicked = true;
                    }

                    buttonPlay.Update(mouse);
                    buttonQuit.Update(mouse);
                    buttonMainMenu.Update(mouse);

                    break;
                case Gamestate.GameOver:

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
                    break;
                case Gamestate.Play:
                    gameController.Draw(spriteBatch);//, camera);
                    break;
                case Gamestate.Pause:

                    spriteBatch.Draw(pauseTexture, pausedRectangle, Color.White);
                    buttonPlay.Draw(spriteBatch);
                    buttonMainMenu.Draw(spriteBatch);
                    buttonQuit.Draw(spriteBatch);

                    break;
                case Gamestate.GameOver:
                    break;
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
