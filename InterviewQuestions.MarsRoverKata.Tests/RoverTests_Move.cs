using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    /// <summary>
    /// Tests for move without the planet changing the location and with the planet changing the location, different mock setups
    /// </summary>
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

        [Test]
        public void RoverLandedNorth_MoveForward_OneStepAhead()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5,5), Direction.North, planet);

            rover.MoveForward();
           
            Assert.AreEqual(Direction.North, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(6, rover.Position.Y);
        }

        [Test]
        public void RoverLandedEast_MoveForward_OneStepAhead()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.East, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(6, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverLandedSouth_MoveForward_OneStepAhead()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.South, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.South, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
        }

        [Test]
        public void RoverLandedWest_MoveForward_OneStepAhead()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(4, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }


        [Test]
        public void RoverLandedNorth_MoveForward_OneStepBehind()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.North, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.North, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
        }

        [Test]
        public void RoverLandedEast_MoveForward_OneStepBehind()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.East, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(4, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverLandedSouth_MoveForward_OneStepBehind()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.South, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.South, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(6, rover.Position.Y);
        }

        [Test]
        public void RoverLandedWest_MoveForward_OneStepBehind()
        {
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => position);
            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(6, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverMoveForward_GetMovedInThePlanet()
        {
            Position destination = new Position(2,3);
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                      .Returns<Position>(position => destination);

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

            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(destination.X, rover.Position.X);
            Assert.AreEqual(destination.Y, rover.Position.Y);
        }
    }
}
