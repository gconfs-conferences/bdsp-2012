using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Structure
{
    public class Color
    {
        #region Attributs
        private byte a;
        private byte r;
        private byte g;
        private byte b;
        #endregion

        #region Constructeur
        public Color(byte r, byte g, byte b)
        {
            this.a = 255;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(byte r, byte g, byte b, byte a)
        {
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }
        #endregion

        #region Propriétés
        public byte A
        {
            get
            {
                return this.a;
            }
            set
            {
                this.a = value;
            }
        }
        public byte R
        {
            get
            {
                return this.r;
            }
            set
            {
                this.r = value;
            }
        }
        public byte G
        {
            get
            {
                return this.g;
            }
            set
            {
                this.g = value;
            }
        }
        public byte B
        {
            get
            {
                return this.b;
            }
            set
            {
                this.b = value;
            }
        }
        #endregion

        #region Propriétés statiques
        public static Color White
        {
            get
            {
                return new Color(255, 255, 255);
            }
        }
        public static Color Gray
        {
            get
            {
                return new Color(127, 127, 127);
            }
        }
        public static Color Black
        {
            get
            {
                return new Color(0, 0, 0);
            }
        }
        public static Color Red
        {
            get
            {
                return new Color(255, 0, 0);
            }
        }
        public static Color Green
        {
            get
            {
                return new Color(0, 255, 0);
            }
        }
        public static Color Blue
        {
            get
            {
                return new Color(0, 0, 255);
            }
        }
        #endregion
    }
}
