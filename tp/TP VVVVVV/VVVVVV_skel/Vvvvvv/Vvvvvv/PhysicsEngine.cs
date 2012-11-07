using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace VVVVVV
{
    static class PhysicsEngine
    {
        static public bool IsHerosCollidingWall_UpDown(Heros heros, List<Rectangle> listWall, int gravity)
        {
            // detection des collisions vers le haut/bas
            return false; //TODO
        }

        static public bool IsHerosCollidingWall_RightLeft(Heros heros, List<Rectangle> listWall, int gravity)
        {
            // detection des collisions vers la gauche/droite
            return false; //TODO
        }
    }
}
