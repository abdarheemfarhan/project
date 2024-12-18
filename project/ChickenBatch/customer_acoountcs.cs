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
    public partial class customer_acoountcs : Form
    {
        DataTable dt = new DataTable();
        public customer_acoountcs()
        {
            InitializeComponent();
        }

        private async void customer_acoountcs_Load(object sender, EventArgs e)
        {
            dt = await db.select_data(Link.link.url_select_customer_acoount);
            dataGridView2.DataSource = dt;
            text_number_acoount.DataBindings.Add("text", dt, "acoount_id");
            text_number_cusomer.DataBindings.Add("text", dt, "customer_id");
            text_sel.DataBindings.Add("text", dt,"amount");
            combox_curenst.DataBindings.Add("SelectedValue", dt, "currency_id");
            combox_stata_acount.DataBindings.Add("SelectedValue", dt, "satat_id");
            data_create.DataBindings.Add("Value", dt,"create_date",true);
            text_descrip.DataBindings.Add("text", dt, "discrip");
     
        }
    }
}
