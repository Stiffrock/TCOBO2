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
        public Vector2 playerPos, origin, aimRec;
        private ContentManager content;
        public Rectangle srcRec, attackHitBox;
        private float deltaTime, Exp = 0, mDamage = 1, sDamage = 1, HP = 10;
        public float rotation = 0f;
        private int 
            animaCount = 1, Level = 1, Str = 10, Dex = 10, 
            Vit = 10, Int = 10, maxLvl = 101, newStat = 0;
        private Color color;
        float speed = 230f, max_speed = 130, slow_speed = 85, slow_speed_2 = 200;
        bool swordEquipped = false;
        public Vector2 velocity, velocity2;
        private Vector2 acceleration;
        private Tuple<int, int, int, int, int, int> playerStats;
        private Tuple<float, float, float> effectiveStats;
        private bool move, moveUp, moveDown, moveLeft, moveRight;
        private List<Texture2D> playerTex = new List<Texture2D>();
        private List<Texture2D> swordTex = new List<Texture2D>();
        private List<float> levelList = new List<float>();
        public Rectangle boundsTop, boundsBot, boundsLeft, boundsRight;
        int playerSize = 36;
      
        public Vector2 GetPos()
        {
            return playerPos;
        }

        public Tuple<int, int, int, int, int, int> GetPlayerStats()
        {
            return playerStats;
        }
        public Tuple<float, float, float> GetEffectiveStats()
        {
            return effectiveStats;
        }


        public Player(ContentManager content)
        {
            this.content = content;
            playerPos = new Vector2(-370, 350);
            srcRec = new Rectangle(0, 0, 100, 100);
            attackHitBox = new Rectangle((int)playerPos.X, (int)playerPos.Y, 100, 150);
            playerTex1 = content.Load<Texture2D>("ballsprite1");
            weaponPH = content.Load<Texture2D>("weaponPH");
            origin = new Vector2(80, 80);
            color = new Color(255, 30, 30, 255);            
            LoadPlayerTex();
            HandleLevel();
            Console.Write(levelList[99]);
        }

        public void HandleLevel()
        {            
            for (int i = 1; i < maxLvl; i++)
            {
                float newLevel = i*10;
                levelList.Add(newLevel);                
            }         
        }

        public void HandleLevelUp()
        {
            if (Level <= 99)
            {
                float needExp = levelList[Level];

                if (Exp > needExp)
                {
                    Level += 1;
                    newStat += 5;
                    Exp = 0;
                    Console.WriteLine("Level   "+  Level);
                }               
            }
        }

        public void HandlePlayerStats() // Bör göra all stat förändring här
        {
            playerStats = Tuple.Create<int, int, int, int, int, int>(Str, Dex, Vit, Int, Level, newStat);
            effectiveStats = Tuple.Create<float, float, float>(mDamage, sDamage, HP);
            
            mDamage = Str * 0.5f;
            sDamage = Int * 0.5f;
            HP = Vit;

            if (newStat != 0)
            {
                if (KeyMouseReader.KeyPressed(Keys.D1))
                {
                    Str += 1;
                    newStat -= 1;
                }
                if (KeyMouseReader.KeyPressed(Keys.D2))
                {
                    Dex += 1;
                    newStat -= 1;
                }
                if (KeyMouseReader.KeyPressed(Keys.D3))
                {
                    Vit += 1;
                    newStat -= 1;
                }
                if (KeyMouseReader.KeyPressed(Keys.D4))
                {
                    Int += 1;
                    newStat -= 1;
                }
             
            }

            if (KeyMouseReader.KeyPressed(Keys.D5))
            {
                Exp += 5;
                Console.WriteLine("Exp   "+Exp);
            }

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
            playerPos += Vector2.Multiply(velocity2, (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (velocity2.Y > 0)
            {
                if (velocity2.Y - slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds <= 0)
                    velocity2.Y = 0;
                else
                    velocity2.Y -= slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            else if (velocity2.Y < 0)
            {
                if (velocity2.Y + slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds >= 0)
                    velocity2.Y = 0;
                else
                    velocity2.Y += slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (velocity2.X > 0)
            {
                if (velocity2.X - slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds <= 0)
                    velocity2.X = 0;
                else
                    velocity2.X -= slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (velocity2.X < 0)
            {
                if (velocity2.X + slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds >= 0)
                    velocity2.X = 0;
                else
                    velocity2.X += slow_speed_2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
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
            if (KeyMouseReader.KeyPressed(Keys.E))
            {
                swordEquipped = !swordEquipped;
            }           
        }


        public override void Update(GameTime gameTime)
        {
            HandleLevelUp();
            HandlePlayerStats(); 
            playerDirection();           
            Movement(gameTime);
            handleAction(gameTime);
            handleAnimation(gameTime);                 
        }

        public void Collision (GameTime gameTime, List<Tile> tiles) 
        {
            boundsTop = new Rectangle((int)playerPos.X - playerSize/2 + playerSize / 10, (int)playerPos.Y - playerSize/2, playerSize - (playerSize / 5), playerSize / 10);
            boundsBot = new Rectangle((int)playerPos.X - playerSize/2 + playerSize / 10, (int)playerPos.Y + playerSize / 2 - playerSize / 10, playerSize - (playerSize / 5), playerSize / 10);
            boundsLeft = new Rectangle((int)playerPos.X - playerSize / 2, (int)playerPos.Y - playerSize / 2 + playerSize / 10, playerSize / 10, playerSize - playerSize / 5);
            boundsRight = new Rectangle((int)playerPos.X + playerSize / 2 - playerSize / 10, (int)playerPos.Y - playerSize / 2 + playerSize / 10, playerSize / 10, playerSize - playerSize / 5);
            foreach (Tile t in tiles)
            {
                if (t.collisionEnabled)
                {
                    if (t.bounds.Intersects(boundsLeft))
                    {
                        if (velocity.X < 0)
                            velocity.X = (velocity.X * -2) + max_speed / 10;
                        else
                            velocity.X = max_speed / 10;
                        velocity.Y = velocity.Y * 1.1f;
                        break;
                        
                    }
                    if (t.bounds.Intersects(boundsRight))
                    {
                        if (velocity.X < 0)
                            velocity.X = -max_speed / 10;
                        else
                            velocity.X = (velocity.X * -2) - max_speed / 10;
                        velocity.Y = velocity.Y * 1.1f;
                        break;
                    }
                    if(t.bounds.Intersects(boundsBot))
                    {
                        if (velocity.Y < 0) //om påväg uppåt
                            velocity.Y = -max_speed / 10;
                        else
                            velocity.Y = (velocity.Y * -2) - max_speed / 10;
                        velocity.X = velocity.X * 1.1f;
                        break;

                    }
                    if (t.bounds.Intersects(boundsTop))
                    {
                        if (velocity.Y < 0) //om påväg neråt
                            velocity.Y = (velocity.Y * -2) + max_speed / 10;
                        else
                            velocity.Y = max_speed / 10;
                        velocity.X = velocity.X * 1.1f;
                        break;
                    }
                    
                }
            }
        }
        

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(TextureManager.sand1, boundingBox, Color.Black);
            if (swordEquipped)
                spriteBatch.Draw(swordTex[animaCount], playerPos, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
              spriteBatch.Draw(playerTex[animaCount], playerPos, null, color, rotation, origin, 1f, SpriteEffects.None, 0f);
              //spriteBatch.Draw(weaponPH, attackHitBox, Color.White); // Show attackHitBox

              //spriteBatch.Draw(TextureManager.sand1, boundsTop, Color.Black);
              //spriteBatch.Draw(TextureManager.sand1, boundsBot, Color.Black);
              //spriteBatch.Draw(TextureManager.sand1, boundsLeft, Color.Black);
              //spriteBatch.Draw(TextureManager.sand1, boundsRight, Color.Black);
        }
    }
}
