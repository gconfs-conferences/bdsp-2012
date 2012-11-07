using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VVVVVV
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Heros hero;
        Carte carte;
        Rectangle camera;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D love, complete;
        Song song;
        int play = 1;
        KeyboardState lastKeyboardState;
        KeyboardState currentKeyboardState;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // TODO: Add your initialization logic here
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = Divers.Largeur_Ecran;
            this.graphics.PreferredBackBufferHeight = Divers.Hauteur_Ecran;
            this.graphics.ApplyChanges();
            this.Window.Title = "VVVVVV";
            this.Window.AllowUserResizing = true;
            carte = new Carte("carte.txt");
            hero = new Heros(Divers.CaseDepart_heros, new Rectangle(1, 1, 18, 32), Keys.Up, Keys.Down, Keys.Right, Keys.Left);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hero.LoadContent(Content, 2);
            carte.LoadTextures(Content);
            camera = new Rectangle(0, 0, Divers.Largeur_Ecran / 32, Divers.Hauteur_Ecran / 32);
            love = Content.Load<Texture2D>("ilove");
           complete = Content.Load<Texture2D>("complete");
            song = Content.Load<Song>("VVVVVVsong");
            MediaPlayer.Play(song);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (lastKeyboardState[Keys.Space] == KeyState.Up &&
                currentKeyboardState[Keys.Space] == KeyState.Down)
            {
                play *= -1;
                if (play == -1)
                    MediaPlayer.Pause();
                else
                    MediaPlayer.Resume();
            }
            // Allows the game to exit
            hero.Update(gameTime, carte, ref camera, Content);
            carte.Update(gameTime, Content);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

            carte.Draw(spriteBatch, camera);

            if (hero.position.Y < 512 && hero.position.X < 512 - hero.Width)
                spriteBatch.Draw(love, new Rectangle(138, 0, 179, 153), Color.White);

            if (hero.position.Y == 960 && hero.position.X < 64 - hero.Width)
                spriteBatch.Draw(complete, new Rectangle(Divers.Largeur_Ecran/2 - 125, Divers.Hauteur_Ecran/2 - 20, 250, 40), Color.White);

            hero.Draw_Hero(spriteBatch, camera);
            // TODO: Add your drawing code here          
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
