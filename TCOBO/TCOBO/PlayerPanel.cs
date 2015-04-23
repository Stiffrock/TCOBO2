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
    class PlayerPanel
    {
        private Texture2D boardTex;
        private Vector2 boardPos;
        private Rectangle hitBox;

        private bool showBoard = false;

        public PlayerPanel(ContentManager content, Vector2 pos)
        {
            this.boardTex = content.Load<Texture2D>("infopanel - stats");
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, boardTex.Width, boardTex.Height);
            this.boardPos = pos;
        }

        private void ShowBoard()
        {
            if (KeyMouseReader.KeyPressed(Keys.I))
            {
                showBoard = !showBoard;
            }
        }

        public void Update()
        {
            ShowBoard();
        }
          

        public void Draw(SpriteBatch spriteBatch)
        {
            if (showBoard)
            {
                spriteBatch.Draw(boardTex, boardPos, Color.White);
            }
        }
    }
}
