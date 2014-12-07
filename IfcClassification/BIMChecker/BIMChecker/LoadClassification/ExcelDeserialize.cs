using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Threading.Tasks;

namespace BIMChecker
{
    class ExcelDeserialize
    {
        public void readExcel(String excelPath,String sheetName,ref DataTable dt) 
        {
            OleDbConnection ole = null;
            OleDbDataAdapter da = null;
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
                             + "Data Source=" + excelPath.Trim() + ";"
                             + "Extended Properties=Excel 5.0";
            //string sTableName = combox1.Text.Trim();
            string strExcel = "select * from [" + sheetName + "]";
            try
            {
                ole = new OleDbConnection(strConn);
                ole.Open();
                da = new OleDbDataAdapter(strExcel, ole);
                dt = new DataTable();
                da.Fill(dt);
                ole.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                if (ole != null)
                    ole.Close();
            }
        }
    }
}
