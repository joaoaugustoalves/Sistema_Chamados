using projeto_final_webApi.database;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
       internal DtechContext ctx;

        public TipoUsuarioRepository(DtechContext context)
        {
            ctx = context;
        }


        public void Atualizar(int id, TipoUsuario AtualizarTipoUsuario)
        {
            TipoUsuario UsuarioBuscado = ctx.TipoUsuario.FirstOrDefault(identificar => identificar.IdTipoUsuario == id);

            if (AtualizarTipoUsuario.Nome != null)
            {
                UsuarioBuscado.Nome = AtualizarTipoUsuario.Nome;
            }

            ctx.TipoUsuario.Update(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario CadastrarTipoUsuario)
        {
            ctx.TipoUsuario.Add(CadastrarTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuario.Remove(BuscarPorId(id));


            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
