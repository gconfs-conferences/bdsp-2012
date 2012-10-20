using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.Structure
{
    public class GraphEngine : DrawableGameComponent
    {
        #region Constantes
        private const string TexturesPath = "sprites/";
        private const string ThemePath = "classic/";
        #endregion

        #region Attributs
        private SpriteBatch renderer;
        /// <summary>
        /// Liste des textures à afficher
        /// </summary>
        private List<GraphicElts> elts;
        private List<Texte> strs;

        private Texture2D[] textures;
        private Dictionary<string, SpriteFont> fontes;
        #endregion

        #region Constructeur
        public GraphEngine(Microsoft.Xna.Framework.Game game)
            : base(game)
        {
            this.elts = new List<GraphicElts>();
            this.strs = new List<Texte>();

            this.textures = new Texture2D[15];
            this.fontes = new Dictionary<string, SpriteFont>();
        }
        #endregion

        #region Méthodes publiques
        public void addElement(Textures texture, Point position)
        {
            this.elts.Add(new GraphicElts(texture, position));
        }

        public void addElement(Textures texture, Point position, Color color)
        {
            this.elts.Add(new GraphicElts(texture, position, color));
        }

        public void addString(string message, Structure.Point position)
        {
            this.strs.Add(new Texte(message, position));
        }

        public void addString(string message, Structure.Point position, Color couleur)
        {
            this.strs.Add(new Texte(message, position, couleur));
        }

        public void addString(Texte texte)
        {
            this.strs.Add(texte);
        }
        #endregion

        #region Méthodes locales
        protected override void LoadContent()
        {
            this.renderer = new SpriteBatch(this.GraphicsDevice);

            //On charge les textures
            this.textures[0] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "beam1");
            this.textures[1] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "beam2");
            this.textures[2] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "explosion");
            this.textures[3] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader11");
            this.textures[4] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader12");
            this.textures[5] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader21");
            this.textures[6] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader22");
            this.textures[7] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader31");
            this.textures[8] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader32");
            this.textures[9] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invader4");
            this.textures[10] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "invaderdeath");
            this.textures[11] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "laser");
            this.textures[12] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "player");
            this.textures[13] = this.Game.Content.Load<Texture2D>(TexturesPath + ThemePath + "shield");

            this.textures[14] = this.Game.Content.Load<Texture2D>(TexturesPath + "wallpaper");

            //On charge les polices
            this.fontes.Add("Arial10", Game.Content.Load<SpriteFont>("fonts/Arial10"));
            this.fontes.Add("Arial15", Game.Content.Load<SpriteFont>("fonts/Arial15"));
            this.fontes.Add("Arial20", Game.Content.Load<SpriteFont>("fonts/Arial20"));
            this.fontes.Add("Courier10", Game.Content.Load<SpriteFont>("fonts/Courier10"));
            this.fontes.Add("Courier20", Game.Content.Load<SpriteFont>("fonts/Courier20"));

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.renderer.Begin();

            foreach (GraphicElts elt in this.elts)
                this.renderer.Draw(this.textures[elt.RefTexture], new Vector2(elt.Position.X, elt.Position.Y), elt.Color);

            foreach (Texte str in this.strs)
                this.renderer.DrawString(this.fontes[str.Police.RefName], str.Message, new Vector2(str.Position.X, str.Position.Y), str.Color);

            this.renderer.End();

            //Une fois qu'on a terminé l'affichage, on efface la liste
            this.elts.Clear();
            this.strs.Clear();

            base.Draw(gameTime);
        }
        #endregion
    }
}
