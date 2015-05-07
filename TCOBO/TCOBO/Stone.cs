using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    class Stone : Item
    {
        private Texture2D stoneTex;
        public Vector2 stonePos;
        //private Texture2D tex;
        //private Vector2 pos;
        public Rectangle hitBox;

        public Stone(ContentManager content) : base(content)
        {
            //this.pos = pos;
            //stoneTex = TextureManager.standardSword;
            stoneTex = TextureManager.standardSword;
            
            this.stonePos = new Vector2(300, 300);
            hitBox = new Rectangle((int)stonePos.X, (int)stonePos.Y, stoneTex.Width, stoneTex.Height);
        }

        public override void Update(GameTime gameTime)
        {
            hitBox = new Rectangle((int)stonePos.X, (int)stonePos.Y, stoneTex.Width, stoneTex.Height);
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
            sb.Draw(stoneTex, stonePos,new Rectangle(0,0,50,50) , Color.White);
        }

    }
}
