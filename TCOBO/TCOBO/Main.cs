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
        private Camera2D camera;        
        private Enemy enemy;
        //private Inventory inventory;
        

        public Main(Game1 game1)
        {
            this.game1 = game1;
            graphics = game1.GraphicsDevice;
            player = new Player(game1.Content);
            testWorld = new TestWorld(game1.Content);
            camera = new Camera2D(game1.GraphicsDevice.Viewport, player);
            enemy = new Enemy(game1.Content);
            //inventory = new Inventory(game1.Content, new Vector2((int)player.playerPos.X, (int)player.playerPos.Y + 250));             
        }

        public void Hit() // "knocksback" enemy
        {
            Rectangle rec = player.GetPlayerRec();
            Texture2D enemyTex = enemy.tex;
            float weaponTimer = player.GetWeaponTimer();
            if (rec.Intersects(enemy.hitBox) && weaponTimer > 0)
               {
                int dir = player.GetPlayerDirection();
                   if (dir != 0)
                   {
                       if (dir == 1)
                       {
                           enemy.pos.Y -= 100;
                       }
                       if (dir == 2)
                       {
                           enemy.pos.Y += 100;
                       }
                       if (dir == 3)
                       {
                           enemy.pos.X += 100;
                       }
                       if (dir == 4)
                       {
                           enemy.pos.X -= 100;
                       }
                   }
            }
        }
        


        public bool PixelCollision(Enemy enemy, Player player)
        {
            Rectangle playerRec = player.GetPlayerRec();
            Rectangle enemyRec = enemy.hitBox;
            Texture2D tex = enemy.tex;
            Color[] dataA = new Color[tex.Width * tex.Height];
            tex.GetData(dataA);
            Color[] dataB = new Color[player.weaponPH.Width * player.weaponPH.Height];
            player.weaponPH.GetData(dataB);

            int top = Math.Max(playerRec.Top, enemyRec.Top);
            int bottom = Math.Max(playerRec.Bottom, enemyRec.Bottom);
            int left = Math.Max(playerRec.Left, enemyRec.Left);
            int right = Math.Max(playerRec.Right, enemyRec.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color colorA = dataA[(x - playerRec.Left) + (y - playerRec.Top) * playerRec.Width];
                    Color colorB = dataB[(x - playerRec.Left) + (y - playerRec.Top) * playerRec.Width];

                    if (colorA.A != 0 && colorB.A != 0)
                     {
                        return true;
                    }
                }
            }
            return false;
        }


        public void Update(GameTime gameTime)
        {          
            Hit();
            player.Update(gameTime);
            camera.Update(gameTime);
            enemy.UpdateEnemy(gameTime, player.GetPos());
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {          
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,
                camera.transform);           
            testWorld.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            //inventory.Draw(spriteBatch);
            spriteBatch.End();

        }

    }
}
