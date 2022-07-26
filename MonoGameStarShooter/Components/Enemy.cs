using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{
    internal class Enemy : Entity
    {
        protected float dropSpeed = (1 * GameManager.SCALE_FACTOR);
        
        public Enemy(int width, Texture2D image)
        {
            base.texture = image;
            base.pos = new Vector2(width, 0);
            createHitbox();
        }
        public override void Update() {

            pos.Y += dropSpeed;
            updateHitbox();
            //Remove enemy after it leaves screen
            if (pos.Y >= GameManager.screenHeight) 
            { 
                //Add logic for removing lives here
                isActive = false;
            
            }
        }


        public void hit() 
        {
            //hp -= 1;
        }
    }
}
