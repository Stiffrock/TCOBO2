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
    class Player : MovableObject
    {
        private Texture2D playerTex, weaponPH;
        public Vector2 playerPos, weaponPos, origin;
        private ContentManager content;
        private Rectangle srcRec, weaponRec;
        private float deltaTime, weaponTimer = 0, rotation = 0.2f;
        private int animaCount = 1, speed = 2;
        private bool actionAttack, move;
        private SpriteEffects spriteEffect;
        
        private enum Direction {Up, Down, Left, Right, Default}
        private Direction CurrentDirection;

        public Vector2 GetPos()
        {
            return playerPos;
        }
        public Texture2D GetPlayerTex()
        {
            return playerTex;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public Rectangle GetSwordRec()
        {
            return weaponRec;
        }

        public Player(ContentManager content)
        {
            this.content = content;
            playerPos = new Vector2(500, 500);
            srcRec = new Rectangle(0, 0, 100, 100);
            spriteEffect = SpriteEffects.None;
            playerTex = content.Load<Texture2D>("playerSpritePH");
            weaponPH = content.Load<Texture2D>("weaponPH");
            origin = new Vector2(weaponPH.Width / 10, weaponPH.Height / 10);
            weaponRec = new Rectangle((int)weaponPos.X, (int)weaponPos.Y, weaponPH.Width, weaponPH.Height);
        }

        public void handleAnimation(GameTime gameTime)
        {
            deltaTime += gameTime.ElapsedGameTime.Milliseconds;
            if (move == true)
            {
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
        }

        public void playerDirection()
        {
            move = false;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                CurrentDirection = Direction.Left;
                weaponPos = new Vector2(playerPos.X+50, playerPos.Y+50);
                move = true;
                playerPos.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                CurrentDirection = Direction.Up;
                weaponPos = new Vector2(playerPos.X+50, playerPos.Y+50);
                move = true;
                playerPos.Y -= speed;   
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                CurrentDirection = Direction.Right;
                weaponPos = new Vector2(playerPos.X+50, playerPos.Y+50);
                move = true;
                playerPos.X += speed; 
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                CurrentDirection = Direction.Down;
                weaponPos = new Vector2(playerPos.X+50, playerPos.Y+50);
                move = true;
                playerPos.Y += speed;
            }           
        }

        private void Movement()
        {
            if (CurrentDirection == Direction.Up)
            {
                //playerPos.Y -= speed;            
                //CurrentDirection = Direction.Default;
            }
            if (CurrentDirection == Direction.Down)
            {
                //playerPos.Y += speed;
                //CurrentDirection = Direction.Default;
            }
            if (CurrentDirection == Direction.Left)
            {
               // playerPos.X -= speed;
                //CurrentDirection = Direction.Default;
            }
            if (CurrentDirection == Direction.Right)
            {
               // playerPos.X += speed;            
                //CurrentDirection = Direction.Default;
            }
           
        }

        private void handleAction(GameTime gameTime)
        {
            weaponTimer -= gameTime.ElapsedGameTime.Milliseconds;
            weaponRec = new Rectangle((int)weaponPos.X, (int)weaponPos.Y, weaponPH.Width, weaponPH.Height);

            if (actionAttack == true)
            {
                rotation += 0.2f;
            }
                     
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && actionAttack == false)
            {
                Attack(CurrentDirection);
                
            }
            if (weaponTimer <= 0)
            {
                actionAttack = false;
                rotation = 0;
               // spriteEffect = SpriteEffects.None;
            }
        }
        private void Attack(Direction dir)
        {
            weaponTimer = 100;
           // origin = new Vector2(weaponPH.Width, weaponPH.Height);

            if (dir == Direction.Up)
            {
                rotation = 1;
                origin = new Vector2(weaponPH.Width, weaponPH.Height);             
                actionAttack = true;
            }
            if (dir == Direction.Down)
            {
                rotation = 4.2f;
                origin = new Vector2(weaponPH.Width, weaponPH.Height);           
                actionAttack = true;
            }
            
            if (dir == Direction.Right)
            {
                rotation = 2.5f;
                origin = new Vector2(weaponPH.Width, weaponPH.Height);
                actionAttack = true;
            }
            if (dir == Direction.Left)
            {
                rotation = 5.5f;
                origin = new Vector2(weaponPH.Width, weaponPH.Height);
                actionAttack = true;
            }                     
        }

        public override void Update(GameTime gameTime)
        {        
            
            playerDirection();
            handleAction(gameTime);
            handleAnimation(gameTime);
            Movement();         
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTex, playerPos, srcRec, Color.White);

            if (weaponTimer > 0)
            {
                spriteBatch.Draw(weaponPH, weaponPos, weaponRec, Color.White, rotation,origin, 1f, spriteEffect, 2f);
            }
           
       
        
            
        }
    }
}
