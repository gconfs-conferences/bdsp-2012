using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Structure
{
    public struct Rectangle
    {
        #region Attributs
        private int x;
        private int y;
        private int width;
        private int height;
        #endregion

        #region Constructeurs
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        #endregion

        #region Propriétés
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Right
        {
            get
            {
                return this.x + this.width;
            }
            set
            {
                this.x = value - this.width;
            }
        }

        public int Left
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Bottom
        {
            get
            {
                return this.y + this.height;
            }
            set
            {
                this.y = value - this.height;
            }
        }

        public int Top
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public Point Center
        {
            get
            {
                return new Point(this.x + this.width / 2, this.y + this.height / 2);
            }
        }
        #endregion
    }
}
