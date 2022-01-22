using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SafePass.WebApp
{
    public class Dapper
    {
        private static readonly string _conexao = ConfigurationManager.AppSettings["CONNECTIONSTRING"];

        public Dapper()
        {
            
        }

        public int Execute(string query, object parameters, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    return conn.Execute(query, parameters, commandType: commandType);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public int Execute<T>(string query, object parameters, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    return conn.Execute(query, parameters, commandType: commandType);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public DataTable ExecuteReader(string query, object parameters, CommandType commandType)
        {
            DataTable dttResult = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    var reader = conn.ExecuteReader(query, parameters, commandType: commandType);

                    dttResult.Load(reader);

                    return dttResult;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public object ExecuteScalar(string query, object parameters, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    return conn.ExecuteScalar(query, parameters, commandType: commandType);
                }
            }
            catch (Exception ex)
            {

                return default;
            }
        }

        public T QueryFirst<T>(string query, object parameters, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    return conn.QueryFirst<T>(query, parameters, commandType: commandType);
                }
            }
            catch (Exception ex)
            {

                return default;
            }
        }

        public T QuerySingle<T>(string query, object parameters, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    return conn.QuerySingle<T>(query, parameters, commandType: commandType);
                }
            }
            catch (Exception ex)
            {

                return default;
            }
        }

        public DataTable QuerySingleOrDefault(string query, object parameters, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    return conn.QuerySingleOrDefault(query, parameters, commandType: commandType);
                }
            }
            catch (Exception ex)
            {

                return default;
            }
        }
    }
}
