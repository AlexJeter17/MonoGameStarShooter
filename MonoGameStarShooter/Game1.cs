namespace MonoGameStarShooter
{
    public class Game1 : Game
    {
        //Initial Variables
        private Player playerUser;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Enemy EnemyOne;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerUser = new Player(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 1.4f);
            EnemyOne = new Enemy();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteArt.Load(Content);
            playerUser.loadImg(SpriteArt.Player);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            playerUser.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            playerUser.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}