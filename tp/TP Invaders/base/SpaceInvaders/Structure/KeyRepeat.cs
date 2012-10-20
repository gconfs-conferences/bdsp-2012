using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.Structure
{
    #region classe KeyRepeat
    public class KeyRepeat
    {
        public Keys key { get; private set; }
        private double time;
        private bool alreadyRepeted;

        public KeyRepeat(Keys key)
        {
            this.key = key;
            this.time = 0;
            this.alreadyRepeted = false;
        }

        public bool launchEvent(GameTime gameTime)
        {
            if (alreadyRepeted)
            {
                if (gameTime.TotalRealTime.TotalSeconds - this.time > 0.15)
                {
                    this.time = gameTime.TotalRealTime.TotalSeconds;
                    return true;
                }
                else
                    return false;
            }
            else if (time == 0)
            {
                this.time = gameTime.TotalRealTime.TotalSeconds;
                return true;
            }
            else
            {
                if (gameTime.TotalRealTime.TotalSeconds - this.time > 0.5)
                {
                    this.alreadyRepeted = true;
                    this.time = gameTime.TotalRealTime.TotalSeconds;
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool isThisKey(List<KeyRepeat> keysDown, Keys search)
        {
            foreach (KeyRepeat k in keysDown)
            {
                if (k.key == search)
                    return true;
            }
            return false;
        }
    }
    #endregion
}
