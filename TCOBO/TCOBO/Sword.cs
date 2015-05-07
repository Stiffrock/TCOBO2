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
       


        public bool Equiped;

        public Sword(ContentManager content) : base(content)
<<<<<<< HEAD

            this.itemTex = TextureManager.standardSword;
            this.pos = new Vector2(300, 300);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, itemTex.Width, itemTex.Height);

            swordTex = TextureManager.standardSword;

            Equiped = false;
=======
        {
            swordTex = TextureManager.standardSword;
            
            this.pos = new Vector2(300, 300);
>>>>>>> parent of 1aa870d... Snap to grid
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, swordTex.Width, swordTex.Height);
        }

        public override void Update(GameTime gameTime)
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, swordTex.Width, swordTex.Height);
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
<<<<<<< HEAD
            sb.Draw(itemTex, pos,new Rectangle(0,0,50,50) , Color.White);

            sb.Draw(swordTex, pos,new Rectangle(0,0,50,50) , Color.White);

=======
            sb.Draw(swordTex, pos,new Rectangle(0,0,50,50) , Color.White);
>>>>>>> parent of 1aa870d... Snap to grid
        }

    }
}
