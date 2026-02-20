using System;
using System.Collections.Generic;
using Week3;

//Week 6 Exercise: Create the themplate for a card game using the template method

namespace Week6_Game.TemplateMethod_Pattern
{
    /// <summary>
    /// Defines the skeleton of a card game algorithm using the Template Method pattern.
    /// </summary>
    /// <remarks>
    /// This class establishes the fixed sequence of steps to play a game: Shuffle, deal, draw and discard cards, and evaluate the winner.
    /// Subclasses implement these specific steps for different card games.
    /// </remarks>
    public abstract class CardGame
    {
        protected List<int> _deck = new List<int>();
        protected RandomDataGenerator _generate = new RandomDataGenerator();

        /// <summary>
        /// Starts the card game using the template algorithm in a predefined order by executing the concrete implementations.
        /// </summary>
        /// <param name="player1">The first <see cref="Player"/>.</param>
        /// <param name="player2">The second <see cref="Player"/>.</param>
        public void Play(Player player1, Player player2)
        {
            Shuffle();
            DealCards(player1, player2);
            while (!Winner(player1, player2))
            {
                DrawCards(player1, player2);
                DiscardCards();
            }
            Console.WriteLine("\nThanks for play!\n");
        }

        /// <summary>
        /// Displays a message that notify the shuffle cards action.
        /// </summary>
        protected void Shuffle()
        {
            Console.WriteLine(
                "\n---------------------------\n" +
                "shuffling cards\ncutting the deck\nshuffling cards" +
                "\n---------------------------\n"
                );
        }

        /// <summary>
        /// Deals cards to the players in a specific manner defined by the concrete game.
        /// </summary>
        /// <param name="player1">The first <see cref="Player"/>.</param>
        /// <param name="player2">The second <see cref="Player"/>.</param>
        protected abstract void DealCards(Player player1, Player player2);

        /// <summary>
        /// Determines whether the <paramref name="player1"/> is the winner based on the winning objectives of the concrete game.
        /// </summary>
        /// <param name="player1">The first <see cref="Player"/>.</param>
        /// <param name="player2">The second <see cref="Player"/>.</param>
        /// <returns><see langword="true"/> if the first <paramref name="player1"/> is the winner; otherwise <see langword="false"/>.</returns>
        protected abstract bool Winner(Player player1, Player player2);

        /// <summary>
        /// Draws cards from the deck in the specific manner defined by the concrete game.
        /// </summary>
        /// <param name="player1">The first <see cref="Player"/>.</param>
        /// <param name="player2">The second <see cref="Player"/>.</param>
        protected abstract void DrawCards(Player player1, Player player2);

        /// <summary>
        /// Discards cards from the deck in the specific manner defined by the concrete game.
        /// </summary>
        protected abstract void DiscardCards();
    }
}
