namespace MonoGameStarShooter
{
    public class Game1 : Game
    {
        //Initial Variables
        private Player playerUser;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Enemy EnemyOne;
        private Enemy EnemyTwo;
        private Bullet shooting;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerUser = new Player(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 1.2f);
            Random rand = new Random();
            
            EnemyOne = new Enemy(rand.Next(_graphics.PreferredBackBufferWidth));
            EnemyTwo = new Enemy(rand.Next(_graphics.PreferredBackBufferWidth));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteArt.Load(Content);
            playerUser.loadImage(SpriteArt.Player);
            

            EnemyOne.loadIMG(SpriteArt.EnemyTypeOne);
            EnemyTwo.loadIMG(SpriteArt.EnemyTypeTwo);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            playerUser.Update();
            EnemyOne.updates();
            EnemyTwo.updates();
            playerUser.updateBullets();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            playerUser.Draw(_spriteBatch);
            EnemyOne.drawEn(_spriteBatch);
            EnemyTwo.drawEn(_spriteBatch);
            for (int i = 0; i < playerUser.bulletList.Count; i++)
            {
                playerUser.bulletList[i].drawBullet(_spriteBatch);
            }



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
