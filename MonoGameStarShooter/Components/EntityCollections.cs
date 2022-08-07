using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameStarShooter
{
    static class EntityCollections
    {
        //From Part 4
        static List<Entity> entities = new List<Entity>();
        static List<Bullet> bullets = new List<Bullet>();
        //The enemy list to add
        public static List<Enemy> enemies = new List<Enemy>();

        //New Variables and Method
        public static Player player;

        public static int score = 0;


        public static bool hasInitialized = false;

        public static void Initialize()
        {
            if (hasInitialized == false)
            {
                player = new Player(SpriteArt.Player, new Vector2(GameManager.screenWidth / 2, GameManager.screenHeight - 200));
                Instantiate(player);
                hasInitialized = true;
            }
        }
        public static void Instantiate(Entity entity)
        {
            entities.Add(entity);
            if (entity is Bullet) bullets.Add(entity as Bullet);
            else if (entity is Enemy) enemies.Add(entity as Enemy);
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(spriteBatch);
            }
        }

        public static void Update()
        {
            //From part 4
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }

            //If any entities have isActive set to false, remove them from the lists
            entities = entities.Where(obj => obj.isActive).ToList();
            bullets = bullets.Where(obj => obj.isActive).ToList();
            enemies = enemies.Where(obj => obj.isActive).ToList();

            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    //Check if any of the enemies or bullets collide with each other
                    if (bullets[j].hitbox.Intersects(enemies[i].hitbox))
                    {
                        //Subtract enemy health by one, remove bullet
                        //enemies[i].health -= 1;
                        enemies[i].OnHit();
                        bullets[j].isActive = false;
                    }
                }
            }



        }

        public static void ClearEntities()
        {

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] is Enemy || entities[i] is Bullet)
                {
                    entities[i].isActive = false;
                }
            }
            enemies.Clear();
            bullets.Clear();
        }

    }
}
