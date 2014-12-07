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
        public void Process()
        {
            string excelPath = @"D:\TestData\ifcClassification\Space140903.xls";
            string sheetName = @"Sheet2$";
            DataTable dt = null;
            excelDeserialize.readExcel(excelPath, sheetName, ref dt);
        }
        //static void Main(string[] args)
        //{
        //    Program program = new Program();
        //    program.Process();
        //}
    }
}
