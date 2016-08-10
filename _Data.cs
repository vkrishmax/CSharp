
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Framework
{
    public class _Data
    {

        public static String DateTIME()
        {
            String val="";
            CommonVariable.tt = "" + System.DateTime.Now;
            CommonVariable.DT =  CommonVariable.tt.Split();
            CommonVariable.DATE = CommonVariable. DT[0].ToString().Trim().Replace("/", "_");
            CommonVariable.TIME =  CommonVariable.DT[1].ToString().Trim().Replace(":", "_") + "_" +  CommonVariable.DT[2].ToString().Trim();
            val = CommonVariable.DATE + "_" + CommonVariable.TIME;
         return val;
        }

public static String retrieve1(String Col)
        {
            String rowval = null;
            XSSFSheet sh;
            XSSFWorkbook wb;
            String Flag = "false";
            string path = CommonVariable.TESTDATA.Trim() + "Data.xlsx";
            if (File.Exists(path))
            {
                wb = new XSSFWorkbook(path);
                // create sheet
                sh = (XSSFSheet)wb.GetSheet("Sheet1");
                // 3 rows, 2 columns
                int r = sh.LastRowNum;
                for (int j = 0; j <=r; j++)
                {
                  XSSFRow row = (XSSFRow)sh.GetRow(j);
                  int c = row.LastCellNum;
                    for (int i = 0; i < c; i++)
                    {
                        rowval = row.GetCell(i).StringCellValue.ToString();
                        if(rowval.equal(Col))
                        {
                            rowval = (XSSFRow)sh.GetRow(j+1).GetCell(i).StringCellValue.ToString();
                            break;
                            Flag = "true";
                        }
                    }
                    if(Flag.equal("true"))
                    {
                        break;
                    }
                }
            }
            return rowval;
        }


        public static String retrieve(String Col)
        {
            string path = CommonVariable.TESTDATA.Trim() + "Data.xls";
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
            String rowval = null;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connStr))
                {
                    connection.Open();

                    try// _SelectValueList(BPS.drp_Program, ExcelRead.retrieve("Program"));    where TestName = "+CommonVariable.TestName+"
                    {
                        OleDbCommand command = new OleDbCommand("select * from [" + CommonVariable._Table + "$] where TestName = '" + CommonVariable.TestName + "'", connection);
                        using (OleDbDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rowval = dr[Col].ToString();


                                // Console.WriteLine(row1Col0);
                            }
                        }

                    }
                    catch (Exception)
                    { }
                }
            }
            catch (Exception)
            {
            }
            return rowval;

        }

        public static void LogFile(string sExceptionName)
        {

            StreamWriter log;


            if (!File.Exists(CommonVariable.TestResult.Trim() + "\\ExecutionResult_" + CommonVariable.DT_ + ".txt"))
            {

                log = new StreamWriter(CommonVariable.TestResult.Trim() + "\\ExecutionResult_" + CommonVariable.DT_ + ".txt");

            }

            else
            {

                log = File.AppendText(CommonVariable.TestResult.Trim() + "\\ExecutionResult_" + CommonVariable.DT_ + ".txt");

            }

            // Write to the file:

            if (CommonVariable.TestName == CommonVariable.CurTest)
            {
                if (sExceptionName.Contains("***"))
                {
                    log.WriteLine(sExceptionName);
                    CommonVariable.logcount = 1;

                }
                else
                {
                    log.WriteLine(CommonVariable.logcount + ". " + sExceptionName);
                    CommonVariable.logcount = CommonVariable.logcount + 1;
                }
            }
            else
            {

                log.WriteLine("                                     ");
                if (sExceptionName.Contains("***"))
                {
                    log.WriteLine(sExceptionName);
                    CommonVariable.logcount = 1;

                }
                else
                {

                    log.WriteLine(CommonVariable.logcount + ". " + sExceptionName);
                    CommonVariable.logcount = CommonVariable.logcount + 1;
                }
            }
            CommonVariable.CurTest = CommonVariable.TestName;

            //log.WriteLine("Event Name:" + sEventName);

            //log.WriteLine("Control Name:" + sControlName);

            //log.WriteLine("Error Line No.:" + nErrorLineNo);

            //log.WriteLine("Form Name:" + sFormName);

            // Close the stream:

            log.Close();

        }

    }
}
