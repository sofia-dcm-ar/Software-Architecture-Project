using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Week 6 Exercise: Create a card game bassed on the template

namespace Week6_Game.TemplateMethod_Pattern
{
    /// <summary>
    /// Implements a simplified variation of the <c>"Steal the Pile"</c> (Casita Robada) card game.
    /// </summary>
    /// <remarks>
    /// <para><c>Gameplay rules:</c></para>
    /// <list type="bullet">
    /// <item><description>Each player starts with 4 cards.</description></item>
    /// <item><description>There is a central deck of 8 cards.</description></item>
    /// <item>
    /// <description>
    /// A card is drawn from the deck and placed on the table:
    /// <list type="number">
    /// <item><description>If the player has a matching card: +1 point (matching card is discarded).</description></item>
    /// <item><description>If no match: no points awarded.</description></item>
    /// </list>
    /// </description>
    /// </item>
    /// </list>
    /// <para>The game ends when the deck is empty or a player reaches 4 points.</para>
    /// <para><c>Winner:</c>The player with the highest score, or a tie if scores are equal.</para>
    /// </remarks>
    public class CardSnatchGame : CardGame
    {
        protected override void DealCards(Player player1, Player player2)
        {
            //set the deck
            for (int i = 0; i<8; i++)
            {
                base._deck.Add(_generate.RandomNumber());//add a card between 1 and 12
            }
            //DealCards cards to players
            Console.WriteLine("Dealing cards to the players\n");
            for (int i = 0; i<4; i++)
            {
                player1.ReceiveCard(_generate.RandomNumber(), i);
            }
            for (int i = 0; i<4; i++)
            {
                player2.ReceiveCard(_generate.RandomNumber(), i);
            }
        }

        protected override bool Winner(Player player1, Player player2)
        {
            if ((base._deck.Count == 0)||(player1.Score==4)||(player2.Score==4))
            { //the deck finished or a player reach 4 points

                if (base._deck.Count == 0)
                    Console.WriteLine("No more cards in the deck, finish game\n");

                if ((player1.Score==4)||(player2.Score==4))
                    Console.WriteLine("\n---- A player reached 4 points ----\n");

                if (player1.HasSameScore(player2))
                {
                    Console.WriteLine("Tie between players, Score: {0}\n", player1.Score);
                    return true;
                }

                if (player1.HasHigherScoreThan(player2))
                {
                    Console.WriteLine("-> Winner:\n{0}", player1.ToString());
                    return true;
                }

                else
                {
                    Console.WriteLine("Winner:\n{0}", player2.ToString());
                    return true;
                }
            }
            return false;
        }

        protected override void DrawCards(Player player1, Player player2)
        {
            int card = base._deck[0]; //take the next card
            Console.WriteLine("Placing card on the table: {0}", card);

            bool player1HasIt = player1.HasCard(card);
            if (player1HasIt)
            {
                Console.WriteLine("Player {0} match the card {1} --> +1 Point", player1.UserName, card);
                player1.IncrementScore();
            }

            bool player2HasIt = player2.HasCard(card);
            if (player2HasIt)
            {
                Console.WriteLine("Player {0} match the card {1} --> +1 Point", player2.UserName, card);
                player2.IncrementScore();
            }

            if (!player1HasIt && !player2HasIt)
                Console.WriteLine("No one match the card");
        }

        protected override void DiscardCards()
        {
            Console.WriteLine("\n--Discarding used card--\n");
            base._deck.RemoveAt(0); 
        }
    }
}
