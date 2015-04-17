using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    abstract class Item
    {
        //private Vector2 itemPos;
        //private Texture2D itemTex;
        //private Rectangle hitBox;
        public Item(ContentManager content)
        {
            //this.itemPos = itemPos;
            //this.itemTex = itemTex;
            //this.hitBox = new Rectangle(0, 0, 50, 50);
        }


        //public void Update(GameTime gameTime)
        //{
        //hitBox = new Rectangle(0, 0, itemTex.Width, itemTex.Height);
        //}
        public virtual void Update(GameTime gameTime) { }

        //public bool PickUp(int x, int y)
        //{
        //    if (hitBox.Contains(x, y))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public void Move(int x, int y)
        //{
        //    itemPos.X = x;
        //    itemPos.Y = y;

        //    hitBox.X = x;
        //    hitBox.Y = y;
        //}


        public virtual void Draw(SpriteBatch sb) { }
    }
}
