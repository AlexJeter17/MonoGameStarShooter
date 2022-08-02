﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameStarShooter
{
    static class UserInterface
    {

        public static void HomeScreen(SpriteBatch _spriteBatch, SpriteFont font)
        {
            
            /*_spriteBatch.Begin();*/
            _spriteBatch.Draw(SpriteArt.backGround, new Rectangle(0, 0, GameManager.screenWidth, GameManager.screenHeight), Color.WhiteSmoke);
            _spriteBatch.DrawString(font, "Press ENTER to start a new game!", new Vector2(GameManager.screenWidth / 10, GameManager.screenHeight / 2), Color.WhiteSmoke);
            _spriteBatch.DrawString(font, "MonoGame Star Shooter Tutorial!", new Vector2(GameManager.screenWidth / 10, (GameManager.screenHeight / 2) - 100), Color.Red);
            /*_spriteBatch.End();*/
        }

        public static void gameScreen(SpriteBatch _spriteBatch, SpriteFont font) 
        {
            _spriteBatch.Draw(SpriteArt.backGround, new Rectangle(0, 0, GameManager.screenWidth, GameManager.screenHeight), Color.WhiteSmoke); // If background does not perfectly fit screen, Edit it here

            EntityCollections.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, "Score: " + EntityCollections.score, new Vector2(10, 10), Color.White);
            _spriteBatch.DrawString(font, "Wave: " + WaveManager.wave, new Vector2(GameManager.screenWidth - 200, 10), Color.White);
            _spriteBatch.DrawString(font, "HP: " + EntityCollections.player1.hp, new Vector2(400, 10), Color.White);

        }
    }
}