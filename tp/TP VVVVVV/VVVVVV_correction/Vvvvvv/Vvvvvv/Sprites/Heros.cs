using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace VVVVVV
{
    class Heros : Sprites
    {
        Vector2 caseDepart;
        int vitesseHeros = 8;
        Keys up, down, right, left;
        float vitesseAnimation = 0.008f, index = 0;
        int maxIndex = 2;
        int gravity_Y = 1;
        int gravity_X = 1;

        bool moving_up_down;

        bool in_collision_up_down = false;
        bool in_collision_right_left = false;

        public Vector2 CaseDepart
        { get { return caseDepart; } set { caseDepart = value; } }

        public int VitesseSprite
        { get { return vitesseHeros; } }

        public int Gravity_X
        { get { return gravity_X; } set { gravity_X = value; } }

        public int Gravity_Y
        { get { return gravity_Y; } set { gravity_Y = value; } }

        public Heros(Vector2 position, Rectangle? sourceRectangle, Keys up, Keys down, Keys right, Keys left)
            : base(position, sourceRectangle)
        {
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;
        }

        public void LoadContent(ContentManager content, int maxIndex)
        {
            base.LoadContent(content, @"heros");
            this.maxIndex = maxIndex;
        }


        public void Update(GameTime gameTime, Carte carte, ref Rectangle camera, ContentManager content)
        {
            // Mise a jour des positions du rectangle autour du heros (pour la gestion des collisions)
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;

            // Interaction avec les touches de changement de gravité
            if (Keyboard.GetState().IsKeyDown(Keys.V) && !moving_up_down)
                gravity_Y *= -1;
            else if (Keyboard.GetState().IsKeyDown(up) && !moving_up_down)
                gravity_Y = -1;
            else if (Keyboard.GetState().IsKeyDown(down) && !moving_up_down)
                gravity_Y = 1;

            // Interaction avec les touches de déplacement gauche/droite
            if (Keyboard.GetState().IsKeyDown(left)) // gauche
                gravity_X = -1;
            if (Keyboard.GetState().IsKeyDown(right)) // droite          
                gravity_X = 1;
            if (Keyboard.GetState().IsKeyDown(left) || (Keyboard.GetState().IsKeyDown(right)))
                if (!in_collision_right_left)
                {
                    // animation du sprite
                    if (gravity_Y < 0 && gravity_X > 0)
                        SourceRectangle = new Rectangle((int)index * 18, 67, Width, Height);
                    else if (gravity_Y > 0 && gravity_X > 0)
                        SourceRectangle = new Rectangle((int)index * 18, 1, Width, Height);
                    else if (gravity_Y < 0 && gravity_X < 0)
                        SourceRectangle = new Rectangle((int)index * 18, 100, Width, Height);
                    else //(gravity_Y > 0 && gravity_X < 0)
                        SourceRectangle = new Rectangle((int)index * 18, 34, Width, Height);

                    index += gameTime.ElapsedGameTime.Milliseconds * vitesseAnimation;

                    if (index >= maxIndex)
                        index = 0f;  // animation sprite           

                    // deplacement du héros vers la droite/gauche
                    position.X += gravity_X * vitesseHeros / 2;
                }

            // Mise à jour de la camera pour le Scrolling
            if (position.Y - camera.Y * 32 < 0)
                camera.Y = 0;
            if (position.Y + camera.Y * 32 > Divers.Hauteur_Ecran - Height)
                camera.Y = 16;
            if (position.X - camera.X * 32 < 0)
                camera.X = 0;
            if (position.X + camera.X > Divers.Largeur_Ecran - Width)
                camera.X = 16;

            // Detection des collisions
            in_collision_up_down = Moteur_physique.Zellagui_heros_up_down(this, carte.List_Mur, gravity_Y) // Vers le haut/bas
                || Moteur_physique.Zellagui_heros_barreMouvante(this, carte.List_BarreMouvante, gravity_Y) //barres mouvantes
                || Moteur_physique.Zellagui_barreRebondissante(this, carte.List_BarreRebondissante); //barres rebondissantes


            // detection des collisions vers la gauche/droite
            in_collision_right_left = Moteur_physique.Zellagui_heros_right_left(this, carte.List_Mur, gravity_X);

            // Cas d'arret de deplacement si collision
            if (!in_collision_up_down)
            {
                if (gravity_Y < 0) // on retourne le heros quand il change de gravité
                    SourceRectangle = new Rectangle(1, 67, Width, Height);
                else
                    SourceRectangle = new Rectangle(1, 1, Width, Height);

                moving_up_down = true;
                position.Y += gravity_Y * vitesseHeros;
            }
            else
                moving_up_down = false;

            // Collision avec les pics
            if (Moteur_physique.Zellagui_pic(this, carte.List_Pic)) // mise a jour de la position / gravité / animation du héros.
            {
                position = Divers.CaseDepart_heros;
                if (carte.List_Teleporteur[Moteur_physique.last_tel].SourceRectangle.Value.Y == 36)
                {
                    gravity_Y = -1;
                    SourceRectangle = new Rectangle(1, 67, Width, Height);
                }
                else
                {
                    gravity_Y = 1;
                    SourceRectangle = new Rectangle(1, 1, Width, Height);
                }
            }

            // Collision avec les teleporteurs
            Moteur_physique.Zellagui_teleporteur(this, carte.List_Teleporteur);
        }

        public void Draw_Hero(SpriteBatch spriteBatch, Rectangle camera)
        { base.Draw(spriteBatch, camera); }
    }
}
