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
        public static Texture2D grass1 { get; private set; }
        public static Texture2D sandtype2 { get; private set; }
        public static Texture2D bushtile1 { get; private set; }
        public static Texture2D treetile1 { get; private set; }
        public static Texture2D graveltile1 { get; private set; }
        public static Texture2D bricktile1 { get; private set; }




        public static void LoadContent(ContentManager Content)
        {
            sand1 = Content.Load<Texture2D>("sand1");
            tree1 = Content.Load<Texture2D>("tree1");
            road1 = Content.Load<Texture2D>("road1");
            grass1 = Content.Load<Texture2D>("grasstile_type4");
            sandtype2 = Content.Load<Texture2D>("sandtile_type3");
            bushtile1 = Content.Load<Texture2D>("bushtile_type5");
            treetile1 = Content.Load<Texture2D>("treetile_type1");
            graveltile1 = Content.Load<Texture2D>("gravel_type1");
            bricktile1 = Content.Load<Texture2D>("brick_type1");
        }

    }




}
