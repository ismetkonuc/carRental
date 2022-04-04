using System.Threading.Tasks;
using CarRental.Core.Utils.Results;
using CarRental.Core.Utils.Security.JWT;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.AppUser;

namespace CarRental.Business.Interfaces
{
    public interface IAuthService
    {
        IDataResult<AppUser> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<AppUser> Login(UserForLoginDto userForLoginDto);
        IDataResult<AppUser> UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(AppUser user);
        IResult Logout();
    }
}