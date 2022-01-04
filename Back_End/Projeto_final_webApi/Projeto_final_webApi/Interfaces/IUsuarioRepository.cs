using projeto_final_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario CadastrarUsuario);

        Usuario Login(string email, string senha);
        
        void Deletar(int id);

        void Atualizar(int id, Usuario Usuario);
    }
}
