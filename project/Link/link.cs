using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Link
{
    
   public static  class link
    {
        
       public const string select_project = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=select_project";
       public const string url_add_project = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=add_project";
       public const string url_delete_project = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=delete_project";
       public const string url_update_project = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=update_project";
       public const string url_select_city = "http://localhost/poultry2_mangemantdb2/ChickenBatch/city.php?mask=select_city";
       public const string url_add_city = "http://localhost/poultry2_mangemantdb2/ChickenBatch/city.php?mask=add_city";
       public const string url_delete_city = "http://localhost/poultry2_mangemantdb2/ChickenBatch/city.php?mask=delete_city";
       public const string url_select_province = "http://localhost/poultry2_mangemantdb2/ChickenBatch/province.php?mask=select_province";
       public const string url_add_province = "http://localhost/poultry2_mangemantdb2/ChickenBatch/province.php?mask=add_province";
       public const string url_delete_province = "http://localhost/poultry2_mangemantdb2/ChickenBatch/province.php?mask=delete_province";
       public const string url_select_areas = "http://localhost/poultry2_mangemantdb2/ChickenBatch/areas.php?mask=select_areas";
       public const string url_add_areas = "http://localhost/poultry2_mangemantdb2/ChickenBatch/areas.php?mask=add_areas";
       public const string url_delete_areas = "http://localhost/poultry2_mangemantdb2/ChickenBatch/areas.php?mask=delete_areas";
       public const string url_select_com_pro = "http://localhost/poultry2_mangemantdb2/ChickenBatch/province.php?mask=select_province";
        public const string url_select_job = "http://localhost/poultry2_mangemantdb2/ChickenBatch/jobs.php?mask=select_job";
        public const string url_add_job = "http://localhost/poultry2_mangemantdb2/ChickenBatch/jobs.php?mask=add_job";
        public const string url_delete_job = "http://localhost/poultry2_mangemantdb2/ChickenBatch/jobs.php?mask=delete_job";
        public const string url_select_chicken = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken.php?mask=select_chicken";
        public const string url_add_chicken = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken.php?mask=add_chicken";
        public const string url_delete_chicken = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken.php?mask=delete_chicken";
        public const string url_select_farm = "http://localhost/poultry2_mangemantdb2/ChickenBatch/farm.php?mask=select_farm";
        public const string url_add_farm = "http://localhost/poultry2_mangemantdb2/ChickenBatch/farm.php?mask=add_farm";
        public const string url_delete_farm = "http://localhost/poultry2_mangemantdb2/ChickenBatch/farm.php?mask=delete_farm";
        public const string url_update_farm = "http://localhost/poultry2_mangemantdb2/ChickenBatch/farm.php?mask=update_farm";
        public const string url_select_batch_details = "http://localhost/poultry2_mangemantdb2/ChickenBatch/batch_details.php?mask=select_batch_details";
        public const string url_add_batch_details = "http://localhost/poultry2_mangemantdb2/ChickenBatch/batch_details.php?mask=add_batch_details";
        public const string url_delete_batch_details = "http://localhost/poultry2_mangemantdb2/ChickenBatch/batch_details.php?mask=delete_batch_details";
        public const string url_update_batch_details = "http://localhost/poultry2_mangemantdb2/ChickenBatch/farm.php?mask=update_batch_details";
        public const string url_select_combox_chicken_batch = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken_batch.php?mask=select_chicken_batch";
        public const string url_add_users = "http://localhost/poultry2_mangemantdb2/ChickenBatch/users.php?mask=add_users";
        public const string url_delete_users = "http://localhost/poultry2_mangemantdb2/ChickenBatch/users.php?mask=delete_users";
        public const string url_update_users = "http://localhost/poultry2_mangemantdb2/ChickenBatch/users.php?mask=update_users";
        public const string url_select_users = "http://localhost/poultry2_mangemantdb2/ChickenBatch/users.php?mask=select_users";
        public const string url_select_chicken_batch_tab = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken_batch_tab.php?mask=select_chicken_batch_tab";
        public const string url_delete_chicken_batch_tab = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken_batch_tab.php?mask=delete_chicken_batch_tab";
        public const string url_update_chicken_batch_tab = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken_batch_tab.php?mask=update_chicken_batch_tab";
        public const string url_add_chicken_batch_tab = "http://localhost/poultry2_mangemantdb2/ChickenBatch/chicken_batch_tab.php?mask=add_chicken_batch_tab";
        public const string url_select_customer = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer.php?mask=select_customer";
        public const string url_delete_customer = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer.php?mask=delete_customer";
        public const string url_update_customer = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer.php?mask=update_customer";
        public const string url_add_customer = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer.php?mask=add_customer";
        public const string url_select_customer_acoount = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer_acoount.php?mask=select_customer_acoount";
        public const string url_delete_customer_acoount = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer_acoount.php?mask=delete_customer_acoount";
        public const string url_update_customer_acoount = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer_acoount.php?mask=update_customer_acoount";
        public const string url_add_customer_acoount = "http://localhost/poultry2_mangemantdb2/ChickenBatch/customer_acoount.php?mask=add_customer_acoount";

    }

}
