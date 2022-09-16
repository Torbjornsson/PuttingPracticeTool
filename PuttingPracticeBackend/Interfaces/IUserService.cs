using PuttingPracticeBackend.Models;

namespace PuttingPracticeBackend.Interfaces;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest request);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest registerRequest);
    void Update(int id, UpdateUserRequest updateUserRequest);
    void Delete(int id);
}