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
       
        Keys up, down, right, left;
        float _animationSpeed; //FIXME
        float index; //FIXME       
        int _maxIndex; // FIXME      

        bool _movingUpDown = false;
        bool _inCollisionUpDown = false;
        bool _inCollisionRightLeft = false;

        Vector2 _squareOne;    // position de départ du héros   
        public Vector2 SquareOne
        { get { return _squareOne; } set { _squareOne = value; } }
     

        public Heros(Vector2 position, Rectangle? sourceRectangle, Keys up, Keys down, Keys right, Keys left)
            : base(position, sourceRectangle)
        {
           //FIXME
        }

        public void LoadContent(ContentManager content, int maxIndex)
        {
            base.LoadContent(content, @"heros");
            this._maxIndex = maxIndex;
        }

        private void UpdatePosRect()
        {
            //TODO
        }

        private void KeyboardChangeGravity()
        {
            //TODO
        }

        private void AnimationHeros()
        {
            //TODO
        }

        private void KeyboardMoveHeros()
        {
            // Interaction avec les touches de déplacement gauche/droite
            AnimationHeros();
        }

        private void UpdatePhysicEngine(Map carte)
        {
            // Detection des collisions
            // Vers le haut/bas  
            _inCollisionUpDown = false;  //FIXME                         


            // Vers la gauche/droite
            _inCollisionRightLeft = false; //FIXME

           
        }

        public void Update(GameTime gameTime, Map carte, ContentManager content)
        {
            // Mise a jour des positions du rectangle autour du heros (pour la gestion des collisions)
            UpdatePosRect();

            // Interaction avec les touches de changement de gravité
            KeyboardChangeGravity();

            // animation du héros
            KeyboardMoveHeros();

            // Detection des collisions
            UpdatePhysicEngine(carte);
        }

        public void Draw_Hero(SpriteBatch spriteBatch)
        { base.Draw(spriteBatch); }
    }
}
