using CoreDAL.Entities;
using System.Threading.Tasks;

namespace CoreDAL
{
    public interface IAuthRepository
    {
        Task<(bool success, string result)> CreateAuthToken(Credentials credentials);
    }
}
