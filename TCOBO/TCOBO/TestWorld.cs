using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TCOBO
{
    class TestWorld
    {

        private ContentManager content;
        private Texture2D grassTile;
        protected Array tileArray;
        protected Vector2 pos;

        public TestWorld(ContentManager content)
        {
            this.content = content;
            tileArray = new Array[12,13];
            grassTile = content.Load<Texture2D>("grassTile");
        }

        public Vector2 GetTilePos()
        {
            return pos;
        }

        public void createTestWorld(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tileArray.GetLength(0); i++)
			{
			    for (int j = 0; j < tileArray.GetLength(1); j++)
			    {
                    pos.X = j * 64; //64 är ett tal.
                    pos.Y = i * 64;
                    spriteBatch.Draw(grassTile, pos, Color.White);
			    }
            }			
        }
           
        public void Draw(SpriteBatch spriteBatch)
        {
            createTestWorld(spriteBatch);
        }
    }
}
