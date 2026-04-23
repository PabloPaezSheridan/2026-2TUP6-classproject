using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Response
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    public string Text {get; set;}
    public DateTime CreatedAt {get; set;}

    public User Creator {get; set;}
}
