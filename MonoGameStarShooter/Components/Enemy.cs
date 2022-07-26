using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{
    internal class Enemy : Entity
   {
        protected int dropSpeed = 1;
        public int botOfScreen = Game1.height;

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


        public void hit() 
        {
            //hp -= 1;
        }
    }
}
