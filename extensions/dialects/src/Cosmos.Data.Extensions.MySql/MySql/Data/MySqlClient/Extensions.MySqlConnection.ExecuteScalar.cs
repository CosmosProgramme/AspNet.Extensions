﻿// Description: C# Extension Methods | Enhance the .NET Framework and .NET Core with over 1000 extension methods.
// Website & Documentation: https://csharp-extension.com/
// Issues: https://github.com/zzzprojects/Z.ExtensionMethods/issues
// License (MIT): https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

using System;
using System.Data;

namespace MySql.Data.MySqlClient
{
    public static partial class MySqlClientExtensions
    {
        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, MySqlParameter[] parameters, CommandType commandType, MySqlTransaction transaction)
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

                return command.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(this MySqlConnection @this, Action<MySqlCommand> commandFactory)
        {
            using (var command = @this.CreateCommand())
            {
                commandFactory(command);

                return command.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText)
        {
            return @this.ExecuteScalar(cmdText, null, CommandType.Text, null);
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, MySqlTransaction transaction)
        {
            return @this.ExecuteScalar(cmdText, null, CommandType.Text, transaction);
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, CommandType commandType)
        {
            return @this.ExecuteScalar(cmdText, null, commandType, null);
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, CommandType commandType, MySqlTransaction transaction)
        {
            return @this.ExecuteScalar(cmdText, null, commandType, transaction);
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, MySqlParameter[] parameters)
        {
            return @this.ExecuteScalar(cmdText, parameters, CommandType.Text, null);
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, MySqlParameter[] parameters, MySqlTransaction transaction)
        {
            return @this.ExecuteScalar(cmdText, parameters, CommandType.Text, transaction);
        }

        public static object ExecuteScalar(this MySqlConnection @this, string cmdText, MySqlParameter[] parameters, CommandType commandType)
        {
            return @this.ExecuteScalar(cmdText, parameters, commandType, null);
        }
    }
}