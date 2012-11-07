using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VVVVVV
{
    class BarreRebondissante : Sprites
    {
        int pos;
        public BarreRebondissante(Rectangle rect, int pos)
            : base(rect)
        { this.pos = pos; }

        public void LoadContent(ContentManager content)
        { base.LoadContent(content, @"barreRebondissante"); }

        public void Draw_barre(SpriteBatch spriteBatch, Rectangle camera)
        { base.Draw(spriteBatch, camera); }

    }
}