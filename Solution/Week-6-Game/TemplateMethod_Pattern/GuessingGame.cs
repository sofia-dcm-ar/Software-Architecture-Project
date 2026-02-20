using System;
using System.Collections.Generic;

//Week 6 Exercise: Create a card game bassed on the template
namespace Week6_Game.TemplateMethod_Pattern
{
    /// <summary>
    /// This game allows a user to play multiple rounds against the computer using the keyboard.(I definitely didn't just make this up... :P)
    /// </summary>
    /// <remarks>
    /// <para><c>Gameplay rules:</c></para>
    /// <list type="bullet">
    /// <item><description>There is a deck with cards numbered 1 to 4.</description></item>
    /// <item><description>One card from the deck is placed face down on the table.</description></item>
    /// <item><description>The player must enter the number they believe the card is:</description></item>
    /// <list type="number">
    /// <item><description>If the guess is correct: +1 point.</description></item>
    /// <item><description>If the guess is incorrect: 0 points.</description></item>
    /// </list>
    /// <item><description>The card is then removed from the table (discarded).</description></item>
    /// </list>
    /// <para><c>Winner:</c></para>
    /// <list type="bullet">
    /// <item><description>None. The player decides when to quit by entering 0, which signifies their last turn.</description></item>
    /// <item><description>The final score is displayed, and the game ends.</description></item>
    /// <item><description>If 0 is not entered, a new round begins.</description></item>
    /// </list>
    /// </remarks>

    public class GuessingGame : CardGame
    {
        protected override void DealCards(Player player1, Player player2) { } //In this game cards aren't dealed

        protected override bool Winner(Player player1, Player player2)
        { 
            if (player1.HasFinished)
                Console.WriteLine(player1.ToString());
            return player1.HasFinished;
        }

        protected override void DrawCards(Player player1, Player player2)
        {
            int card = _generate.RandomNumber(5);
            Console.WriteLine("-> settle down a card");
            Console.Write("What number is?   ");
            int adivino = int.Parse(Console.ReadLine());
            if (card == adivino)
            {
                player1.IncrementScore(); //+1 Point
                Console.WriteLine("You Guessed! --> +1 Point");
            }
            else
                Console.WriteLine("no, the number was {0}", card);
            if (adivino == 0)
                player1.DontPlayAnymore();

        }

        protected override void DiscardCards()
        {
            Console.WriteLine("\n--removing the card from the table--\n");
        }
    }
}
