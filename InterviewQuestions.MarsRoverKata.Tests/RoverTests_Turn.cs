using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverTests_Turn
    {
        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        public void TurnRight(Direction initialDirection, Direction destinationDirection)
        {
            Rover rover = new Rover(new Position(5,5), initialDirection, new Mars(10,10));

            rover.TurnRight();

            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
            Assert.AreEqual(destinationDirection, rover.Direction);
        }

        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.East, Direction.North)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.West, Direction.South)]
        public void TurnLeft(Direction initialDirection, Direction destinationDirection)
        {
            Rover rover = new Rover(new Position(5, 5), initialDirection, new Mars(10,10));
            
            rover.TurnLeft();

            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
            Assert.AreEqual(destinationDirection, rover.Direction);
        }
    }
}