using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameStarShooter
{
    //Stuff
    class Player : Entity
    {
        //Initialize variables unique to player
        float sideSpeed;

        //Constructor
        public Player(float x, float y)
        {
            //Center Player to screen width, and position 
            base.pos = new Vector2(x, y);
            //playerPos = Game1.ScreenSize / 2;
            sideSpeed = 5;
        }


        //Update method, takes in the abstract method from Entity
        public override void Update()
        {
            //Keyboard Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) 
            {
                pos.X -= sideSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos.X += sideSpeed;
            }
        }
    }
}
