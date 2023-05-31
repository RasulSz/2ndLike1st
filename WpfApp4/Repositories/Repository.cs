using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp4.Models;

namespace WpfApp4.Repositories
{
    public class Repository
    {
        SqlConnection conn;
        string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DataSet set = new DataSet();
        public Repository()
        {
            conn = new SqlConnection();

            using (conn = new SqlConnection())
            {
                var da = new SqlDataAdapter();
                conn.ConnectionString = cs;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Authors", conn);

                da.SelectCommand = command;
                da.Fill(set, "AuthorsSet");
            }
        }

        public DataSet GetAll()
        {
            return set;
        }

        public void Insert(int id, string firstName, string lastName)
        {
            using (conn = new SqlConnection())
            {
                var command = new SqlCommand("INSERT INTO Authors(Id,FirstName,LastName) VALUES(@id,@firstName,@lastName)", conn);
                conn.ConnectionString = cs;
                conn.Open();

                command.Parameters.Add(new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@id",
                    Value = id
                });

                command.Parameters.Add(new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@firstName",
                    Value = firstName
                });

                command.Parameters.Add(new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@lastName",
                    Value = lastName
                });

                var da = new SqlDataAdapter();
                da.InsertCommand = command;
                da.InsertCommand.ExecuteNonQuery();
                da.Update(set, "AuthorsSet");
                set.Clear();

                da = new SqlDataAdapter("SELECT * FROM Authors", conn);

                da.Fill(set, "AuthorsSet");


            }
        }
    }
}
