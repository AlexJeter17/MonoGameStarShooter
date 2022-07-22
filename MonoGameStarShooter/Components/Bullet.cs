using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{



    internal class Bullet
    {
        protected Vector2 PositionBullet;
        public Texture2D ImageBullet;
        protected int hp;

        public Bullet(Vector2 xy, Texture2D image) {
            ImageBullet = image;
            PositionBullet = xy;
            PositionBullet.X += 47;
        
        }

        public void hit() {

            hp -= 1;

        }

        public void update() {

            PositionBullet.Y -= 8;

            if (PositionBullet.Y <= 0){ 
            // Call the delete function
            }
        
        }

        public void LoadBull(Texture2D img) {

            ImageBullet = img;

        }

        public void drawBullet(SpriteBatch spriteBatch) {

            spriteBatch.Draw(ImageBullet, PositionBullet, Color.White);

        }

    }
}
