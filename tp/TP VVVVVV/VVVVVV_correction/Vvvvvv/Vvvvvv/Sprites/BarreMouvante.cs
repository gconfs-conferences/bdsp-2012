using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VVVVVV
{
    class BarreMouvante : Sprites
    {
        int pos, vitesseBar = 4, gravity = 1;
        bool in_collision;

        public int VitesseBar
        { get { return vitesseBar; } }

        public int Gravity
        { get { return gravity; } }

        public BarreMouvante(Rectangle rect, int pos)
            : base(rect)
        { this.pos = pos; }

        public void LoadContent(ContentManager content)
        { base.LoadContent(content, @"barreMouvante"); }

        public void Update(GameTime gameTime, Carte carte, ContentManager content)
        {
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;

            in_collision = Moteur_physique.Zellagui_barreMouvante_mur(this, carte.List_Mur, gravity);
            if (in_collision)
                gravity *= -1;
            else
                position.X += gravity * vitesseBar;

        }

        public void Draw_barre(SpriteBatch spriteBatch, Rectangle camera)
        { base.Draw(spriteBatch, camera); }

    }
}