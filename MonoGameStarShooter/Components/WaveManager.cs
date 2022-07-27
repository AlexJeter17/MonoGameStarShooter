namespace MonoGameStarShooter
{
    static class WaveManager
    {
        public static int wave = 0;
        public static int remainingEnemiesToSpawn = 0;
        private static int maxNumEnemies = 0;

        static int spawnRate = 50;
        static int spawnDelay = 0;
        static Random random = new Random();

        public static void Update()
        {
            if (EntityCollections.enemies.Count == 0 && remainingEnemiesToSpawn == 0)
            {
                InitializeWave();
            }
            if (spawnDelay <= 0 && remainingEnemiesToSpawn != 0)
            {
                
                if (remainingEnemiesToSpawn % 2 == 0)
                {
                    remainingEnemiesToSpawn -= 1;
                    EntityCollections.Instantiate(new Enemy(random.Next(128, (EntityCollections.screenW - 128)), SpriteArt.EnemyTypeOne, 3f));
                }
                else
                {
                    remainingEnemiesToSpawn -= 1;
                    EntityCollections.Instantiate(new Enemy(random.Next(128, (EntityCollections.screenW - 128)), SpriteArt.EnemyTypeTwo, 8f));
                }
                spawnDelay = spawnRate;

            }
            if (spawnDelay > 0) spawnDelay--;
        }
        public static void InitializeWave()
        {
            wave += 1;
            remainingEnemiesToSpawn += maxNumEnemies;
            maxNumEnemies += 2;
        }
        public static void Reset()
        {
            wave = 0;
            remainingEnemiesToSpawn = 0;
            maxNumEnemies = 0;
        }
        
    }
}
