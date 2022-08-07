using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameStarShooter
{
    static class SpriteArt
    {
        //Fonts
        public static SpriteFont font { get; private set; }
        //Create the texture references here
        public static Texture2D Player { get; private set; }
        public static Texture2D EnemyTypeOne { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D EnemyTypeTwo { get; private set; }
        public static Texture2D backGround { get; private set; }

        //Load the textures into the references from the Content mgcb editor
        public static void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>("File");
            Player = content.Load<Texture2D>("Sprites/PlayerShip");
            EnemyTypeOne = content.Load<Texture2D>("Sprites/EnemyTier1");
            EnemyTypeTwo = content.Load<Texture2D>("Sprites/EnemyTier2");
            Bullet = content.Load<Texture2D>("Sprites/Bullet");
            backGround = content.Load<Texture2D>("Sprites/StarBackground");
        }

        //Call the texture by using "SpriteArt.Name" ex "image = SpriteArt.Player" 
 }
}
