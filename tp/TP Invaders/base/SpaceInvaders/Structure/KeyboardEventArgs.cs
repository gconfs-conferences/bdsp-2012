using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.Structure
{
    #region enum Keymap
    public enum Keymap
    {
        Azerty,
        Qwerty,
        US_int,
        Bepo,
        Dvorak
    }
    #endregion

    public class KeyboardEventArgs : EventArgs
    {
        #region Propriétés statiques
        public static char Accent { get; private set; }
        #endregion

        #region Propriétés
        protected string KeyString
        {
            get
            {
                if (this.toChar(Keymap.Qwerty) == '\0')
                    return this.PressedKey.ToString();
                else
                    return this.toChar(Keymap.Qwerty).ToString();
            }
        }
        protected Keys PressedKey
        {
            get;
            private set;
        }
        public bool Shift
        {
            get;
            private set;
        }
        public bool Ctrl
        {
            get;
            private set;
        }
        public bool Alt
        {
            get;
            private set;
        }
        public bool Meta
        {
            get;
            private set;
        }
        #endregion

        #region Constructeur
        public KeyboardEventArgs(Keys k, KeyboardState kb)
        {
            this.PressedKey = k;

            this.Shift = kb.IsKeyDown(Keys.RightShift) || kb.IsKeyDown(Keys.LeftShift);
            this.Ctrl = kb.IsKeyDown(Keys.RightControl) || kb.IsKeyDown(Keys.LeftControl);
            this.Alt = kb.IsKeyDown(Keys.RightAlt) || kb.IsKeyDown(Keys.LeftAlt);
            this.Meta = kb.IsKeyDown(Keys.RightWindows) || kb.IsKeyDown(Keys.LeftWindows);
        }
        #endregion

        #region Méthodes
        public char toChar(Keymap km)
        {
            #region Azerty
            if (km == Keymap.Azerty)
            {
                if (this.PressedKey == Keys.D1)
                {
                    if (this.Shift)
                        return ('1');
                    else
                        return ('&');
                }
                else if (this.PressedKey == Keys.D2)
                {
                    if (this.Shift)
                        return ('2');
                    else if (this.Alt)
                        return ('~');
                    else
                        return ('é');
                }
                else if (this.PressedKey == Keys.D3)
                {
                    if (this.Shift)
                        return ('3');
                    else if (this.Alt)
                        return ('#');
                    else
                        return ('"');
                }
                else if (this.PressedKey == Keys.D4)
                {
                    if (this.Shift)
                        return ('4');
                    else if (this.Alt)
                        return ('{');
                    else
                        return ('\'');
                }
                else if (this.PressedKey == Keys.D5)
                {
                    if (this.Shift)
                        return ('5');
                    else if (this.Alt)
                        return ('[');
                    else
                        return ('(');
                }
                else if (this.PressedKey == Keys.D6)
                {
                    if (this.Shift)
                        return '6';
                    else if (this.Alt)
                        return ('|');
                    else
                        return ('-');
                }
                else if (this.PressedKey == Keys.D7)
                {
                    if (this.Shift)
                        return ('7');
                    else if (this.Alt)
                        return ('`');
                    else
                        return ('è');
                }
                else if (this.PressedKey == Keys.D8)
                {
                    if (this.Shift)
                        return ('8');
                    else if (this.Alt)
                        return ('\\');
                    else
                        return ('_');
                }
                else if (this.PressedKey == Keys.D9)
                {
                    if (this.Shift)
                        return ('9');
                    else if (this.Alt)
                        return ('^');
                    else
                        return ('ç');
                }
                else if (this.PressedKey == Keys.D0)
                {
                    if (this.Shift)
                        return ('0');
                    else if (this.Alt)
                        return ('@');
                    else
                        return ('à');
                }
                else if (this.PressedKey == Keys.OemPeriod)
                {
                    if (this.Shift)
                        return ('.');
                    else
                        return (';');
                }
                else if (this.PressedKey == Keys.OemComma)
                {
                    if (this.Shift)
                        return ('?');
                    else
                        return (',');
                }
                else if (this.PressedKey == Keys.OemQuotes)
                {
                    if (this.Shift)
                        return '%';
                    else
                        return 'ù';
                }
                else if (this.PressedKey == Keys.OemMinus)
                {
                    if (this.Shift)
                        return ('°');
                    else
                        return (')');
                }
                else if (this.PressedKey == Keys.OemPlus)
                {
                    if (this.Shift)
                        return ('+');
                    else if (this.Alt)
                        return ('}');
                    else
                        return ('=');
                }
                else if (this.PressedKey == Keys.OemQuestion)
                {
                    if (this.Shift)
                        return ('/');
                    else
                        return (':');
                }
                else if (this.PressedKey == Keys.OemPipe)
                {
                    if (this.Shift)
                        return ('µ');
                    else
                        return ('*');
                }
                else if (this.PressedKey == Keys.OemOpenBrackets)
                {
                    if (this.Shift)
                        return ('°');
                    else if (this.Alt)
                        return (']');
                    else
                        return (')');
                }
                else if (this.PressedKey == Keys.OemCloseBrackets)
                {
                    if (this.Shift)
                        KeyboardEventArgs.Accent = '¨';
                    else
                        KeyboardEventArgs.Accent = '^';
                }
            }
            #endregion
            #region Qwerty/US-intl
            else if (km == Keymap.US_int || km == Keymap.Qwerty)
            {
                if (this.PressedKey == Keys.D1)
                {
                    if (this.Shift)
                        return ('!');
                    else
                        return ('1');
                }
                else if (this.PressedKey == Keys.D2)
                {
                    if (this.Shift)
                        return ('@');
                    else
                        return ('2');
                }
                else if (this.PressedKey == Keys.D3)
                {
                    if (this.Shift)
                        return ('#');
                    else
                        return ('3');
                }
                else if (this.PressedKey == Keys.D4)
                {
                    if (this.Shift)
                        return ('$');
                    else
                        return ('4');
                }
                else if (this.PressedKey == Keys.D5)
                {
                    if (this.Shift)
                        return ('%');
                    else
                        return ('5');
                }
                else if (this.PressedKey == Keys.D6)
                {
                    if (this.Shift)
                    {
                        if (km == Keymap.US_int)
                            KeyboardEventArgs.Accent = '^';
                        else
                            return '^';
                    }
                    else
                        return ('6');
                }
                else if (this.PressedKey == Keys.D7)
                {
                    if (this.Shift)
                        return ('&');
                    else
                        return ('7');
                }
                else if (this.PressedKey == Keys.D8)
                {
                    if (this.Shift)
                        return ('*');
                    else
                        return ('8');
                }
                else if (this.PressedKey == Keys.D9)
                {
                    if (this.Shift)
                        return ('(');
                    else
                        return ('9');
                }
                else if (this.PressedKey == Keys.D0)
                {
                    if (this.Shift)
                        return (')');
                    else
                        return ('0');
                }
                else if (this.PressedKey == Keys.OemSemicolon)
                {
                    if (this.Shift)
                        return (':');
                    else
                        return (';');
                }
                else if (this.PressedKey == Keys.OemPeriod)
                {
                    if (this.Shift)
                        return ('>');
                    else
                        return ('.');
                }
                else if (this.PressedKey == Keys.OemComma)
                {
                    if (this.Shift)
                        return ('<');
                    else
                        return (',');
                }
                else if (this.PressedKey == Keys.OemQuotes)
                {
                    if (this.Shift)
                    {
                        if (km == Keymap.US_int)
                            KeyboardEventArgs.Accent = '"';
                        else
                            return '"';
                    }
                    else
                    {
                        if (km == Keymap.US_int)
                            KeyboardEventArgs.Accent = '\'';
                        else
                            return '\'';
                    }
                }
                else if (this.PressedKey == Keys.OemMinus)
                {
                    if (this.Shift)
                        return ('_');
                    else
                        return ('-');
                }
                else if (this.PressedKey == Keys.OemPlus)
                {
                    if (this.Shift)
                        return ('+');
                    else
                        return ('=');
                }
                else if (this.PressedKey == Keys.OemQuestion)
                {
                    if (this.Shift)
                        return ('?');
                    else
                        return ('/');
                }
                else if (this.PressedKey == Keys.OemTilde)
                {
                    if (this.Shift)
                    {
                        if (km == Keymap.US_int)
                            KeyboardEventArgs.Accent = '~';
                        else
                            return '~';
                    }
                    else
                    {
                        if (km == Keymap.US_int)
                            KeyboardEventArgs.Accent = '`';
                        else
                            return '`';
                    }
                }
                else if (this.PressedKey == Keys.OemPipe)
                {
                    if (this.Shift)
                        return ('|');
                    else
                        return ('\\');
                }
                else if (this.PressedKey == Keys.OemOpenBrackets)
                {
                    if (this.Shift)
                        return ('{');
                    else
                        return ('[');
                }
                else if (this.PressedKey == Keys.OemCloseBrackets)
                {
                    if (this.Shift)
                        return ('}');
                    else
                        return (']');
                }
            }
            #endregion
            #region Dvorak
            else if (km == Keymap.Dvorak)
            {
                throw new NotImplementedException();
            }
            #endregion
            #region Bépo
            else if (km == Keymap.Bepo)
            {
                throw new NotImplementedException();
            }
            #endregion

            if (!(this.Meta || this.Alt || this.Ctrl))
            {
                if (this.PressedKey == Keys.Back)
                    return '\b';
                else if (this.PressedKey == Keys.Enter)
                    return '\n';
                #region Pavé numérique
                else if (this.PressedKey == Keys.NumPad0)
                    return '0';
                else if (this.PressedKey == Keys.NumPad1)
                    return '1';
                else if (this.PressedKey == Keys.NumPad2)
                    return '2';
                else if (this.PressedKey == Keys.NumPad3)
                    return '3';
                else if (this.PressedKey == Keys.NumPad4)
                    return '4';
                else if (this.PressedKey == Keys.NumPad5)
                    return '5';
                else if (this.PressedKey == Keys.NumPad6)
                    return '6';
                else if (this.PressedKey == Keys.NumPad7)
                    return '7';
                else if (this.PressedKey == Keys.NumPad8)
                    return '8';
                else if (this.PressedKey == Keys.NumPad9)
                    return '9';
                #endregion
                #region Accents
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.Space)
                    return KeyboardEventArgs.Accent;
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.A)
                {
                    if (KeyboardEventArgs.Accent == '`')
                    {
                        if (this.Shift)
                            return 'À';
                        else
                            return 'à';
                    }
                    else if (KeyboardEventArgs.Accent == '~')
                    {
                        if (this.Shift)
                            return 'Ã';
                        else
                            return 'ã';
                    }
                    else if (KeyboardEventArgs.Accent == '\'')
                    {
                        if (this.Shift)
                            return 'Á';
                        else
                            return 'á';
                    }
                    else if (KeyboardEventArgs.Accent == '"')
                    {
                        if (this.Shift)
                            return 'Ä';
                        else
                            return 'ä';
                    }
                    else if (KeyboardEventArgs.Accent == '^')
                    {
                        if (this.Shift)
                            return 'Â';
                        else
                            return 'â';
                    }
                    KeyboardEventArgs.Accent = char.MinValue;
                }
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.N)
                {
                    if (KeyboardEventArgs.Accent == '~')
                    {
                        if (this.Shift)
                            return 'Ñ';
                        else
                            return 'ñ';
                    }
                    else
                    {
                        if (this.Shift)
                            return 'N';
                        else
                            return 'n';
                    }
                }
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.E)
                {
                    if (KeyboardEventArgs.Accent == '`')
                    {
                        if (this.Shift)
                            return 'È';
                        else
                            return 'è';
                    }
                    else if (KeyboardEventArgs.Accent == '\'')
                    {
                        if (this.Shift)
                            return 'É';
                        else
                            return 'é';
                    }
                    else if (KeyboardEventArgs.Accent == '"')
                    {
                        if (this.Shift)
                            return 'Ë';
                        else
                            return 'ë';
                    }
                    else if (KeyboardEventArgs.Accent == '^')
                    {
                        if (this.Shift)
                            return 'Ê';
                        else
                            return 'ê';
                    }
                    else
                    {
                        if (this.Shift)
                            return 'E';
                        else
                            return 'e';
                    }
                }
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.I)
                {
                    if (KeyboardEventArgs.Accent == '`')
                    {
                        if (this.Shift)
                            return 'Ì';
                        else
                            return 'ì';
                    }
                    else if (KeyboardEventArgs.Accent == '\'')
                    {
                        if (this.Shift)
                            return 'Í';
                        else
                            return 'í';
                    }
                    else if (KeyboardEventArgs.Accent == '"')
                    {
                        if (this.Shift)
                            return 'Ï';
                        else
                            return 'ï';
                    }
                    else if (KeyboardEventArgs.Accent == '^')
                    {
                        if (this.Shift)
                            return 'Î';
                        else
                            return 'î';
                    }
                    else
                    {
                        if (this.Shift)
                            return 'I';
                        else
                            return 'i';
                    }
                }
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.O)
                {
                    if (KeyboardEventArgs.Accent == '`')
                    {
                        if (this.Shift)
                            return 'Ò';
                        else
                            return 'ò';
                    }
                    else if (KeyboardEventArgs.Accent == '~')
                    {
                        if (this.Shift)
                            return 'Õ';
                        else
                            return 'õ';
                    }
                    else if (KeyboardEventArgs.Accent == '\'')
                    {
                        if (this.Shift)
                            return 'Ó';
                        else
                            return 'ó';
                    }
                    else if (KeyboardEventArgs.Accent == '"')
                    {
                        if (this.Shift)
                            return 'Ö';
                        else
                            return 'ö';
                    }
                    else if (KeyboardEventArgs.Accent == '^')
                    {
                        if (this.Shift)
                            return 'Ô';
                        else
                            return 'ô';
                    }
                    KeyboardEventArgs.Accent = char.MinValue;
                }
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.U)
                {
                    if (KeyboardEventArgs.Accent == '`')
                    {
                        if (this.Shift)
                            return 'Ù';
                        else
                            return 'ù';
                    }
                    else if (KeyboardEventArgs.Accent == '\'')
                    {
                        if (this.Shift)
                            return 'Ú';
                        else
                            return 'ú';
                    }
                    else if (KeyboardEventArgs.Accent == '"')
                    {
                        if (this.Shift)
                            return 'Ü';
                        else
                            return 'ü';
                    }
                    else if (KeyboardEventArgs.Accent == '^')
                    {
                        if (this.Shift)
                            return 'Û';
                        else
                            return 'û';
                    }
                    else
                    {
                        if (this.Shift)
                            return 'U';
                        else
                            return 'u';
                    }
                }
                else if (KeyboardEventArgs.Accent != char.MinValue && this.PressedKey == Keys.Y)
                {
                    if (KeyboardEventArgs.Accent == '\'')
                    {
                        if (this.Shift)
                            return 'Ý';
                        else
                            return 'ý';
                    }
                    else if (KeyboardEventArgs.Accent == '"')
                    {
                        if (this.Shift)
                            return 'Y';
                        else
                            return 'ÿ';
                    }
                    else
                    {
                        if (this.Shift)
                            return 'Y';
                        else
                            return 'y';
                    }
                }
                #endregion
                else if (this.PressedKey == Keys.Space)
                    return ' ';
                else if (
                    this.PressedKey == Keys.A || this.PressedKey == Keys.B ||
                    this.PressedKey == Keys.C || this.PressedKey == Keys.D ||
                    this.PressedKey == Keys.E || this.PressedKey == Keys.F ||
                    this.PressedKey == Keys.G || this.PressedKey == Keys.H ||
                    this.PressedKey == Keys.I || this.PressedKey == Keys.J ||
                    this.PressedKey == Keys.K || this.PressedKey == Keys.L ||
                    this.PressedKey == Keys.M || this.PressedKey == Keys.N ||
                    this.PressedKey == Keys.O || this.PressedKey == Keys.P ||
                    this.PressedKey == Keys.Q || this.PressedKey == Keys.R ||
                    this.PressedKey == Keys.S || this.PressedKey == Keys.T ||
                    this.PressedKey == Keys.U || this.PressedKey == Keys.V ||
                    this.PressedKey == Keys.W || this.PressedKey == Keys.X ||
                    this.PressedKey == Keys.Y || this.PressedKey == Keys.Z
                    )
                {
                    KeyboardEventArgs.Accent = char.MinValue;

                    if (this.Shift)
                        return this.PressedKey.ToString()[0];
                    else
                        return this.PressedKey.ToString().ToLower()[0];
                }
            }

            return '\0';
        }
        #endregion
    }
}
