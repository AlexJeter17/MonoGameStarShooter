using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace MonoGameStarShooter
{
    //SpriteArt.cs

    //The class name should generally be the same as the file name
    static class SpriteArt
    {
        //Place our texture references and methods here
        public static Texture2D Player { get; private set; }
        public static Texture2D Enemy1 { get; private set; }
        public static Texture2D Enemy2 { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D background { get; private set; }


        //Function to load our content
        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("PlayerShip");
            Enemy1 = content.Load<Texture2D>("EnemyTier1");
            Enemy2 = content.Load<Texture2D>("EnemyTier2");
            Bullet = content.Load<Texture2D>("Bullet");
            background = content.Load<Texture2D>("StarBackground");
        }

    }
}
