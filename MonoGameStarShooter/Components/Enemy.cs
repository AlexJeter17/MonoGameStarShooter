using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    internal class Enemy : Entity
    {
        //Enemy Properties
        public int health = 2;
        protected float dropSpeed = (1 * GameManager.SCALE_FACTOR);


        //Variables that control OnHit effects
        protected Color tint = Color.White;
        private int hitCooldown = 0;
        private int hitFrames = 10;
        private int knockbackMultiplier = 3;
        
        public Enemy(int width, Texture2D image, float newSpeed, int healthPoints)
        {
            dropSpeed = newSpeed * GameManager.SCALE_FACTOR;
            health = healthPoints;
            base.texture = image;
            base.pos = new Vector2(width, 0);
            createHitbox();
        }
        public override void Update() {

            //Add Score to Player if Enemy is dead
            if (health <= 0) {
                //Award score based on the speed of enemy
                EntityCollections.score += ((int)dropSpeed + 1);
                isActive = false;
            }
            //Remove lives from Player if enemy reaches end of screen
            if (pos.Y >= GameManager.screenHeight)
            {
                this.isActive = false;
                EntityCollections.player1.hp -= 1;
            }
            //Apply speed, current onhit effect, and hitbox location
            pos.Y += dropSpeed;
            OnHitEffect();
            updateHitbox();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,                        //Texture
                pos,                            //Position
                null,                           //What portion of the sprite to draw (Default Draws whole sprite)
                tint,                           //Tint Color
                0f,                             //Rotation
                Vector2.Zero,                   //Origin
                GameManager.SCALE_FACTOR,       //Scale
                SpriteEffects.None,             //Effects
                0f);
        }

        public void OnHit() 
        {
            health -= 1;
            hitCooldown = hitFrames;
            pos.Y -= dropSpeed * knockbackMultiplier;
        }
        
        private void OnHitEffect()
        {
            if (hitCooldown >= 0)
            {
                hitCooldown -= 1;
                tint = Color.Red;
            }
            else
            {
                tint = Color.White;
            }
        }
    }
}
