using System;
using System.Numerics;
using Week1;

//Week 6 Exercise: Create players for the card games

namespace Week6_Game
{
    /// <summary>
    /// Represents a player in the game, with username, score, card collection, and play status.
    /// </summary>
    /// <remarks>The <see cref="Player"/> class provides methods to manage a player's score, track their
    /// participation status, and handle their cards.</remarks>
    public class Player 
    {
        private string _userName;
        private int _score;
        private bool _hasFinished;
        private int[] _cards;

        public Player(string userName)
        {
            _userName = userName;
            _score = 0;
            _hasFinished = false;
            _cards = new int[4];
        }

        public string UserName { get => _userName; }
        public int Score { get => _score; }

        public bool HasFinished { get => _hasFinished; }

        /// <summary>
        /// Increments the score one point.
        /// </summary>
        public void IncrementScore()
        {
            _score++;
        }

        /// <summary>
        /// Marks the current play session as finished. The current <see cref="Player"/> don't play anymore.
        /// </summary>
        public void DontPlayAnymore()
        {
            _hasFinished = true;
        }

        /// <summary>
        /// Adds a specified card to the player's current hand.
        /// </summary>
        /// <remarks>
        /// This method manages the player's hand, ensuring the card is correctly stored among the 4 available slots the player can hold.
        /// </remarks>
        /// <param name="card">The card (<see cref="int"/>) to be added to the hand.</param>
        /// <param name="index">The hand index where the card is added.</param>
        public void ReceiveCard(int card, int index)
        {
            _cards[index]=card;
        }

        /// <summary>
        /// Determines whether the player's hand contains the card.
        /// </summary>
        /// <param name="search">The card (<see cref="int"/>) to find.</param>
        /// <returns><see langword="true"/> if card is found; otherwise <see langword="false"/>.</returns>
        public bool HasCard(int search)
        {
            int i = 0;
            foreach (int card in _cards)
            {
                if (search == card)
                {
                    _cards[i]=0; //the hand slot is 0 because doesn't exist a 0 card
                    return true;
                }
                i++;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("Player: {0}\nScore: {1}", _userName, _score);
        }

        /// <summary>
        /// Determines whether the current instance score is equal to another <see cref="Player"/> score.
        /// </summary>
        /// <param name="player">The object to compare with the current instance.</param>
        /// <returns><see langword="true"/> if the scores are considered equal; otherwise, <see langword="false"/>.</returns>
        public bool HasSameScore(Player player)
        {
            return (_score==(player)._score);
        }

        /// <summary>
        /// Determines whether the current instance score is greater than another <see cref="Player"/> score.
        /// </summary>
        /// <param name="player">The object to compare with the current instance.</param>
        /// <returns><see langword="true"/> if the current instance score is greater; otherwise, <see langword="false"/>.</returns>
        public bool HasHigherScoreThan(Player player)
        {
            return (_score>(player)._score);
        }
    }
}
