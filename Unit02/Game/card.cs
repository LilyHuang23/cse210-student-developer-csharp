using System;


namespace Unit02.Game
{
    // TODO: Implement the Card class as follows...
    // 1) Add the class declaration. Use the following class comment.
    public class Card{
        public int value;
        public int points;

        public Card(){
            value = 1;
            points = 300;
        }
        public void Draw(){
            Random r = new Random();
            value = r.Next(1,14);
            if (value == 1){
                points = 100;
            }
            // else if(value == 5){
            //     points = 50;
            // }
            else {
                points = -75;
            }
        
        }

    }

    }
        /// <summary>
        /// A small cube with a different number of spots on each of its six sides.
        /// 
        /// The responsibility of Card is to keep track of its currently rolled value and the points its
        /// worth.
        /// </summary> 


    // 2) Create the class constructor. Use the following method comment.

        /// <summary>
        /// Constructs a new instance of Card.
        /// </summary>

    
    // 3) Create the Roll() method. Use the following method comment.
        
        /// <summary>
        /// Generates a new random value and calculates the points for the Card. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
        