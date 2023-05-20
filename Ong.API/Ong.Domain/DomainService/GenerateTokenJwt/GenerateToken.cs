using AutoMapper;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Ong.API.CrossCutting.Authentication;
using Ong.Domain.Command.Autenticacao.CreateToken;
using Ong.Domain.Entities;
using Ong.Domain.Enum;
using Ong.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Ong.Domain.DomainService.GenerateTokenJwt
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenResponse GerarTokenJwt(Usuario user)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var claim = GenerateClaim(user);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                claims: claim
            );

            return new TokenResponse
            {
                IdUsuario = user.Id,
                Nome = user.Nome,
                Email = user.Authentication.EmailUsuario,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Cpf = user.Cpf
            };
        }

        private IEnumerable<Claim> GenerateClaim(Usuario usuario)
        {
            return new List<Claim>{
                new Claim (ClaimTypes.Role, usuario.Perfil.ToString()),
                new Claim("Nome: ", usuario.Nome),
                new Claim("Cpf: ", usuario.Cpf),
                new Claim("Email: ", usuario.Authentication.EmailUsuario),
                new Claim("Username: ", usuario.Authentication.NomeUsuario),
                new Claim("Data Nascimento: ", usuario.DataNascimento.ToString()),

            };
        }
    }
}
