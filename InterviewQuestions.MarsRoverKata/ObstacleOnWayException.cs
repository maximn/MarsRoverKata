using System;
using System.Runtime.Serialization;

namespace InterviewQuestions.MarsRoverKata
{
    [Serializable]
    public class ObstacleOnWayException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ObstacleOnWayException()
        {
        }

        public ObstacleOnWayException(string message) : base(message)
        {
        }

        public ObstacleOnWayException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ObstacleOnWayException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}