using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicrosservicoAutenticacaoApi.Modelos;

namespace MicrosservicoAutenticacaoApi.Controllers
{
    [Route("v1/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        List<Usuario> listaUsuarios;

        public UsuarioController()
        {
            listaUsuarios = new List<Usuario>
            {
                new Usuario { Login = "carina", Senha = "abc123!" }
            };
        }

        [HttpPost]
        public async Task<ActionResult<bool>> ValidaUsuario(Usuario usuario)
        {
            var usuarioEncontrado = listaUsuarios.Where(l => l.Login == usuario.Login && l.Senha == usuario.Senha).FirstOrDefault();

            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            return true;
        }
    }
}
