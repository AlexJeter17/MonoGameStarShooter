using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MonoGameStarShooter
{
    static class EntityCollections
    {
        
        //All Entities
        static List<Entity> entities = new List<Entity>();

        //Entity specific lists and Player 
        public static Player player1;
        public static List<Enemy> enemies = new List<Enemy>();
        static List<Bullet> bullets = new List<Bullet>();
        
        //Score counter
        public static int score = 0;
        

        static bool hasInitalized = false;
        static Random random = new Random();
        //Function to initialize player, only runs once.
        public static void Initialize()
        {
            if (hasInitalized == false)
            {
                player1 = new Player(new Vector2(GameManager.screenWidth / 2, GameManager.screenHeight - 200), SpriteArt.Player);
                Instantiate(player1);
                hasInitalized = true;
            }
        }
        public static void Update()
        {
            //Update all entities on screen
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }
            
            //If any entities have isActive set to false, remove them from the lists
            entities = entities.Where(obj => obj.isActive).ToList();
            enemies = enemies.Where(obj => obj.isActive).ToList();
            bullets = bullets.Where(obj => obj.isActive).ToList();
            



            //Handle Collisions between enemies and bullets
            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    //Check if any of the enemies or bullets collide wiwth each other
                    if (bullets[j].hitbox.Intersects(enemies[i].hitbox))
                    {
                        //Collision logic here, if enemies are hit, call OnHit and remove bullet
                        enemies[i].OnHit();
                        bullets[j].isActive = false;
                    }
                }
            }
        }
        //Draw all entities in the list
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(spriteBatch);
            }
        }
        //Create the entity on screen and add them to an appropriate list
        public static void Instantiate(Entity entity)
        {
            entities.Add(entity);
            if (entity is Enemy) enemies.Add(entity as Enemy);
            else if (entity is Bullet) bullets.Add(entity as Bullet);
        }
    }
}
