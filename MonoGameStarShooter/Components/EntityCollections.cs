namespace MonoGameStarShooter
{
    static class EntityCollections
    {
        static Random random = new Random();
        //All Entities
        static List<Entity> entities = new List<Entity>();
        //Entity specific lists
        static List<Enemy> enemies = new List<Enemy>();
        static List<Bullet> bullets = new List<Bullet>();

        static bool hasInitalized = false;

        public static void Initialize(int screenW, int screenH)
        {
            if (hasInitalized == false)
            {
                Instantiate(new Player(new Vector2(screenW / 2, screenH / 1.2f), SpriteArt.Player, screenW));
                Instantiate(new Enemy(random.Next(screenW), SpriteArt.EnemyTypeOne));
                Instantiate(new Enemy(random.Next(screenW), SpriteArt.EnemyTypeTwo));
                hasInitalized = true;
            }
        }
        public static void Update()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }
            
            entities = entities.Where(obj => obj.isActive).ToList();
            enemies = enemies.Where(obj => obj.isActive).ToList();
            bullets = bullets.Where(obj => obj.isActive).ToList();
            


            //Collisions
            //Collisions between enemies and bullets
            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    
                    if (bullets[j].hitbox.Intersects(enemies[i].hitbox))
                    {
                        //Do hitbox stuff here
                        Console.WriteLine("Hitbox");
                        enemies[i].isActive = false;
                        bullets[j].isActive = false;
                    }
                }
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(spriteBatch);
            }
        }
        public static void Instantiate(Entity entity)
        {
            entities.Add(entity);
            if (entity is Enemy) enemies.Add(entity as Enemy);
            else if (entity is Bullet) bullets.Add(entity as Bullet);
        }
    }
}
