using System;

namespace SpaceInvaders
{
    static class Program
    {
        /// <summary>
        /// Le point d'entrée de l'application
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceInvaders game = new SpaceInvaders())
            {
                game.Run();
            }
        }
    }
}

