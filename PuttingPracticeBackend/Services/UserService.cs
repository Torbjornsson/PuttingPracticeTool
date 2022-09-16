using System.Security.Authentication;
using AutoMapper;
using PuttingPracticeBackend.Data;
using PuttingPracticeBackend.Interfaces;
using PuttingPracticeBackend.Models;

namespace PuttingPracticeBackend.Services;

public class UserService : IUserService
{
    private PuttingPracticeDataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UserService(PuttingPracticeDataContext context, IJwtUtils jwtUtils, IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest request)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == request.Email.ToLower().Trim());

        if (user == null || BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new AuthenticationException("Email or Password is incorrect");
        }

        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);

        return response;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return GetUser(id);
    }

    private User GetUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return user;
    }

    public void Register(RegisterRequest registerRequest)
    {
        registerRequest.Email = registerRequest.Email.ToLower().Trim();
        if (_context.Users.Any(x => x.Email == registerRequest.Email))
        {
            throw new Exception($"Email {registerRequest.Email} is already taken");
        }

        var user = _mapper.Map<User>(registerRequest);

        user.Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateUserRequest updateUserRequest)
    {
        var user = GetUser(id);
        // use lowercase and trim whitespaces for email
        updateUserRequest.Email = updateUserRequest.Email.ToLower().Trim();

        if (updateUserRequest.Email != user.Email && _context.Users.Any(x => x.Email == updateUserRequest.Email))
        {
            throw new Exception($"Email {updateUserRequest.Email} is already taken");
        }

        if (!string.IsNullOrEmpty(updateUserRequest.Password))
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserRequest.Password);
        }

        _mapper.Map(updateUserRequest, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}