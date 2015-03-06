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
      

        public Main(Game1 game1)
        {
            
            this.game1 = game1;
            graphics = game1.GraphicsDevice;
            testWorld = new TestWorld(game1.Content);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            testWorld.Draw(spriteBatch);
        }
    }
}
