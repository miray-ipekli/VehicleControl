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
        // Verilen bir 'F' (ileri) komutu i�lendi�inde CommandProcessor'�n arac� do�ru �ekilde ileri hareket ettirip, arac�n y�n�n� de�i�tirmedi�ini do�rulayan test.
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

        // Verilen bir 'L' komutu i�lendi�inde CommandProcessor'�n arac�n sola d�nmesini sa�lay�p (Direction.W), arac�n konumunu de�i�tirmedi�ini do�rulayan test.
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

        // Verilen bir 'R' komutu i�lendi�inde CommandProcessor'�n arac�n sa�a d�nmesini sa�lay�p (Direction.E), arac�n konumunu de�i�tirmedi�ini do�rulayan test.
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

        // Verilen ge�ersiz bir komut (X) i�lendi�inde CommandProcessor'�n bir InvalidOperationException f�rlatmas�n� ve do�ru hata mesaj�n� do�rulayan test.
        [Test]
        public void ProcessCommands_ShouldThrowException_OnInvalidCommand()
        {
            //Arrange
            CommandProcessor processor = new CommandProcessor();
            Vehicle vehicle = new Vehicle(3, 2, Direction.N);
            string commands = "X";

            //Action & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => processor.ProcessCommands(vehicle, commands));
            Assert.That(ex.Message, Is.EqualTo("Ge�ersiz komut: X"));
        }

        // Verilen karma��k bir komut dizisi i�lendi�inde arac�n do�ru �ekilde hareket etti�ini ve d�nd���n� do�rulayan test.
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

        // Verilen bo� bir komut dizisi i�lendi�inde arac�n konumunun ve y�n�n�n de�i�medi�ini do�rulayan test.
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
