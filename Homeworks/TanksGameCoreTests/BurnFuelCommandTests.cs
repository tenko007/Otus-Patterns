using NUnit.Framework;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class BurnFuelCommandTests
    {
        [Test]
        public void BurnFuelCommandDecreasesFuelAmount()
        {
            // Команда сжигания топлива уменьшает количество топлива

            Fuel fuel = new Fuel(100, 100, 50);

            BurnFuelCommand burnFuelCommand = new BurnFuelCommand(fuel);

            Assert.AreEqual(fuel.Amount, 100);
            burnFuelCommand.Execute();
            Assert.AreEqual(fuel.Amount, 50);
            burnFuelCommand.Execute();
            Assert.AreEqual(fuel.Amount, 0);
            burnFuelCommand.Execute();
            Assert.AreEqual(fuel.Amount, -50);
        }
    }
}