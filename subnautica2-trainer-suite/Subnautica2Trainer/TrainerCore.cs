using System;
using System.Collections.Generic;
using System.Threading;

namespace Subnautica2Trainer
{
    public class TrainerCore
    {
        private bool running;
        private Thread workerThread;
        private Dictionary<string, bool> toggles;

        public TrainerCore()
        {
            toggles = new Dictionary<string, bool>
            {
                { "infiniteOxygen", false },
                { "noDamage", false }
            };
        }

        public void Start()
        {
            running = true;
            workerThread = new Thread(WorkerLoop);
            workerThread.Start();
        }

        public void Stop()
        {
            running = false;
            workerThread?.Join();
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    toggles["infiniteOxygen"] = !toggles["infiniteOxygen"];
                    Console.WriteLine($"Infinite Oxygen: {toggles["infiniteOxygen"]}");
                    break;
                case ConsoleKey.F2:
                    toggles["noDamage"] = !toggles["noDamage"];
                    Console.WriteLine($"No Damage: {toggles["noDamage"]}");
                    break;
                case ConsoleKey.F3:
                    Console.WriteLine("Spawning item... (simulated)");
                    break;
            }
        }

        private void WorkerLoop()
        {
            while (running)
            {
                if (toggles["infiniteOxygen"])
                {
                    // Simulate memory write for infinite oxygen
                    Console.WriteLine("[Worker] Writing infinite oxygen value...");
                }
                if (toggles["noDamage"])
                {
                    // Simulate memory write for no damage
                    Console.WriteLine("[Worker] Writing no damage value...");
                }
                Thread.Sleep(1000);
            }
        }
    }
}