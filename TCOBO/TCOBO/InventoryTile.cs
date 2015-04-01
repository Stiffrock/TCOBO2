using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    class InventoryTile
    {
        Vector2 pos;
        Rectangle texture_rect;
        //public bool isCollided = false;
        public InventoryTile(int x, int y, int tex_x, int tex_y)
        {
            pos = new Vector2(x, y);
            texture_rect = new Rectangle(200, 200, 50, 50);
        }
        public void Draw(Texture2D texture, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }

    }
}
