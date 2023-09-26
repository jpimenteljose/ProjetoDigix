using ProjetoDigix.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDigix.Interfaces
{
    /// <summary>
    /// Beneficiario - nesta interface, o tipo T representa uma Beneficiario (define um título concreto -> Beneficiario)
    /// </summary>
    public interface IBeneficiarioRepository : IBaseRepository<Beneficiario, Guid>
    {
        // Método para consultar uma Beneficiario no banco de dados, através do CPF
        Beneficiario ConsultaPorCpf(string cpf);
    }
}
