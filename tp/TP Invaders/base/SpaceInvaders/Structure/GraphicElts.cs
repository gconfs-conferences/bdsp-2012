using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Structure
{
    public struct GraphicElts
    {
        #region Attributs
        private Textures texture;
        private Point position;
        private Color couleur;
        #endregion

        #region Constructeurs
        public GraphicElts(Textures texture, Point position)
        {
            this.texture = texture;
            this.position = position;
            this.couleur = Structure.Color.White;
        }

        public GraphicElts(Textures texture, Point position, Color couleur)
        {
            this.texture = texture;
            this.position = position;
            this.couleur = couleur;
        }

        public GraphicElts(Textures texture, Point position, Microsoft.Xna.Framework.Graphics.Color couleurXNA)
        {
            this.texture = texture;
            this.position = position;
            this.couleur = new Color(couleurXNA.R, couleurXNA.G, couleurXNA.B, couleurXNA.A);
        }
        #endregion

        #region Propriétés
        public Textures Texture
        {
            get
            {
                return this.texture;
            }
        }

        public int RefTexture
        {
            get
            {
                switch (this.Texture)
                {
                    case Textures.Beam1:
                        return 0;
                    case Textures.Beam2:
                        return 1;
                    case Textures.Explosion:
                        return 2;
                    case Textures.Invader11:
                        return 3;
                    case Textures.Invader12:
                        return 4;
                    case Textures.Invader21:
                        return 5;
                    case Textures.Invader22:
                        return 6;
                    case Textures.Invader31:
                        return 7;
                    case Textures.Invader32:
                        return 8;
                    case Textures.Invader4:
                        return 9;
                    case Textures.InvaderDeath:
                        return 10;
                    case Textures.Laser:
                        return 11;
                    case Textures.Player:
                        return 12;
                    case Textures.Shield:
                        return 13;
                    default:
                        return 0;
                }
            }
        }

        public Microsoft.Xna.Framework.Point Position
        {
            get
            {
                return new Microsoft.Xna.Framework.Point(this.position.X, this.position.Y);
            }
        }

        public Microsoft.Xna.Framework.Graphics.Color Color
        {
            get
            {
                return new Microsoft.Xna.Framework.Graphics.Color(this.couleur.R, this.couleur.G, this.couleur.B, this.couleur.A);
            }
            set
            {
                this.couleur = new Color(value.R, value.G, value.B, value.A);
            }
        }

        public Color Couleur
        {
            get
            {
                return this.couleur;
            }
            set
            {
                this.couleur = value;
            }
        }
        #endregion
    }
}
