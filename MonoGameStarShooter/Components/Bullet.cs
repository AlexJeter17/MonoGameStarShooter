using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{
    class Bullet : Entity
    {
        protected int hp;
        public int BulletSpeed = 8;

        public Bullet(Vector2 xy, Texture2D image) {
            base.texture = image;
            pos = xy;
            pos.X += 47;
        
        }

        public void hit() {
            hp -= 1;
        }

        public override void Update() {

            pos.Y -= BulletSpeed;

            if (pos.Y <= 0){ 
            // Call the delete function
            
            }
        
        }
    }
}
