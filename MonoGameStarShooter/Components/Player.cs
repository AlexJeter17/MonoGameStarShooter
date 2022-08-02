using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameStarShooter
{
    //Stuff
    class Player : Entity
    {
        //Initialize variables unique to player
        float sideSpeed;

        public int hp = GameManager.playerHealth;

        int cooldownRemaining = 0;

        //Constructor
        public Player(Vector2 centerPos, Texture2D image)
        {
            //Center Player to screen width, and position 
            pos = centerPos;
            texture = image;
            sideSpeed = GameManager.playerSpeed * GameManager.SCALE_FACTOR;
        }


        //Update method, takes in the abstract method from Entity
        public override void Update()
        {
            //Health check
            if (hp <= 0)
            {
                GameManager.inGame = false;
                /*this.isActive = false;*/
                hp = GameManager.playerHealth;
                
            }

            //Keyboard Logic
            //Left movement
            if ((Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A)) && GameManager.inGame) 
            {
                if (pos.X > 0) {
                    pos.X -= sideSpeed;
                }
            }
            //Right movement
            if ((Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D)) && GameManager.inGame)
            {
                if (pos.X < GameManager.screenWidth - 128) {
                    pos.X += sideSpeed;
                }
            }
            //Shooting Logic
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && cooldownRemaining <= 0 && GameManager.inGame)
            {
                Vector2 projectile = new Vector2 (pos.X + ((texture.Width * GameManager.SCALE_FACTOR)/2), pos.Y);
                cooldownRemaining = GameManager.fireRate;
                EntityCollections.Instantiate(new Bullet(projectile, SpriteArt.Bullet));
            }
            if (cooldownRemaining > 0) { cooldownRemaining--; }
        }
    }
}
