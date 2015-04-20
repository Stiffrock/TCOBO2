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

        public void inRange(Enemy enemy)
        {

            if (KeyMouseReader.LeftClick() == true)
            {
                double deltaX = player.playerPos.X - enemy.pos.X;
                double deltaY = player.playerPos.Y - enemy.pos.Y;
                double deltaXY = Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2);
                double distanceVector = Math.Sqrt(deltaXY); // Längden
                //  Vector2 deltaPos = new Vector2(deltaX, deltaY);
                double radians = Math.Atan2(deltaY, deltaX);
                double angle = (180 / Math.PI) * radians; // Vinkel              
                float newPosX = (float)Math.Cos(angle) * (float)distanceVector;
                float newPosY = (float)Math.Sin(angle) * (float)distanceVector;
                enemy.pos.X += newPosX;
                enemy.pos.Y += newPosY;

                write = (float)angle;
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
