using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03
{
    public class Director
    {
        Word _word = new Word();
        Random randword = new Random();
        bool _isplaying = true;
        bool _isCorrect = true;
        bool _wordComplete = false;
        // string _guess = "";
        TerminalService _terminalService = new TerminalService();
        Jamper _jamper = new Jamper();


        public Director()
        {
        }       

        public void StartGame()
        {
            _jamper.displayJumper();
            while (_isplaying)
            {
                GetInput();
                DoUpdate();
                DoOutput();
            }

        }
        //
        public void GetInput()
        {
            
            string guess = _terminalService.ReadText("Guess a letter [a-z]: ");
            _isCorrect = _word.DoGuess(guess);

        }
        private void DoUpdate()
        {
            /// <summary>
            /// Dispaly new result, include update new hint and parachute 
            /// </summary>
            

            // _word.DoGuess();
            if (!_isCorrect){

                _jamper.lessParachute();
            }
            //check word complete
            
            _wordComplete = _word.wordComplete();                   
            
            
               

        }
        /// <summary>
        /// If it is winning/ losing do update here
        /// </summary>
        private void DoOutput()
        {
            if(_wordComplete){
                _terminalService.WriteText("You win!");
                _isplaying = false;
            }
            else if(!_jamper.checkLifes()){
                _jamper.changeParachute();
                _jamper.displayJumper();
                _terminalService.WriteText("Game over");
                _isplaying = false;
            }
            else 
            {    
                _jamper.displayJumper();
                string hint = _word.GetHint();
                _terminalService.WriteText(hint); 
                
            }
            
            
            // update word & display man life
            
            
        }

       
    }
}
