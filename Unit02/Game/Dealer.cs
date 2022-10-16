using System;

namespace Unit02.Game 
{
    public class Dealer 
    {
        public Dealer()
        {

        }

        public int drawCard()
        {
            Random rnd = new Random();
            return rnd.Next(1, 14);
        }
    }
}