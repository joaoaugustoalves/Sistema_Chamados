using projeto_final_webApi.database;
using projeto_final_webApi.Domains;
using projeto_final_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        internal DtechContext ctx;

        public UsuarioRepository(DtechContext context)
        {
            ctx = context;
        }

      

        public void Atualizar(int id, Usuario AtualizarUsuario)
        {
           
            ctx.Usuario.Update(AtualizarUsuario);
            ctx.SaveChanges();
        }
       
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuario.FirstOrDefault(d => d.Email == email && d.Senha == senha);
        }

        public void Deletar(int id)
        {
            Usuario usuario = ctx.Usuario.Where(d => d.IdUsuario == id).FirstOrDefault();

            ctx.Usuario.Remove(usuario);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public void Cadastrar(Usuario CadastrarUsuario)
        {
            ctx.Usuario.Add(CadastrarUsuario);
            ctx.SaveChanges();
        }
    }
}
