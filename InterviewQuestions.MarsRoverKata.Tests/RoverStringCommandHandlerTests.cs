using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    [TestFixture]
    class RoverStringCommandHandlerTests
    {
        private Mock<IRover> roverMock;
        private IRover rover;
        private RoverStringCommandHandler commandHandler;

        [SetUp]
        public void InitMock()
        {
            roverMock = new Mock<IRover>();
            rover = roverMock.Object;
            commandHandler = new RoverStringCommandHandler(rover);
        }

        [Test]
        public void F_MovedForward()
        {
            commandHandler.HandleString("F");

            roverMock.Verify(r => r.MoveForward());
        }


        [Test]
        public void B_MovedBackward()
        {
            commandHandler.HandleString("B");

            roverMock.Verify(r => r.MoveBackward());
        }

        [Test]
        public void CombinationOfCommands_MoveAccordingly()
        {
            //Use a stringbuilder to verify MoveForward()/MoveBackward was called in the correct order.
            StringBuilder sb = new  StringBuilder();

            roverMock.Setup(r => r.MoveForward()).Callback(() => sb.Append("F"));
            roverMock.Setup(r => r.MoveBackward()).Callback(() => sb.Append("B"));

            string testString = "BFBFBFBBBFFFFFFFFF";
            commandHandler.HandleString(testString);

            Assert.AreEqual(testString, sb.ToString());
        }

        [Test]
        public void UndefinedCharacter_ThrowsException()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => commandHandler.HandleString("X"));
        }
    }
}
