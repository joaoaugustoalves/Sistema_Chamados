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
    public class MaterialController : Controller
    {
        private readonly IChamadoRepository _ChamadoRepository;
        private readonly IMaterialRepository _MaterialRepository;
        public MaterialController(IMaterialRepository materialRepository, IChamadoRepository chamadoRepository)
        {
            _ChamadoRepository = chamadoRepository;
            _MaterialRepository = materialRepository;
        }

        [HttpGet]
        public IActionResult ListarMaterial()
        {
            var lista = _MaterialRepository.Listar();
            if (!lista.Any())
            {
                return BadRequest("Nenhum Material encontrado");
            }
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarMaterial(MaterialPostViewModel model)
        {
            try
            {
                var Materiais = _MaterialRepository.Listar();

                if (Materiais != null)
                {
                    var chamado = _ChamadoRepository.Listar().Where(o => o.IdChamado == model.IdChamado).FirstOrDefault();
                    if (chamado == null)
                    {
                        return BadRequest("Chamado  não existe!!!");
                    }

                }


                var MaterialCadastro = new Material()
                {
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    Tipo = model.Tipo,
                    IdChamado = model.IdChamado,
                 
                };

                _MaterialRepository.Cadastrar(MaterialCadastro);

                return Ok(MaterialCadastro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarMaterial(MaterialPutViewModel model)
        {
            try
            {

                var material = _MaterialRepository.Listar().Where(o => o.IdMaterial == model.IdMaterial).FirstOrDefault();
                
                if (material == null)

                {
                    return BadRequest("Material não encontrado !!!");
                }
                var chamado = _ChamadoRepository.Listar().Where(o => o.IdChamado == model.IdChamado).FirstOrDefault();
                if (chamado == null)
                {
                    return BadRequest("Chamado  não existe!!!");
                }


                material.Nome = model.Nome;
                material.Descricao = model.Descricao;
                material.Tipo = model.Tipo;
                material.IdChamado = model.IdChamado;

                _MaterialRepository.Atualizar(model.IdMaterial, material);

                return Ok(material);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpDelete("{id}")]

        public IActionResult DeletarMaterial(int id)
        {
            try
            {
                var material = _MaterialRepository.Listar().Where(o => o.IdMaterial == id).FirstOrDefault();

                if (material == null)
                {
                    return BadRequest("Material não encontrado");
                }
                _MaterialRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{nome}")]
        public IActionResult BuscarMaterial(string nome)
        {
            var lista = _MaterialRepository.Listar().Where(o => o.Nome.Contains(nome));
            if (!lista.Any())
            {
                return BadRequest("Nenhum Material encontrado");
            }
            return Ok(lista);
        }

    }
}
