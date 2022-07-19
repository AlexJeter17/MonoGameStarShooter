using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameStarShooter
{
    internal class lvlOneEnemy : Enemy
    {
        int hp;
        int widthOfGame;
        // Vector2 Position;
        int dropSpeed = 2;
        Texture2D ImageEn;


        public lvlOneEnemy(int width) {
            
            widthOfGame = width;
            //Position = new Vector2(rand.Next(widthOfGame), 0);
            
        }

        public void spawn(int width) {
            
            base.Position = new Vector2(width, 0);

        }

    }
}
