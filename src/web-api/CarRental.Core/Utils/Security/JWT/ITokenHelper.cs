using System.Collections.Generic;
using System.Security.Claims;
using CarRental.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Core.Utils.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUserBase user, List<string> roles);
    }
}