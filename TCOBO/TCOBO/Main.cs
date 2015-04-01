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
        private Enemy enemyone;
        

        public Main(Game1 game1)
        {
            this.game1 = game1;
            graphics = game1.GraphicsDevice;
            player = new Player(game1.Content);
            testWorld = new TestWorld(game1.Content);
            camera = new Camera2D(game1.GraphicsDevice.Viewport, player);
            enemyone = new Enemy(game1.Content);
             
        }

        public void Hit()
        {
        }


        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            camera.Update(gameTime);
            HuntTheNoobPlayer();
            enemyone.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,
                camera.transform);
            testWorld.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemyone.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.End();
        }

        public void HuntTheNoobPlayer()
        {

                if (player.playerPos.X > enemyone.pos.X && player.playerPos.Y > enemyone.pos.Y)
                {
                       enemyone.speed.X = 1;
                }
                else
                {
                    enemyone.speed.X = 0;
                }
                if (player.playerPos.Y > enemyone.pos.Y && enemyone.speed.X == 0)
                {
                    enemyone.speed.Y = 1;
                }
                else
                {
                    enemyone.speed.Y = 0;
                }
                if (player.playerPos.X < enemyone.pos.X && player.playerPos.Y < enemyone.pos.Y)
                {
                    enemyone.speed.X = -1;
                }
                if (player.playerPos.Y < enemyone.pos.Y && enemyone.speed.X == 0)
                {
                    enemyone.speed.Y = -1;
                }
        }
    }
}
