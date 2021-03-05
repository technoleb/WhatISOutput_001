using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOutput_001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            mallard.Swim();
            mallard.PerformQuack();
            mallard.PerformFly();
            Console.ReadLine();
        }
    }
    public abstract class Duck
    {
        private readonly IFlyBehavior flyBehavior;
        private readonly IQuackBehavior quackBehavior;

        protected Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
        {
            this.flyBehavior = flyBehavior;
            this.quackBehavior = quackBehavior;
        }

        public abstract void Display();

        public void PerformFly()
        {
            this.flyBehavior.Fly();
        }

        public void PerformQuack()
        {
            this.quackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }
    }

    public interface IFlyBehavior
    {
        void Fly();
    }

    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly!");
        }
    }

    public interface IQuackBehavior
    {
        void Quack();
    }

    public class Quack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack, Quack");
        }
    }

    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("<<  Silence  >>");
        }
    }

    public class Squeak : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeak");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck() : base(new FlyWithWings(), new Squeak())
        {
            Console.WriteLine(Display());
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }
}
