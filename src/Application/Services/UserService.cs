using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetUsers();
    }
}
