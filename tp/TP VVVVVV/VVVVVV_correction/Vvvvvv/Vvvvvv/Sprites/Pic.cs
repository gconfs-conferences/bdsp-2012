using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VVVVVV
{
    class Pic : Sprites
    {
        int pos;
        public Pic(Rectangle rect, int pos)
            : base(rect)
        { this.pos = pos; }

        public void LoadContent(ContentManager content)
        { base.LoadContent(content, @"pic"); }       

        public void Draw_Pic(SpriteBatch spriteBatch, Rectangle camera)
        { base.DrawRotate(spriteBatch, camera, (float)(pos*Math.PI)); }
    }
}
