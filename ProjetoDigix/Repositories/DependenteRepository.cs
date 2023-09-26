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
    public class DependenteRepository : IBaseRepository<Dependente, Guid>
    {

        public void Inserir(Dependente obj)
        {
            var query = @"INSERT INTO DEPENDENTE(IDDEPENDENTE, NOME, DATANASCIMENTO, IDBeneficiario) 
                          VALUES(@IDDEPENDENTE, @NOME, @DATANASCIMENTO, @IDBeneficiario)";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Dependente obj)
        {
            var query = @"UPDATE DEPENDENTE SET NOME = @NOME, DATANASCIMENTO = @DATANASCIMENTO, 
                          	IDBeneficiario = @IDBeneficiario 
                            WHERE IDDEPENDENTE = @IDDEPENDENTE";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Dependente obj)
        {
            var query = @"DELETE FROM DEPENDENTE 
                            WHERE IDDEPENDENTE = @IDDEPENDENTE";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Dependente> Consultar()
        {
            var query = @"SELECT * FROM DEPENDENTE 
                          ORDER BY NOME";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Dependente>(query).ToList();
            }

        }

        public Dependente ObterPorId(Guid id)
        {
            var query = @"SELECT * FROM DEPENDENTE 
                          WHERE IDDEPENDENTE = @ID";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Dependente>(query, new { id }).FirstOrDefault();
            }

        }
    }
}
