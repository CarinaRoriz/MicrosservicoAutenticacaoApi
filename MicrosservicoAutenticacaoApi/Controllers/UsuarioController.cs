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
                new Usuario { Id = 1, Nome = "Carina" },
                new Usuario { Id = 2, Nome = "Renato" }
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> ValidaUsuario(long id)
        {
            var usuario = listaUsuarios.Where(l => l.Id == id).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return true;
        }
    }
}
