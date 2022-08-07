using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    class Bullet : Entity
    {
        //Bullet speed
        public int BulletSpeed = 8;

        public Bullet(Vector2 inital, Texture2D image)
        {
            texture = image;
            pos = inital;
            pos.X -= (texture.Width * GameManager.SCALE) / 2;

            createHitbox();
        }

        public override void Update()
        {
            pos.Y -= BulletSpeed;

            if (pos.Y <= 0)
            {
                isActive = false;
            }
            //Update hitbox here
            updateHitbox();
        }

    }
}
