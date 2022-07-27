namespace MonoGameStarShooter
{
    static class SpriteArt
    {
        //Create the texture references here
        public static Texture2D Player { get; private set; }
        public static Texture2D EnemyTypeOne { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D EnemyTypeTwo { get; private set; }

        public static Texture2D backGround { get; private set; }

        //Load the textures into the references from the Content mgcb editor
        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("PlayerShip");
            EnemyTypeOne = content.Load<Texture2D>("EnemyTier1");
            EnemyTypeTwo = content.Load<Texture2D>("EnemyTier2");
            Bullet = content.Load<Texture2D>("Bullet");
            backGround = content.Load<Texture2D>("StarBackground");
        }

        //Call the texture by using "SpriteArt.Name" ex "image = SpriteArt.Player" 
 }
}
