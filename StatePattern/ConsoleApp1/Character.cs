namespace StatePattern
{
    internal class Character
    {
        private string currentState = string.Empty;

        public void Action(ICharacter character) => currentState = character.Action();

        public override string ToString() => this.currentState;
    }
}






