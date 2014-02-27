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

        [Test]
        public void RoverLandedNorth_MoveForward_OneStepAhead()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5,5), Direction.North, planet);

            rover.MoveForward();
           
            Assert.AreEqual(Direction.North, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(6, rover.Position.Y);
        }

        [Test]
        public void RoverLandedEast_MoveForward_OneStepAhead()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), Direction.East, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(6, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverLandedSouth_MoveForward_OneStepAhead()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), Direction.South, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.South, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
        }

        [Test]
        public void RoverLandedWest_MoveForward_OneStepAhead()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            rover.MoveForward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(4, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }


        [Test]
        public void RoverLandedNorth_MoveForward_OneStepBehind()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), Direction.North, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.North, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
        }

        [Test]
        public void RoverLandedEast_MoveForward_OneStepBehind()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), Direction.East, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(4, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverLandedSouth_MoveForward_OneStepBehind()
        {
            SetDefaultPlanet();
            Rover rover = new Rover(new Position(5, 5), Direction.South, planet);

            rover.MoveBackward();

            Assert.AreEqual(Direction.South, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(6, rover.Position.Y);
        }

        [Test]
        public void RoverLandedWest_MoveForward_OneStepBehind()
        {
            SetDefaultPlanet();
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
        public void RoverMoveForward_HitObstacle_ThrowsException()
        {
            Position destination = new Position(6,7);
           planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                            .Returns<Position>(position => destination);
            planetMock.Setup(p => p.IsClear(It.IsAny<Position>())).Returns(false);

            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            Assert.Throws<ObstacleOnWayException>(rover.MoveForward,
                string.Format("Can't move to (%0, %1) due to an obstacle on the planet", destination.X, destination.Y));
        }


        [Test]
        public void RoverMoveBackward_HitObstacle_ThrowsException()
        {
            Position destination = new Position(6, 7);
            planetMock.Setup(p => p.CalculateOutOfBoundaryPosition(It.IsAny<Position>()))
                             .Returns<Position>(position => destination);
            planetMock.Setup(p => p.IsClear(It.IsAny<Position>())).Returns(false);

            Rover rover = new Rover(new Position(5, 5), Direction.West, planet);

            Assert.Throws<ObstacleOnWayException>(rover.MoveBackward,
                string.Format("Can't move to (%0, %1) due to an obstacle on the planet", destination.X, destination.Y));
        }
    }
}
