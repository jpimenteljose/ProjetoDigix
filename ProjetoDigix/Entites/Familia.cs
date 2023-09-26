using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDigix.Entities
{
    public class Familia
    {
        public string cpf { get; set; }
        public decimal rendaTotal { get; set; }
        public int numeroDependentes { get; set; }

        /*
        public Familia(string cpf, decimal rendaTotal, int numeroDependentes)
        {
            cpf = cpf;
            rendaTotal = rendaTotal;
            numeroDependentes = numeroDependentes;
        }
        */

        public int CalcularPontuacao()
        {
            int pontuacao = 0;

            if (rendaTotal <= 900)
            {
                pontuacao += 5;
            }
            else if (rendaTotal <= 1500)
            {
                pontuacao += 3;
            }

            if (numeroDependentes >= 3)
            {
                pontuacao += 3;
            }
            else if (numeroDependentes >= 1)
            {
                pontuacao += 2;
            }

            return pontuacao;
        }

    }
}
