using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.Structure
{
    public class GUI
    {
        #region Attributs
        private KeyboardState lastKbState;
        private List<KeyRepeat> KeysDown;
        #endregion

        #region Constructeurs
        public GUI()
        {
            this.lastKbState = Keyboard.GetState();
            this.KeysDown = new List<KeyRepeat>();
            foreach (Keys k in this.lastKbState.GetPressedKeys())
                this.KeysDown.Add(new KeyRepeat(k));
        }
        #endregion

        #region Propriétés

        #endregion

        #region Événements
        public delegate void KeyboardEventHandler(object sender, KeyboardEventArgs e);
        /// <summary>
        /// Événement déclenché lorsqu'une touche est appuyée puis relâchée (synchronisation sur impulsion positive !)
        /// </summary>
        public event KeyboardEventHandler OnKeyPressed;
        public event KeyboardEventHandler OnKeyDown;
        public event KeyboardEventHandler OnKeyUp;
        #endregion

        #region Méthodes
        public void Update(GameTime gameTime)
        {
            #region Gestion du clavier
            KeyboardState kb = Keyboard.GetState();
            if (kb != this.lastKbState)
            {
                bool modified;
                do
                {
                    modified = false;
                    foreach (KeyRepeat k in this.KeysDown)
                    {
                        if (kb.IsKeyUp(k.key))
                        {
                            //On ne déclence un événement que s'il s'agit d'une touche, pas d'une touche de controle
                            if (k.key != Keys.LeftAlt && k.key != Keys.LeftControl && k.key != Keys.LeftShift && k.key != Keys.LeftWindows && k.key != Keys.RightAlt && k.key != Keys.RightControl && k.key != Keys.RightShift && k.key != Keys.RightWindows)
                            {
                                if (this.OnKeyUp != null)
                                    this.OnKeyUp(this, new KeyboardEventArgs(k.key, kb));
                                if (this.OnKeyPressed != null)
                                    this.OnKeyPressed(this, new KeyboardEventArgs(k.key, kb));
                            }

                            this.KeysDown.Remove(k);
                            modified = true;
                            break;
                        }
                    }
                } while (modified);

                //On ajoute les nouvelles touches appuyées
                Keys[] downs = kb.GetPressedKeys();
                if (downs.Length != this.KeysDown.Count)
                {
                    foreach (Keys d in downs)
                    {
                        if (!KeyRepeat.isThisKey(this.KeysDown, d))
                        {
                            this.KeysDown.Add(new KeyRepeat(d));
                            if (this.OnKeyDown != null)
                                this.OnKeyDown(this, new KeyboardEventArgs(d, kb));
                        }
                    }
                }

                this.lastKbState = kb;
            }
            #endregion
        }
        #endregion
    }
}
