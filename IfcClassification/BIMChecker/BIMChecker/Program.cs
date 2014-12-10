using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BIMChecker
{
    class Program
    {
        ExcelDeserialize excelDeserialize = new ExcelDeserialize();
        string filename = @"D:\TestData\ifcClassification\test.xml";
        public void Process()
        {
            string excelPath = @"D:\TestData\ifcClassification\Space140903.xls";
            string sheetName = @"Sheet2$";
            DataTable dt = null;
            excelDeserialize.readExcel(excelPath, sheetName, ref dt);
            for (int i = 1; i < dt.Rows.Count; i++)
            {

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 1 && !string.IsNullOrEmpty(dt.Rows[i][j].ToString())) 
                    {

                    }
                    Console.Write(j+"_"+dt.Rows[i][j].ToString()+" ");
                }
                Console.WriteLine();
            }

        }
        //static void Main(string[] args)
        //{
        //    Program program = new Program();
        //    program.Process();
        //}
    }
}
