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
            EntityCollections.Initialize(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            EntityCollections.Update();
            WaveManager.Update();
            //awave = WaveManager.wave;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(SpriteArt.backGround, new Rectangle(0, 0,GameManager.screenWidth,GameManager.screenHeight), Color.DarkGray); // If background does not perfectly fit screen, Edit it here

            EntityCollections.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, "Score: " + EntityCollections.score, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(font, "Wave: " + WaveManager.wave, new Vector2(GameManager.screenWidth - 200, 10), Color.White);
            _spriteBatch.DrawString(font, "HP: " + EntityCollections.player1.hp, new Vector2(400, 10), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


