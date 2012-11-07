using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VVVVVV
{
    class Teleporteur : Sprites
    {
        Color other_color = Color.DarkGray;

        public Color Other_Color
        { get { return other_color; } set { other_color = value; } }


        public Teleporteur(Vector2 position, Rectangle? sourceRectangle)
            : base(position, sourceRectangle)
        {}

        public void LoadContent(ContentManager content)
        { base.LoadContent(content, @"teleporteur"); }

        public void Draw_Tel(SpriteBatch spriteBatch, Rectangle camera)
        { base.Draw(spriteBatch, other_color, camera); }
    }
}