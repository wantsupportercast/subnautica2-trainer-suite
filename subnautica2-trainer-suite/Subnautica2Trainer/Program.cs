using System;
using System.Threading;

namespace Subnautica2Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Subnautica 2 Trainer Suite v1.0");
            Console.WriteLine("Press F1 to toggle infinite oxygen.");
            Console.WriteLine("Press F2 to toggle no damage.");
            Console.WriteLine("Press F3 to spawn item.");
            Console.WriteLine("Press Escape to exit.");

            var trainer = new TrainerCore();
            trainer.Start();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                        break;
                    trainer.HandleKey(key);
                }
                Thread.Sleep(50);
            }

            trainer.Stop();
            Console.WriteLine("Trainer exited.");
        }
    }
}