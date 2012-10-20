using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Structure
{
    public struct Point
    {
        #region Attributs
        private int x;
        private int y;
        #endregion

        #region Constructeur
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Constructeur
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
        #endregion
    }
}
