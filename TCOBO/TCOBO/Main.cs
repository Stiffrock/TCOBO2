using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TCOBO
{
    class Main
    {
        public Game1 game1;
        private TestWorld testWorld;
        private GraphicsDevice graphics;
        public Player player;
        private Attack attack;
        private Camera2D camera;        
        private Enemy enemy;
        private KeyMouseReader krm;
        private Inventory inventory;
        private List<Enemy> enemyList;
        private List<Enemy> inrangeList;
        

        public Main(Game1 game1)
        {
            this.game1 = game1;
            graphics = game1.GraphicsDevice;
            krm = new KeyMouseReader();
            player = new Player(game1.Content);
            testWorld = new TestWorld(game1.Content);
            camera = new Camera2D(game1.GraphicsDevice.Viewport, player);
            enemy = new Enemy(game1.Content);
            enemyList = new List<Enemy>();
            inrangeList = new List<Enemy>();
            enemyList.Add(enemy);
            attack = new Attack(player);
            inventory = new Inventory(game1.Content);
            testWorld.ReadLevel("Map");
            testWorld.SetMap();
        }

        
        
        public void Rotation()
        {
            Vector2 mousePosition;
            mousePosition.X = Mouse.GetState().X;
            mousePosition.Y = Mouse.GetState().Y;
            Vector2 worldPosition = Vector2.Transform(mousePosition, Matrix.Invert(camera.GetTransformation(graphics)));
            Vector2 ms = worldPosition;
            float xDistance = (float)ms.X - player.playerPos.X;
            float yDistance = (float)ms.Y - player.playerPos.Y;
            player.rotation = (float)Math.Atan2(yDistance, xDistance);


            player.aimVector = new Vector2(xDistance, yDistance); // PlayerAimRectangle
            player.aimVector.Normalize();
            double recX = (double)player.aimVector.X * 100;
            double recY = (double)player.aimVector.Y * 100;
            player.attackHitBox = new Rectangle(((int)player.playerPos.X - 40) + (int)recX, ((int)player.playerPos.Y - 40) + (int)recY, 100, 100);
        }


        private void detectEnemy()
        {
            foreach (Enemy enemy in enemyList)
            {
                if (enemy.hitBox.Intersects(player.attackHitBox))
                {
                    inrangeList.Add(enemy);
                }                       
            }
            if (inrangeList.Count() != 0)
            {
                if (!enemy.hitBox.Intersects(player.attackHitBox))
                {
                    inrangeList.Remove(enemy);
                }
                attack.inRange(inrangeList);
            }         
        }


        public void Update(GameTime gameTime)
        {
            krm.Update();
            attack.Update(gameTime);
            player.Update(gameTime);
            detectEnemy();
            Rotation();
            camera.Update(gameTime);
            enemy.UpdateEnemy(gameTime, player.GetPos());
            Console.WriteLine(player.playerPos.X);
        }

        public void Draw(SpriteBatch spriteBatch)
        {                       
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,
                camera.transform);           
            testWorld.Draw(spriteBatch);           
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            inventory.Draw(spriteBatch);
            spriteBatch.End();
        }        
    }
}
