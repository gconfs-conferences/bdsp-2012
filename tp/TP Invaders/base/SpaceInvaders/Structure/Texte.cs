using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Structure
{
    public class Texte
    {
        #region Attributs
        private String message;
        private Fonte police;
        private Color couleur;
        private Point position;
        #endregion

        #region Constructeurs
        public Texte(string message, Point position)
        {
            this.message = message;
            this.position = position;
            this.couleur = Structure.Color.White;
            this.police = Fonte.Arial15;
        }

        public Texte(string message, Point position, Color couleur)
        {
            this.message = message;
            this.position = position;
            this.couleur = couleur;
            this.police = Fonte.Arial15;
        }

        public Texte(string message, Point position, Color couleur, Fonte police)
        {
            this.message = message;
            this.position = position;
            this.couleur = couleur;
            this.police = police;
        }
        #endregion

        #region Propriétés
        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public Fonte Police
        {
            get
            {
                return this.police;
            }
        }

        public Point Position
        {
            get
            {
                return this.position;
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

        #region Méthodes
        #endregion
    }
}
