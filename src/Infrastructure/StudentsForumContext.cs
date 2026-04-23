using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StudentsForumContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Response> Responses {get; set;}

    public StudentsForumContext(DbContextOptions<StudentsForumContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Pablo",
                Email = "pablo@example.com",
                DateOfBirth = new DateTime(2001, 5, 15)
            },
            new User
            {
                Id = 2,
                Name = "Camila",
                Email = "camila@example.com",
                DateOfBirth = new DateTime(2000, 11, 3)
            }
        );

        modelBuilder.Entity<Response>().HasData(
            new
            {
                Id = 1,
                Text = "Bienvenidos al foro de estudiantes.",
                CreatedAt = new DateTime(2026, 4, 23, 18, 0, 0),
                CreatorId = 1
            },
            new
            {
                Id = 2,
                Text = "Gracias por compartir este espacio.",
                CreatedAt = new DateTime(2026, 4, 23, 18, 30, 0),
                CreatorId = 2
            }
        );
    }

}
