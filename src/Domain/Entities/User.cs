using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class User
{
    [Key]
    public int Id { get; set; } 
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; } = null;
    public Role Role {get; set;} = Role.User;

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => _password = BCrypt.Net.BCrypt.HashPassword(value);
    }
    public bool IsActive {get; set;} = true;
}

public enum Role
{
    User,
    Admin
}
