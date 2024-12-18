using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace project.ChickenBatch
{
    public static class db
    {
        static DataTable dt = new DataTable();

        public static async void view_all(string link, DataTable ds, DataGridView dataGridView)
        {
            DataTable s = new DataTable();
            s = ds;
            var client = new HttpClient();
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(link);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        // var s = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseData);
                        var f = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseData);
                        foreach (var key in f[0].Keys)
                        {
                            s.Columns.Add(key);
                        }
                        foreach (var row in f)
                        {
                            var ro = s.NewRow();
                            foreach (var kvp in row)
                            {
                                ro[kvp.Key] = kvp.Value;
                            }
                            s.Rows.Add(ro);
                            dataGridView.DataSource = s;
                            dataGridView.Refresh();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            s = dt;
        }
        public static async void delete_all(string index, string city_id, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {index,city_id }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responseString = await response.Content.ReadAsStringAsync();

        }
        public static async void Insert_city(string name, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "city_name", name },
        };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }


        /* public static async void delete_city(string city_id,string link)
          {
              var client = new HttpClient();
              var values = new Dictionary<string, string> {
                  {"city_id",city_id }
              };
              var content =  new  FormUrlEncodedContent(values);
              var response = await client.PostAsync(link, content);
              var responseString = await response.Content.ReadAsStringAsync();

          }

        */  //   ------------------------------------------------------   province_id    -----------------------------------------------------------

        public static async void Insert_province(string name, int city_id, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "province_name", name },
            { "city_id", city_id.ToString() },

        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }



        //-------------------------------------------------------     araes     ---------------------------------------------------------

        public static async void insert_areas(string name_areas, int province_id, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {"area_name",name_areas},
                {"province_id",province_id.ToString()},
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responsestring = await response.Content.ReadAsStringAsync();

        }



        //-------------------------------------------------------        project        -------------------------------------------------


        public static async void Insert_project(string project_name, int city_id,int prov_id,int area_id,string create_dare,string details,string link)
        {
           
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "project_name", project_name },
            { "city_id", city_id.ToString() },
            { "prov_id", prov_id.ToString() },
            { "area_id", area_id.ToString() },
            { "create_dare", create_dare },
            { "details", details },
        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void update_project(string project_id, string project_name, int city_id, int prov_id, int area_id, string create_dare, string details, string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "project_id", project_id },
            { "project_name", project_name },
            { "city_id", city_id.ToString() },
            { "prov_id", prov_id.ToString() },
            { "area_id", area_id.ToString() },
            { "create_dare", create_dare },
            { "details", details },
        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }

        //----------------------------------------------      all job             -----------------------------------------

      public static async void insert_job_chicken(string name_table, string job_chicken_name, string job_datils,string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                {name_table ,job_chicken_name},
                {"details" ,job_datils},

            };
            var content = new FormUrlEncodedContent(values);
            var respons = await client.PostAsync(link, content);
            var respons_string = await respons.Content.ReadAsStringAsync();

        }
        //-----------------------------------------------------------    all farm   --------------------------------------------------
        public static async void insert_farm (string farm_name, int farm_qountiy, int project_id,string details, string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "farm_name", farm_name },
            { "amount_expan", farm_qountiy.ToString() },
            { "project_id", project_id.ToString() },
            { "details", details },
        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void update_farm(string farm_id , string farm_name, int farm_qountiy, int project_id, string details, string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "farm_id", farm_id },
            { "farm_name", farm_name },
            { "amount_expan", farm_qountiy.ToString() },
            { "project_id", project_id.ToString() },
            { "details", details },
        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        //------------------------------------------------   all batch_details   ---------------------------------------------
        public static async void insert_batch_details(int batch, int farm, int farm_qountiy, string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "batch_id", batch.ToString() },
            { "farm_id", farm.ToString() },
            { "quantity", farm_qountiy.ToString() },
        };
            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        //------------------------------------------------   all batch_details   ---------------------------------------------
        public static async void insert_usres(string user_name, int job_id, string pass,string conf_pass, string email,string phone,int  city_id,int prov_id,int area_id,string details, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "user_name", user_name },
            {"job_id",job_id.ToString() },
            { "password", pass },
            { "conf_pass", conf_pass.ToString() },
            { "email", email },
            { "phone", phone },
            { "city_id", city_id.ToString() },
            { "prov_id", prov_id.ToString() },
            { "area_id", area_id.ToString() },
            { "details", details },

            };
            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void update_usres(string user_id,string user_name, int job_id, string pass, string conf_pass, string email, string phone, int city_id, int prov_id, int area_id, string details, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            {"user_id",user_id},
            { "user_name", user_name },
            {"job_id",job_id.ToString() },
            { "password", pass },
            { "conf_pass", conf_pass.ToString() },
            { "email", email },
            { "phone", phone },
            { "city_id", city_id.ToString() },
            { "prov_id", prov_id.ToString() },
            { "area_id", area_id.ToString() },
            { "details", details },

            };


            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void insert_chicken_batch_tab(int chicken_type, int project, int user,string date_in,int unknow,string details,string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "chicken_type",chicken_type.ToString() },
            { "project_id",project.ToString() },
            { "user_id", user.ToString() },
            { "date_in", date_in },
            { "unknow", unknow.ToString() },
            { "details", details},

        };
            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void insert_all(Dictionary<string,string> values, string link)
        {

            var client = new HttpClient();
           
            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void update_all(Dictionary<string, string> values, string link)
        {

            var client = new HttpClient();

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void update_chicken_batch_tab(string batch_id, int chicken_type, int project, int user, string date_in, int unknow, string details, string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "batch_id",batch_id },
            { "chicken_type",chicken_type.ToString() },
            { "project_id",project.ToString() },
            { "user_id", user.ToString() },
            { "date_in", date_in },
            { "unknow", unknow.ToString() },
            { "details", details},

        };
            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        //------------------------------------------------  selelct combox all  ---------------------------------------------
        public static async void view_combox_provinse(ComboBox combox_proinces, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<Item>>(response);
                    combox_proinces.DataSource = items;
                    combox_proinces.DisplayMember = "province_name"; // عرض الاسم
                    combox_proinces.ValueMember = "province_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }
        public static async void view_combox_project(ComboBox combox_proinces, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_project>>(response);
                    combox_proinces.DataSource = items;
                    combox_proinces.DisplayMember = "project_name"; // عرض الاسم
                    combox_proinces.ValueMember = "project_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }
        public static async void view_combox_city(ComboBox combox_city, string link)
        {

            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<BindingList<com_city>>(response);
                    combox_city.DataSource = items;
                    combox_city.DisplayMember = "city_name"; // عرض الاسم
                    combox_city.ValueMember = "city_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }
        public static async void view_combox_arare(ComboBox combox_city, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_arera>>(response);
                    combox_city.DataSource = items;
                    combox_city.DisplayMember = "area_name"; // عرض الاسم
                    combox_city.ValueMember = "area_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }
        public static async void view_combox_farm(ComboBox combox_farm, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_farm>>(response);
                    combox_farm.DataSource = items;
                    combox_farm.DisplayMember = "farm_name"; // عرض الاسم
                    combox_farm.ValueMember = "farm_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }
        public static async void view_combox_user(ComboBox combox_farm, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_user>>(response);
                    combox_farm.DataSource = items;
                    combox_farm.DisplayMember = "user_name"; // عرض الاسم
                    combox_farm.ValueMember = "user_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }
        public static async void view_combox_chicken(ComboBox combox_farm, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_chicken>>(response);
                    combox_farm.DataSource = items;
                    combox_farm.DisplayMember = "chicken_type"; // عرض الاسم
                    combox_farm.ValueMember = "chicken_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }
        public static async void view_combox_job(ComboBox combox_job, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_job>>(response);
                    combox_job.DataSource = items;
                    combox_job.DisplayMember = "job_name"; // عرض الاسم
                    combox_job.ValueMember = "job_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }
        static public async Task<DataTable> select_data(string url)
        {
            DataTable data_table = new DataTable();
            // string url = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=select_project";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // إرسال طلب GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    // إذا كانت الاستجابة ناجحة
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        // var s = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseData);
                        data_table = JsonConvert.DeserializeObject<DataTable>(responseData);


                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            return data_table;

        }
        static public async Task<int> select_data_id(string url,string n)
        {
            DataTable data_table = new DataTable();
            // string url = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=select_project";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // إرسال طلب GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    // إذا كانت الاستجابة ناجحة
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        //  var s = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseData);
                         var s = JsonConvert.DeserializeObject<dynamic>(responseData);
                       // int d = int.Parse(s);
                        //MessageBox.Show("" + s["max(batch_id)"]);
                        return s["max("+n+")+1"];
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            return 0;

        }

        public static void Fill_comobox(DataTable dataTable, ComboBox comboBox)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = dataTable.Columns[1].ColumnName;
            comboBox.ValueMember = dataTable.Columns[0].ColumnName;
        }
        public static void Fill_data_comobox(DataTable dataTable, DataGridViewComboBoxColumn comboBox)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = dataTable.Columns[0].ColumnName;
            comboBox.ValueMember = dataTable.Columns[0].ColumnName;
        }
        public static async void view_combox_provinces(ComboBox comboBox,int city_id) {
            var client = new HttpClient();
            {
                string link = $"http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=view_combox_provinces&city_id={city_id}";
                try
                {
                    // استدعاء ملف PHP والحصول على النتائج
                    var response = await client.GetStringAsync(link);
                    var governates = JsonConvert.DeserializeObject<BindingList<Item>>(response);
                    var d = governates;
                     comboBox.DataSource = governates;
                    //comboBox.DataSource = d;
                    comboBox.DisplayMember = "province_name";
                    comboBox.ValueMember = "province_id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        public static async void view_combox_arare_id(ComboBox comboBox, int province_id)
        {
            var client = new HttpClient();
            {
                string link = $"http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=view_combox_arare&province_id={province_id}";
                try
                {
                    // استدعاء ملف PHP والحصول على النتائج
                    var response = await client.GetStringAsync(link);
                    var governates = JsonConvert.DeserializeObject<List<com_arera>>(response);
                    comboBox.DataSource = governates;
                    comboBox.DisplayMember = "area_name";
                    comboBox.ValueMember = "area_id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }


    }


 



    //-----------------------------------------------------------    class_get_combox   --------------------------------------------------
    public class com_city
    {
        public int city_id { get; set; }
        public string city_name { get; set; }
    }
    public class com_arera
    {
        public int area_id { get; set; }
        public string area_name { get; set; }

    }
    public class com_project
    {
        public int project_id { get; set; }
        public string project_name { get; set; }

    }
    public class com_farm
    {
        public int farm_id { get; set; }
        public string farm_name { get; set; }

    }
    public class com_job
    {
        public int job_id { get; set; }
        public string job_name { get; set; }

    }
    public class com_user
    {
       public int user_id { get; set; }
       public string user_name { get; set; }
    }

    public class com_chicken
    {
        public int chicken_id { get; set; }
        public string chicken_type { get; set; }
    }

}

