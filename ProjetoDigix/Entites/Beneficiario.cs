using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDigix.Entities
{
    public class Beneficiario
    {
        public Guid IdBeneficiario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Salario { get; set; }

        public List<Dependente> Dependentes { get; set; }
    }
}
