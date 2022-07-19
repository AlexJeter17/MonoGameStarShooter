using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameStarShooter
{
    //Stuff
    class Player
    {
        //Initialize variables

        Texture2D image;
        Vector2 playerPos;
        float sideSpeed;

        //Constructor
        public Player(float x, float y)
        {
            image = null;
            //Center Player to screen width, and position 
            playerPos = new Vector2(x, y);
            //playerPos = Game1.ScreenSize / 2;
            sideSpeed = 5;

        }

        //Functions
        public void loadImg(Texture2D img)
        {
            image = img;
        }
        //Update method, execute every time Game1.cs calls Update
        public void Update()
        {
            //Keyboard Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) 
            {
                playerPos.X -= sideSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerPos.X += sideSpeed;
            }
        }

        //Draw method
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, playerPos, Color.White);
        }
    }
}
