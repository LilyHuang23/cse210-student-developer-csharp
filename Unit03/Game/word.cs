using System;
using System.Collections.Generic;
using System.IO;


namespace Unit03
{
    /// <summary>
    /// <para>
    /// The responsibility of take user input and update the word and hangman.
    /// </para>
    /// </summary>
    public class Word
    {
        string randword;
        string hint;
        // get a random word from the file

        public Word(){
            getWord();
            wordToHint();
        }                
        public void getWord()
        {
            List<string> lines = new List<string>(File.ReadLines("Game/sample.txt"));

            Random rand = new Random();
            int randomIndex = rand.Next(0, lines.Count); // pick a random number
            randword = lines[randomIndex];

        }
        // replace the word to underline

        public void wordToHint()
        {
            hint = randword;
            int i = 0;
            foreach (char letter in randword)
            
            {
                
                hint = hint.Remove(i, 1).Insert(i, Convert.ToString("_"));
                i++;
            }

        }
        public bool DoGuess(string guess)
        {

            // Check whether a letter is in a word
            if (randword.Contains(guess))
            {
                int i = 0;
                // Loop through each letter in a word
                foreach (char letter in randword)
                {
                    // Do something here...
                    if (letter.ToString() == guess)
                    {
                        hint = hint.Remove(i, 1).Insert(i, Convert.ToString(guess));
                    }
                    i++;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        public string GetHint()
        {
            return hint;
        }



        // check if word complete
        public bool wordComplete()
        {
            if (hint == randword)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
    }
}




