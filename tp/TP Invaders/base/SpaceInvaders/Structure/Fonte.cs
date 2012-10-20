using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Structure
{
    public class Fonte
    {
        #region Attributs
        private string name;
        private byte size;
        #endregion

        #region Constructeurs
        public Fonte(string name, byte size)
        {
            this.name = name;
            this.size = size;
        }
        #endregion

        #region Propriétés
        public string RefName
        {
            get
            {
                return this.name + this.size;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public byte Size
        {
            get
            {
                return this.size;
            }
        }
        #endregion

        #region Propriétés statiques
        public static Fonte Arial10
        {
            get
            {
                return new Fonte("Arial", 10);
            }
        }
        public static Fonte Arial15
        {
            get
            {
                return new Fonte("Arial", 15);
            }
        }
        public static Fonte Arial20
        {
            get
            {
                return new Fonte("Arial", 20);
            }
        }
        public static Fonte Courier10
        {
            get
            {
                return new Fonte("Courier", 10);
            }
        }
        public static Fonte Courier20
        {
            get
            {
                return new Fonte("Courier", 20);
            }
        }
        #endregion
    }
}