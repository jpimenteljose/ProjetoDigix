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
        public decimal rendaTotal { get; set; }
        public int numeroDependentes { get; set; }

        public List<Dependente> Dependentes { get; set; }

        public int CalcularPontuacao()
        {
            int pontuacao = 0;

            if (rendaTotal <= 900)
            {
                pontuacao += 5;
            }
            else if (rendaTotal > 900 && rendaTotal <= 1500)
            {
                pontuacao += 3;
            }

            if (numeroDependentes >= 3)
            {
                pontuacao += 3;
            }
            else if (numeroDependentes >= 1 && numeroDependentes < 3)
            {
                pontuacao += 2;
            }

            return pontuacao;
        }
    }
}
