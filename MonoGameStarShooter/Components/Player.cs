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
        public List<Bullet> bulletList = new List<Bullet>();

        //Firerate
        const int fireRate = 20;
        int cooldownRemaining = 0;
        int widthOfGame;

        //Constructor
        public Player(float x, float y, int widthOfGame)
        {
            //Center Player to screen width, and position 
            base.pos = new Vector2(x, y);
            //playerPos = Game1.ScreenSize / 2;
            sideSpeed = 5;
            this.widthOfGame = widthOfGame;
        }


        //Update method, takes in the abstract method from Entity
        public override void Update()
        {
            //Keyboard Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) 
            {
                if (pos.X > -15) {
                    pos.X -= sideSpeed;
                }

                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {

                if (pos.X < widthOfGame - 114) {
                    pos.X += sideSpeed;
                }

                //pos.X += sideSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && cooldownRemaining <= 0)
            {

                cooldownRemaining = fireRate;
                bulletList.Add(new Bullet(base.pos, SpriteArt.Bullet));

            }
            if (cooldownRemaining > 0) { cooldownRemaining--; }
        }
        public void updateBullets()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].update();
            }
        }
    }
}
