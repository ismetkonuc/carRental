using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Core.Utils.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512);
        }
    }
}