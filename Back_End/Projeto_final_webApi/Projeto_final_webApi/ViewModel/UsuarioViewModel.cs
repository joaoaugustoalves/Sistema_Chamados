using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.ViewModel
{
    public class UsuarioPostViewModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public int Telefone { get; set; }
    }

    public class UsuarioPutViewModel : UsuarioPostViewModel
    {
        public int IdUsuario { get; set; }

        public int IdSetor { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
