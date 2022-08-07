using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    abstract class Entity
    {
        protected Texture2D texture;
        public Rectangle hitbox;
        public Vector2 pos;
        public bool isActive = true;

        //Method must be implemented in derived class
        public abstract void Update();

        //Method can be changed in dervied class or just use on its own
        //Example you can override the Draw method in the derived class, or just use as is.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,                        //Texture
                pos,                            //Position
                null,                           //What portion of the sprite to draw (Default Draws whole sprite)
                Color.White,                           //Tint Color
                0f,                             //Rotation
                Vector2.Zero,                   //Origin
                GameManager.SCALE_FACTOR,       //Scale
                SpriteEffects.None,             //Effects
                0f);                            //Z-Layer
        }
        public virtual void createHitbox()
        {
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, (int)(texture.Width * GameManager.SCALE_FACTOR), (int)(texture.Height * GameManager.SCALE_FACTOR));
        }
        public virtual void updateHitbox()
        {
            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y;
        }
    }
}
