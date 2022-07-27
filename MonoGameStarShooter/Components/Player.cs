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
        public int hp = GameManager.playerHealth;

        int cooldownRemaining = 0;

        //Constructor
        public Player(Vector2 centerPos, Texture2D image)
        {
            //Center Player to screen width, and position 
            pos = centerPos;
            base.texture = image;
            sideSpeed = GameManager.playerSpeed * GameManager.SCALE_FACTOR;
         
        }


        //Update method, takes in the abstract method from Entity
        public override void Update()
        {
            //Health check
            if (hp <= 0) { 
            
                this.isActive = false;
                // TODO::: Stop game here

            }
            //Keyboard Logic
            //Left movement
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) 
            {
                if (pos.X > 0) {
                    pos.X -= sideSpeed;
                }
            }
            //Right movement
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (pos.X < GameManager.screenWidth - 128) {
                    pos.X += sideSpeed;
                }
            }
            //Shooting Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && cooldownRemaining <= 0)
            {
                cooldownRemaining = GameManager.fireRate;
                EntityCollections.Instantiate(new Bullet(base.pos, SpriteArt.Bullet));
            }
            if (cooldownRemaining > 0) { cooldownRemaining--; }
        }
    }
}
