namespace CarRental.Core.Utils.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool isSuccess, string message) : base(false, message)
        {
        }

        public ErrorResult(bool isSuccess) : base(false)
        {
        }
    }
}