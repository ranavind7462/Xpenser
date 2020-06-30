using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Xpenser.WebAPI
{
    public class DapperBaseRepository
    {
        //This class handles the logging.
        public readonly ILogger  _logger;

        //This class represents a connection to the database.
        //Dapper will automatically open this connection whenever
        //it is used in a query.
        private readonly IDbConnection _conn;

        public DapperBaseRepository(ILogger logger,
                                IDbConnection conn)
        {
            _logger = logger;
            _conn = conn;
        }

        public List<T> Query<T>(string query, object parameters = null)
        {
            try
            {
                return _conn.Query<T>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<T>();
            }
        }

        [Obsolete]
        public T QuerySingle<T>(string query, object parameters = null)
        {
            try
            {
                return _conn.QuerySingle<T>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,ex.GetBaseException());
                throw;
            }
        }

        [Obsolete]
        public T QueryFirst<T>(string query, object parameters = null)
        {
            try
            {
                return _conn.QueryFirst<T>(query, parameters);
            }
            catch (Exception ex)
            {
                //var args = CreateArgs(query, parameters, methodName);
                _logger.LogError(ex.Message,ex);
                return default(T);
            }
        }
    }
}
