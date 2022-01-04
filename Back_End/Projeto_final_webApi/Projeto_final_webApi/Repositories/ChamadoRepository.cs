using projeto_final_webApi.database;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        internal DtechContext ctx;

        public ChamadoRepository(DtechContext context)
        {
            ctx = context;
        }


        public void Atualizar(int id, Chamado AtualizarTipoUsuario)
        {
            Chamado ChamadoBuscado = ctx.Chamado.FirstOrDefault(identificar => identificar.IdChamado == id);

            if (ChamadoBuscado != null)
            {
                ChamadoBuscado.Status = AtualizarTipoUsuario.Status;
            }

            ctx.Chamado.Update(ChamadoBuscado);
            ctx.SaveChanges();
        }

        public Chamado BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Chamado CadastrarChamado)
        {
            ctx.Chamado.Add(CadastrarChamado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Chamado> Listar()
        {
            return ctx.Chamado.ToList();
        }
    }
}
