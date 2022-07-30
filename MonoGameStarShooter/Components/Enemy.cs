using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{
    class Enemy : Entity
   {
        
        public int botOfScreen = GameManager.screenHeight;
        protected float dropSpeed;

        
        public Enemy(int width, Texture2D image, float newSpeed)
        {
            dropSpeed = newSpeed;
            base.texture = image;
            base.pos = new Vector2(width, 0);
            dropSpeed = (dropSpeed * GameManager.SCALE_FACTOR);
            createHitbox();
           
        }
        public override void Update() {

            pos.Y += dropSpeed;
            updateHitbox();

            if (pos.Y >= botOfScreen) {

                this.isActive = false;
                EntityCollections.player1.hp -= 1;
            }

            //Remove enemy after it leaves screen
            if (pos.Y >= GameManager.screenHeight) 
            { 
                //Add logic for removing lives here

                isActive = false;
            
            }

        }

    }
}
