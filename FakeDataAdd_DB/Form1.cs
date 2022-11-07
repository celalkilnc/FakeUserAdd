using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeDataAdd_DB
{
    public partial class Form1 : Form
    {
        List<string> schools = new List<string>();
        Database db = new Database();
        public Form1()
        {
            InitializeComponent();
            schools.Add("Akdeniz Üni.");
            schools.Add("Ege Üni.");
            schools.Add("Pamukkale Üni.");
            schools.Add("Dokuz Eylül Üni.");
            schools.Add("Adnan Menderes Üni.");
            schools.Add("Aydın Üni.");
            schools.Add("İstanbul Teknik Üni.");
            schools.Add("Yıldız Teknik Üni.");
            schools.Add("Hacettepe Üni.");
            schools.Add("Özyeğin Üni.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 400; i++)
            {
                #region values
                int id = db.idCreator();
                string name = FakeData.NameData.GetFirstName();
                string surname = FakeData.NameData.GetSurname();
                string school = schools[random.Next(0, (schools.Count))];
                string email = FakeData.NetworkData.GetEmail(name, surname);
                string password = "123";
                #endregion

                db.AddUserDB(id, name, surname, school, email, password);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
