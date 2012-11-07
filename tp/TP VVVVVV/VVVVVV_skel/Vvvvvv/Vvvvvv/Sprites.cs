using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace VVVVVV
{
    class Sprites
    {
        public Vector2 Position; // position du sprite
        public Rectangle Rect;  // rectangle définit autour du sprite
        
        Texture2D _texture; // texture définissant le sprite
        Color _color = Color.White;

        int _width; // largeur du sprite
        public int Width
        { get { return _width; } }

        int _height; // hauteur du sprite
        public int Height
        { get { return _height; } }

        Rectangle? _sourceRectangle; // le sourceRectangle permet de définir un Rectangle qui sera affiché dans la texture chargée.
        public Rectangle? SourceRectangle
        {
            get { return _sourceRectangle; }
            set { _sourceRectangle = value; }
        }

        public Sprites(Rectangle rect) // afficher toute la texture
        {
            this.Rect = rect;
            Position = new Vector2(rect.X, rect.Y);
            _width = rect.Width;
            _height = rect.Height;
        }

        public Sprites(Vector2 position, Rectangle? sourceRectangle) // afficher une partie de la texture
        {
            this.Position = position;
            this._height = sourceRectangle.Value.Height;
            this._width = sourceRectangle.Value.Width;
            this._sourceRectangle = sourceRectangle;
            this.Rect = new Rectangle((int)position.X, (int)position.Y, _width, _height);
        }

       public void LoadContent(ContentManager content, string nom)
        { _texture = content.Load<Texture2D>(nom); }

        public void Draw(SpriteBatch spriteBatch)
        { spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), _sourceRectangle, _color); }
       
    }
}
