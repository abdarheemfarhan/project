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
    public partial class customer : Form
    {
        DataTable dt = new DataTable();
        public customer()
        {
            InitializeComponent();
        }
        private async void customer_Load(object sender, EventArgs e)
        {
            dt = await db.select_data(Link.link.url_select_customer);
            dataGridView2.DataSource = dt;
            text_number_customer.DataBindings.Add("text", dt, "customer_id");
            text_name_customer.DataBindings.Add("text", dt, "customer_name");
            text_phone_customer.DataBindings.Add("text", dt, "customer_phone");
            text_email_customer.DataBindings.Add("text", dt, "customer_email");
            combox_city_customer.DataBindings.Add("SelectedValue", dt, "city");
            combox_provinces_customer.DataBindings.Add("SelectedValue", dt, "provinces_id");
            combox_arera_customer.DataBindings.Add("SelectedValue", dt, "araer_id");
            db.Fill_comobox(await db.select_data(Link.link.url_select_city), combox_city_customer);
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();   
            int d = await db.select_data_id("http://localhost/poultry2_mangemantdb2/ChickenBatch/se.php?mask=aa", "customer_id");
            text_number_customer.Text = d.ToString();
        }
        private async void combox_provinces_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Fill_comobox(await db.select_data(Link.link.url_select_areas),combox_arera_customer);
        }
        private async void combox_arera_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private async void combox_city_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Fill_comobox(await db.select_data(Link.link.url_select_province), combox_provinces_customer);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string>
            {
                { "customer_name",text_name_customer.Text },
                { "customer_email",text_email_customer.Text },
                { "customer_phone",text_phone_customer.Text },
                { "city",$"{combox_city_customer.SelectedValue}" },
                { "provinces_id",$"{combox_provinces_customer.SelectedValue}"},
                { "araer_id",$"{combox_arera_customer.SelectedValue}"},
            };

            db.insert_all(values, Link.link.url_add_customer);
            BindingContext[dt].EndCurrentEdit();
            dataGridView2.Refresh();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_number_customer.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("customer_id", text_number_customer.Text, Link.link.url_delete_customer);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }
    }
}
