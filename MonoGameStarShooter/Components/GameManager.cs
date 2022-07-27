namespace MonoGameStarShooter
{
    static class GameManager
    {
        /* 
        Application Options

        SCALE_FACTOR -> The scaling to multiply the sprites and speed with. Lower = Smaller (Default = 0.7f)
        screenWidth -> The window application screen width (Default = 720)
        screenWidth -> The window application screen height (Default = 1080)
        */
        public static float SCALE_FACTOR = 0.7f;
        public static int screenWidth = 720;
        public static int screenHeight = 1080;


        /*
        Player Options
        
        playerHealth -> How much health the player has (Default = 5)
        fireRate -> How fast the player can shoot. Lower = Faster (Default = 15) 
        playerSpeed -> How fast the player can move (Default = 5)
        */
        public static int playerHealth = 5;
        public static int fireRate = 15;
        public static int playerSpeed = 5;


        /*
        Enemy Options 

        Level 1 Enemy
        level1Health -> How many bullets can the level one enemy take (Default = 2)
        level1Speed -> How fast the level one enemy moves (Default = 3f)

        */
        public static int level1Health = 2;
        public static float level1Speed = 3f;

        /*
        Level 2 Enemy
        level2Health -> How many bullets can the level two enemy take (Default = 32)
        level2Speed -> How fast the level two enemy moves (Default = 5f)
        */
        public static int level2Health = 3;
        public static float level2Speed = 5f;

        /* Misc Options */
        public static float bulletSpeed = 16f;
    }
}
