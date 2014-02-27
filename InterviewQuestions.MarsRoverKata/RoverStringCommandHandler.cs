using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.MarsRoverKata
{
    public class RoverStringCommandHandler
    {
        private IRover rover;

        public RoverStringCommandHandler(IRover rover)
        {
            this.rover = rover;
        }

        public void HandleString(string str)
        {
            foreach (char ch in str)
            {
                HandleCharacter(ch);
            }
        }

        private void HandleCharacter(char ch)
        {
            switch (ch)
            {
                case 'F':
                    rover.MoveForward();
                    break; ;
                case 'B':
                    rover.MoveBackward();
                    break;
                default:
                    throw new InvalidEnumArgumentException(string.Format("The received command : '%0' is not supported", ch));

            }
        }
    }
}