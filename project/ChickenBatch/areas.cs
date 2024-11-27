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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project.ChickenBatch
{
    public partial class areas : Form
    {
        DataTable dt = new DataTable();
        public areas()
        {
            InitializeComponent();
        }

        private void areas_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_areas, dt, dataGridView2);
            db.view_combox_provinse(combox_proinces,Link.link.url_select_com_pro);


        }

        private async void areas_Shown(object sender, EventArgs e)
        {
            await Task.Delay(200);
            dataGridView2.Columns[0].HeaderText = "رقم المنطقة";
            dataGridView2.Columns[1].HeaderText = "اسم المنطقة";
            dataGridView2.Columns[2].HeaderText = "رقم المحافظة";

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_araes.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_areas.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //combox_proinces.SelectedText = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name_areas.Text.Trim() != "" && combox_proinces.Text.Trim() != "")
            {
                DataTable data = new DataTable();
                dt = data;
                
                db.insert_areas(text_name_areas.Text, Convert.ToUInt16(combox_proinces.SelectedValue), link.url_add_areas);
                dataGridView2.Refresh();
                db.view_all(Link.link.url_select_areas, dt, dataGridView2);
            }
            else if (text_name_areas.Text.Trim() == "") {
                MessageBox.Show("ادخل الاسم ");

            }
            else if (combox_proinces.Text.Trim() == "")
            {
                MessageBox.Show("ادخل رقم المحافظة");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name_areas.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("area_id", text_number_araes.Text, Link.link.url_delete_areas);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position -= 1;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position +=1;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private async void guna2Button7_Click(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void combox_proinces_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
public class Item
{
    public int province_id { get; set; }
    public string province_name { get; set; }
}

