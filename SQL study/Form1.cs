using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SQL_study
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = loginFeald.Text;
            string passUser = passFeald.Text;
            try
            {
ProfilesBase Pb = new ProfilesBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@lU AND `pass`=@pU",Pb.GetConnection() );
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = passUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);

                if(table.Rows.Count > 0)
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }       
            else MessageBox.Show("Что-то не найден");
            }
            catch (Exception)
            {

                MessageBox.Show("Что-то пошло не так, похоже сервер не подключен");
            }
            


        }

        private void goToReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegForm regForm = new RegForm();
            regForm.Show();
        }
    }
}
