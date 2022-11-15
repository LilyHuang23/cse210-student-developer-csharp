using System;
/// use list///
using System.Collections.Generic;

namespace Unit03
{
    /// <summary>
    /// <para>
    /// The responsibility of display the hangman in terminal.
    /// </para>
    /// </summary>
    public class Jamper
    {
        List<string> manList = new List<string>();


        public Jamper() {
            createJamper();

        }
        public void createJamper(){
            manList.Add(@"   -----   ");
            manList.Add(@"  /     \  ");
            manList.Add(@"  -------  ");
            manList.Add(@"  \     /  ");
            manList.Add(@"   \   /   ");
            manList.Add(@"     O     ");
            manList.Add(@"    /|\    ");
            manList.Add(@"    / \    ");
            manList.Add(@"           ");
            manList.Add(@"~ ~ ~ ~ ~ ~");
        
        }
        public void displayJumper(){
            // print the list
            manList.ForEach(Console.WriteLine);
            Console.WriteLine();

        }
        
        /// <summary>
        /// If the guess is wroung, get rid of one line of life
        /// </summary>
        // less life
        public void lessParachute(){    
            
            if (manList.Count != 5){
                manList.RemoveAt(0);
            }
        }

       
        /// <summary>
        /// Change the man's head from O to X.
        /// </summary>
        public void changeParachute(){

            manList[0] = "     X     ";
        }
        /// <summary>
        /// chaeck life is enough, if not thee game will end
        /// </summary>
        public bool checkLifes()
        {
            if (manList.Count > 5){
                return true;
            }
            else {
                return false;
            }

        }

    }
}
