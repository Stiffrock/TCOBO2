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
    public static class TextureManager
    {
        public static Texture2D sand1 { get; private set; }
        public static Texture2D tree1 { get; private set; }
        public static Texture2D road1 { get; private set; }




        public static void LoadContent(ContentManager Content)
        {
            sand1 = Content.Load<Texture2D>("sand1");
            tree1 = Content.Load<Texture2D>("tree1");
            road1 = Content.Load<Texture2D>("road1");
        }

    }




}
