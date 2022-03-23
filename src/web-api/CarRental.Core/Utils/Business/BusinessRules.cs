using CarRental.Core.Utils.Results;

namespace CarRental.Core.Utils.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.IsSuccess)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}