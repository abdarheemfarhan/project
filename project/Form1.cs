using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace project
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            //dataGridView1.DataSource = dt;
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBox_city_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           // 
//MessageBox.Show("s");
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           //essageBox.Show("ss");
            ///aGridView1.Rows.Add();


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
          //  MessageBox.Show("s");

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ssageBox.Show("sggggggggg");

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
           // MessageBox.Show("sjhjhj");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("s");

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
             
            //MessageBox.Show("s");

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)

        {
            if (string.IsNullOrWhiteSpace (e.FormattedValue.ToString()))
            {
                MessageBox.Show( "niu", "c", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode==Keys.Enter && dataGridView1.CurrentCell.RowIndex==dataGridView1.Rows.Count-1&& 
                dataGridView1.CurrentCell.ColumnIndex==dataGridView1.Columns.Count-1)
            {
                e.Handled = true;
                dataGridView1.Rows.Add();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }

        }
    }
}