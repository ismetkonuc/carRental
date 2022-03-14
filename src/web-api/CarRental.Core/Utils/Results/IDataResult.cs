namespace CarRental.Core.Utils.Results
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; }
    }
}