namespace CarRental.Core.Utils.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool isSuccess, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data, bool isSuccess) : base(data, false)
        {
        }
    }
}