using Dapper;
using ProjetoDigix.Entities;
using ProjetoDigix.Interfaces;
using ProjetoDigix.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjetoDigix.Interfaces
{
    internal interface IFamiliaRepository : IBaseRepository<Familia, Guid>
    {

    }
}

