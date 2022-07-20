namespace MonoGameStarShooter
{
    abstract class Entity
    {
        protected Texture2D texture;
        protected Rectangle hitbox;
        public Vector2 pos;

        //Method must be implemented in derived class
        public abstract void Update();

        //Method can be changed in dervied class or just use on its own
        //Example you can override the Draw method in the derived class, or just use as is.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }
        public virtual void createHitbox()
        {
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }
        public virtual void loadImage(Texture2D image)
        {
            texture = image;
        }
    }
}
