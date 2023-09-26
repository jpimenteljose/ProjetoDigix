using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDigix.Settings
{
    /// <summary>
    ///  Classe para armazenar as configurações para acesso ao SqlServer
    /// </summary>
    public class SqlServerSettings
    {
        // Método estático para retornar a connectionstring
        public static string GetConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjetoDigix;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
