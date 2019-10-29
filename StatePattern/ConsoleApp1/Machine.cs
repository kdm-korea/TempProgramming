namespace StatePattern
{
    internal class Machine
    {
        private string currentState = string.Empty;

        public void Action(ICharacter character) => currentState = character.Action();

        public string CurrentState() => this.currentState;
    }
}






