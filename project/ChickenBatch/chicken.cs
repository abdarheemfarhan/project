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
 
    public partial class chicken : Form
    {
        DataTable dt = new DataTable();

        public chicken()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name_chicken.Text.Trim() != "" && text_datiels.Text.Trim() != "")
            {
                DataTable d = new DataTable();
                dt = d;
                db.insert_job_chicken("chicken_type", text_name_chicken.Text, text_datiels.Text, Link.link.url_add_chicken);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_chicken, dt, dataGridView2);

            }
            else if (text_name_chicken.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الاسم ");

            }
            else if (text_datiels.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  تفاصيل");
            }
        }

        private void chicken_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_chicken, dt, dataGridView2);

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_chicken.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_chicken.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            text_datiels.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();

        }

        private async void chicken_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100);
            dataGridView2.Columns[0].HeaderText = "رقم الدجاج";
            dataGridView2.Columns[1].HeaderText = "نوع الدجاج";
            dataGridView2.Columns[2].HeaderText = "تفاصيل الدجاج";

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name_chicken.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("chicken_id", text_number_chicken.Text, Link.link.url_delete_chicken);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);

            }
        }
    }
}
