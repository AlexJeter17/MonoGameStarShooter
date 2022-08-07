using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    class Enemy : Entity
    {
        public int health = 2;
        protected float dropSpeed = (1 * GameManager.SCALE);

        //Variables to control hit effects
        protected Color tint = Color.White;
        private int hitCooldown = 0;
        private int hitFrames = 10;
        private int knockbackMultiplier = 3;


        public Enemy(int width, Texture2D image, float newSpeed, int healthPoints)
        {
            //From Part 4
            pos = new Vector2(width, 0);
            texture = image;
            dropSpeed = newSpeed;
            health = healthPoints;
            //Create the hitbox for the Enemy object
            createHitbox();
        }

        public override void Update()
        {
            //When Health is 0, remove itself
            if (health <= 0)
            {
                EntityCollections.score += ((int)dropSpeed - 1);
                GameManager.explosion.Play(0.7f, 0.0f, 0.0f);
                isActive = false;
            }
            //When the Enemy reaches the edge of screen, remove itself
            if (pos.Y >= GameManager.screenHeight)
            {
                GameManager.hpDown.Play(0.25f, 0.0f, 0.0f);
                isActive = false;
                EntityCollections.player.hp -= 1;
            }
            //Apply movement to the Enemy by updating its position
            pos.Y += dropSpeed;
            //Update hitbox every frame
            updateHitbox();
            OnHitEffect();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
            texture,
            pos,
            null,
            tint,                       //Tint Color
            0f,
            Vector2.Zero,
            GameManager.SCALE,
            SpriteEffects.None,
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
