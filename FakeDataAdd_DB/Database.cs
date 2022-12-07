using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FakeDataAdd_DB
{
    internal class Database
    {
        const string connectionString = @"Data Source=LAPTOP-60OVNJGF;Initial Catalog=LibraryTest;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionString);

        public void AddUserDB(int id, string name, string surname, string schoolname, string email, string password)
        {
            string commandStr = $"INSERT INTO tblUsers(UserID,UserName,UserSurname,refSchoolID,UserEmail,UserPassword) VALUES ({id},{name},{surname},{schoolname},{email},{password})";

            connection.Open();
            ReturnCommand(commandStr, connection, CommandTypeActive: false).ExecuteNonQuery();
            connection.Close();
        }

        public int idCreator()
        {
            Random random = new Random();
            int id; bool ctrl = false;

            while (ctrl)
            {
                id = random.Next(1000000, 9999999);
                if (!idControl(id)) { return id; }
            }
            return 0;
        }

        private bool idControl(int id)
        {
            SqlDataReader reader;

            connection.Open();
            reader = ReturnCommand("Select UserID From TblUsers",connection,true).ExecuteReader();

            while (reader.Read())
            {
                if (id == Convert.ToInt32(reader["UserID"]))
                {
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            
            return false;
        }

        private SqlCommand ReturnCommand(string CommandString, SqlConnection connection ,bool CommandTypeActive)
        {
            SqlCommand cmd = new SqlCommand(CommandString, connection);
            if (CommandTypeActive) { cmd.CommandType = CommandType.Text; }
            
            return cmd;
        }
    }
}
