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

        public bool Equiped;

        public Stone(ContentManager content) : base(content)
        {
            //this.pos = pos;
            stoneTex = content.Load<Texture2D>("stone");
            
            this.stonePos = new Vector2(300, 300);
            hitBox = new Rectangle((int)stonePos.X, (int)stonePos.Y, stoneTex.Width, stoneTex.Height);

            Equiped = false;
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
            if (!Equiped)
            {
                sb.Draw(stoneTex, stonePos, Color.White);
            }
            else
            {
                sb.Draw(stoneTex, stonePos, Color.Red);
            }
        }

    }
}
