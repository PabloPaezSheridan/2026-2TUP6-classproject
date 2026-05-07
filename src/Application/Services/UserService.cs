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

    public void DeleteUser(int id, string mode)
    {
        if (mode == "logic")
        {
            User userToRemove = _userRepository.Get(id);
            if (userToRemove.IsActive)
                userToRemove.IsActive = false;
                _userRepository.Update(userToRemove);
        }
        else
        {
            _userRepository.Delete(id);
        }
    }
}
