using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    [TestFixture]
    class RoverTests
    {
        
        [Test]
        public void RoverLandedNorth_MoveForward_OneStepAhead()
        {
            Rover rover = new Rover(new Position(5,5), Direction.North);

            rover.MoveForward();
           
            Assert.AreEqual(Direction.North, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(6, rover.Position.Y);
        }

        [Test]
        public void RoverLandedEast_MoveForward_OneStepAhead()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.East);

            rover.MoveForward();

            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(6, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverLandedSouth_MoveForward_OneStepAhead()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.South);

            rover.MoveForward();

            Assert.AreEqual(Direction.South, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
        }

        [Test]
        public void RoverLandedWest_MoveForward_OneStepAhead()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.West);

            rover.MoveForward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(4, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }


        [Test]
        public void RoverLandedNorth_MoveForward_OneStepBehind()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.North);

            rover.MoveBackward();

            Assert.AreEqual(Direction.North, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(4, rover.Position.Y);
        }

        [Test]
        public void RoverLandedEast_MoveForward_OneStepBehind()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.East);

            rover.MoveBackward();

            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(4, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }

        [Test]
        public void RoverLandedSouth_MoveForward_OneStepBehind()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.South);

            rover.MoveBackward();

            Assert.AreEqual(Direction.South, rover.Direction);
            Assert.AreEqual(5, rover.Position.X);
            Assert.AreEqual(6, rover.Position.Y);
        }

        [Test]
        public void RoverLandedWest_MoveForward_OneStepBehind()
        {
            Rover rover = new Rover(new Position(5, 5), Direction.West);

            rover.MoveBackward();

            Assert.AreEqual(Direction.West, rover.Direction);
            Assert.AreEqual(6, rover.Position.X);
            Assert.AreEqual(5, rover.Position.Y);
        }
    }
}
