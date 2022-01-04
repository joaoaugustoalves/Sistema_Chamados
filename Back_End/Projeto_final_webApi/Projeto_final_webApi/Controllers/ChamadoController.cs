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
    public class ChamadoController : Controller
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IChamadoRepository _ChamadoRepository;
        public ChamadoController(IChamadoRepository chamadoRepository, IUsuarioRepository usuarioRepository)
        {
            _ChamadoRepository = chamadoRepository;
            _UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult ListarChamado()
        {
            var lista = _ChamadoRepository.Listar();
            if (!lista.Any())
            {
                return BadRequest("Nenhum Chamado encontrado");
            }
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarChamado(ChamadoPostViewModel model)
        {
            try
            {
                var Chamados = _ChamadoRepository.Listar();

                if (Chamados != null)
                {
                    var colaborador = _UsuarioRepository.Listar().Where(o => o.IdUsuario == model.IdColaborador).FirstOrDefault();
                    if (colaborador == null)
                    {
                        return BadRequest("Usuario Colaborador não existe!!!");
                    }

                    var especialista = _UsuarioRepository.Listar().Where(o => o.IdUsuario == model.IdEspecialista).FirstOrDefault();
                    if (colaborador == null)
                    {
                        return BadRequest("Usuario Especialista não existe!!!");
                    }
                }


                var ChamadoCadastro = new Chamado()
                {
                    Tipo = model.Tipo,
                    Descricao = model.Descricao,
                    IdColaborador = model.IdColaborador,
                    IdEspecialista = model.IdEspecialista,
                    Status = model.Status,
                    DataAbertura = DateTime.Now,
                    Prioridade = model.Prioridade


                };

                _ChamadoRepository.Cadastrar(ChamadoCadastro);

                return Ok(ChamadoCadastro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarChamado(ChamadoPutViewModel model)
        {
            try
            {

                var Chamado = _ChamadoRepository.Listar().Where(o => o.IdChamado == model.IdChamado).FirstOrDefault();
                
                if (Chamado == null)

                {
                    return BadRequest("Setor não encontrado !!!");
                }
                var colaborador = _UsuarioRepository.Listar().Where(o => o.IdUsuario == model.IdColaborador).FirstOrDefault();
                if (colaborador == null)
                {
                    return BadRequest("Usuario Colaborador não existe!!!");
                }

                var especialista = _UsuarioRepository.Listar().Where(o => o.IdUsuario == model.IdEspecialista).FirstOrDefault();
                if (colaborador == null)
                {
                    return BadRequest("Usuario Especialista não existe!!!");
                }

                Chamado.Tipo = model.Tipo;
                Chamado.Descricao = model.Descricao;
                Chamado.IdColaborador = model.IdColaborador;
                Chamado.IdEspecialista = model.IdEspecialista;
                Chamado.Status = model.Status;
                Chamado.DataAbertura = DateTime.Now;
                Chamado.Prioridade = model.Prioridade;

                _ChamadoRepository.Atualizar(model.IdChamado, Chamado);

                return Ok(Chamado);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpDelete("{id}")]

        public IActionResult DeletarChamado(int id)
        {
            try
            {
                var Chamado = _ChamadoRepository.Listar().Where(o => o.IdChamado == id).FirstOrDefault();

                if (Chamado == null)
                {
                    return BadRequest("Chamado não encontrado");
                }
                _ChamadoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{id}")]

        public IActionResult MudarStatus(int id)
        {
            try
            {
                var Chamado = _ChamadoRepository.Listar().Where(o => o.IdChamado == id).FirstOrDefault();

                if (Chamado == null)
                {
                    return BadRequest("Chamado não encontrado");
                }
                Chamado.Status = true;
                Chamado.DataFinalizacao = DateTime.Now;

                _ChamadoRepository.Atualizar(id, Chamado);

                return Ok(Chamado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
