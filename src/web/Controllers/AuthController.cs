using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using web.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfigurationManager _config;
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody]CredentialsRequest CredDto)
        {
            if(_userService.IsValidUser(CredDto.Email, CredDto.Password))
            {
                User user = _userService.Get(CredDto.Email)
                    ?? throw new Exception();              
                string token = GenerateToken(user);
                return Ok(token);
            }
            else
                return BadRequest("User or password incorrect");
        } 

        private string GenerateToken(User user)
        {
            var securityPassword = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_config["AutenticacionService:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var secretHashed = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", user.Name)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
            claimsForToken.Add(new Claim("role", user.Role.ToString())); //Debería venir del usuario

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["AutenticacionService.Issuer"],
              _config["AutenticacionService.Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              secretHashed);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }
    }
}
