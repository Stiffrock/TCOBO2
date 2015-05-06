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
        private float write;

        public Attack(Player player)
        {
  
            this.player = player;
            
        }

        public void inRange(Enemy enemy, Vector2 aimVector)
        {

            if (KeyMouseReader.LeftClick() == true)
            {
                double deltaX = enemy.pos.X - player.playerPos.X;
                double deltaY =  enemy.pos.Y - player.playerPos.Y;
                double deltaXY = Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2);
                double distance = Math.Sqrt(deltaXY); // Längden         
                double radians = Math.Atan2((float)aimVector.Y, (float)aimVector.X);             
                double distanceX = Math.Cos(radians) * distance;
                double distanceY = Math.Sin(radians) * distance;
                write = (float)distance;

                


                if (distance <= 190 && distance > 150)
                {                    
                enemy.pos.X += (float)distanceX / 4;
                enemy.pos.Y += (float)distanceY / 4;
                }
                if (distance <= 150 && distance > 100)
                {
                    enemy.pos.X += (float)distanceX / 2;
                    enemy.pos.Y += (float)distanceY / 2;
                }

                if (distance < 100 && distance > 80)
                {
                    enemy.pos.X += (float)distanceX;
                    enemy.pos.Y += (float)distanceY; 
                }
                if (distance < 80 && distance > 0)
                {
                    enemy.pos.X += (float)distanceX * 2;
                    enemy.pos.Y += (float)distanceY * 2;
                }
            }
        }


        public override void Draw()
        {
           
           
        }
        public override void Update(GameTime gameTime)
        {
            Console.WriteLine(write);
        }
    }
}
