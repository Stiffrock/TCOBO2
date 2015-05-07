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

<<<<<<< HEAD:TCOBO/TCOBO/Stone.cs
        public bool Equiped;

        public Stone(ContentManager content) : base(content)
=======
        public Sword(ContentManager content) : base(content)
>>>>>>> origin/Stoffe:TCOBO/TCOBO/Sword.cs
        {
<<<<<<< HEAD
            this.itemTex = TextureManager.standardSword;
            this.pos = new Vector2(300, 300);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, itemTex.Width, itemTex.Height);
=======
            swordTex = TextureManager.standardSword;
            
<<<<<<< HEAD:TCOBO/TCOBO/Stone.cs
            this.stonePos = new Vector2(300, 300);
            hitBox = new Rectangle((int)stonePos.X, (int)stonePos.Y, stoneTex.Width, stoneTex.Height);

            Equiped = false;
=======
            this.pos = new Vector2(300, 300);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, swordTex.Width, swordTex.Height);
>>>>>>> origin/Stoffe:TCOBO/TCOBO/Sword.cs
>>>>>>> origin/Stoffe
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
<<<<<<< HEAD
            sb.Draw(itemTex, pos,new Rectangle(0,0,50,50) , Color.White);
=======
<<<<<<< HEAD:TCOBO/TCOBO/Stone.cs
            if (!Equiped)
            {
                sb.Draw(stoneTex, stonePos, Color.White);
            }
            else
            {
                sb.Draw(stoneTex, stonePos, Color.Red);
            }
=======
            sb.Draw(swordTex, pos,new Rectangle(0,0,50,50) , Color.White);
>>>>>>> origin/Stoffe:TCOBO/TCOBO/Sword.cs
>>>>>>> origin/Stoffe
        }

    }
}
