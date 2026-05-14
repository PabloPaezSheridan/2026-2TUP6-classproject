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

    public User? Get(string email)
    {
        return _userRepository.Get(email);
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

    public bool IsValidUser(string email, string password)
    {
        User? userToValidate = _userRepository.Get(email);
        if(userToValidate is null)
            return false;
        else if(userToValidate.Password == password)
            return true;
        return false;
    }

}
