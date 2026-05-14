using System;
using System.ComponentModel.DataAnnotations;

namespace web.DTOs;

public class CredentialsRequest
{

    public required string Password {get;set;}

    [EmailAddress]
    public required string Email {get;set;} 

}
