using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDigix.Interfaces
{
    public interface IBaseRepository<Tentity, TKey>
        where Tentity : class
    {
        void Inserir(Tentity obj);
        void Alterar(Tentity obj);
        void Excluir(Tentity obj);

        List<Tentity> Consultar();

        Tentity ObterPorId(TKey id);
    }
}
