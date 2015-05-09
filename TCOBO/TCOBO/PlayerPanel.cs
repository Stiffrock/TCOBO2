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
        public Rectangle StrButton, DexButton, VitButton, IntButton;
        private Tuple<int, int, int, int, int, int> playerStats;
        private Tuple<float, float, float> effectiveStats;
        public SpriteFont spriteFont;
        public  SpriteFont MOStatFont;
        public Color statColor;
        public int Str, Dex, Vit, Int;
        public bool showStatButton = false;
        public SpriteFont currentStrFont, currentDexFont, currentVitFont, currentIntFont;


        public PlayerPanel(ContentManager content, Vector2 pos, SpriteFont spriteFont)
        {
            this.boardTex = content.Load<Texture2D>("infopanel - stats");
            MOStatFont = content.Load<SpriteFont>("MOStatFont");
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, boardTex.Width, boardTex.Height);
            this.boardPos = pos;
            this.spriteFont = spriteFont;
            currentStrFont = spriteFont;
            currentDexFont = spriteFont;
            currentVitFont = spriteFont;
            currentIntFont = spriteFont;
            statColor = Color.Black;
            StrButton = new Rectangle(573, 38, 25, 25);
            DexButton = new Rectangle(615, 38, 25, 25);
            VitButton = new Rectangle(658, 38, 25, 25);
            IntButton = new Rectangle(700, 38, 25, 25);            
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
            Str = playerStats.Item1;
            Dex = playerStats.Item2;
            Vit = playerStats.Item3;
            Int = playerStats.Item4;
            int Level = playerStats.Item5;
            int newStat = playerStats.Item6;

            if (showBoard)
            {
                
                spriteBatch.Draw(boardTex, boardPos, Color.White);
                spriteBatch.DrawString(spriteFont, " Available Stats: " + newStat.ToString(), new Vector2(567, 20), Color.Black);

               // spriteBatch.DrawString(currentFont, " Str   " + "Dex   " + "Vit   " + "Int   " + "Lvl", new Vector2(567, 40), statColor);

                spriteBatch.DrawString(currentStrFont, "Str", new Vector2(573 ,36), Color.Black);
                spriteBatch.DrawString(currentDexFont, "Dex", new Vector2(615, 36), Color.Black);
                spriteBatch.DrawString(currentVitFont, "Vit", new Vector2(655, 36), Color.Black);
                spriteBatch.DrawString(currentIntFont, "Int", new Vector2(698, 36), Color.Black);
                spriteBatch.DrawString(spriteFont, "Level", new Vector2(735, 36), Color.Black);



                spriteBatch.DrawString(spriteFont, " "+Str.ToString() + "    " + Dex.ToString() + "    " + Vit.ToString() + "    " + Int.ToString() + "    " + Level.ToString(), new Vector2(567, 50), statColor);               
                spriteBatch.DrawString(spriteFont, " Damage:" + Dmg.ToString() + "   Spell Damage:" + SpellDmg.ToString() + "\n" + " Hp:" + HP.ToString()+ "      Speed Bonus:" + Dex.ToString(), new Vector2(567, 70), Color.Black);
                if (showStatButton)
                {
                   // currentFont = MOStatFont;
                    spriteBatch.Draw(TextureManager.statBox, new Vector2(572, 48), new Rectangle(6, 6, 23, 23), Color.White);
                    spriteBatch.Draw(TextureManager.statBox, new Vector2(614, 48), new Rectangle(6, 6, 23, 23), Color.White);
                    spriteBatch.Draw(TextureManager.statBox, new Vector2(656, 48), new Rectangle(6, 6, 23, 23), Color.Gold);
                    spriteBatch.Draw(TextureManager.statBox, new Vector2(696, 48), new Rectangle(6, 6, 23, 23), Color.Gold);  
                    
                }
                else
                {
                    //currentFont = spriteFont;
                }
        
            }



            
        }
    }
}
