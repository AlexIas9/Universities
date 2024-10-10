using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Niculai Ilie-Traian\Documents\II\Laboratoare\Laborator 3\Lab3.1\Lab3.1\Database1.mdf"";Integrated Security=True";
                var procedure = "dbo.InserareUniversitate";
                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    bool success = true;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@numeUniversitate", universityName.Text));
                    command.Parameters.Add(new SqlParameter("@numeOras", cityName.Text));
                    command.Parameters.Add(new SqlParameter("@code", universityCode.Text));
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch(Exception _ex)
                    {
                        success = false;
                        MessageBox.Show("Eroare: " + _ex.ToString());
                    }
                    connection.Close();
                    if(success)
                    {
                        MessageBox.Show("Universitatea " + universityName.Text + " a fost adaugata!");
                    }
                }
            }
        }
    }
}
