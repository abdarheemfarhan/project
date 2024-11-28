using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.HttpRequest
{
    internal class HttpRequest
    {
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
        public static async void insert_data(string url, Dictionary<string, string> valuse)
        {

            // var jesonData = JsonConvert.SerializeObject(b);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //  var body = new StringContent(jesonData, Encoding.UTF8,"application/json");
                    var body = new FormUrlEncodedContent(valuse);
                    HttpResponseMessage responseMessage = await client.PostAsync(url, body);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("تم الاظافo");
                    }
                    else
                    {
                        MessageBox.Show("faild");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}");
                }

            }


        }
    }
}
