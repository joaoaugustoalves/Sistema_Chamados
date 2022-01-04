using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using projeto_final_webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuarioRepository _TipoUsuarioRepository;
        public TipoUsuarioController(ITipoUsuarioRepository TipoUsuarioRepository)
        {
            _TipoUsuarioRepository = TipoUsuarioRepository;
        }

        [HttpGet]
        public IActionResult ListarTipoUsuarios()
        {
            var lista = _TipoUsuarioRepository.Listar();
            if (!lista.Any())
            {
                return BadRequest("Nenhum Tipo Usuario encontrado");
            }
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTipoUsuario(TipoUsuarioPostViewModel model)
        {
            try
            {
                var tipoUsuarios = _TipoUsuarioRepository.Listar();

                if (tipoUsuarios != null)
                {
                    var nome = tipoUsuarios.Where(o => o.Nome == model.Nome).FirstOrDefault();
                    if (nome != null)
                    {
                        return BadRequest("Tipo Usuario ja existente !!!");
                    }
                }

                var TipoUsuarioCadastro = new TipoUsuario()
                {
                    Nome = model.Nome,

                };

                _TipoUsuarioRepository.Cadastrar(TipoUsuarioCadastro);

                return Ok(TipoUsuarioCadastro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTipoUsuario(TipoUsuarioPutViewModel model)
        {
            try
            {
                var tipoUsuario = _TipoUsuarioRepository.Listar().Where(o => o.IdTipoUsuario == model.IdTipoUsuario).FirstOrDefault();
                
                if (tipoUsuario == null)

                {
                    return BadRequest("Tipo Usuario não encontrado !!!");
                }

                tipoUsuario.Nome = model.Nome;

                _TipoUsuarioRepository.Atualizar(model.IdTipoUsuario, tipoUsuario);

                return Ok(tipoUsuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeletarTipoUsuarios(int id)
        {
            try
            {
                var tipoUsuario = _TipoUsuarioRepository.Listar().Where(o => o.IdTipoUsuario == id).FirstOrDefault();

                if (tipoUsuario == null)
                {
                    return BadRequest("Tipo Usuario não encontrado");
                }
                _TipoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
