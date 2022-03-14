namespace CarRental.Core.Utils.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool isSuccess, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data, bool isSuccess) : base(data, true)
        {
        }
    }
}