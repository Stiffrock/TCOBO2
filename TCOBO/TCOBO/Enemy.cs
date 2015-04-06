using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCOBO
{
    class Enemy : MovableObject
    {
        public Texture2D tex;
        public Vector2 pos;
        Rectangle srcRec;
        private ContentManager content;
        protected double frameTimer, frameInterval;
        protected int frame;
        protected SpriteEffects Fx;
        protected float rotation;
        public Rectangle hitBox;
        public Vector2 speed;

        public Enemy(ContentManager content)
        {
            this.content = content;
            pos = new Vector2(300, 300);
            srcRec = new Rectangle(0, 0, 50, 57);
            tex = content.Load<Texture2D>("Bird");
            this.speed = new Vector2(0, 0); 
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 50, 57);
            frameTimer = 100;
            frameInterval = 100;
            Fx = SpriteEffects.None;
        }
        public void HuntPlayer(Vector2 playerPos)
        {

            if (playerPos.X > pos.X && playerPos.Y > pos.Y)
            {
                speed.X = 1;
            }
            else
            {
                speed.X = 0;
            }
            if (playerPos.Y > pos.Y && speed.X == 0)
            {
                speed.Y = 1;
            }
            else
            {
                speed.Y = 0;
            }
            if (playerPos.X < pos.X && playerPos.Y < pos.Y)
            {
                speed.X = -1;
            }
            if (playerPos.Y < pos.Y && speed.X == 0)
            {
                speed.Y = -1;
            }
        }

        public void UpdateEnemy(GameTime gameTime, Vector2 playerPos)
        {
            Fx = SpriteEffects.None;
            HuntPlayer(playerPos);
            rotation = MathHelper.ToRadians(0);
            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            pos += speed;
            hitBox.X = (int)pos.X;
            hitBox.Y = (int)pos.Y;

            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                srcRec.X = (frame % 4) * 50;
            }

            if (speed.X < 0)
            {
                Fx = SpriteEffects.FlipHorizontally;
                rotation = MathHelper.ToRadians(0);
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, srcRec, Color.White, rotation, new Vector2(0, 25), 1, Fx, 1);
        }
    }
}
