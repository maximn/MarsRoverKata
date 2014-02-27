using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.MarsRoverKata
{
    public class Rover : IRover
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        //hold this to cache the number of directions
        private readonly int directionsCount ;

        public Rover(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;

            directionsCount = Enum.GetValues(typeof (Direction)).Length;
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

        public void TurnRight()
        {
            //Because of the Directions ordering all we have to do to move right is to add 1 and make sure we're not out of the bounds of the enum
            this.Direction = (Direction) ((int) (this.Direction + 1)%directionsCount);
        }

        public void TurnLeft()
        {
            //Because of the Directions ordering all we have to do to move right is to add (directionsCount - 1) and make sure we're not out of the bounds of the enum
            //We're not going to subtract 1 because we don't want to handle negative numbers here so it's simpler just to add  (directionsCount - 1)
            this.Direction = (Direction)((int)(this.Direction + directionsCount- 1) % directionsCount);
        }
    }


}
