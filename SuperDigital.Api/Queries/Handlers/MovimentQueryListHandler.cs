using Dapper;
using Microsoft.Extensions.Configuration;
using SuperDigital.Api.Messages.Resource;
using SuperDigital.Api.Queries.Resources;
using SuperDigital.Domain.Model.Accounts;
using SuperDigital.Persistency.Repositories;
using SuperDigital.QueryProcessor.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Api
{
    public class MovimentQueryListHandler : IQueryListHandler<QueryMoviment, MovimentResource>
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;

        private const string SQL_QUERY = @"SELECT [DATA], 
		                                          [OPERACAO], 
		                                          [TIPO], 
		                                          [VALOR], 
		                                          [DESCRICAO], 
		                                          [CONTA_ORIGEM], 
		                                          [CONTA_DESTINO]
		                                       FROM [accounts].Moviment
                                           WHERE DATA BETWEEN @date1 AND @date2 
                                             AND CONTA_ORIGEM = @accountNumber";

        public MovimentQueryListHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<MovimentResource>> Handle(QueryMoviment query)
        {
            List<MovimentResource> movimentList = new List<MovimentResource>();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (var queryResult = conn.QueryMultiple(SQL_QUERY, new { @date1 = query.InitialDate, @date2 = query.EndDate, @accountNumber = query.AccountNumber }))
                {
                    movimentList = queryResult.Read<MovimentResource>().ToList();
                }

                return movimentList;
            }
        }
    }
}
