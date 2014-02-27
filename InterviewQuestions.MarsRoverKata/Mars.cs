using System;

namespace InterviewQuestions.MarsRoverKata
{
    public class Mars : IPlanet
    {
        public int Width { get; set; }
        public int Height { get; set; }


        public Mars(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Position CalculateOutOfBoundaryPosition(Position position)
        {
            int x = WrapAroundInteger(position.X, Width);
            int y = WrapAroundInteger(position.Y, Height);

            return new Position(x, y);
        }

        private int WrapAroundInteger(int number, int max)
        {
            if (max <= 0)
            {
                throw new ArgumentException("max parameter MUST be grater than zero");
            }

            int moduluResult = number % max;

            // If negative need to return to range
            if (moduluResult < 0)
            {
                moduluResult = moduluResult + max;
            }

            return moduluResult;
        }
    }
}