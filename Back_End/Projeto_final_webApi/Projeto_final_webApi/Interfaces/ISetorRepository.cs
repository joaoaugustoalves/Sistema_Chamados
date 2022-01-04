using projeto_final_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Interfaces
{
    public interface ISetorRepository
    {
        List<Setor> Listar();

        Setor BuscarPorId(int id);

        void Cadastrar(Setor novoSetor);

        void Atualizar(int id, Setor SetorAtualizado);

        void Deletar(int id);
    }
}
