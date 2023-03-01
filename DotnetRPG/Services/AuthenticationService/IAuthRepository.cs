using DotnetRPG.Models;
using System.Threading.Tasks;

namespace DotnetRPG.Services.AuthenticationService
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);    // returns int Id of User
        Task<ServiceResponse<string>> Login(string username, string password);  //returns token as string
        Task<bool> UserExists(string username);
    }
}
