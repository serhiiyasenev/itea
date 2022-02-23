using CoreBL.Models;

namespace CoreBL
{
    interface IAuthService
    {
        string CreateAuthToken(Credentials credentials);
    }
}
