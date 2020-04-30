using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopWeb.Models;
using shopWeb.Repositories;
using shopWeb.Services;

namespace shopWeb.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> TryLogin([FromBody]Usuario model)
        {
            var usuario = UsuarioRepository.Get(model.Name, model.Pass);
            if (usuario == null)
                return NotFound(new {message = "usuario ou senha invalidos"});

            var token = TokenService.Generate(usuario);
            return new
            {
                user = usuario,
                token = token
            };
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "Anonimo";


        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => $"Usuario logado:{User.Identity.Name}";
        
        [HttpGet]
        [Route("usuario")]
        [Authorize(Roles = "basic")]
        public string Usuario() => $"Usuario => :{User.Identity.Name}";
        
        
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => $"Admin => :{User.Identity.Name}";

    }
}