using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    class Sword : Item
    {
        private Texture2D swordTex;

        //private Texture2D tex;
        //private Vector2 pos;
       



        public Sword(ContentManager content) : base(content)
        {
            this.itemTex = TextureManager.standardSword;
            this.pos = new Vector2(300, 300);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, itemTex.Width, itemTex.Height);
            
        }

        public override void Update(GameTime gameTime)
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, itemTex.Width, itemTex.Height);
        }

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
        //    stonePos.X = x;
        //    stonePos.Y = y;

        //    hitBox.X = x;
        //    hitBox.Y = y;
        //}

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(itemTex, pos,new Rectangle(0,0,50,50) , Color.White);

        }

    }
}
