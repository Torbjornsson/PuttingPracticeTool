using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuttingPracticeBackend.Authorization;
using PuttingPracticeBackend.Helpers;
using PuttingPracticeBackend.Interfaces;
using PuttingPracticeBackend.Models;

namespace PuttingPracticeBackend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UserController(IUserService userService, IMapper mapper, AppSettings appSettings)
    {
        _userService = userService;
        _mapper = mapper;
        _appSettings = appSettings;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest request)
    {
        var response = _userService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        _userService.Register(request);
        return Ok(new { message = "Registration successful" });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateUserRequest request)
    {
        _userService.Update(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpPut("{id:int}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }
}