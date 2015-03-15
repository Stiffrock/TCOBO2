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
    class Player
    {
        private Texture2D playerTex;
        private Vector2 pos;
        private ContentManager content;
        private Rectangle srcRec;
        private float deltaTime;
        private int animaCount = 1, speed = 2;
        
        private enum Direction {Up, Down, Left, Right, Default}
        private Direction CurrentDirection;

        public Vector2 GetPos()
        {
            return pos;
        }
        public Texture2D GetPlayerTex()
        {
            return playerTex;
        }
        public int GetSpeed()
        {
            return speed;
        }       

        public Player(ContentManager content)
        {
            this.content = content;
            pos = new Vector2(500, 500);
            srcRec = new Rectangle(0, 0, 100, 100);
            playerTex = content.Load<Texture2D>("playerSpritePH");
        }

        public void handleAnimation(GameTime gameTime)
        {
            deltaTime += gameTime.ElapsedGameTime.Milliseconds;
            if (CurrentDirection == Direction.Left)
            {
                if (deltaTime >= 150)
                {
                    deltaTime = 0;
                    srcRec.Y = 0;
                    srcRec.X = (animaCount % 5) * 90;
                    animaCount++;                   
                }              
            }

            if (CurrentDirection == Direction.Right)
            {
                if (deltaTime >= 150)
                {
                    deltaTime = 0;
                    srcRec.Y = 90;
                    srcRec.X = (animaCount % 5) * 90;
                    animaCount++;
                }
            }

            if (CurrentDirection == Direction.Up)
            {
                if (deltaTime >= 150)
                {
                    deltaTime = 0;
                    srcRec.Y = 180;
                    srcRec.X = (animaCount % 5) * 90;
                    animaCount++;
                }
            }

            if (CurrentDirection == Direction.Down)
            {
                if (deltaTime >= 150)
                {
                    deltaTime = 0;
                    srcRec.Y = 270;
                    srcRec.X = (animaCount % 5) * 90;
                    animaCount++;
                }
            }
        }

        public void Movement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                CurrentDirection = Direction.Left;  
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                CurrentDirection = Direction.Up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                CurrentDirection = Direction.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                CurrentDirection = Direction.Down;
            }
        }


        public void Update(GameTime gameTime)
        {
            
            Movement();
            handleAnimation(gameTime);
            if (CurrentDirection == Direction.Up)
            {
                pos.Y -= speed;
                CurrentDirection = Direction.Default;
            }
            if (CurrentDirection == Direction.Down)
            {
                pos.Y += speed;
                CurrentDirection = Direction.Default;
            }
            if (CurrentDirection == Direction.Left)
            {
                pos.X -= speed;
                CurrentDirection = Direction.Default;
            }
            if (CurrentDirection == Direction.Right)
            {
                pos.X += speed;
                CurrentDirection = Direction.Default;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTex, pos, srcRec, Color.White);
        }



    }
}
