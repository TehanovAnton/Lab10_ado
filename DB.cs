using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace LabWork10_ado
{
    public class DB
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static void SaveUser(User user)
        {
            //добавить хранимую процедуру на вывод

            string expression =
                "insert into UserInfo(Name, LastName, Mail, Birthday, ImageData) " +
                "values(@name, @lastName, @mail, @birthDay, @imageData)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = expression;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@name", Value = user.name, SqlDbType = SqlDbType.NVarChar });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@lastName", Value = user.lastName, SqlDbType = SqlDbType.NVarChar });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@mail", Value = user.mail, SqlDbType = SqlDbType.NVarChar });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@birthDay", Value = user.dateDay, SqlDbType = SqlDbType.Date });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@imageData", Value = user.imageData, SqlDbType = SqlDbType.VarBinary });
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("ok", "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    transaction.Rollback();
                }
            }
        }

        public static bool LogIn(string nickName, int password)
        {
            string expression = "checkLog";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter
                    nickNamePara = new SqlParameter("@nickName", nickName),
                    passwordPara = new SqlParameter("@password", password),
                    logedUserPara = new SqlParameter() { ParameterName = "@logedUser", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                command.Parameters.Add(nickNamePara);
                command.Parameters.Add(passwordPara);
                command.Parameters.Add(logedUserPara);
                command.ExecuteNonQuery();
                return (int)command.Parameters["@logedUser"].Value > 0;
            }
        }

        public static void EditUser(User user)
        {
            string expression = "editUser";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(expression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { ParameterName = "@password", Value = user.userLogInfo.password, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@nickName", Value = user.userLogInfo.nickName, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@name", Value = user.name, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@lastName", Value = user.lastName, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@mail", Value = user.mail, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@birthDay", Value = user.dateDay, SqlDbType = SqlDbType.Date });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@imageData", Value = user.imageData, SqlDbType = SqlDbType.VarBinary });
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteUser(User user)
        {
            string expression =
                "delete from UserInfo where Name = @name and LastName = @lastName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = expression;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@lastName", Value = user.lastName, SqlDbType = SqlDbType.NVarChar });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@name", Value = user.name, SqlDbType = SqlDbType.NVarChar });
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    transaction.Rollback();
                }
            }
        }
    }
}
