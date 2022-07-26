namespace MonoGameStarShooter
{
    class Bullet : Entity
    {
        protected int hp;
        public int BulletSpeed = 8;

        public Bullet(Vector2 xy, Texture2D image) {
            base.texture = image;   
            pos = xy;
            pos.X += 47;
            createHitbox();
        }

        public void hit() {
            hp -= 1;
        }

        public override void Update() {

            pos.Y -= BulletSpeed;
            updateHitbox();

            //Remove object after it leaves the screen
            if (pos.Y <= 0){
                isActive = false;
            }
        
        }
    }
}
