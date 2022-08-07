using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameStarShooter
{
    static class GameManager
    {
        //The SCALE variable allows you to 
        //uniformly scale sprites and movement with this value.
        public static float SCALE = 0.75f;
        //screenWidth and screenHeight will control the size of the window
        public static int screenWidth = 720;
        public static int screenHeight = 1080;

        public static int playerSpeed = 5;
        public static int playerHealth = 5;


        public static int level1Health = 2;
        public static float level1Speed = 3f;

        public static int level2Health = 3;
        public static float level2Speed = 5f;

        public static bool inGame = false;
    }
}

