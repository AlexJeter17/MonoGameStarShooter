using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameStarShooter
{
    static class UserInterface
    {
        public static bool hasStarted = false;
        private static string titleString = "My First Game!";
        public static void HomeScreen(SpriteBatch _spriteBatch, SpriteFont font)
        {
            if (!hasStarted) titleString = "My First Game!";   
            else  titleString = "Game Over! | Score :" + EntityCollections.score; 
            _spriteBatch.DrawString(font, "Press ENTER to start a new game!", new Vector2(GameManager.screenWidth / 10, GameManager.screenHeight / 2), Color.WhiteSmoke);
            _spriteBatch.DrawString(font, titleString, new Vector2(GameManager.screenWidth / 10, (GameManager.screenHeight / 2) - 100), Color.Red);
        }

        public static void gameScreen(SpriteBatch _spriteBatch, SpriteFont font) 
        {
            EntityCollections.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, "Score: " + EntityCollections.score, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(font, "Wave: " + WaveManager.wave, new Vector2(GameManager.screenWidth - 200, 10), Color.White);
            _spriteBatch.DrawString(font, "HP: " + EntityCollections.player.hp, new Vector2(400, 10), Color.White);
        }
    }
}
