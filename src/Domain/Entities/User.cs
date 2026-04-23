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
}
