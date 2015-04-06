using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    class Inventory
    {

        Texture2D inventoryTex;

        InventoryTile[,] grid;
        const int num_rows = 5;
        const int num_cols = 5;

        public Inventory(ContentManager content)
        {
            inventoryTex = content.Load<Texture2D>("mah_logo");

            CreateGameGrid();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < num_cols; j++)
                {
                     if (Keyboard.GetState().IsKeyDown(Keys.I))
	                {
                        grid[i, j].Draw(inventoryTex, spritebatch);		 
	                }
                }
            }
        }

        void CreateGameGrid()
        {
            grid = new InventoryTile[num_rows, num_cols];

            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < num_cols; j++)
                {
                    grid[i, j] = new InventoryTile(500 * 50 + 100, 500 * 50 + 200, 0, 0);
                }
            }
        }
    }
}
