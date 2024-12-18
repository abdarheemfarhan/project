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
            b_sava.Enabled = false;
            b_cansel.Enabled = false;

        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();   
            int d = await db.select_data_id("http://localhost/poultry2_mangemantdb2/ChickenBatch/se.php?mask=aa", "customer_id");
            text_number_customer.Text = d.ToString();
            b_sava.Enabled = true;
            b_cansel.Enabled = true;
            b_update.Enabled = false;
            b_delete.Enabled = false;
            b_add.Enabled = false;

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
            b_add.Enabled = true;
        }
        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_number_customer.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("customer_id", text_number_customer.Text, Link.link.url_delete_customer);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد تعديل السجل=" + text_number_customer.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var values = new Dictionary<string, string>
            {
                { "customer_id",text_number_customer.Text },
                { "customer_name",text_name_customer.Text },
                { "customer_email",text_email_customer.Text },
                { "customer_phone",text_phone_customer.Text },
                { "city",$"{combox_city_customer.SelectedValue}" },
                { "provinces_id",$"{combox_provinces_customer.SelectedValue}"},
                { "araer_id",$"{combox_arera_customer.SelectedValue}"},
            };

                db.update_all(values, Link.link.url_update_customer);
                BindingContext[dt].EndCurrentEdit();
                dataGridView2.Refresh();
            }
        }

        private void b_cansel_Click(object sender, EventArgs e)
        {
            b_add.Enabled = true;
            BindingContext[dt].CancelCurrentEdit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position += 1;
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position -= 1;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position = 1;
        }
    }
}
