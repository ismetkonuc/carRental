using System;

namespace CarRental.Core.Utils.Results
{
    public class Result : IResult
    {

        public bool IsSuccess { get; }
        public string Message { get; } = string.Empty;

        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

    }
}