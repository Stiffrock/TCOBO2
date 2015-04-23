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
        private Stone stone;
        private Item leaf;
        private Inventory inventory;
        private GraphicsDevice grahpics;
        private PlayerPanel board;

        private bool PickedUp;
        private bool Inventored;

        public ItemManager(Game1 game1)
        {
            this.game1 = game1;
            grahpics = game1.GraphicsDevice;
            stone = new Stone(game1.Content);
            //leaf = new Item(game1.Content, new Vector2(400, 200));
            inventory = new Inventory(game1.Content, new Vector2(200, 200));
            board = new PlayerPanel(game1.Content, new Vector2(550, 0));


            PickedUp = false;
            Inventored = false;
        }

        public void Update(GameTime gameTime)
        {
            stone.Update(gameTime);
            inventory.Update();
            PickItem();
            MoveItem();
            board.Update();
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
            if (stone.hitBox.Contains(Mouse.GetState().X,Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Released && inventory.hitBox.Contains(stone.hitBox))
            {
                Inventored = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                Inventored = false;
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

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            board.Draw(sb);
            inventory.Draw(sb);

            if (!Inventored)
            {
                stone.Draw(sb);
            }
            sb.End();

        }
    }
}
