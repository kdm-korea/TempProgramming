using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args) {
            Machine machine = new Machine();

            machine.Action(new Walk());
            Console.WriteLine(machine.CurrentState().ToString());

            machine.Action(new Idle());
            Console.WriteLine(machine.CurrentState().ToString());

            machine.Action(new Fight());
            Console.WriteLine(machine.CurrentState().ToString());
        }
    }
}






