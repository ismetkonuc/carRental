namespace CarRental.Core.Utils.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}