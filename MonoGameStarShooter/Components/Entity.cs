using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    abstract class Entity
    {
        protected Texture2D texture;
        public Vector2 pos;
        public bool isActive = true;

        public Rectangle hitbox;

        //Abstract Methods
        public abstract void Update();


        //Common Draw Method
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,                        //Texture
                pos,                            //Position
                null,                           //What portion of the sprite to draw (Default Draws whole sprite)
                Color.White,                           //Tint Color
                0f,                             //Rotation
                Vector2.Zero,                   //Origin
                GameManager.SCALE,       //Scale
                SpriteEffects.None,             //Effects
                0f);                            //Z-Layer
        }

        public virtual void createHitbox()
        {
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, (int)(texture.Width * GameManager.SCALE), (int)(texture.Height * GameManager.SCALE));
        }

        public virtual void updateHitbox()
        {
            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
        }

    }
}
