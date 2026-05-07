using System;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StudentsForumContext _studentsForumContext;
    public UserRepository(StudentsForumContext studentsForumContext)
    {
        _studentsForumContext = studentsForumContext
    }

    public List<User> Get()
    {
        return new List<User>
        {
            new User { Id = 1, Name = "Pablo", Email = "pablo@email.com"}
        };
    }

    public void Update(User userToUpdate)
    {
        _studentsForumContext.Users.Update(userToUpdate);
        _studentsForumContext.SaveChanges();
    }

    public void Delete(int userToDeleteId)
    {
        User userToDelete = new();
        userToDelete.Id = userToDeleteId;

        _studentsForumContext.Users.Remove(userToDelete);
        _studentsForumContext.SaveChangesAsync();
    }

    public User Get(int id)
    {
        _studentsForumContext.Users.
    }
}
