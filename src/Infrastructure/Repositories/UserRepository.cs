using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public UserRepository()
    {
    }

    public List<User> GetUsers()
    {
        return new List<User>
        {
            new User { Id = 1, Name = "Pablo", Email = "pablo@email.com"}
        };
    }
}
