using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    [TestFixture]
    class RoverTests_Move
    {
        private Mock<IPlanet> planetMock;
        private IPlanet planet;

        [SetUp]
        public void Init()
        {
            planetMock = new Mock<IPlanet>();
            planet = planetMock.Object;
        }


        [TestCase(Direction.North, 5, 6)]
        [TestCase(Direction.East, 6, 5)]
        [TestCase(Direction.South, 5, 4)]
        [TestCase(Direction.West, 4, 5)]
        public void MoveForward_OneStepAhead(Direction initialDirection, int destinationX, int destinationY)
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), initialDirection, planet);

            rover.MoveForward();

            Assert.AreEqual(initialDirection, rover.Direction);
            Assert.AreEqual(destinationX, rover.Position.X);
            Assert.AreEqual(destinationY, rover.Position.Y);
        }

        [TestCase(Direction.North, 5, 4)]
        [TestCase(Direction.East, 4, 5)]
        [TestCase(Direction.South, 5, 6)]
        [TestCase(Direction.West, 6, 5)]
        public void MoveBackward_OneStepBehind(Direction initialDirection, int destinationX, int destinationY)
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), initialDirection, planet);

            rover.MoveBackward();

            Assert.AreEqual(initialDirection, rover.Direction);
            Assert.AreEqual(destinationX, rover.Position.X);
            Assert.AreEqual(destinationY, rover.Position.Y);
        }

        [Test]
        public void RoverMoveForward_GetMovedInThePlanet()
        {
            Position destination = new Position(2, 3);
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => destination);
            planetMock.Setup(p => p.IsClear(It.IsAny<Position>())).Returns(true);

            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(destination.X, rover.Position.X);
            Assert.AreEqual(destination.Y, rover.Position.Y);
        }

        [Test]
        public void RoverMoveBackward_GetMovedInThePlanet()
        {
            Position destination = new Position(2, 3);
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => destination);
            planetMock.Setup(p => p.IsClear(It.IsAny<Position>())).Returns(true);

            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(destination.X, rover.Position.X);
            Assert.AreEqual(destination.Y, rover.Position.Y);
        }

        [Test]
        public void RoverMoveForward_HitObstacle_ThrowsException([Range(0, 3)] Direction direction)
        {
            var destination = SetUpPlanet_WayNotClear();

            Rover rover = new Rover(new Position(5, 5), direction, planet);

            Assert.Throws<ObstacleOnWayException>(rover.MoveForward,
                string.Format("Can't move to (%0, %1) due to an obstacle on the planet", destination.X, destination.Y));
        }

        [Test]
        public void RoverMoveBackward_HitObstacle_ThrowsException([Range(0, 3)]Direction direction)
        {
            Position destination = SetUpPlanet_WayNotClear();

            Rover rover = new Rover(new Position(5, 5), direction, planet);

            Assert.Throws<ObstacleOnWayException>(rover.MoveBackward,
                string.Format("Can't move to (%0, %1) due to an obstacle on the planet", destination.X, destination.Y));
        }




        /// <summary>
        /// The scenario for most test cases -
        /// * move is in boundaries 
        /// * way is clear
        /// </summary>
        private void SetDefaultPlanet()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);

            planetMock.Setup(p => p.IsClear(It.IsAny<Position>())).Returns(true);
        }


        private Position SetUpPlanet_WayNotClear()
        {
            Position destination = new Position(6, 7);
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                .Returns<Position>(position => destination);
            planetMock.Setup(p => p.IsClear(It.IsAny<Position>())).Returns(false);
            return destination;
        }
    }
}