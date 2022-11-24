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
        static SqlCommand command;

        public void AddUserDB(int id, string name, string surname, string schoolname, string email, string password)
        {
            command = new SqlCommand(@"INSERT INTO tblUsers(UserID,UserName,UserSurname,refSchoolID,UserEmail,UserPassword) VALUES (@id,@name,@surname,@schoolId,@email,@password)", connection);

            #region commands
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@schoolId", schoolname);//Düzeltme : 'refSchoolID' int(id) değil 'okul adı'(string) alır
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            #endregion

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public int idCreator()
        {
            Random random = new Random();
            int id;
            bool ctrl = false;
            while (ctrl)
            {
                id = random.Next(1000000, 9999999);
                if (!idControl(id))
                {
                    return id;
                }
            }
            return 0;
        }

        private bool idControl(int id)
        {
            SqlCommand tblschlcommand = new SqlCommand("Select UserID From TblUsers", connection);
            tblschlcommand.CommandType = CommandType.Text;
            SqlDataReader reader;

            connection.Open();
            reader = tblschlcommand.ExecuteReader();
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
    }
}
