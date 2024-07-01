using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using VehicleControl.Commands;
using VehicleControl.Enums;
using VehicleControl.Models;
using VehicleControl.Services;

namespace VehicleControl.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        // Verilen bir 'F' (ileri) komutu iþlendiðinde CommandProcessor'ýn aracý doðru þekilde ileri hareket ettirip, aracýn yönünü deðiþtirmediðini doðrulayan test.
        [Test]
        public void ProcessCommands_ShouldMoveForward()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 2, Direction.N);
            string commands = "F";

            //Action
            processor.ProcessCommands(vehicle, commands);

            //Assert
            Assert.AreEqual(3, vehicle.Position.X);
            Assert.AreEqual(3, vehicle.Position.Y);
            Assert.AreEqual(Direction.N, vehicle.Direction);
        }

        // Verilen bir 'L' komutu iþlendiðinde CommandProcessor'ýn aracýn sola dönmesini saðlayýp (Direction.W), aracýn konumunu deðiþtirmediðini doðrulayan test.
        [Test]
        public void ProcessCommands_ShouldRotateLeft()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 2, Direction.N);
            string commands = "L";

            //Action
            processor.ProcessCommands(vehicle, commands);

            //Assert
            Assert.AreEqual(3, vehicle.Position.X);
            Assert.AreEqual(2, vehicle.Position.Y);
            Assert.AreEqual(Direction.W, vehicle.Direction);
        }

        // Verilen bir 'R' komutu iþlendiðinde CommandProcessor'ýn aracýn saða dönmesini saðlayýp (Direction.E), aracýn konumunu deðiþtirmediðini doðrulayan test.
        [Test]
        public void ProcessCommands_ShouldRotateRight()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 2, Direction.N);
            string commands = "R";

            //Action
            processor.ProcessCommands(vehicle, commands);

            //Assert
            Assert.AreEqual(3, vehicle.Position.X);
            Assert.AreEqual(2, vehicle.Position.Y);
            Assert.AreEqual(Direction.E, vehicle.Direction);
        }

        // Verilen geçersiz bir komut (X) iþlendiðinde CommandProcessor'ýn bir InvalidOperationException fýrlatmasýný ve doðru hata mesajýný doðrulayan test.
        [Test]
        public void ProcessCommands_ShouldThrowException_OnInvalidCommand()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 2, Direction.N);
            string commands = "X";

            //Action & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => processor.ProcessCommands(vehicle, commands));
            Assert.That(ex.Message, Is.EqualTo("Geçersiz komut: X"));
        }

        // Verilen karmaþýk bir komut dizisi iþlendiðinde aracýn doðru þekilde hareket ettiðini ve döndüðünü doðrulayan test.
        [Test]
        public void ProcessCommands_ShouldHandleComplexSequence()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 2, Direction.N);
            string commands = "FFRFFLFFFFFL";

            //Action
            processor.ProcessCommands(vehicle, commands);

            //Assert
            Assert.AreEqual(5, vehicle.Position.X);
            Assert.AreEqual(9, vehicle.Position.Y);
            Assert.AreEqual(Direction.W, vehicle.Direction);
        }

        // Verilen boþ bir komut dizisi iþlendiðinde aracýn konumunun ve yönünün deðiþmediðini doðrulayan test.
        [Test]
        public void ProcessCommands_ShouldNotChangePosition_OnEmptyCommand()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 3, Direction.E);
            string commands = "";

            //Action
            processor.ProcessCommands(vehicle, commands);

            //Assert
            Assert.AreEqual(3, vehicle.Position.X);
            Assert.AreEqual(3, vehicle.Position.Y);
            Assert.AreEqual(Direction.E, vehicle.Direction);
        }
    }
}
