using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Card> _cards = new List<Card>();
        Dealer _dealer = new Dealer();
        bool _isPlaying = true;
        int _score = 300;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            // create 13 cards
            for (int i = 1; i < 14; i++)
            {   
                Card card = new Card(i);
                _cards.Add(card);
            }
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while(_isPlaying){
                int firstCard   = drawCard();
                string guess    = getGuess();
                int nextCard    = drawNextCard();
                updateScore(firstCard, nextCard, guess);
                _isPlaying      = playAgain();
            }
        }

        // Purpose: store first card varable
        public int drawCard() 
        {
            // Get a card
            int card = _dealer.drawCard();          
            // Display it
            Console.WriteLine($"The first card is {card}.");
            return card;
        }

        public string getGuess(){
            // Get guess
            Console.WriteLine("Higher or lower? [l/h]");
            string lowHigh = Console.ReadLine();

            // Return the guess
            return lowHigh;
        }

        public int drawNextCard() {
            // Draw another card
            int newCard = _dealer.drawCard();          
            // Display it
            Console.WriteLine($"The first card is {newCard}.");
            return newCard;
        }

        public void updateScore(int firstCard, int nextCard, string guess) {
            //calculate score
            if (firstCard < nextCard && guess =="h"){
                _score = _score + 100;
            }
            else if(firstCard > nextCard && guess =="l"){
                _score = _score + 100;
            }
            else if(firstCard < nextCard && guess =="l"){
                _score = _score - 75;
            }
            else if(firstCard > nextCard && guess =="h"){
                _score = _score - 75;                
            }
            else{
                Console.WriteLine("Sorry, you have to play again.");
            }
            
            // Edit score
            Console.WriteLine($"Your score is {_score}");

            //display score
        }

        public bool playAgain()
        {
            Console.Write("Draw a card? [y/n] ");
            string rollDice = Console.ReadLine();
            if (rollDice == "y"){
                return true; 
            }
            else{
                return false;
            }

            // Ask player if they want to play again and return respons
        }
    }
}
        /// <summary>
        /// Asks the user if they want to roll.
        /// </summary>
        
        
        
        
        // Old code
        
        // public void GetInputs()
        // {
        //     Console.Write("Draw a card? [y/n] ");
        //     string rollDice = Console.ReadLine();
        //     if (rollDice == "y"){
        //         return _isPlaying; 

        //     }

            
        // }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
//         public void DoUpdates()
//         {
//             if (!_isPlaying)
//             {
//                 return;
//             }

//             // _initialScore = 0;
//             // foreach (Card card in _cards)
//             // {
//             //     card.Draw();
//             //     _initialScore += card.points;
//             // }
//             // _totalScore += _initialScore;
//         }

//         /// <summary>
//         /// Displays the dice and the score. Also asks the player if they want to roll again. 
//         /// </summary>
//         public void DoOutputs()
//         {
//             if (!_isPlaying)
//             {
//                 return;
//             }

//             string values = "";
//             foreach (Card card in _cards)
//             {
//                 values += $"{card.value} ";
//             }

//             Console.WriteLine($"You rolled: {values}");
//             // Console.WriteLine($"Your score is: {_totalScore}\n");
//             // _isPlaying = (_initialScore > 0);
//         }
//     }
// }


