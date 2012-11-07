using System;
using System.IO;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VVVVVV
{
    class Map
    {
        StreamReader _file;
        char[,] _map;
        int _width, _height, _size;
        Texture2D[] _textures;
        List<Rectangle> _listWall;


        public Map(string file_path)
        {
            _listWall = new List<Rectangle>();


            _width = 0; //FIXME
            _height = 0; //FIXME

            Divers.HerosSquareOne = new Vector2(); //FIXME

            _map = new char[_height, _width];
            OpenFile();
            GetWalls();
        }

        public char[,] ArrayMap
        { get { return _map; } }

        public List<Rectangle> ListWall
        { get { return _listWall; } }


        public void GetWalls()
        {
            // recuperer la list des murs
        }

        private void OpenFile() // Ouvrir la map pour la stocké dans le tableau map[,]
        {
            // Recuperation de la map              
        }

        public void LoadTextures(ContentManager contentManager)
        {
            // Chargement de toutes les textures dans le tableau textures[]
        }


        public void DrawMap(SpriteBatch spriteBatch, Rectangle camera)
        {
            // Dessiner la map
        }
    }
}