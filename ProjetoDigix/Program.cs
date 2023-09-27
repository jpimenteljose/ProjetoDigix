using ProjetoDigix.Controllers;
using System;

namespace ProjetoDigix
{
    class Program
    {
        static void Main(string[] args)
        {
            var BeneficiarioController = new BeneficiarioController();
            BeneficiarioController.ExecutarMenu();
        }
    }
}
