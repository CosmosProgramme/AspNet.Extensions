using System;
using System.Data;

namespace Oracle.ManagedDataAccess.Client
{
    public static partial class OracleClientExtensions
    {
        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, OracleParameter[] parameters, CommandType commandType, OracleTransaction transaction)
            where T : new()
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

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return reader.ToEntity<T>();
                }
            }
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, Action<OracleCommand> commandFactory) where T : new()
        {
            using (var command = @this.CreateCommand())
            {
                commandFactory(command);

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return reader.ToEntity<T>();
                }
            }
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, null, CommandType.Text, null);
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, OracleTransaction transaction) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, null, CommandType.Text, transaction);
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, CommandType commandType) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, null, commandType, null);
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, CommandType commandType, OracleTransaction transaction) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, null, commandType, transaction);
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, OracleParameter[] parameters) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, parameters, CommandType.Text, null);
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, OracleParameter[] parameters, OracleTransaction transaction) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, parameters, CommandType.Text, transaction);
        }

        public static T ExecuteEntity<T>(this OracleConnection @this, string cmdText, OracleParameter[] parameters, CommandType commandType) where T : new()
        {
            return @this.ExecuteEntity<T>(cmdText, parameters, commandType, null);
        }
    }
}