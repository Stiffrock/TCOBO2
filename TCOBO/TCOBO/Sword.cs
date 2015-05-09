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
        public Color swordColor;

        public Sword(ContentManager content)
            : base(content)
        {
            this.itemTex = TextureManager.goldenSword;
            itemColor = Color.Gold;
            swordColor = Color.LightBlue;
            this.pos = new Vector2(300, 300);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, itemTex.Width, itemTex.Height);


        }

        public override void Update(GameTime gameTime)
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, itemTex.Width, itemTex.Height);
        }


        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(itemTex, pos,new Rectangle(0,0,50,50) , Color.White);

        }

    }
}
