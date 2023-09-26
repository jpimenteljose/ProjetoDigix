using ProjetoDigix.Controllers;
using System;

namespace ProjetoDigix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*** CONTROLE DE BENEFICIÁRIOS ***\n");
            Console.WriteLine("(1) - CADASTRAR BENEFICIÁRIO");
            Console.WriteLine("(2) - VERIFICAR PONTUAÇÃO DE BENEFICIÁRIO");

            try
            {
                Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        var BeneficiarioController = new BeneficiarioController();
                        BeneficiarioController.ExecutarMenu();
                        break;
                    
                    case 2:
                        var FamiliaController = new FamiliaController();
                        FamiliaController.ExecutarMenu();
                        break;
                    
                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
