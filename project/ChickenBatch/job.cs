using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.ChickenBatch
{
    public partial class job : Form
    {
        DataTable dt = new DataTable();
        public job()
        {
            InitializeComponent();
        }
        private void job_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_job, dt, dataGridView2);
        }
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_job.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_job.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            text_datiels.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }
        private async void job_Shown(object sender, EventArgs e)
        {
           await Task.Delay(100);
            dataGridView2.Columns[0].HeaderText = "رقم الوظيفة";
            dataGridView2.Columns[1].HeaderText = "اسم الوطيفة";
            dataGridView2.Columns[2].HeaderText = "تفاصيل الوطسفة";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name_job.Text.Trim() != "" && text_datiels.Text.Trim() != "")
            {
                DataTable d = new DataTable();
                dt = d;
                db.insert_job_chicken("job_name", text_name_job.Text, text_datiels.Text, Link.link.url_add_job);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_job, dt, dataGridView2);
               
            }
            else if (text_name_job.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الاسم ");

            }
            else if (text_datiels.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  تفاصيل");
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name_job.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("job_id", text_number_job.Text, Link.link.url_delete_job);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void text_search_MouseLeave(object sender, EventArgs e)
        {
        }
        private void text_search_MouseHover(object sender, EventArgs e)
        {
            text_search.Clear();
           
        }

        private void text_search_TextChanged(object sender, EventArgs e)
        { 
            string search_name = $"job_name LIKE '%{text_search.Text}%'";
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = search_name;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            BindingContext[dt].CancelCurrentEdit();
        }
    }
}
