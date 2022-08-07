using System;


namespace MonoGameStarShooter
{
    static class WaveManager
    {
        public static int wave = 0;

        static int spawnRate = 50;
        static int spawnDelay = 0;
        static int maxNumEnemies = 0;
        static int remainingEnemiesToSpawn = 0;

        static Random random = new Random();

        public static void InitializeWave()
        {
            if (EntityCollections.enemies.Count == 0 && remainingEnemiesToSpawn == 0)
            {
                wave += 1;
                remainingEnemiesToSpawn += maxNumEnemies;
                maxNumEnemies += 2;
            }
        }
        public static void Reset()
        {
            wave = 0;
            remainingEnemiesToSpawn = 0;
            maxNumEnemies = 2;
        }

        public static void Update()
        {
            //The method that you created earlier
            InitializeWave();
            //Spawning logic
            //First check if the spawn delay is 0 and 
            //that there are no enemies left to spawn form current wave
            if (spawnDelay <= 0 && remainingEnemiesToSpawn != 0)
            {
                //Every even enemy is a level 1 enemy, every odd enemy is a level 2 enemy
                if (remainingEnemiesToSpawn % 2 == 0)
                {
                    //Subtract 1 from remaining enemies, then spawn the enemy object using EntityManager
                    remainingEnemiesToSpawn -= 1;

                    //Spawn enemy using the Instantiate method from EntityManager
                    EntityCollections.Instantiate(new Enemy(
                        random.Next(128, (GameManager.screenWidth - 128)),    //Position to Spawn Enemy
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
                //Reset the spawn delay to the spawn rate.
                spawnDelay = spawnRate;

            }
            //If the spawn delay is not 0, subtract 1 from it.
            if (spawnDelay > 0) spawnDelay--;
        }
    }
}
