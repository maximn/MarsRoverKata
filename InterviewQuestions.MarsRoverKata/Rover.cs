using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.MarsRoverKata
{
    public class Rover
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public Rover(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    this.Position.Y++;
                    break;
                case Direction.East:
                    this.Position.X++;
                    break;
                case Direction.South:
                    this.Position.Y--;
                    break;
                case Direction.West:
                    this.Position.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid value set for Direction enum");
            }
        }

        public void MoveBackward()
        {
            switch (Direction)
            {
                case Direction.North:
                    this.Position.Y--;
                    break;
                case Direction.East:
                    this.Position.X--;
                    break;
                case Direction.South:
                    this.Position.Y++;
                    break;
                case Direction.West:
                    this.Position.X++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid value set for Direction enum");
            }
        }
    }


}
