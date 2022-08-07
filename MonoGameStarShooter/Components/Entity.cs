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
                    texture,                      //Texture 
                    pos,                          //Position
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    GameManager.SCALE,     //Scale
                    SpriteEffects.None,
                    0f);
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
