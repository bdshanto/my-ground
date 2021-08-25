using System.Threading.Tasks;
using MeetUp.Domains.Entities;

namespace MeetUp.Repo.Contract.IRepositoryContracts
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string name, string password);
        Task<bool> UserExist(string username);
    }
}