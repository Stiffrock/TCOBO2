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
    class ItemManager
    {
        //private Texture2D tex;
        //private Vector2 pos;
        private Game1 game1;
        public Stone stone;
        private Item leaf;
        private Inventory inventory;
        private GraphicsDevice grahpics;
       // private PlayerPanel board;
        private SpriteFont sf;

        private bool PickedUp;
        private bool DrawStone;
        private bool Backpacked;
        private bool Showstats;
        private bool IsInventoryshown;

        public ItemManager(Game1 game1)
        {
            this.game1 = game1;
            grahpics = game1.GraphicsDevice;
            stone = new Stone(game1.Content);
            inventory = new Inventory(game1.Content, new Vector2(200, 200));

            this.sf = game1.Content.Load<SpriteFont>("SpriteFont1");


            PickedUp = false;
            DrawStone = true;
            Showstats = false;
            IsInventoryshown = false;
            Backpacked = false;
        }

        public void Update(GameTime gameTime)
        {
            stone.Update(gameTime);
            inventory.Update();
            PickItem();
            MoveItem();
            ShowStats();
            IsInventoryShown();
            EquipItem();
        }

        public void PickItem()
        {
            if (stone.hitBox.Contains(Mouse.GetState().X,Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                PickedUp = true;
                
            }
            if (stone.hitBox.Contains(Mouse.GetState().X,Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                PickedUp = false;
            }
            if (stone.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released && inventory.hitBox.Contains(stone.hitBox))
            {
                Backpacked = true;
            }
            if (!inventory.hitBox.Contains(stone.hitBox))
            {
                Backpacked = false;
            }

            if (!inventory.hitBox.Contains(stone.hitBox) && !IsInventoryshown)
            {
                DrawStone = false;
            }
            else
            {
                DrawStone = true;
            }

            
        }

        public void EquipItem()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed && inventory.hitBox.Contains(stone.hitBox))
            {
                stone.Equiped = !stone.Equiped;
            }
        }

        public void MoveItem()
        {
            if (PickedUp == true)
            {
                stone.stonePos.X = Mouse.GetState().X -25;
                stone.stonePos.Y = Mouse.GetState().Y -25;
            }
        }

        public void ShowStats()
        {
            if (stone.hitBox.Contains(Mouse.GetState().X,Mouse.GetState().Y))
            {
                Showstats = true;
            }
            else
            {
                Showstats = false;
            }
        }

        private void IsInventoryShown()
        {
            if (KeyMouseReader.KeyPressed(Keys.I))
            {
                IsInventoryshown = !IsInventoryshown;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            inventory.Draw(sb);

            if (IsInventoryshown || !IsInventoryshown && !inventory.hitBox.Contains(stone.hitBox))
            {
                stone.Draw(sb);
            }

            if (Showstats && IsInventoryshown)
            {
                sb.DrawString(sf, "This is a stone.", new Vector2(575, 350), Color.Black);
                sb.DrawString(sf, "You can't do shit with it.", new Vector2(575, 375), Color.Black);

            }
            sb.End();

        }
    }
}
