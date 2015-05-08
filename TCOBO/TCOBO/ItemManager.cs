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
        //public Stone stone;
        private Sword sword;

        //private Sword sword;
        private Item leaf;
        private Inventory inventory;
        private GraphicsDevice grahpics;
       // private PlayerPanel board;
        private SpriteFont sf;
        private bool PickedUp;

        private bool Inventored;

        private bool Showstats;
        private bool IsInventoryshown;
        public List<Item> ItemList = new List<Item>();
        public List<Item> InventoryList = new List<Item>();

        public ItemManager(Game1 game1)
        {
            this.game1 = game1;
            grahpics = game1.GraphicsDevice;
            //stone = new Stone(game1.Content);
            inventory = new Inventory(game1.Content, new Vector2(200, 200));
            sword = new Sword(game1.Content);
            inventory = new Inventory(game1.Content, new Vector2(200, 200));
            //leaf = new Item(game1.Content, new Vector2(400, 200));
           
          //  board = new PlayerPanel(game1.Content, new Vector2(550, 0));


            this.sf = game1.Content.Load<SpriteFont>("SpriteFont1");

            ItemList.Add(sword);
            PickedUp = false;

            Showstats = false;
            IsInventoryshown = false;
        }

        public void Update(GameTime gameTime)
        {
            sword.Update(gameTime);
            inventory.Update();
            PickItem();
            MoveItem(Mouse.GetState().X, Mouse.GetState().Y);
            ShowStats();
            //IsInventoryShown();
            //EquipItem();
            IsInventoryShown();
            HandleInventory();
           // EquipItem();

        }

        public void PickItem()
        {

            foreach (Item item in ItemList)
            {
                if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && KeyMouseReader.LeftClick() == true)
                {
                    InventoryList.Add(item);
                    ItemList.Remove(item);
                    item.pos.X = 550;
                    item.pos.Y = 130;
                    break;
                }
              /*  if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    PickedUp = false;
                }
                if (PickedUp == true && inventory.hitBox.Contains(sword.hitBox))
                {                
                    InventoryList.Add(item);
                    ItemList.Remove(item);
                    break;
                }*/
            }
            //if (stone.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released && inventory.hitBox.Contains(stone.hitBox))
            //{
            //    Backpacked = true;
            //}
            //if (!inventory.hitBox.Contains(stone.hitBox))
            //{
            //    Backpacked = false;
            //}

            //if (!inventory.hitBox.Contains(stone.hitBox) && !IsInventoryshown)
            //{
            //    DrawStone = false;
            //}
            //else
            //{
            //    DrawStone = true;
            //}

                /*  if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released)
                  {
                      PickedUp = false;
                  }
                  if (PickedUp == true && inventory.hitBox.Contains(sword.hitBox))
                  {                
                      InventoryList.Add(item);
                      ItemList.Remove(item);
                      break;
                  }*/
            
        }

        public void HandleInventory()
        {
            foreach (Item item in InventoryList)
            {
                if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    PickedUp = true;
                }
                if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    PickedUp = false;
                }
                //if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released && inventory.hitBox.Contains(sword.hitBox))
                //{
                //    Inventored = true;
                //}               
            }

        

        //public void EquipItem()
        //{
        //    if (Mouse.GetState().RightButton == ButtonState.Pressed && inventory.hitBox.Contains(stone.hitBox))
        //    {
        //        stone.Equiped = !stone.Equiped;
        //    }
        //}

                 
            

            foreach (InventoryTile tile in inventory.grid)
            {
                foreach (Item item in InventoryList)
                {
                    if (item.hitBox.Intersects(tile.texture_rect) && KeyMouseReader.RightClick())
                    {
                        item.pos = tile.pos;
                        PickedUp = false;
                    }
                }
            }
        }

        public void MoveItem(int x, int y)
        {

            foreach (Item item in InventoryList)
            {
                    if (PickedUp == true && inventory.hitBox.Contains(item.hitBox))
                    {
                        sword.pos.X = ((Mouse.GetState().X)/50)*50;
                        sword.pos.Y = ((Mouse.GetState().Y +15) / 50) * 50;
                        sword.hitBox.X = ((Mouse.GetState().X) / 50) * 50;
                        sword.hitBox.Y = ((Mouse.GetState().Y +15) / 50) * 50;
                    }
                    else if (PickedUp == true)
                    {
                        sword.pos.X = (Mouse.GetState().X - 25);
                        sword.pos.Y = (Mouse.GetState().Y - 25);
                        sword.hitBox.X = (Mouse.GetState().X - 25);
                        sword.hitBox.Y = (Mouse.GetState().Y - 25);
                    }
            }
        }


        public void ShowStats()
        {
            if (sword.hitBox.Contains(Mouse.GetState().X,Mouse.GetState().Y))
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
          //  sb.Begin();
            inventory.Draw(sb);

            //if (IsInventoryshown || !IsInventoryshown && !inventory.hitBox.Contains(stone.hitBox))
            //foreach (Item item in ItemList)
            foreach (Item item in ItemList)

            {
                item.Draw(sb); 
            }

            if (Showstats && IsInventoryshown)
            {
                sb.DrawString(sf, "This is a sword.", new Vector2(575, 350), Color.Black);
                sb.DrawString(sf, "Dmg + 3  Str + 3", new Vector2(575, 375), Color.Black);

            }
            sb.End();
            sb.Begin();
            foreach (Item item in InventoryList)
            {
                if (IsInventoryshown || !IsInventoryshown && !inventory.hitBox.Contains(item.hitBox))
                {
                    item.Draw(sb);
                }

            }
            sb.End();
          
  
     

        }
    }
}
