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
    class Attack : Abilities
    {
        private Player player;
        private List<Enemy> inrangeList;

        public Attack(Player player)
        {
  
            this.player = player;
            
        }

        public void inRange(List<Enemy> enemyList)
        {
            if (KeyMouseReader.LeftClick() == true)
            {
                foreach (Enemy enemy in enemyList) // TODO Fixxa så att fienden får en knockback som är rakt ut från player.
                {
             
                    float deltaX = enemy.pos.X - player.playerPos.X;
                    float deltaY = enemy.pos.Y - player.playerPos.Y;
                    Vector2 deltaPos = new Vector2(deltaX, deltaY);
                   // deltaPos.Normalize();                                   
                    enemy.pos.X = deltaPos.X;
                    enemy.pos.Y = deltaPos.Y;
                }
            }
        }


        public override void Draw()
        {
           
           
        }
        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
