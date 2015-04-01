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
        public Texture2D playerTex1, weaponPH;
        public Vector2 playerPos, weaponPos, origin, mousePos;
        private ContentManager content;
        private Rectangle srcRec, weaponRec, playerRec;
        private float deltaTime, weaponTimer = 0, weaponRotation = 0.2f, playerRotation = 0f, rotation = 0.2f;
        private int animaCount = 1;
        private bool actionAttack;
        private double playerAngle;
        MouseState ms;
        private SpriteEffects spriteEffect;
        Color color;
        float speed = 230f, max_speed = 130, slow_speed = 85;
        bool swordEquipped = false;
        public Vector2 velocity;
        Vector2 acceleration;
        private bool move, moveUp, moveDown, moveLeft, moveRight;
        private List<Texture2D> playerTex = new List<Texture2D>();
        private List<Texture2D> swordTex = new List<Texture2D>();
        
        private enum Direction {Up, Down, Left, Right, Default}
        private Direction CurrentDirection;

        public Vector2 GetPos()
        {
            return playerPos;
        }
        public int GetPlayerDirection()
        {
            if (CurrentDirection == Direction.Up)
            {
                return 1;
            }
            if (CurrentDirection == Direction.Down)
            {
                return 2;
            }
            if (CurrentDirection == Direction.Right)
            {
                return 3;
            }
            if (CurrentDirection == Direction.Left)
            {
                return 4;
            }
            else
            {
                return 0;
            }         
        }

        public float GetWeaponTimer()
        {
            return weaponTimer;
        }
        public Texture2D GetPlayerTex()
        {
            return playerTex1;
        }
       /* public int GetSpeed()
        {
          //  return speed;
        }*/
        public Rectangle GetSwordRec()
        {
            return weaponRec;
        }
        public Rectangle GetPlayerRec()
        {
            return playerRec;
        }

        public Player(ContentManager content)
        {
            this.content = content;
            playerPos = new Vector2(500, 500);
            srcRec = new Rectangle(0, 0, 100, 100);
            playerRec = new Rectangle((int)playerPos.X, (int)playerPos.Y, 100, 150);
            spriteEffect = SpriteEffects.None;
            playerTex1 = content.Load<Texture2D>("ballsprite1");
            weaponPH = content.Load<Texture2D>("weaponPH");
            origin = new Vector2(80, 80);
            weaponRec = new Rectangle((int)weaponPos.X, (int)weaponPos.Y, weaponPH.Width, weaponPH.Height);

            for (int i = 1; i < 22; i++)
            {
                playerTex.Add(content.Load<Texture2D>("player" + i));
            }
            for (int i = 1; i < 22; i++)
            {
                swordTex.Add(content.Load<Texture2D>("sword" + i));
            }
            color = new Color(255, 30, 30, 255);  
        }
        private void Movement(GameTime gameTime)
        {
            if (moveLeft)
            {
                acceleration.X = -speed;
            }
            else if (moveRight)
            {
                acceleration.X = speed;
            }
            else
            {
                acceleration.X = 0;
                if (velocity.X > 0)
                {
                    if (velocity.X - slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds <= 0)
                        velocity.X = 0;
                    else
                        velocity.X -= slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (velocity.X < 0)
                {
                    if (velocity.X + slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds >= 0)
                        velocity.X = 0;
                    else
                        velocity.X += slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (moveUp)
            {
                acceleration.Y = -speed;
            }
            else if (moveDown)
            {
                acceleration.Y = speed;
            }
            else
            {
                acceleration.Y = 0;
                if (velocity.Y > 0)
                {
                    if (velocity.Y - slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds <= 0)
                        velocity.Y = 0;
                    else
                        velocity.Y -= slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                }
                else if (velocity.Y < 0)
                {
                    if (velocity.Y + slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds >= 0)
                        velocity.Y = 0;
                    else
                        velocity.Y += slow_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (velocity.X > max_speed)
                velocity.X = max_speed;
            else if (velocity.X < -max_speed)
                velocity.X = -max_speed;
            if (velocity.Y > max_speed)
                velocity.Y = max_speed;
            else if (velocity.Y < -max_speed)
                velocity.Y = -max_speed;


            velocity += Vector2.Multiply(acceleration, (float)gameTime.ElapsedGameTime.TotalSeconds);
            playerPos += Vector2.Multiply(velocity, (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void handleAnimation(GameTime gameTime)
        {
            deltaTime += gameTime.ElapsedGameTime.Milliseconds;
            if (move == true)
            {
                if (deltaTime >= 60)
                {
                    deltaTime = 0;
                    animaCount++;
                    if (animaCount > 19)
                        animaCount = 0;
                }
            }
            ms = Mouse.GetState();
            float xDistance = (float)ms.X - playerPos.X;
            float yDistance = (float)ms.Y - playerPos.Y;
            rotation = (float)Math.Atan2(yDistance, xDistance);
        }


        public void playerDirection()
        {
            moveLeft = false;
            moveRight = false;
            moveUp = false;
            moveDown = false;
            move = false;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                CurrentDirection = Direction.Right;
                move = true;
                moveRight = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                CurrentDirection = Direction.Left;
                move = true;
                moveLeft = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                CurrentDirection = Direction.Up;
                move = true;
                moveUp = true;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                CurrentDirection = Direction.Down;
                move = true;
                moveDown = true;
            }
        }

        private void handleAction(GameTime gameTime)
        {
            weaponTimer -= gameTime.ElapsedGameTime.Milliseconds;
            weaponRec = new Rectangle((int)weaponPos.X, (int)weaponPos.Y, weaponPH.Width, weaponPH.Height);

            if (actionAttack == true)
            {
                //rotation += 0.2f;
                weaponRotation += 0.1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                swordEquipped = !swordEquipped;
            }
                     
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && actionAttack == false)
            {
                Attack(CurrentDirection);
                
            }
            if (weaponTimer <= 0)
            {
                actionAttack = false;
                weaponRotation = 0;
               // spriteEffect = SpriteEffects.None;
            }
        }
        private void Attack(Direction dir)
        {
            weaponTimer = 200;
           // origin = new Vector2(weaponPH.Width, weaponPH.Height);

            if (dir == Direction.Up)
            {
                weaponRotation = 1;
                velocity.Y -= 100;          
                actionAttack = true;
            }
            if (dir == Direction.Down)
            {
                velocity.Y += 100;
                weaponRotation = 4.2f;
                actionAttack = true;
            }
            
            if (dir == Direction.Right)
            {
                velocity.X += 100;
                weaponRotation = 2.5f;
                actionAttack = true;
            }
            if (dir == Direction.Left)
            {
                velocity.X += 100;
                weaponRotation = 5.5f;
                actionAttack = true;
            }                     
        }

        public override void Update(GameTime gameTime)
        {
            //mousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);           
            
            playerDirection();
            Movement(gameTime);
            handleAction(gameTime);
            handleAnimation(gameTime);  
            double playerAngle = playerRotation * (180.0 / Math.PI);
            Console.WriteLine(playerAngle);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(playerTex, playerPos, srcRec, Color.White);
            // spriteBatch.Draw(playerTex[animaCount], playerPos, , Color.playerPosWhite, playerRotation, new Vector2(playerTex.Width /2, playerTex.Height / 2), 1f, spriteEffect, 2f);
          //  spriteBatch.Draw(weaponPH, playerRec, Color.White); // Show where the players hit range is

            if (swordEquipped)
                spriteBatch.Draw(swordTex[animaCount], playerPos, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(playerTex[animaCount], playerPos, null, color, rotation, origin, 1f, SpriteEffects.None, 0f);

            if (weaponTimer > 0)
            {
                //spriteBatch.Draw(weaponPH, weaponPos, weaponRec, Color.White, weaponRotation,origin, 1f, spriteEffect, 2f);
            }           
        }
    }
}
