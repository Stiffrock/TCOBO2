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
        private Sword sword;
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
            sword = new Sword(game1.Content);
            inventory = new Inventory(game1.Content, new Vector2(200, 200));
            //leaf = new Item(game1.Content, new Vector2(400, 200));
           
          //  board = new PlayerPanel(game1.Content, new Vector2(550, 0));

            this.sf = game1.Content.Load<SpriteFont>("SpriteFont1");

            ItemList.Add(sword);
            PickedUp = false;
            Inventored = false;
            Showstats = false;
            IsInventoryshown = false;
        }

        public void Update(GameTime gameTime)
        {
            sword.Update(gameTime);
            inventory.Update();
            PickItem();
            MoveItem();
            ShowStats();
            IsInventoryShown();
          //  board.Update();
        }

        public void PickItem()
        {
            foreach (Item item in ItemList)
            {
                
                if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    PickedUp = true;
                }
                if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    PickedUp = false;
                }
                if (item.hitBox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released && inventory.hitBox.Contains(sword.hitBox))
                {
                    Inventored = true;
                }
                
            }


           /* if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                Inventored = false;
            }*/
            
        }

        public void MoveItem()
        {
            if (PickedUp == true)
            {
                sword.pos.X = Mouse.GetState().X -25;
                sword.pos.Y = Mouse.GetState().Y -25;
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
            sb.Begin();
            inventory.Draw(sb);
            
            if (!Inventored)
            {
                sword.Draw(sb);
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
