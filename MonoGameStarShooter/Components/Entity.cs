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
                texture, 
                pos, 
                null,
                Color.White,
                0f,
                Vector2.Zero,
                GameManager.SCALE_FACTOR,
                SpriteEffects.None,
                0f);
        }
        public virtual void loadImage(Texture2D image)
        {
            texture = image;
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
