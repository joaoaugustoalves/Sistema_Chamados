using projeto_final_webApi.database;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        internal DtechContext ctx;

        public SetorRepository(DtechContext context)
        {
            ctx = context;
        }

        public List<Setor> Listar()
        {
            return ctx.Setor.ToList();
        }

        public void Deletar(int id)
        {
            ctx.Setor.Remove(BuscarPorId(id));

            
            ctx.SaveChanges();
        }

        public Setor BuscarPorId(int id)
        {
            return ctx.Setor.FirstOrDefault(e => e.IdSetor == id);
        }

            public void Cadastrar(Setor novoSetor)
        {
            ctx.Setor.Add(novoSetor);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Setor SetorAtualizado)
        {
           Setor setorBuscado = ctx.Setor.FirstOrDefault(identificar => identificar.IdSetor == id);

            if (SetorAtualizado.Nome != null)
            {
                setorBuscado.Nome = SetorAtualizado.Nome;
            }
        }
    }
}
