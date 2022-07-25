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
        
        public Enemy(int width, Texture2D image)
        {
            base.texture = image;
            base.pos = new Vector2(width, 0);
        }
        public override void Update() {

            pos.Y += dropSpeed;

        }

        public void hit() 
        {
            //hp -= 1;
        }
    }
}
