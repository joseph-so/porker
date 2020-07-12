using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0) 
                Game.DisplayResult(args[0]);
            else
                Console.WriteLine("Please enter the filepath as the parameter");
        }
    }
}
