using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    class ItemManager
    {
        //private Texture2D tex;
        //private Vector2 pos;
        private Game1 game1;
        private Stone stone;
        private GraphicsDevice grahpics;

        public ItemManager(Game1 game1)
        {
            this.game1 = game1;
            grahpics = game1.GraphicsDevice;
            stone = new Stone(game1.Content);
        }

        public void Update(GameTime gameTime)
        {
            stone.Update(gameTime);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            stone.Draw(sb);
            sb.End();
        }
    }
}
