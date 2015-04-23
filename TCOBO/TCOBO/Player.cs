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
        public Vector2 playerPos, origin, aimRec, mousePos;
        private ContentManager content;
        public Rectangle srcRec, attackHitBox;
        private float deltaTime, weaponTimer = 0;
        public float rotation = 0f;
        private int animaCount = 1;
        Color color;
        float speed = 230f, max_speed = 130, slow_speed = 85;
        bool swordEquipped = false;
        public Vector2 velocity;
        Vector2 acceleration;
        private bool move, moveUp, moveDown, moveLeft, moveRight;
        private List<Texture2D> playerTex = new List<Texture2D>();
        private List<Texture2D> swordTex = new List<Texture2D>();
        
        private enum Direction {Up, Down, Left, Right, TopRight, TopLeft, BottomRight, BottomLeft, Default}
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
        public Rectangle GetPlayerRec()
        {
            return attackHitBox;
        }

        public Player(ContentManager content)
        {
            this.content = content;
            playerPos = new Vector2(-400, 350);
            srcRec = new Rectangle(0, 0, 100, 100);
            attackHitBox = new Rectangle((int)playerPos.X, (int)playerPos.Y, 100, 150);
            playerTex1 = content.Load<Texture2D>("ballsprite1");
            weaponPH = content.Load<Texture2D>("weaponPH");
            origin = new Vector2(80, 80);    
            LoadPlayerTex();
            color = new Color(255, 30, 30, 255);  
        }

        private void LoadPlayerTex()
        {
            for (int i = 1; i < 22; i++)
            {
                playerTex.Add(content.Load<Texture2D>("player" + i));
            }
            for (int i = 1; i < 22; i++)
            {
                swordTex.Add(content.Load<Texture2D>("sword" + i));
            }
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
                move = true;
                moveRight = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                move = true;
                moveLeft = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                move = true;
                moveUp = true;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                move = true;
                moveDown = true;
            }
        }

        private void handleAction(GameTime gameTime)
        {        
            if (KeyMouseReader.KeyPressed(Keys.D1))
            {
                swordEquipped = !swordEquipped;
            }           
        }


        public override void Update(GameTime gameTime)
        {
            mousePos.X = Mouse.GetState().X;
            mousePos.Y = Mouse.GetState().Y;
            playerDirection();
            Movement(gameTime);
            handleAction(gameTime);
            handleAnimation(gameTime);       
          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {           
            if (swordEquipped)
                spriteBatch.Draw(swordTex[animaCount], playerPos, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
              spriteBatch.Draw(playerTex[animaCount], playerPos, null, color, rotation, origin, 1f, SpriteEffects.None, 0f);
              spriteBatch.Draw(weaponPH, attackHitBox, Color.White); // Show attackHitBox
        }
    }
}
