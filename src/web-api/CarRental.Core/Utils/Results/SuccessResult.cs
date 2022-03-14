namespace CarRental.Core.Utils.Results
{
    public class SuccessResult : Result
    {


        public SuccessResult(bool isSuccess, string message) : base(true, message)
        {
        }

        public SuccessResult(bool isSuccess) : base(true)
        {
        }
    }
}