using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using FuteBet.ApiWeb.Models;
using FuteBet.Dominio.Commands.Command;
using FuteBet.Dominio.Commands.Request;
using FuteBet.Dominio.Commands.Response;
using FuteBet.Dominio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FuteBet.ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UsuarioCommandHandler UsuarioCommand;

        public LoginController(IUsuarioRepositorio usuarioCommand)
        {
            UsuarioCommand = new UsuarioCommandHandler(usuarioCommand);
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post(  [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations, [FromBody] LoginUsuarioRequest login)
        {
            LoginUsuarioResponse loginResponse = (LoginUsuarioResponse)UsuarioCommand.Handler(login);
          

            bool credenciaisValidas = (loginResponse != null && loginResponse.Autenticado);

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(loginResponse.ID.ToString()),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.UniqueName, loginResponse.Nome),
                        new Claim(JwtRegisteredClaimNames.Email, loginResponse.Email),
                    }
                );

                DateTime dataCriacao = loginResponse.DataInicio;
                DateTime dataExpiracao = loginResponse.DataExpiracao;

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Ok
                (
                    new
                    {
                        authenticated = true,
                        created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = token,
                        message = "OK"
                    }
                );
            }
            else
            {
                 return BadRequest(new
                {
                    autenticacao = false,
                    messagem = "Falha ao autenticar"
                });
            }

        }


    }
}
