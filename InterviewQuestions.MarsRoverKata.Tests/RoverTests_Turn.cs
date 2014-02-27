using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverTests_Turn
    {
        [Test]
        public void North_TurnRight_East()
        {
            Rover rover = new Rover(new Position(5,5), Direction.North);

            rover.TurnRight();

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [Test]
        public void East_TurnRight_East()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.East);

            rover.TurnRight();

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [Test]
        public void South_TurnRight_East()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.South);

            rover.TurnRight();

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [Test]
        public void West_TurnRight_East()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.West);

            rover.TurnRight();

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [Test]
        public void North_TurnLeft_East()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.North);
            
            rover.TurnLeft();

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [Test]
        public void East_TurnLeft_North()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.East);

            rover.TurnLeft();

            Assert.AreEqual(Direction.North, rover.Direction);
        }
        [Test]
        public void South_TurnLeft_East()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.South);

            rover.TurnLeft();

            Assert.AreEqual(Direction.East, rover.Direction);
        }
        [Test]
        public void West_TurnLeft_South()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.West);

            rover.TurnLeft();

            Assert.AreEqual(Direction.South, rover.Direction);
        }
    }
}