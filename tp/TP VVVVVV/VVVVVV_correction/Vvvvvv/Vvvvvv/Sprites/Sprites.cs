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
        public Vector2 position;
        public Rectangle rect;
        Rectangle? sourceRectangle;
        int width, height;
        Texture2D texture;
        Color color = Color.White;


        public Sprites(Rectangle rect) // afficher toute la texture
        {
            this.rect = rect;
            position = new Vector2(rect.X, rect.Y);
            width = rect.Width;
            height = rect.Height;
        }

        public Sprites(Vector2 position, Rectangle? sourceRectangle) // afficher une partie de la texture
        {
            this.position = position;
            this.height = sourceRectangle.Value.Height;
            this.width = sourceRectangle.Value.Width;
            this.sourceRectangle = sourceRectangle;
            this.rect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public int Width
        { get { return width; } }

        public int Height
        { get { return height; } }

        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }

        public void LoadContent(ContentManager content, string nom)
        { texture = content.Load<Texture2D>(nom); }

        public void Draw(SpriteBatch spriteBatch, Rectangle camera)
        { spriteBatch.Draw(texture, new Vector2(position.X - camera.X * 32, position.Y - camera.Y * 32), sourceRectangle, color); }

        public void DrawRotate(SpriteBatch spriteBatch, Rectangle camera, float rotate)
        {
            spriteBatch.Draw(texture,
                new Rectangle((int)position.X - camera.X * 32, (int)position.Y - camera.Y * 32, width, Height), sourceRectangle, color, rotate, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Color othercolor, Rectangle camera)
        { spriteBatch.Draw(texture, new Vector2(position.X - camera.X * 32, position.Y - camera.Y * 32), sourceRectangle, othercolor); }
    }
}
