using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.DeliveryOrder
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        async private void Supplier_Load(object sender, EventArgs e)
        {



            DataTable dt = new DataTable();

            dt = await HttpRequest.HttpRequest.select_data(Link.link.select_supplier);

            dataGridView2.DataSource = dt;

            string[] colums_name = { "الرقم", "اسم المورد", "الهاتف", "البريد", "المدينة", "المحافظة", "المنطقة" };

            GenrFuncation.name_dataGrad_header(dataGridView2.Columns , colums_name);

            GenrFuncation.Fill_comobox(await HttpRequest.HttpRequest.select_data(Link.link.select_city), ComboBox_city);
            GenrFuncation.Fill_comobox(await HttpRequest.HttpRequest.select_data(Link.link.select_prov), combox_prov);
            GenrFuncation.Fill_comobox(await HttpRequest.HttpRequest.select_data(Link.link.select_areas), combox_area);





        }


        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_sup_name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_supp_phone.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_supp_email.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            ComboBox_city.SelectedValue = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            combox_prov.SelectedValue = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            combox_area.SelectedValue = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {




            var values = new Dictionary<string, string> {
                { "supp_name",$"{txt_sup_name.Text}"},
             { "supp_phone",$"{txt_supp_phone.Text}"},
             { "supp_email",$"{txt_supp_email.Text}"},
             { "city_id",$"{ComboBox_city.SelectedValue}"},
             { "prov_id",$"{combox_prov.SelectedValue}"},
             { "area_id",$"{combox_area.SelectedValue}"},

            };

            HttpRequest.HttpRequest.insert_data(Link.link.add_supplier
                , values);
        }
    }
}
