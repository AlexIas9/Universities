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
    public partial class Form4 : Form
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
        private string id;
        public Form4(string id, string name)
        {
            this.id = id;
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
            textBox1.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlCommand sqlCommand = new SqlCommand("UPDATE Facultati SET nameFac = @nameFac, code = @code WHERE id = @id", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@id", this.id);
                sqlCommand.Parameters.AddWithValue("@nameFac", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@code", (comboBox1.SelectedItem as ComboboxItem).Value);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception _ex)
                {
                    MessageBox.Show(_ex.ToString());
                }
                sqlConnection.Close();
            }
        }
    }
}
