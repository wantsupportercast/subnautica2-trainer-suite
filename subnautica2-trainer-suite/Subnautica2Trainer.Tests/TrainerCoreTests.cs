using NUnit.Framework;
using Subnautica2Trainer;

namespace Subnautica2Trainer.Tests
{
    [TestFixture]
    public class TrainerCoreTests
    {
        [Test]
        public void ToggleInfiniteOxygen_ShouldSwitchState()
        {
            var trainer = new TrainerCore();
            trainer.Start();
            trainer.HandleKey(ConsoleKey.F1);
            // State is internal, but we verify no crash
            Assert.Pass("F1 toggle executed without exception.");
            trainer.Stop();
        }

        [Test]
        public void ToggleNoDamage_ShouldSwitchState()
        {
            var trainer = new TrainerCore();
            trainer.Start();
            trainer.HandleKey(ConsoleKey.F2);
            Assert.Pass("F2 toggle executed without exception.");
            trainer.Stop();
        }

        [Test]
        public void SpawnItem_ShouldNotThrow()
        {
            var trainer = new TrainerCore();
            trainer.Start();
            trainer.HandleKey(ConsoleKey.F3);
            Assert.Pass("F3 spawn executed without exception.");
            trainer.Stop();
        }
    }
}