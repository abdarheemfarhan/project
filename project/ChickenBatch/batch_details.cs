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
    public partial class batch_details : Form
    {
        DataTable dt = new DataTable();
        public batch_details()
        {
            InitializeComponent();
        }
        private void batch_details_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_batch_details, dt, dataGridView1);
            db.view_combox_farm(combox_farm, Link.link.url_select_farm);
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_detalis.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            text_batch.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            text_qountity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private async void batch_details_Shown(object sender, EventArgs e)
        {
            await Task.Delay(200);
            dataGridView1.Columns[0].HeaderText = "رقم التفاصيل";
            dataGridView1.Columns[1].HeaderText = " رقم الدفعة";
            dataGridView1.Columns[2].HeaderText = "المزرعة ";
            dataGridView1.Columns[3].HeaderText = "الكمية ";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_batch.Text.Trim() != "" && combox_farm.Text.Trim() != "" && text_qountity.Text.Trim() != "")
            {
                DataTable d = new DataTable();
                dt = d;
                db.insert_batch_details(int.Parse(text_batch.Text),Convert.ToInt16(combox_farm.SelectedValue), int.Parse(text_qountity.Text), Link.link.url_add_batch_details);
                dataGridView1.Refresh();
                db.view_all(Link.link.url_select_batch_details, dt, dataGridView1);

            }
            else if (text_batch.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الدفعة ");

            }
            else if (combox_farm.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  المزرعة");
            }
            else if (text_qountity.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  الكمية");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_number_detalis.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("details_id", text_number_detalis.Text, Link.link.url_delete_batch_details);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }
    
    }
}
