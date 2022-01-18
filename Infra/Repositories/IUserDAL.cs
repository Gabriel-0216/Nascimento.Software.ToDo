using Domain.Users;
namespace Infra.Repositories;
    public interface IUserDAL : IDAL<User>
    {
        Task<bool> UserExists(string email, string passwordHash);
        Task<User?> GetUserByEmail(string email);
        Task<User?> Login(User user);
    }
