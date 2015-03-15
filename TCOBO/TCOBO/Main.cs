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

        public Main(Game1 game1)
        {
            
            this.game1 = game1;
            graphics = game1.GraphicsDevice;
            player = new Player(game1.Content);
            testWorld = new TestWorld(game1.Content);
            camera = new Camera2D(game1.GraphicsDevice.Viewport, player);
        }


        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            camera.Update(gameTime);
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,
                camera.transform);
            testWorld.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
        }

    }
}
