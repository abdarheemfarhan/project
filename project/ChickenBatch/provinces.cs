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
    public partial class provinces : Form
    {
        DataTable dt = new DataTable();
        public provinces()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void provinces_Load(object sender, EventArgs e)

        {
            db.view_all(Link.link.url_select_province, dt, dataGridView2);
            db.view_combox_city(ComboBox_city, Link.link.url_select_city);
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_provinec.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_provinces.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            ComboBox_city.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //dataGridView2.Columns[2].HeaderText = "cccccc";
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView2_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.RefreshEdit();
//            dataGridView2.Refresh();
        }

        private async void provinces_Shown(object sender, EventArgs e)
        {
           await Task.Delay(500);
            dataGridView2.Columns[0].HeaderText = "رقم الحافظة";
            dataGridView2.Columns[1].HeaderText = "اسم الحافظة";
            dataGridView2.Columns[2].HeaderText = "رقم المدينة";

        }
        private async void guna2Button3_Click(object sender, EventArgs e)
        {

            
            //db.view_all(Link.link.url_select_province, dt, dataGridView2);
           
          //  dataGridView2.Rows.Add();
            BindingContext[dt].AddNew();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name_provinces.Text.Trim() != "" && ComboBox_city.Text.Trim() != "")
            {
                DataTable d = new DataTable();
                dt = d;
                db.Insert_province(text_name_provinces.Text, Convert.ToInt16(ComboBox_city.SelectedValue), Link.link.url_add_province);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_province, dt, dataGridView2);
                //dt = d;
                // dataGridView2.Refresh();
            }
            else if (text_name_provinces.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الاسم ");

            }
            else if (ComboBox_city.Text.Trim() == "")
            {
                MessageBox.Show("ادخل رقم المدينة");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name_provinces.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("province_id", text_number_provinec.Text, Link.link.url_delete_province);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
                /*DataTable d = new DataTable();
                dt = d;
                db.view_all(Link.link.url_select_province, dt, dataGridView2);
             //   dt = d;*/
            }

        }

        private void ComboBox_city_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
