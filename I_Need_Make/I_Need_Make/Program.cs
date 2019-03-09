using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_Make
{
    class Program
    {
        static void Main(string[] args) {
            TryCatchMethod();
        }

        private static void TryCatchMethod() {
            try {
                FstTryMethod();
            }
            catch (IndexOutOfRangeException) {

                throw;
            }
        }

        private static void FstTryMethod(){
            int a;
            int b;
            throw new IndexOutOfRangeException();
        }

    }

    class MapEx : IMapExperiment<Program>
    {

    }

    interface Duck
    {
        void quack();
        void fly();
    }

    public class MallardDuck : Duck
    {
        public void fly() {
            Console.WriteLine("Quack");
        }

        public void quack() {
            Console.WriteLine("Im flying");
        }
    }

    interface Turkey
    {
        void Gobble();
        void fly();
    }

    public class WildTurkey : Turkey
    {
        public void fly() {
            Console.WriteLine("Gobble gobble");
        }

        public void Gobble() {
            Console.WriteLine("I'm flying a short distance");
        }
    }

    class TurkeyAdapter : Duck
    {
        Turkey turkey;

        public TurkeyAdapter(Turkey turkey) {
            this.turkey = turkey;
        }

        public void fly() {
            turkey.fly();
        }

        public void quack() {
            turkey.Gobble();
        }
    }

    class DuckTestDrive
    {
        public void ExMain() {
            MallardDuck mallardDuck = new MallardDuck(); 
            WildTurkey turkey = new WildTurkey();
            TurkeyAdapter turkeyAdapter = new TurkeyAdapter(turkey);

            TurkeyTalk(turkeyAdapter);

            MallardTalk(mallardDuck);
            MallardTalk(turkeyAdapter);

            MallardDuck duck = new MallardDuck();
        }

        private void TurkeyTalk(TurkeyAdapter turkeyAdapter) {
            turkeyAdapter.fly();
            turkeyAdapter.quack();
        }

        private void MallardTalk(Duck duck) {
            duck.fly();
        }
    }
}