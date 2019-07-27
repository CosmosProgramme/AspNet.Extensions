using System;
using System.Data;

namespace Oracle.ManagedDataAccess.Client
{
    public static partial class OracleClientExtensions
    {
        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, OracleParameter[] parameters, CommandType commandType, OracleTransaction transaction)
        {
            using (var command = @this.CreateCommand())
            {
                command.CommandText = cmdText;
                command.CommandType = commandType;
                command.Transaction = transaction;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                var ds = new DataSet();
                using (var dataAdapter = new OracleDataAdapter(command))
                {
                    dataAdapter.Fill(ds);
                }

                return ds;
            }
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, Action<OracleCommand> commandFactory)
        {
            using (var command = @this.CreateCommand())
            {
                commandFactory(command);

                var ds = new DataSet();
                using (var dataAdapter = new OracleDataAdapter(command))
                {
                    dataAdapter.Fill(ds);
                }

                return ds;
            }
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText)
        {
            return @this.ExecuteDataSet(cmdText, null, CommandType.Text, null);
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, OracleTransaction transaction)
        {
            return @this.ExecuteDataSet(cmdText, null, CommandType.Text, transaction);
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, CommandType commandType)
        {
            return @this.ExecuteDataSet(cmdText, null, commandType, null);
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, CommandType commandType, OracleTransaction transaction)
        {
            return @this.ExecuteDataSet(cmdText, null, commandType, transaction);
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, OracleParameter[] parameters)
        {
            return @this.ExecuteDataSet(cmdText, parameters, CommandType.Text, null);
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, OracleParameter[] parameters, OracleTransaction transaction)
        {
            return @this.ExecuteDataSet(cmdText, parameters, CommandType.Text, transaction);
        }

        public static DataSet ExecuteDataSet(this OracleConnection @this, string cmdText, OracleParameter[] parameters, CommandType commandType)
        {
            return @this.ExecuteDataSet(cmdText, parameters, commandType, null);
        }
    }
}