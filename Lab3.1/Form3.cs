using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3._1
{
    public partial class Form3 : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        SqlConnection sqlConnection = new SqlConnection();
        DataSet Universitati;
        public Form3()
        {
            InitializeComponent();
            sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Niculai Ilie-Traian\Documents\II\Laboratoare\Laborator 3\Lab3.1\Lab3.1\Database1.mdf"";Integrated Security=True";
            sqlConnection.Open();
            Universitati = new DataSet();
            SqlDataAdapter daUniversitati = new SqlDataAdapter("SELECT code, nameUniv FROM Universitati", sqlConnection);
            daUniversitati.Fill(Universitati, "Universitati");

            foreach (DataRow dr in Universitati.Tables["Universitati"].Rows)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dr.ItemArray.GetValue(1).ToString();
                item.Value = dr.ItemArray.GetValue(0).ToString();
                comboBox1.Items.Add(item);
            }
            sqlConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelCode.Text = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int code = 0;

            Int32.TryParse(labelCode.Text, out code);
            if (facultyName.TextLength > 0 && code > 0)
            {
                bool success = true;
                string query = "INSERT INTO dbo.Facultati (code, nameFac) VALUES (@code, @nameFac)";
                using(SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@code", code));
                    command.Parameters.Add(new SqlParameter("@nameFac", facultyName.Text));
                    try
                    {
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                }
                    catch (Exception _ex)
                    {
                        success = false;
                        MessageBox.Show(_ex.ToString());
                    }
                    sqlConnection.Close();
                    if (success)
                    {
                        MessageBox.Show("Facultatea " + facultyName.Text + "fost adaugata cu succes!");
                    }
                }
            } 
            else
            {
                MessageBox.Show("Toate campule trebuie completate!");
            }
        }
    }
}
