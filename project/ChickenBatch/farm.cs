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
    public partial class farm : Form
    {
        DataTable dt = new DataTable();
        public farm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void farm_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_farm, dt, dataGridView2);
            db.view_combox_project(combox_project, Link.link.select_project);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name_farm.Text.Trim() != "" && text_amount_expan.Text.Trim() != "" && combox_project.Text.Trim() != "")
            {
                DataTable data = new DataTable();
                dt = data;

                db.insert_farm(text_name_farm.Text,int.Parse(text_amount_expan.Text) ,Convert.ToUInt16(combox_project.SelectedValue),text_datals.Text, Link.link.url_add_farm);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_farm, dt, dataGridView2);
            }
            else if (text_name_farm.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الاسم ");

            }
            else if (text_amount_expan.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الكمية ");

            }
            else if (combox_project.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  المشروع");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name_farm.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("farm_id", text_number_farm.Text, Link.link.url_delete_farm);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);

            }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_farm.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_farm.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            text_amount_expan.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            text_datals.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();


        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هلا تريد تعديل السجل=" + text_name_farm.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataTable data = new DataTable();
                dt = data;
                db.update_farm(text_number_farm.Text,text_name_farm.Text, int.Parse(text_amount_expan.Text), Convert.ToUInt16(combox_project.SelectedValue), text_datals.Text, Link.link.url_update_farm);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_farm, dt, dataGridView2);
                dataGridView2.Refresh(); 
            }
        }

        private async void farm_Shown(object sender, EventArgs e)
        {
           await Task.Delay(100);
            dataGridView2.Columns[0].HeaderText = "رقم المزرعة";
            dataGridView2.Columns[1].HeaderText = "اسم المزرعة";
            dataGridView2.Columns[2].HeaderText = "كمية الانتاج";
            dataGridView2.Columns[3].HeaderText = "المشروع";
            dataGridView2.Columns[4].HeaderText = "تفاصيل";
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            BindingContext[dt].CancelCurrentEdit();
        }

        private void text_number_farm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
