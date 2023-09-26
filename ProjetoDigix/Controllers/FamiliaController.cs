using ProjetoDigix.Entities;
using ProjetoDigix.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDigix.Controllers
{
    public class FamiliaController
    {
        // Método para executar o menu de opções
        public void ExecutarMenu()
        {
            Console.WriteLine("\n*** CONTROLE DE BENEFICIÁRIOS ***\n");
            Console.WriteLine("(1) - CONSULTAR PONTUAÇÃO DE BENEFICIÁRIO");

            try
            {
                Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: ConsultarPontuacaoFamilia(); break;
                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                        break;
                }

                Console.Write("\nDESEJA CONTINUAR? (S,N): ");
                var escolha = Console.ReadLine();

                if (escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    ExecutarMenu();
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        // Método para consultar e listar a pontuação dos Beneficiários
        public void ConsultarPontuacaoFamilia()
        {
            try
            {
                Console.WriteLine("\nCONSULTA PONTUAÇÃO DE FAMÍLIA: ");

                var familiaRepository = new FamiliaRepository();
                var Familias = familiaRepository.Consultar();

                // Veririca a pontuação conforme critérios definidos
                Familias.Sort((f2, f3) => f3.CalcularPontuacao().CompareTo(f2.CalcularPontuacao()));

                foreach (var item in Familias)
                {
                    Console.WriteLine("CPF..........: " + item.cpf);
                    Console.WriteLine("RENDA........: " + item.rendaTotal);
                    Console.WriteLine("DEPENDENTES..: " + item.numeroDependentes);
                    Console.WriteLine("PONTUAÇÃO....: " + item.CalcularPontuacao());
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao consultar Pontuação das Famílias.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
