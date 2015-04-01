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
    class Camera2D
    {
        public Matrix transform;
        private Viewport view;
        private Vector2 centre;
        private Player player;
        private Vector2 playerPos;

        public Camera2D(Viewport newView, Player player)
        {
            view = newView;
            this.player = player;           
        }

        public void Update(GameTime gameTime)
        {
            playerPos = player.GetPos();
            centre = new Vector2(playerPos.X-400, playerPos.Y-260);
            transform = Matrix.CreateScale(new Vector3(1,1,0))*
                Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y,0));
        }

    }
}
