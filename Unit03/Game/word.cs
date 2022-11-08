using System;
using System.Collections.Generic;


namespace Unit03
{
    /// <summary>
    /// <para>
    /// The responsibility of take user input and update the word and hangman.
    /// </para>
    /// </summary>
    public class Word
    {
        public string word = "apple";
        public string hint = "_____";  
        // public string hint = "";      
        public bool DoGuess(string guess){
                  
            // Check whether a letter is in a word
            if (word.Contains(guess)){
                int i = 0;
                // Loop through each letter in a word
                foreach (char letter in word){
                    // Do something here...
                    if (letter.ToString() == guess){
                        hint = hint.Remove(i,1).Insert(i,Convert.ToString(guess));                       
                    }
                    i++;
                }
                return true;
            }
            else{
                return false;
            }
                     
        }
        

        public string GetHint(){
            return hint;
        }
        // check if word complete
        public bool wordComplete(string hint, string word){
            if (hint == word){
                return true;
            }
            
            else{
                return false;
            }                     

        }       
    
    }
}

