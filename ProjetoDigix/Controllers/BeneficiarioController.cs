using Dapper;
using ProjetoDigix.Entities;
using ProjetoDigix.Repositories;
using ProjetoDigix.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDigix.Controllers
{
    public class BeneficiarioController
    {
        // Método para executar o menu de opções
        public void ExecutarMenu()
        {
            Console.WriteLine("\n*** CONTROLE DE BENEFICIÁRIOS ***\n");
            Console.WriteLine("(1) - CADASTRAR BENEFICIÁRIO");
            Console.WriteLine("(2) - CONSULTAR BENEFICIÁRIO");
            Console.WriteLine("(3) - CONSULTAR PONTUAÇÃO DE BENEFICIÁRIO");

            try
            {
                Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: CadastrarBeneficiario(); break;
                    case 2: ConsultarBeneficiario(); break;
                    case 3: ConsultarPontuacao(); break;
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

        // Método para realizar o cadastro de uma Beneficiario 
        public void CadastrarBeneficiario()
        {
            Console.WriteLine("\nCADASTRO DE BENEFICIÁRIOS\n");

            var Beneficiario = new Beneficiario();

            Beneficiario.IdBeneficiario = Guid.NewGuid(); 

            Console.Write("Entre com o nome do Beneficiário..: ");
            Beneficiario.Nome = Console.ReadLine();

            Console.Write("Entre com o CPF...................: ");
            Beneficiario.Cpf = Console.ReadLine();

            Console.Write("Entre com o salário...............: ");
            Beneficiario.Salario = Decimal.Parse(Console.ReadLine());

            var BeneficiarioRepository = new BeneficiarioRepository();
            BeneficiarioRepository.Inserir(Beneficiario);

            Console.WriteLine("\nBENEFICIÁRIO CADASTRADA COM SUCESSO!");

            Console.Write("\nINFORME O NÚMERO DE DEPENDENTES: ");
            var qtd = int.Parse(Console.ReadLine());

            var dependenteRepository = new DependenteRepository();

            for (int i = 0; i < qtd; i++)
            {
                var dependente = new Dependente();
                dependente.IdDependente = Guid.NewGuid(); 

                Console.Write("\nEntre com o nome do dependente: ");
                dependente.Nome = Console.ReadLine();

                Console.Write("Entre com a data de nascimento: ");
                dependente.DataNascimento = DateTime.Parse(Console.ReadLine());

                dependente.IdBeneficiario = Beneficiario.IdBeneficiario;

                dependenteRepository.Inserir(dependente);

                Console.WriteLine("\nDEPENDENTE CADASTRADO COM SUCESSO\n");
            }
        }

        // Método para consultar e imprimir todos as BENEFICIÁRIOs cadastrados
        public void ConsultarBeneficiario()
        {

            try
            {
                Console.WriteLine("\n*** CONSULTA DE BENEFICIÁRIOS ***\n");

                var BeneficiarioRepository = new BeneficiarioRepository();
                var Beneficiarios = BeneficiarioRepository.Consultar();

                foreach (var item in Beneficiarios)
                {
                    Console.WriteLine("ID...........: " + item.IdBeneficiario);
                    Console.WriteLine("NOME.........: " + item.Nome);
                    Console.WriteLine("CPF..........: " + FormatarCPF(item.Cpf));
                    Console.WriteLine("SALARIO......: " + item.Salario);
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao consultar BENEFICIÁRIOs.");
                Console.WriteLine(e.Message);
            }
        }

        // Método para consultar e listar a pontuação dos Beneficiários
        public void ConsultarPontuacao()
        {
            try
            {
                Console.WriteLine("\nCONSULTA PONTUAÇÃO DE FAMÍLIA: ");

                var beneficiarioRepository = new BeneficiarioRepository();
                var Beneficiarios = beneficiarioRepository.ConsultarPontuacaoBeneficiario();

                // Veririca a pontuação conforme critérios definidos
                Beneficiarios.Sort((f2, f3) => f3.CalcularPontuacao().CompareTo(f2.CalcularPontuacao()));

                foreach (var item in Beneficiarios)
                {
                    Console.WriteLine("BENEFICIARIO.: " + item.Nome);
                    Console.WriteLine("CPF..........: " + FormatarCPF(item.Cpf));
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


        // Métodp para formatar o CPF
        public static string FormatarCPF(string cpf)
        {
            // Verifique se o CPF possui 11 caracteres
            if (cpf.Length != 11)
            {
                throw new ArgumentException("CPF deve conter 11 dígitos.");
            }

            // Aplica a máscara do CPF (XXX.XXX.XXX-XX)
            return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }

    }
}
