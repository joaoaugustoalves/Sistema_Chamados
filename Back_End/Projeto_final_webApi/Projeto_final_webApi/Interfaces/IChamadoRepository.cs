using projeto_final_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Interfaces
{
    public interface IChamadoRepository
    {
        List<Chamado> Listar();

        void Cadastrar(Chamado CadastrarChamado);

        void Atualizar(int id, Chamado ChamadoAtualizado);
        void Deletar(int id);
    }
}
