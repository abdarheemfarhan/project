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
  
    public partial class chicken_batch_tab : Form
    {
        DataTable dt = new DataTable();
        public chicken_batch_tab()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
        private void combox_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.view_combox_user(combox_users, Link.link.url_select_users);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void chicken_batch_tab_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_chicken_batch_tab,dt,dataGridView2);
            db.view_combox_chicken(combox_chicken_type, Link.link.url_select_chicken);
        }

        private async void chicken_batch_tab_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100);
            //dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[0].HeaderText = "الدفعة";
            dataGridView2.Columns[1].HeaderText = "نوع الدجاج";
            dataGridView2.Columns[2].HeaderText = "المشروع";
            dataGridView2.Columns[3].HeaderText = "المستخدم";
            dataGridView2.Columns[4].HeaderText = "تاريخ الادخال";
            dataGridView2.Columns[5].HeaderText = "الفقسة";
            dataGridView2.Columns[6].HeaderText = "التفاصيل";
        }

        private void text_name_users_TextChanged(object sender, EventArgs e)
        {

        }
        private void combox_chicken_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.view_combox_project(combox_project, Link.link.select_project);
        }

        private void combox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (combox_chicken_type.Text.Trim() != "" && combox_project.Text.Trim() != "" && data_batch.Text.Trim() != "" && text_f.Text.Trim()!= "")
            {
                    DataTable d = new DataTable();
                    dt = d;
                db.insert_chicken_batch_tab(Convert.ToInt16(combox_chicken_type.SelectedValue), Convert.ToInt16(combox_project.SelectedValue), Convert.ToInt16(combox_users.SelectedValue),
                    data_batch.Text,int.Parse(text_f.Text),text_datals_batch.Text,Link.link.url_add_chicken_batch_tab);
                    dataGridView2.Refresh();
                db.view_all(Link.link.url_select_chicken_batch_tab,dt,dataGridView2);
                dataGridView2.Refresh();
                }
            else if (combox_chicken_type.Text.Trim() == "")
            {
                MessageBox.Show("ادخل النوع ");
            }
            else if (combox_project.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  المشروع ");
            }
            else if (combox_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل المشرف");
            }
            else if (data_batch.Text.Trim() == "")
            {
                MessageBox.Show("ادخل تاريخ الادخال");
            }
            else if (text_f.Text.Trim() == "")
            {
                MessageBox.Show("ادخل نوع الفقسة");
            }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_batch_id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_f.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            text_datals_batch.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_number_batch_id.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("batch_id", text_number_batch_id.Text, Link.link.url_delete_chicken_batch_tab);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position += 1;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
          BindingContext[dt].Position-=1;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد تعديل السجل=" + text_number_batch_id.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                DataTable d = new DataTable();
                dt = d;
                db.update_chicken_batch_tab(text_number_batch_id.Text,Convert.ToInt16(combox_chicken_type.SelectedValue), Convert.ToInt16(combox_project.SelectedValue), Convert.ToInt16(combox_users.SelectedValue),
                    data_batch.Text, int.Parse(text_f.Text), text_datals_batch.Text, Link.link.url_update_chicken_batch_tab);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_chicken_batch_tab, dt, dataGridView2);
                dataGridView2.Refresh();
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            BindingContext[dt].CancelCurrentEdit();
        }
    }
}
