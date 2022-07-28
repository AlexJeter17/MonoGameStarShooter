using System;

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
            //When all enemies are not on screen, and there are no enemies left to spawn, start next wave
            if (EntityCollections.enemies.Count == 0 && remainingEnemiesToSpawn == 0)
            {
                InitializeWave();
            }
            //Spawner logic, this spawns the enemies by spawn rate.
            if (spawnDelay <= 0 && remainingEnemiesToSpawn != 0)
            {
                
                if (remainingEnemiesToSpawn % 2 == 0)
                {
                    remainingEnemiesToSpawn -= 1;
                    EntityCollections.Instantiate(new Enemy(
                        random.Next(128, (GameManager.screenWidth - 128)),   //Position to Spawn Enemy
                        SpriteArt.EnemyTypeOne,                              //Texture for the Enemy
                        GameManager.level1Speed,                             //Speed of the Enemy
                        GameManager.level1Health                             //Health of the Enemy
                        ));
                }
                else
                {
                    remainingEnemiesToSpawn -= 1;
                    EntityCollections.Instantiate(new Enemy(
                        random.Next(128, (GameManager.screenWidth - 128)),
                        SpriteArt.EnemyTypeTwo,
                        GameManager.level2Speed,                                                  
                        GameManager.level2Health
                        ));
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
