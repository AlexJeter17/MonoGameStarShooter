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
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteArt.Load(Content);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(SpriteArt.song);
            MediaPlayer.Volume = .5f;
            
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
                UserInterface.hasStarted = true;
                EntityCollections.Initialize();
                EntityCollections.Update();
                WaveManager.Update();
            }
            base.Update(gameTime);
        }

        

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(SpriteArt.backGround, new Rectangle(0, 0, GameManager.screenWidth, GameManager.screenHeight), Color.WhiteSmoke);
            
            if (GameManager.inGame) // if inGame is true
            {
                UserInterface.gameScreen(_spriteBatch, SpriteArt.font);
                EntityCollections.Draw(_spriteBatch);
            }
            else // else inGame must be false
            {
                UserInterface.HomeScreen(_spriteBatch, SpriteArt.font);
            }

            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}