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
    public class BeneficiarioRepository : IBaseRepository<Beneficiario, Guid>
    {
        public void Inserir(Beneficiario obj)
        {
            var query = @"INSERT INTO Beneficiario(IDBeneficiario, NOME, CPF, SALARIO) 
                          VALUES(@IDBeneficiario, @NOME, @CPF, @SALARIO)";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Beneficiario obj)
        {
            var query = @"UPDATE Beneficiario SET NOME = @NOME, CPF = @CPF, SALARIO=@SALARIO 
                          WHERE IDBeneficiario = @IDBeneficiario";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, obj);
            }

        }

        public void Excluir(Beneficiario obj)
        {
            var query = @"DELETE FROM Beneficiario
                          WHERE IDBeneficiario = @IDBeneficiario";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, obj);
            }

        }

        public List<Beneficiario> Consultar()
        {
            var query = @"SELECT * FROM Beneficiario
                          ORDER BY NOME ASC";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Beneficiario>(query).ToList();
            }

        }

        public Beneficiario ConsultarPorCpf(string cpf)
        {
            var query = @"SELECT * FROM Beneficiario 
                          WHERE CPF = @CPF";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Beneficiario>(query, new { cpf }).FirstOrDefault();
            }

        }

        public Beneficiario ObterPorId(Guid id)
        {
            var query = @"SELECT * FROM Beneficiario 
                          WHERE IDBeneficiario = @ID";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Beneficiario>(query, new { id }).FirstOrDefault();
            }

        }

        // Método para varificar a pontuação dos BENEFICIÁRIOs de acordo com os critérios estabelecidos
        public List<Beneficiario> ConsultarPontuacaoBeneficiario()
        {
            var query = @"SELECT B.CPF, B.NOME, B.SALARIO AS RENDATOTAL, COUNT(D.DATANASCIMENTO) AS NUMERODEPENDENTES
                          FROM BENEFICIARIO B, DEPENDENTE D
                          WHERE B.IDBENEFICIARIO = D.IDBENEFICIARIO
                          AND   DATEDIFF(YY, D.DATANASCIMENTO, GETDATE()) <= 18
                          GROUP BY B.CPF, B.NOME, B.SALARIO
                          ORDER BY B.CPF
                        ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Beneficiario>(query).ToList();
            }
        }

    }
}
