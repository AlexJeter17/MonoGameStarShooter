using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace MonoGameStarShooter
{
    //SpriteArt.cs

    //The class name should generally be the same as the file name
    static class SpriteArt
    {
        //Fonts
        public static SpriteFont font { get; private set; }
        //Create the texture references here
        public static Texture2D Player { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D EnemyTypeTwo { get; private set; }
        public static Texture2D EnemyTypeOne { get; private set; }
        public static Texture2D backGround { get; private set; }

        //Sound and Music References
        public static Song song { get; private set; }
        public static SoundEffect shootSound { get; private set; }
        public static SoundEffect explosion { get; private set; }
        public static SoundEffect gameOver { get; private set; }
        public static SoundEffect hpDown { get; private set; }


        //Function to load our content
        public static void Load(ContentManager content)
        {
            //Load Font and Sprites
            font = content.Load<SpriteFont>("File");
            Player = content.Load<Texture2D>("PlayerShip");
            EnemyTypeOne = content.Load<Texture2D>("EnemyTier1");
            EnemyTypeTwo = content.Load<Texture2D>("EnemyTier2");
            Bullet = content.Load<Texture2D>("Bullet");
            backGround = content.Load<Texture2D>("StarBackground");

            //Load Songs and SoundEffects
            song = content.Load<Song>("11_FreeSpaceMusic");
            explosion = content.Load<SoundEffect>("11_Explosion");
            shootSound = content.Load<SoundEffect>("11_ShootingNoise");
            gameOver = content.Load<SoundEffect>("11_GameOver");
            hpDown = content.Load<SoundEffect>("11_HealthDrop");
        }

    }
}
