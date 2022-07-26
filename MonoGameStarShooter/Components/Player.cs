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
        public int hp = 5;
        //Firerate
        const int fireRate = 20;
        int cooldownRemaining = 0;
        int widthOfGame;

        //Constructor
        public Player(Vector2 centerPos, Texture2D image, int width)
        {
            //Center Player to screen width, and position 
            pos = centerPos;
            base.texture = image;
            widthOfGame = width;
            sideSpeed = 5 * GameManager.SCALE_FACTOR;
        }


        //Update method, takes in the abstract method from Entity
        public override void Update()
        {
            // health check

            if (hp <= 0) { 
            
                this.isActive = false;
                // TODO::: Stop game here

            }


            //Keyboard Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) 
            {
                if (pos.X > 0) {
                    pos.X -= sideSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (pos.X < widthOfGame - 128) {
                    pos.X += sideSpeed;
                }
            }
            //Weapon Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && cooldownRemaining <= 0)
            {
                cooldownRemaining = fireRate;
                EntityCollections.Instantiate(new Bullet(base.pos, SpriteArt.Bullet));
            }
            if (cooldownRemaining > 0) { cooldownRemaining--; }
        }
    }
}
