using Newtonsoft.Json;
using project.Link;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.ChickenBatch
{
    public partial class project : Form
    {
        DataTable dt = new DataTable();
        public project()
        {
            InitializeComponent();
        }
        private void project_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.select_project, dt, dataGridView2);
            db.view_combox_city(combox_city, Link.link.url_select_city);
          //  db.view_combox_provinse(combox_provinces, Link.link.url_select_province);
            //db.view_combox_arare(combox_arera, Link.link.url_select_areas);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_project.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            text_datals.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name.Text.Trim() != "" && combox_city.Text.Trim() != "" && combox_provinces.Text.Trim() != "" && combox_arera.Text.Trim() != ""
                && date_Time_Picker.Text.Trim() != "" && text_datals.Text.Trim() != "")
            {
                db.Insert_project(text_name.Text, Convert.ToInt16(combox_city.SelectedValue),
                 Convert.ToInt16(combox_provinces.SelectedValue), Convert.ToInt16(combox_arera.SelectedValue),
               date_Time_Picker.Value.ToShortDateString(), text_datals.Text, Link.link.url_add_project);
                DataTable data = new DataTable();
                dt = data;
                dataGridView2.Refresh();
                db.view_all(Link.link.select_project, data, dataGridView2);
                dataGridView2.Refresh();
            }
            else if (text_name.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الاسم");
            }
            else if (combox_city.Text.Trim() == "")
            {
                MessageBox.Show("ادخل المدينة");
            }
            else if (combox_provinces.Text.Trim() == "")
            {
                MessageBox.Show("ادخل المحافظة");
            }
            else if (combox_arera.Text.Trim() == "")
            {
                MessageBox.Show("ادخل المنطقة");
            }
            else
            {
                MessageBox.Show("dddddddddd");
            }
        }

        private async void project_Shown(object sender, EventArgs e)
        {
            await Task.Delay(150);
            dataGridView2.Columns[0].HeaderText = "الرقم";
            dataGridView2.Columns[1].HeaderText = "اسم المشروع";
            dataGridView2.Columns[2].HeaderText = " المدينة";
            dataGridView2.Columns[3].HeaderText = " المحافظة";
            dataGridView2.Columns[4].HeaderText = " المنطقة";
            dataGridView2.Columns[5].HeaderText = "  تاريخ الانشاء";
            dataGridView2.Columns[6].HeaderText = " التفاصيل";
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("project_id", text_number_project.Text, Link.link.url_delete_project);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }

        private void text_number_project_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position += 1;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            BindingContext[dt].Position -= 1;

        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position = 1;

        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد تعديل السجل=" + text_name.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.update_project(text_number_project.Text, text_name.Text, Convert.ToInt16(combox_city.SelectedValue),
                Convert.ToInt16(combox_provinces.SelectedValue), Convert.ToInt16(combox_arera.SelectedValue),
              date_Time_Picker.Value.ToShortDateString(), text_datals.Text, Link.link.url_update_project);
                DataTable data = new DataTable();
                dt = data;
                dataGridView2.Refresh();
                db.view_all(Link.link.select_project, data, dataGridView2);
                dataGridView2.Refresh();
            }

        }

        private async void combox_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Delay(100);
            db.view_combox_provinces(combox_provinces,Convert.ToInt16(combox_city.SelectedValue));
        }

        private async void combox_provinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Delay(100);
           //MessageBox.Show(" sd" + combox_provinces.SelectedValue);
            db.view_combox_arare_id(combox_arera,Convert.ToInt16(combox_provinces.SelectedValue));

        }

        private void text_search_TextChanged(object sender, EventArgs e)
        {
            string search_name = $"project_name LIKE '%{text_search.Text}%'";
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = search_name;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position -= 1;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            BindingContext[dt].CancelCurrentEdit();

        }
    }
}
