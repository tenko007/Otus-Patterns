using NUnit.Framework;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class CheckFuelCommandTests
    {
        [Test]
        public void CheckFuelCommandWithEnoughFuelDoesNotThrow()
        {
            // Если топлива достаточно, команда не выбрасывает никаких исключений

            Fuel fuel = new Fuel(10, 100, 10);
            CheckFuelCommand сheckFuelCommand = new CheckFuelCommand(fuel);

            Assert.DoesNotThrow(() => сheckFuelCommand.Execute());
        }

        [Test]
        public void CheckFuelCommandThrow()
        {
            // Если топлива недостаточно, команда выбрасывает исключение CommandException

            Fuel fuel = new Fuel(9, 100, 10);
            CheckFuelCommand сheckFuelCommand = new CheckFuelCommand(fuel);

            Assert.Throws<CommandException>(() => сheckFuelCommand.Execute());
        }
    }
}