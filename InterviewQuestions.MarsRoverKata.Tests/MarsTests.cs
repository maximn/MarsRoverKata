using NUnit.Framework;

namespace InterviewQuestions.MarsRoverKata.Tests
{
    [TestFixture]
    public class MarsTests
    {
        [Test]
        public void Mars_CalculateOutOfBoundaryHorizontal()
        {
            Mars mars = new Mars(10, 10);

            Position position = mars.CalculateOutOfBoundaryPosition(new Position(10, 5));

            Assert.AreEqual(0, position.X);
            Assert.AreEqual(5, position.Y);
        }

        [Test]
        public void Mars_CalculateUnderBoundaryHorizontal()
        {
            Mars mars = new Mars(10, 10);

            Position position = mars.CalculateOutOfBoundaryPosition(new Position(-1, 5));

            Assert.AreEqual(9, position.X);
            Assert.AreEqual(5, position.Y);
        }

        [Test]
        public void Mars_CalculateOutOfBoundaryVertically()
        {
            Mars mars = new Mars(10, 10);

            Position position = mars.CalculateOutOfBoundaryPosition(new Position(5, 10));

            Assert.AreEqual(5, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void Mars_CalculateUnderBoundaryVertically()
        {
            Mars mars = new Mars(10, 10);

            Position position = mars.CalculateOutOfBoundaryPosition(new Position(5, -1));

            Assert.AreEqual(5, position.X);
            Assert.AreEqual(9, position.Y);
        }

        [Test]
        public void Mars_CalculateOutBoundaryBoth()
        {
            Mars mars = new Mars(10, 10);

            Position position = mars.CalculateOutOfBoundaryPosition(new Position(13, 56));

            Assert.AreEqual(3, position.X);
            Assert.AreEqual(6, position.Y);
        }


        [Test]
        public void Mars_CalculateUnderBoundaryBoth()
        {
            Mars mars = new Mars(10, 10);

            Position position = mars.CalculateOutOfBoundaryPosition(new Position(-4, -56));

            Assert.AreEqual(6, position.X);
            Assert.AreEqual(4, position.Y);
        }
    }
}