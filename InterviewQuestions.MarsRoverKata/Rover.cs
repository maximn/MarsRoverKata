using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.MarsRoverKata
{
    public class Rover : IRover
    {
        private readonly IPlanet planet;
        public Position Position { get; set; }
        public Direction Direction { get; private set; }

        //hold this to cache the number of directions
        private readonly int directionsCount;

        public Rover(Position position, Direction direction, IPlanet planet)
        {
            this.planet = planet;
            Position = position;
            Direction = direction;

            directionsCount = Enum.GetValues(typeof(Direction)).Length;
        }

        public void MoveForward()
        {
            int x = this.Position.X;
            int y = this.Position.Y;

            switch (Direction)
            {
                case Direction.North:
                    y++;
                    break;
                case Direction.East:
                    x++;
                    break;
                case Direction.South:
                    y--;
                    break;
                case Direction.West:
                    x--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid value set for Direction enum");
            }

            Position nextPosition = planet.CalculateOutOfBoundaryPosition(new Position(x, y));
            ThrowIfPositionNotClear(nextPosition);
            this.Position = nextPosition;
        }

        public void MoveBackward()
        {
            int x = this.Position.X;
            int y = this.Position.Y;


            switch (Direction)
            {
                case Direction.North:
                    y--;
                    break;
                case Direction.East:
                    x--;
                    break;
                case Direction.South:
                    y++;
                    break;
                case Direction.West:
                    x++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid value set for Direction enum");
            }

            Position nextPosition = planet.CalculateOutOfBoundaryPosition(new Position(x, y));
            ThrowIfPositionNotClear(nextPosition);
            this.Position = nextPosition;
        }

        private void ThrowIfPositionNotClear(Position position)
        {
            if (!planet.IsClear(position))
            {
                throw new ObstacleOnWayException(string.Format("Can't move to (%0, %1) due to an obstacle on the planet", position.X, position.Y));
            }
        }

        public void TurnRight()
        {
            //Because of the Directions ordering all we have to do to move right is to add 1 and make sure we're not out of the bounds of the enum
            this.Direction = (Direction)((int)(this.Direction + 1) % directionsCount);
        }

        public void TurnLeft()
        {
            //Because of the Directions ordering all we have to do to move left is to add (directionsCount - 1) and make sure we're not out of the bounds of the enum
            //We're not going to subtract 1 because we don't want to handle negative numbers here so it's simpler just to add  (directionsCount - 1)
            this.Direction = (Direction)((int)(this.Direction + directionsCount - 1) % directionsCount);
        }
    }
}
