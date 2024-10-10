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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3._1
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();

            sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ias\Documents\II\Laboratoare\Laborator 3\Lab3.1\Lab3.1\Database1.mdf"";Integrated Security=True";
            sqlConnection.Open();
            Universitati = new DataSet();
            SqlDataAdapter daUniversitati = new SqlDataAdapter("SELECT * FROM Universitati", sqlConnection);
            daUniversitati.Fill(Universitati, "Universitati");

            foreach(DataRow dr in Universitati.Tables["Universitati"].Rows)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dr.ItemArray.GetValue(1).ToString();
                item.Value = dr.ItemArray.GetValue(3).ToString();
                listBoxUniversitati.Items.Add(item);
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void listBoxUniversitati_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxFaculty.Items.Clear();
            string code = (listBoxUniversitati.SelectedItem as ComboboxItem).Value; ;
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT id, nameFac FROM Facultati WHERE code = @code", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@code", code);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while(reader.Read())
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = reader["id"].ToString();
                    item.Text = reader["nameFac"].ToString();
                    listBoxFaculty.Items.Add(item);
                }
                sqlConnection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id;
            if(listBoxFaculty.SelectedIndex >= 0)
            {
                id = (listBoxFaculty.SelectedItem as ComboboxItem).Value;
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Facultati WHERE id = @id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch(Exception _ex)
                    {
                        MessageBox.Show(_ex.ToString());
                    }
                    sqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Alege o facultate!");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBoxFaculty.SelectedIndex >= 0)
            {
                Form4 form4 = new Form4((listBoxFaculty.SelectedItem as ComboboxItem).Value, (listBoxFaculty.SelectedItem as ComboboxItem).Text);
                form4.Show();
            } 
            else
            {
                MessageBox.Show("Alege o facultate!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Facultati' table. You can move, or remove it, as needed.
            this.facultatiTableAdapter.Fill(this.database1DataSet.Facultati);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int rowId = dataGridView2.CurrentCell.RowIndex;
            using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Facultati WHERE id = @id", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@id", dataGridView2.Rows[rowId].Cells[0].Value.ToString());
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

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = dataGridView2.CurrentCell.RowIndex;
            using (SqlCommand sqlCommand = new SqlCommand("UPDATE Facultati SET nameFac = @nameFac, code = @code WHERE id = @id", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@id", dataGridView2.Rows[rowId].Cells[0].Value.ToString());
                sqlCommand.Parameters.AddWithValue("@nameFac", dataGridView2.Rows[rowId].Cells[2].Value.ToString());
                sqlCommand.Parameters.AddWithValue("@code", dataGridView2.Rows[rowId].Cells[1].Value.ToString());
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
