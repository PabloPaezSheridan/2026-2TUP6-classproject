using System;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    List<User> GetUsers();

    void Update(User user);

    void Delete( int id);

    User Get(int id);
}
