namespace MonoGameStarShooter
{
    class Bullet : Entity
    {
        
        
        public Bullet(Vector2 xy, Texture2D image) {
            base.texture = image;   
            pos = xy;
            pos.X += 33;
            createHitbox();
        }

        public override void Update() {

            pos.Y -= GameManager.bulletSpeed * GameManager.SCALE_FACTOR;
            updateHitbox();

            //Remove object after it leaves the screen
            if (pos.Y <= 0){
                isActive = false;
            }
        
        }
    }
}
