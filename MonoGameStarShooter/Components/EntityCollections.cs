namespace MonoGameStarShooter
{
    static class EntityCollections
    {
        static Random random = new Random();
        static List<Entity> entities = new List<Entity>();
        static bool hasInitalized = false;

        public static void Initialize(int screenW, int screenH)
        {
            if (hasInitalized == false)
            {
                entities.Add(new Player(new Vector2(screenW / 2, screenH / 1.2f), SpriteArt.Player, screenW));
                entities.Add(new Enemy(random.Next(screenW), SpriteArt.EnemyTypeOne));
                entities.Add(new Enemy(random.Next(screenW), SpriteArt.EnemyTypeTwo));
                hasInitalized = true;
            }
        }
        public static void Update()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
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
        }
    }
}
