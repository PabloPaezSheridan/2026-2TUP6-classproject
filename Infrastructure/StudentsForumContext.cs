using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StudentsForumContext : DbContext
{
    public DbSet<User>? Users;

    public StudentsForumContext(DbContextOptions<StudentsForumContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    {
    }

}
