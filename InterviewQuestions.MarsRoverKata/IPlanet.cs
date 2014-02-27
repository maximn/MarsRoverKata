namespace InterviewQuestions.MarsRoverKata
{
    public interface IPlanet
    {
        Position CalculateOutOfBoundaryPosition(Position position);
        bool IsClear(Position position);
    }
}