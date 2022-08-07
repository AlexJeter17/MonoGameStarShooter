using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameStarShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Window resize implementation here
            _graphics.PreferredBackBufferHeight = GameManager.screenHeight;
            _graphics.PreferredBackBufferWidth = GameManager.screenWidth;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            // 0.0f is silent, 1.0f is full volume

        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Load the SpriteArt file, which will load all the Sprites inside it
            //using the method you created in that file
            font = Content.Load<SpriteFont>("File");
            GameManager.song = Content.Load<Song>("11_FreeSpaceMusic");
            GameManager.explosion = Content.Load<SoundEffect>("11_Explosion");
            GameManager.shootSound = Content.Load<SoundEffect>("11_ShootingNoise");
            GameManager.gameOver = Content.Load<SoundEffect>("11_GameOver");
            GameManager.hpDown = Content.Load<SoundEffect>("11_HealthDrop");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(GameManager.song);
            MediaPlayer.Volume = .5f;
            SpriteArt.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !GameManager.inGame)
            { // Here we added to check if inGame is false 
                GameManager.inGame = true;
                WaveManager.Reset(); // 1
                EntityCollections.ClearEntities(); // 2 - Uncomment this when told later in the article
                EntityCollections.score = 0; // 3

                MediaPlayer.Stop();
            }
            if (GameManager.inGame) // Here we check to make sure inGame is true
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

            _spriteBatch.Draw(SpriteArt.background, new Rectangle(0, 0, GameManager.screenWidth, GameManager.screenHeight), Color.WhiteSmoke);

            if (GameManager.inGame) // if inGame is true
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                UserInterface.gameScreen(_spriteBatch, font);

            }
            else // else inGame must be false
            {

                UserInterface.HomeScreen(_spriteBatch, font);

            }
            EntityCollections.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}