using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args) {
            Character character = new Character();

            character.Action(new Walk());
            Console.WriteLine(character.ToString());

            character.Action(new Idle());
            Console.WriteLine(character.ToString());

            character.Action(new Fight());
            Console.WriteLine(character.ToString());
        }
    }
}






