using Microsoft.AspNetCore.Identity;

namespace Tamrin13shahrivar.Interface
{
    public interface ITokenService
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
