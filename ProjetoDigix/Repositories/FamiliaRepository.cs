using Dapper;
using ProjetoDigix.Entities;
using ProjetoDigix.Interfaces;
using ProjetoDigix.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjetoDigix.Repositories
{
    
    internal class FamiliaRepository : IBaseRepository<Familia, Guid>
    {
        public List<Familia> Consultar()
        {
            var query = @"SELECT B.CPF, B.SALARIO AS RENDATOTAL, COUNT(D.DATANASCIMENTO) AS NUMERODEPENDENTES
                          FROM BENEFICIARIO B, DEPENDENTE D
                          WHERE B.IDBENEFICIARIO = D.IDBENEFICIARIO
                          AND   DATEDIFF(YY, D.DATANASCIMENTO, GETDATE()) <= 18
                          GROUP BY B.CPF, B.SALARIO
                          ORDER BY B.CPF
                        ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Familia>(query).ToList();
            }
        }


        public void Inserir(Familia obj)
        {
            throw new NotImplementedException();
        }

        public void Alterar(Familia obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Familia obj)
        {
            throw new NotImplementedException();
        }

        public Familia ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
