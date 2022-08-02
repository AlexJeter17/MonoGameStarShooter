using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameStarShooter
{
    public class Game1 : Game
    {
        //Initial Variables
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        

 
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = GameManager.screenHeight;
            _graphics.PreferredBackBufferWidth = GameManager.screenWidth;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("File");
            SpriteArt.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {


            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !GameManager.inGame) { 
                GameManager.inGame = true;
                WaveManager.Reset();
                EntityCollections.ClearEntities();
                EntityCollections.score = 0;
            }
            if (GameManager.inGame)
            {
                EntityCollections.Initialize();
                EntityCollections.Update();
                WaveManager.Update();
                base.Update(gameTime);
            }
 

        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (GameManager.inGame)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                UserInterface.gameScreen(_spriteBatch, font);

            }
            else
            {

                UserInterface.HomeScreen(_spriteBatch, font);
                
            }
            EntityCollections.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }




    }
}


