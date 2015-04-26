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
        private Tuple<int, int, int, int, int, int> playerStats;
        private Tuple<float, float, float> effectiveStats;
        private SpriteFont spriteFont;


        public PlayerPanel(ContentManager content, Vector2 pos, SpriteFont spriteFont)
        {
            this.boardTex = content.Load<Texture2D>("infopanel - stats");
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, boardTex.Width, boardTex.Height);
            this.boardPos = pos;
            this.spriteFont = spriteFont;
        

        }

        private void ShowBoard()
        {
            if (KeyMouseReader.KeyPressed(Keys.I))
            {
                showBoard = !showBoard;
            }
        }

        public void Update(Tuple<int, int, int, int, int, int> playerStats, Tuple<float, float, float> effectiveStats)
        {            
            this.playerStats = playerStats;
            this.effectiveStats = effectiveStats;
            ShowBoard();
        }
          

        public void Draw(SpriteBatch spriteBatch)
        {
            float Dmg = effectiveStats.Item1;
            float SpellDmg = effectiveStats.Item2;
            float HP = effectiveStats.Item3;
            int Str = playerStats.Item1;
            int Dex = playerStats.Item2;
            int Vit = playerStats.Item3;
            int Int = playerStats.Item4;
            int Level = playerStats.Item5;
            int newStat = playerStats.Item6;
            if (showBoard)
            {             
                spriteBatch.Draw(boardTex, boardPos, Color.White);
                spriteBatch.DrawString(spriteFont, " Available Stats: " + newStat.ToString(), new Vector2(567, 20), Color.Black);
                spriteBatch.DrawString(spriteFont, " Str   " + "Dex   " + "Vit   " + "Int   " + "Lvl", new Vector2(567, 40), Color.Black);
                spriteBatch.DrawString(spriteFont, " "+Str.ToString() + "    " + Dex.ToString() + "    " + Vit.ToString() + "    " + Int.ToString() + "    " + Level.ToString(), new Vector2(567, 50), Color.Black);
                spriteBatch.DrawString(spriteFont, " Damage:" + Dmg.ToString() + "   Spell Damage:" + SpellDmg.ToString() + "\n" + " Hp:" + HP.ToString()+ "      Attack Speed:" + Dex.ToString(), new Vector2(567, 70), Color.Black);
                           
            }
        }
    }
}
