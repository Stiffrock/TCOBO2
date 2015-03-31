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
        private Game1 game1;
        private TestWorld testWorld;
        private GraphicsDevice graphics;
        private Player player;
        private Camera2D camera;
        private Enemy enemy;
        private Inventory inventory;
        

        public Main(Game1 game1)
        {
            this.game1 = game1;
            graphics = game1.GraphicsDevice;
            player = new Player(game1.Content);
            testWorld = new TestWorld(game1.Content);
            camera = new Camera2D(game1.GraphicsDevice.Viewport, player);
            enemy = new Enemy(game1.Content);
            inventory = new Inventory(game1.Content);
             
        }

        public void Hit()
        {
            Rectangle rec = player.GetSwordRec();
            if (rec.Intersects(enemy.hitBox))
            {
                
            }
        }


        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            camera.Update(gameTime);
            
            enemy.Update(gameTime);

            //if (player.pos.X - enemyone.pos.X < 200 || enemyone.pos.X - player.pos.X > 200)
            //{
                HuntTheNoobPlayer();
            //}
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

        public void HuntTheNoobPlayer()
        {

                if (player.playerPos.X > enemy.pos.X && player.playerPos.Y > enemy.pos.Y)
                {
                       enemy.speed.X = 1;
                }
                else
                {
                    enemy.speed.X = 0;
                }
                if (player.playerPos.Y > enemy.pos.Y && enemy.speed.X == 0)
                {
                    enemy.speed.Y = 1;
                }
                else
                {
                    enemy.speed.Y = 0;
                }
                if (player.playerPos.X < enemy.pos.X && player.playerPos.Y < enemy.pos.Y)
                {
                    enemy.speed.X = -1;
                }
                if (player.playerPos.Y < enemy.pos.Y && enemy.speed.X == 0)
                {
                    enemy.speed.Y = -1;
                }
        }
    }
}
