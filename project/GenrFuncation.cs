using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public class GenrFuncation
    {
        public static void Fill_comobox(DataTable dataTable, ComboBox comboBox)
        {
            comboBox.DataSource = dataTable;

            comboBox.DisplayMember = dataTable.Columns[1].ColumnName;
            comboBox.ValueMember = dataTable.Columns[0].ColumnName;
        }
        public static void name_dataGrad_header(DataGridViewColumnCollection colums, string[] colum_name)
        {
            for (int i = 0; i < colums.Count; i++)
            {
                colums[i].HeaderText = colum_name[i];
            }
        }
    }

}
