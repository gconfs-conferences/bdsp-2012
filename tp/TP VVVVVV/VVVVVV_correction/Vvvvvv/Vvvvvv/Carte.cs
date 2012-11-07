using System;
using System.IO;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VVVVVV
{
    class Carte
    {
        StreamReader file;
        char[,] map;
        int largeur, hauteur, taille;
        string line;
        Texture2D[] textures;
        List<Rectangle> list_mur;
        List<Pic> list_pic;
        List<Teleporteur> list_teleporteur;
        List<BarreMouvante> list_barreMouvante;
        List<BarreRebondissante> list_barreRebondissante;

        public Carte(string file_path)
        {
            list_mur = new List<Rectangle>();
            list_pic = new List<Pic>();
            list_teleporteur = new List<Teleporteur>();
            list_barreRebondissante = new List<BarreRebondissante>();
            list_barreMouvante = new List<BarreMouvante>();
            file = new StreamReader(file_path);

            largeur = Convert.ToInt32(file.ReadLine());
            hauteur = Convert.ToInt32(file.ReadLine());

            Divers.CaseDepart_heros = new Vector2(32 * Convert.ToInt32(file.ReadLine()), 32 * Convert.ToInt32(file.ReadLine()));

            map = new char[hauteur, largeur];
            OpenFile();
            Get_Mur();
        }

        public char[,] Map
        { get { return map; } }

        public List<Rectangle> List_Mur
        { get { return list_mur; } }

        public List<Pic> List_Pic
        { get { return list_pic; } }

        public List<Teleporteur> List_Teleporteur
        { get { return list_teleporteur; } }

        public List<BarreRebondissante> List_BarreRebondissante
        { get { return list_barreRebondissante; } }

        public List<BarreMouvante> List_BarreMouvante
        { get { return list_barreMouvante; } }

        public void Get_Mur() // recuperer la list des murs
        {
            for (int y = 0; y < hauteur; y++)
                for (int x = 0; x < largeur; x++)
                {
                    if (map[x, y] == 'm')
                        list_mur.Add(new Rectangle(x * 32, y * 32, 32, 32));
                }
        }

        private void OpenFile() // Ouvrir la map pour la stocké dans le tableau map[,]
        {
            string banana = "";
            string[] dessert = new string[3];

            try
            {  // Recuperation de la map
                for (int y = 0; y < hauteur; y++)
                {
                    line = file.ReadLine();
                    for (int x = 0; x < largeur; x++)
                        map[x, y] = line[x];
                }
                // Recuperation des coordonnées des :

                if (file.ReadLine() == "pic") // Pics
                    do
                    {
                        banana = file.ReadLine();
                        dessert = banana.Split(','); // :LOL:
                        if (banana != "teleporteur")
                            list_pic.Add(new Pic
                                (new Rectangle(Convert.ToInt32(dessert[0]), Convert.ToInt32(dessert[1]), 14, 15),
                                Convert.ToInt32(dessert[2]))); // sens du pic
                    } while (banana != "teleporteur");

                if (banana == "teleporteur") // Teleporteurs
                    do
                    {
                        banana = file.ReadLine();
                        dessert = banana.Split(','); // :LOL:
                        if (banana != "barreRebondissante")
                            list_teleporteur.Add(new Teleporteur(
                                new Vector2(Convert.ToInt32(dessert[0]), Convert.ToInt32(dessert[1])),
                                new Rectangle(1, 1 + Convert.ToInt32(dessert[2]) * 35, 32, 32)));
                    } while (banana != "barreRebondissante");

                if (banana == "barreRebondissante") // Barres Rebondissantes
                    do
                    {
                        banana = file.ReadLine();
                        dessert = banana.Split(','); // :LOL:
                        if (banana != "barreMouvante")
                            list_barreRebondissante.Add(new BarreRebondissante(
                                  new Rectangle(Convert.ToInt32(dessert[0]), Convert.ToInt32(dessert[1]), 150, 2),
                             Convert.ToInt32(dessert[2]))); // sens de la barre
                    } while (banana != "barreMouvante"); // Barres mouvantes

                if (banana == "barreMouvante") // Barres Mouvantes
                    do
                    {
                        banana = file.ReadLine();
                        dessert = banana.Split(','); // :LOL:
                        if (banana != "end")
                            list_barreMouvante.Add(new BarreMouvante(
                            new Rectangle(Convert.ToInt32(dessert[0]), Convert.ToInt32(dessert[1]), 52, 8),
                            Convert.ToInt32(dessert[2]))); // sens de la barre
                    } while (banana != "end");
            }
            catch (NullReferenceException) { } // kikoo gestion des exceptions n°1
            catch (IndexOutOfRangeException) { } // kikoo gestion des exceptions n°2
        }

        public void LoadTextures(ContentManager contentManager) // Chargement de toutes les textures dans le tableau textures[]
        {
            textures = new Texture2D[2];
            textures[0] = contentManager.Load<Texture2D>("fondNoir");
            textures[1] = contentManager.Load<Texture2D>("mur");

            foreach (Pic pic in list_pic)
                pic.LoadContent(contentManager);

            foreach (Teleporteur tel in list_teleporteur)
                tel.LoadContent(contentManager);

            foreach (BarreRebondissante barreRebondissante in list_barreRebondissante)
                barreRebondissante.LoadContent(contentManager);

            foreach (BarreMouvante barreMouvante in list_barreMouvante)
                barreMouvante.LoadContent(contentManager);

            taille = textures[0].Width;
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            foreach (BarreMouvante barreMouvante in list_barreMouvante)
                barreMouvante.Update(gameTime, this, content);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle camera) // Dessiner la map
        {
            /********** dessiner les textures (y compris les non affichées) **********/

            for (int y = 0; y < hauteur; y++)
                for (int x = 0; x < largeur; x++)
                    spriteBatch.Draw(Switch(map[x, y]), new Vector2((x - camera.X) * taille, (y - camera.Y) * taille), Color.White);

            /********** dessiner les textures (qui seront affichées) **********/

            /* for (int y = hauteur - camera.Height + camera.Y - 1; y >= camera.Y; y--) 
                 for (int x = largeur - camera.Width + camera.X - 1; x >= camera.X; x--)
                     spriteBatch.Draw(Switch(map[x, y]), new Vector2((x - camera.X) * taille, (y - camera.Y) * taille), Color.White);
             */

            for (int i = 0; i < list_pic.Count; i++) // dessiner les pics
                list_pic[i].Draw_Pic(spriteBatch, camera);

            for (int i = 0; i < list_teleporteur.Count; i++) // dessiner les teleporteurs
                list_teleporteur[i].Draw_Tel(spriteBatch, camera);


            for (int i = 0; i < list_barreRebondissante.Count; i++) // dessiner les barres rebondissante
                list_barreRebondissante[i].Draw_barre(spriteBatch, camera);

            for (int i = 0; i < list_barreMouvante.Count; i++) // dessiner les barres mouvantes
                list_barreMouvante[i].Draw_barre(spriteBatch, camera);

        }


        private Texture2D Switch(char c) // Convertion de la texture -> Char_to_int
        {
            switch (c)
            {
                case 'm':
                    return textures[1];
                default:
                    return textures[0];
            }
        }

    }
}