using System.Threading.Tasks;
using MeetUp.Model.Models;

namespace MeetUp.Repo.Contract
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string name, string password);
        Task<bool> UserExist(string username);
    }
}