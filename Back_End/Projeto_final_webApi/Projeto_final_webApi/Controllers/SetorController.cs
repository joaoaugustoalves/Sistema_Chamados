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
    public class SetorController : Controller
    {
        private readonly ISetorRepository _SetorRepository;
        public SetorController(ISetorRepository SetorRepository)
        {
            _SetorRepository = SetorRepository;
        }

        [HttpGet]
        public IActionResult ListarSetor()
        {
            var lista = _SetorRepository.Listar();
            if (!lista.Any())
            {
                return BadRequest("Nenhum Setor encontrado");
            }
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarSetor(SetorPostViewModel model)
        {
            try
            {
                var Setors = _SetorRepository.Listar();

                if (Setors != null)
                {
                    var nome = Setors.Where(o => o.Nome == model.Nome).FirstOrDefault();
                    if (nome != null)
                    {
                        return BadRequest("Setor ja existente !!!");
                    }
                }

                var SetorCadastro = new Setor()
                {
                    Nome = model.Nome,

                };

                _SetorRepository.Cadastrar(SetorCadastro);

                return Ok(SetorCadastro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarSetor(SetorPutViewModel model)
        {
            try
            {
                var Setor = _SetorRepository.Listar().Where(o => o.IdSetor == model.IdSetor).FirstOrDefault();
                
                if (Setor == null)

                {
                    return BadRequest("Setor não encontrado !!!");
                }

                Setor.Nome = model.Nome;

                _SetorRepository.Atualizar(model.IdSetor, Setor);

                return Ok(Setor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeletarSetor(int id)
        {
            try
            {
                var Setor = _SetorRepository.Listar().Where(o => o.IdSetor == id).FirstOrDefault();

                if (Setor == null)
                {
                    return BadRequest("Setor não encontrado");
                }
                _SetorRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
