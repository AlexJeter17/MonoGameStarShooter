using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{
    internal abstract class Enemy
    {
        int hp; 
        // Random rand = new Random();
        int widthOfGame;
        protected Vector2 Position;
        protected int dropSpeed = 1;
        protected Texture2D ImageEn;

        // public Enemy(int width) { 
        //    widthOfGame = width;    
        //    Position = new Vector2(rand.Next(widthOfGame), 0);
        //    hp = 1;
        //}

        public void loadIMG(Texture2D img) { 

            ImageEn = img;
        
        }

        public void updates() {

            Position.Y += dropSpeed;

        }

        public void hit() {

            hp -= 1;

        }

        public void drawEn(SpriteBatch spriteBatch) { 
        
            spriteBatch.Draw(ImageEn, Position, Color.White);
        
        }

    }
}
