namespace Unit04.Game.Casting{
        /// <summary>
        /// <para>An item of cultural or historical interest.</para>
        /// <para>
        /// The responsibility of an Artifact is to provide a message about itself.
        /// </para>
        /// </summary>
    class Artifact : Actor{
        private int _value;
        /// <summary>
        /// Constructs a new instance of Artifact.
        /// </summary>
        public Artifact(){
            _value = 0 ;
        }

        /// <summary>
        /// Gets the artifact's message.
        /// </summary>
        /// <returns>The message as a string.</returns>
        public int GetValue(){
            return _value;
        }
        
        /// <summary>
        /// Sets the artifact's score to the given value.
        /// </summary>
        /// <param name="message">The given message.</param>
        public void SetValue(int value){
            _value = value;
        }
    }
}
