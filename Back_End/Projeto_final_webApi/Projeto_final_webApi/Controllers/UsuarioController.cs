using Microsoft.AspNetCore.Mvc;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using projeto_final_webApi.Repositories;
using projeto_final_webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Controlles
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            var lista = _UsuarioRepository.Listar();
            if (!lista.Any())
            {
                return BadRequest("Nenhum Usuario encontrado");
            }
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(UsuarioPostViewModel model)
        {
            try
            {
                var User = _UsuarioRepository.Listar();

                if (User != null)
                {
                    var mail = User.Where(o => o.Email == model.Email).FirstOrDefault();
                    if (mail != null)
                    {
                        return BadRequest("E-Mail do usuario ja existente !!!");
                    }
                    var user = User.Where(o => o.Nome == model.Nome).FirstOrDefault();
                    if (user != null)
                    {
                        return BadRequest("Usuario com nome ja existente !!!");
                    }
                }

                var UsuarioCadastro = new Usuario()
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    Cpf = model.Cpf,
                    Telefone = model.Telefone,
                };

                _UsuarioRepository.Cadastrar(UsuarioCadastro);

                return Ok(UsuarioCadastro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario(UsuarioPutViewModel model)
        {
            try
            {
                var User = _UsuarioRepository.Listar().Where(o => o.IdUsuario == model.IdUsuario).FirstOrDefault();
                if (User == null)
                {
                    return BadRequest("Usuario não encontrado !!!");
                }

                User.Nome = model.Nome;
                User.Email = model.Email;
                User.Senha = model.Senha;
                User.Cpf = model.Cpf;
                User.Telefone = model.Telefone;
                User.IdTipoUsuario = model.IdTipoUsuario;
                User.IdSetor = model.IdSetor;

                _UsuarioRepository.Atualizar(model.IdUsuario, User);

                return Ok(User);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

            [HttpDelete("{id}")]

            public IActionResult DeletarUsuarios(int id)
            {
            try
            {
                var usuario = _UsuarioRepository.Listar().Where(o => o.IdUsuario == id ).FirstOrDefault();

                if(usuario == null)
                {
                    return BadRequest("Usuario não encontrado");
                }
                _UsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
    }
}
