using System;
using System.Collections.Generic;

namespace Unit03
{
    public class Director
    {
        Word _word = new Word();
        bool _isplaying = true;
        bool _isCorrect = true;
        bool _wordComplete = true;
        // string _guess = "";
        TerminalService _terminalService = new TerminalService();
        Jamper _jamper = new Jamper();


        public Director()
        {
        }       

        public void StartGame()
        {
           
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
            else if(_wordComplete == true){
                _terminalService.WriteText("You win!");
            }
            _jamper.displayJumper();
            string hint = _word.GetHint();
            _terminalService.WriteText(hint); 
            
               

        }
        /// <summary>
        /// If it is winning/ losing do update here
        /// </summary>
        private void DoOutput()
        {
            if(!_isplaying){
                _jamper.changeParachute();
                _terminalService.WriteText("Game over");

            }
            else 
            {    
                _terminalService.WriteText("You win!");
                
            }
            
            // update word & display man life
            
            
        }

       
    }
}
