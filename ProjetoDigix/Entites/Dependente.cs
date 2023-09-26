using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDigix.Entities
{
    public class Dependente
    {
        public Guid IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdBeneficiario { get; set; }
    }
}
