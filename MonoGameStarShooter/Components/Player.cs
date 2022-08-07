using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameStarShooter
{
    class Player : Entity
    {
        int sideSpeed = GameManager.playerSpeed;

        int cooldownRemaining = 0;
        int fireRate = 15;

        public int hp = GameManager.playerHealth;

        //Player code will go here


        public Player(Texture2D image, Vector2 initalPosition)
        {
            texture = image;
            pos = initalPosition;

        }

        public override void Update()
        {

            // HEALTH CHECK
            if (hp <= 0)
            {
                GameManager.inGame = false;
                SpriteArt.gameOver.Play(0.5f, 0.0f, 0.0f);
                hp = GameManager.playerHealth;
                MediaPlayer.Play(SpriteArt.song);
            }

            //Keyboard Controls
            //Side to Side Movement

            //Moving Left
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //Constraint so that it can't move outside the window
                if (pos.X > 0)
                {
                    pos.X -= sideSpeed;
                }
            }
            //Moving Right
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //Constraint
                if (pos.X < GameManager.screenWidth - (texture.Width * GameManager.SCALE))
                {
                    pos.X += sideSpeed;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && cooldownRemaining <= 0)
            {
                Vector2 projectileSpawn = new Vector2(pos.X + ((texture.Width * GameManager.SCALE) / 2), pos.Y);
                cooldownRemaining = fireRate;
                EntityCollections.Instantiate(new Bullet(projectileSpawn, SpriteArt.Bullet));

                SpriteArt.shootSound.Play(0.25f, 0.0f, 0.0f);

            }
            if (cooldownRemaining > 0)
            {
                cooldownRemaining--;
            }

        }

    }
}