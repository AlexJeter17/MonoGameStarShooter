using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    static class SpriteArt
    {
        //Create the texture references here
        public static Texture2D Player { get; private set; }

        //Load the textures into the references from the Content mgcb editor
        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Sprites/ball");
            Console.WriteLine(Player);
        }

        //Call the texture by using "SpriteArt.Name" ex "image = SpriteArt.Player" 
    }
}
