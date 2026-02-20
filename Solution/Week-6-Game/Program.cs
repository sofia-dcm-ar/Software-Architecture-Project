using System;
using Week6_Game.TemplateMethod_Pattern;

namespace Week6_Game
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Card snatch game ; the players "play" alone
            Console.WriteLine("\n--------------Card snatch Game--------------\n");
            Player playerLeon = new Player("Leon");
            Player playerHelena = new Player("Helena");
            CardGame snatchGame = new CardSnatchGame();
            snatchGame.Play(playerLeon, playerHelena);

            //Guessing game
            Console.WriteLine("\n--------------Guessing card Game--------------\n");
            Player gamer = new Player("Me");
            Player computer = new Player("Computer"); //This is not used because is a solitary game
            CardGame guessing = new GuessingGame();
            guessing.Play(gamer, computer);

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}