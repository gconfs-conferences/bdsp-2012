using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace VVVVVV
{
    static class Moteur_physique
    {
        static public bool Zellagui_heros_up_down(Heros heros, List<Rectangle> list_mur, int gravity) // detection des collisions vers le haut/bas
        {
            for (int i = 0; i < list_mur.Count; i++)
                if (new Rectangle((int)heros.position.X, (int)heros.position.Y + gravity * heros.VitesseSprite, heros.Width, heros.Height).Intersects(list_mur[i])) // up
                    return true;
            return false;
        }

        static public bool Zellagui_heros_right_left(Heros heros, List<Rectangle> list_mur, int gravity) // detection des collisions vers la gauche/droite
        {
            for (int i = 0; i < list_mur.Count; i++)
                if (new Rectangle((int)(heros.position.X + ((gravity * heros.VitesseSprite) / 2)), (int)heros.position.Y, heros.Width, heros.Height).Intersects(list_mur[i])) // right
                    return true;
            return false;
        }

        static public bool Zellagui_heros_barreMouvante(Heros heros, List<BarreMouvante> list_barreMouvante, int gravity) // detection des collisions avec les barres Mouvantes
        {
            for (int i = 0; i < list_barreMouvante.Count; i++)
                if (new Rectangle((int)heros.position.X, (int)heros.position.Y + gravity * heros.VitesseSprite, heros.Width, heros.Height).Intersects(list_barreMouvante[i].rect)) // up
                {
                    heros.Gravity_X = list_barreMouvante[i].Gravity;
                    heros.position.X += heros.Gravity_X * list_barreMouvante[i].VitesseBar;
                    return true;
                }
            return false;
        }

        static public bool Zellagui_pic(Heros heros, List<Pic> list_pic) // detection des collisions avec les pics
        {
            for (int i = 0; i < list_pic.Count; i++)
                if (heros.rect.Intersects(list_pic[i].rect))
                    return true;
            return false;
        }

        static public bool Zellagui_barreRebondissante(Heros heros, List<BarreRebondissante> list_barreRebondissante) // detection des collisions avec les barres Rebondissantes
        {
            for (int i = 0; i < list_barreRebondissante.Count; i++)
                if (heros.rect.Intersects(list_barreRebondissante[i].rect))
                {
                    heros.Gravity_Y *= -1;
                    heros.position.Y += heros.VitesseSprite * 2 * heros.Gravity_Y;
                    return true;
                }
            return false;
        }

        static public int last_tel = 0;
        static public void Zellagui_teleporteur(Heros heros, List<Teleporteur> list_teleporteur) // detection des collisions avec les teleporteurs
        {
            for (int i = 0; i < list_teleporteur.Count; i++)
                if (heros.rect.Intersects(list_teleporteur[i].rect))
                {

                    list_teleporteur[last_tel].Other_Color = Color.DarkGray;
                    Divers.CaseDepart_heros = new Vector2(list_teleporteur[i].rect.X, list_teleporteur[i].rect.Y);
                    list_teleporteur[i].Other_Color = Color.White;
                    last_tel = i;
                }
        }

        static public bool Zellagui_barreMouvante_mur(BarreMouvante bar, List<Rectangle> list_mur, int gravity) // detection des collisions barre mouvantes / mur
        {
            for (int i = 0; i < list_mur.Count; i++)
                if (new Rectangle((int)bar.position.X + gravity * bar.VitesseBar / 2, (int)bar.position.Y, bar.Width, bar.Height).Intersects(list_mur[i])) // right
                    return true;
            return false;
        }
    }
}
