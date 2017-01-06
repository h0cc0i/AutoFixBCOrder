using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
using Microsoft.Win32;

namespace AutoFixBCOrder
{
    public static class Common
    {

        // 20161116 HonC Create temp form Checkokurijou

        public static object IsNull(object nguon, object dich)
        {
            if (nguon == null || string.IsNullOrEmpty(nguon.ToString()) || nguon.GetType().ToString() == "DBNull")
            {
                return dich;
            }
            else
                return nguon;
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }

        }

        public static void ExportExcel(DataGridView dtg, string Path)
        {


            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Object misValue = System.Reflection.Missing.Value;

            String strPath;
            FolderBrowserDialog fileBrowser = new FolderBrowserDialog();

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            strPath = Path;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlApp.Worksheets[1];
            xlWorkSheet.Select(Type.Missing);

            for (int i = 0; i <= dtg.RowCount - 1; i++)
            {
                for (int j = 0; j <= dtg.Columns.Count - 1; j++)
                {
                    for (int k = 1; k <= dtg.Columns.Count; k++)
                    {
                        xlWorkSheet.Cells[1][k] = dtg.Columns[k - 1].HeaderText;
                        xlWorkSheet.Cells[i + 2][j + 1] = dtg[j, i].Value.ToString();
                    }
                }
            }

            xlWorkSheet.SaveAs(Path + "\\vbexcel.xlsx");
            xlWorkBook.Close();
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);



        }

        //Auto gent code for ID
        public static string GentCode4ID(string _str, int _len)
        {
            int _lenstr = _str.Length;
            if (_lenstr < _len)
            {
                do
                {
                    _str = "0" + _str;
                    _lenstr = _str.Length;
                } while (_lenstr < _len);
                return _str;
            }
            else
                return _str;
        }

        public static void AutoCreateTabPage(TabControl _tab, UserControl _uc, string _NameTabPage, string _TextTabPage)
        {
            //define user control
            _uc.Dock = DockStyle.Fill;

            //flag for check tabpage is avaiable
            bool _isAvaiable = false;
            int _countTabPages = Convert.ToInt32(_tab.TabPages.Count.ToString());
            if ((_uc != null) && _countTabPages > 0)
            {
                //if tabcontrol has avaiable tabpages
                for (int i = 0; i < _countTabPages; i++)
                {
                    //if name of tabpage is avaiable
                    if (_tab.TabPages[i].Text == _TextTabPage)
                    {
                        _isAvaiable = true;
                        break;
                    }
                }
                if (!_isAvaiable)
                {
                    //if not avaiable --> create new tabpage

                    //define new tab pages
                    TabPage _tpNew = new TabPage();
                    _tpNew.Text = _TextTabPage;
                    _tpNew.Name = _NameTabPage;
                    _tpNew.Controls.Add(_uc);
                    _tab.TabPages.Add(_tpNew);
                }
            }
            else
            {
                //if tabcontrol not avaiable tab pages
                //define new tab pages
                TabPage _tpNew = new TabPage();
                _tpNew.Text = _TextTabPage;
                _tpNew.Name = _NameTabPage;
                _tpNew.Controls.Add(_uc);
                _tab.TabPages.Add(_tpNew);
            }
            //go to tab pages had choose
            _tab.SelectTab(_NameTabPage);

        }

        public static void PeformTextboxKeyDown(KeyEventArgs e, System.Windows.Forms.TextBox _TxtPre, System.Windows.Forms.TextBox _TxtNext)
        {
            if (e.KeyCode == Keys.Up)
                _TxtPre.Select();
            else if (e.KeyCode == Keys.Enter)
                _TxtNext.Select();
        }

        /// <summary>
        /// Select All Control in current UserControl/Form
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        /// <summary>
        /// 2016/10/19 HonC
        /// </summary>
        /// <param name="excelpathfile"> Excel path Source </param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(string excelfile)
        {
            System.Data.DataTable dtb = new System.Data.DataTable();

            OleDbConnection ObjConn = null;
            System.Data.DataTable dtbExcel = new System.Data.DataTable();
            string connString = "";
            #region "check xls or xlsx"
            //check xls or xlsx
            if (excelfile.Substring(excelfile.Length - 4) == "xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
              "Data Source=" + excelfile + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;Importmixedtypes=text;HDR=NO;IMEX=1\"";
            }
            else
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                      "Data Source=" + excelfile + ";Mode=ReadWrite;Extended Properties=\"Excel 8.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\"";
            }
            #endregion

            try
            {
                ObjConn = new OleDbConnection(connString);
                ObjConn.Open();

                // get data table cotaining the schema 
                dtb = ObjConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtb.Rows[0]["TABLE_NAME"].ToString();
                if (SheetName == "_xlnm#_FilterDatabase")
                {
                    SheetName = dtb.Rows[1]["TABLE_NAME"].ToString();
                }
                string CommandText = "SELECT * From [" + SheetName + "]";

                OleDbCommand cmdExcel = new OleDbCommand(CommandText, ObjConn);
                OleDbDataAdapter oda = new OleDbDataAdapter(CommandText, ObjConn);

                oda.SelectCommand = cmdExcel;
                oda.Fill(dtbExcel);
                return dtbExcel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally // close and dispose connection
            {
                ObjConn.Close();
                ObjConn.Dispose();
            }
            return dtb;
        }

        /// <summary>
        /// Sort DataTable by Column asc or dsc
        /// </summary>
        /// <param name="_dtb">DataTable Source </param>
        /// <param name="_ColName">Sort by Column</param>
        /// <param name="_Direction"> </param>
        /// <returns></returns>
        public static System.Data.DataTable SortDataTable(System.Data.DataTable _dtb, string _ColName, string _Direction)
        {
            _dtb.DefaultView.Sort = _ColName + " " + _Direction;
            _dtb = _dtb.DefaultView.ToTable();
            return _dtb;
        }

        /// <summary>
        /// Write Printer Config to text file
        /// </summary>
        /// <param name="_path"> Path of text file</param>
        /// <param name="_line1"> Line 1 </param>
        /// <param name="_line2"> Line 2 </param>
        /// <param name="_line3"> Line 3 </param>
        public static void WriteTextPrinterConfig(string _path, string _line1, string _line2, string _line3)
        {
            if (!File.Exists(_path))
                File.Create(_path).Dispose();

            string[] _lines = { _line1, _line2, _line3 };
            File.WriteAllLines(_path, _lines);
        }

        //2016/11/14 HonC CHeck failed
        public static void ToCSV(this System.Data.DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        //2016/11/14 HonC Create function export to excel
        public static void DtbToExcel(DataSet ds, string _path)
        {
            //Creae an Excel application instance
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            object misValue = System.Reflection.Missing.Value;
            //Check file null
            if (!File.Exists(_path))
            {
                var app = new Microsoft.Office.Interop.Excel.Application();
                var _wb = app.Workbooks.Add();
                _wb.SaveAs(_path);
                _wb.Close();
            }

            //Create an Excel workbook instance and open it from the predefined location
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(_path);

            foreach (System.Data.DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[2, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 3, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                    //Check data in 備考
                    if (!string.IsNullOrEmpty(table.Rows[j]["備考"].ToString()))
                    {
                        excelWorkSheet.get_Range("A" + (j + 3).ToString(), "H" + (j + 3).ToString()).Interior.Color = System.Drawing.Color.LightSkyBlue;
                    }
                }

                //set border for this range
                Range _rg = excelWorkSheet.get_Range("A2", "H" + (table.Rows.Count + 2).ToString());
                _rg.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //Auto fit Columns width for this range
                _rg.Rows.AutoFit();

                //set font for this range
                _rg.Font.Size = 14;
                excelWorkSheet.get_Range("A2", "H2").Font.Color = System.Drawing.Color.Blue;

                excelWorkBook.Save();
            }


            excelWorkBook.Close();
            excelApp.Quit();

        }

        public static bool _flagHide = false;


        #region　20161129 - BotJava - Custom Get Data Table from BC Excel file        -> Multi table <-
        public static System.Data.DataTable CustomGetDataTable(string excelfile)
        {
            System.Data.DataTable dtb = new System.Data.DataTable();

            #region 20161130 - BotJava - Define DataTable Des: 品目コードと注文番号と発注日
            System.Data.DataTable _dtbDes = new System.Data.DataTable();
            _dtbDes.Columns.Add("品名", typeof(string));
            _dtbDes.Columns.Add("注文番号", typeof(string));
            _dtbDes.Columns.Add("発注日", typeof(string));
            #endregion

            #region 20161130 - BotJava - Read Cell Value from Excel
            //Creae an Excel application instance
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //Create an Excel workbook instance and open it from the predefined location
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(excelfile);

            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(excelfile, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Object misValue = System.Reflection.Missing.Value;

            #region Loop get value of cell to Des Table
            foreach (Worksheet _ws in excelWorkbook.Worksheets)
            {
                Worksheet _excelWS = excelWorkbook.Worksheets.get_Item(_ws.Name.ToString());
                excelApp.DisplayAlerts = false;
                if (!string.IsNullOrEmpty(_excelWS.get_Range("Q14", misValue).Text.ToString()))
                {
                    DataRow _row = _dtbDes.NewRow();

                    // get value of cell 
                    _row["品名"] = _excelWS.get_Range("C5", misValue).Text.ToString();
                    _row["発注日"] = _excelWS.get_Range("F3", misValue).Text.ToString().Replace("発注日", "");
                    _row["注文番号"] = _excelWS.get_Range("A14", misValue).Text.ToString().Split('*')[1].ToString();
                    _dtbDes.Rows.Add(_row);
                }
                else
                    continue;
            }
            #endregion


            #endregion


            return _dtbDes;
        }
        #endregion

        /// <summary>
        /// Fix Data format from file 負荷 to Data Table
        /// Get Index of column from _listParam => dont delete
        /// </summary>
        /// <param name="_listParam"> List Colums need to execute </param>
        /// <param name="_dtbSource"> Data Table Source </param>
        /// <returns></returns>
        public static System.Data.DataTable CSVDataFukaToDataTableFormat(System.Data.DataTable _dtbSource, int[] _listParam)
        {
            #region 20161218 - BotFJP - Delete Columns Not Use
            for (int i = _dtbSource.Columns.Count - 1; i >= 0; i--)
            {
                if (!_listParam.Contains(i))
                {
                    _dtbSource.Columns.RemoveAt(i);
                }
            }
            _dtbSource.AcceptChanges();
            #endregion
            return _dtbSource;
        }


        /// <summary>
        /// XLS Data file => Delete Columns and Rows not use and format
        /// </summary>
        /// <param name="_dtbSource"> Data Table Source</param>
        /// <param name="_listParam"> List Param Column is Using</param>
        /// <returns></returns>
        public static System.Data.DataTable XLSDataToDataTableFormat(System.Data.DataTable _dtbSource, int[] _ListParam)
        {

            #region 20161218 - BotFjP - Delete Columns not use
            for (int i = _dtbSource.Columns.Count - 1; i >= 0; i--)
            {
                if (!_ListParam.Contains(i))
                    _dtbSource.Columns.RemoveAt(i);
            }

            //Fix Name of Data Table
            _dtbSource.Columns[0].ColumnName = "図面番号";
            _dtbSource.Columns[1].ColumnName = "納期";
            _dtbSource.Columns[2].ColumnName = "注文番号";
            _dtbSource.Columns[3].ColumnName = "受注番号";
            _dtbSource.Rows[0].Delete();
            _dtbSource.AcceptChanges();
            #endregion

            #region 20161218 - BotFjP - Delete Rows Not Use
            for (int i = 0; i < _dtbSource.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(_dtbSource.Rows[i][3].ToString()))
                    _dtbSource.Rows[i].Delete();
                else
                    _dtbSource.Rows[i]["図面番号"] = _dtbSource.Rows[i]["図面番号"].ToString().Split(' ')[0];
            }
            _dtbSource.AcceptChanges();
            _dtbSource.Rows[0].Delete();
            #endregion

            return _dtbSource;
        }


        #region 20161218 - BotFjP - Fix Column Name of DataTable
        public static System.Data.DataTable AutoFixColumnName(System.Data.DataTable _dtbSource)
        {
            for (int i = 0; i < _dtbSource.Columns.Count - 1; i++)
            {
                _dtbSource.Columns[i].ColumnName = _dtbSource.Rows[0][i].ToString();
            }
            _dtbSource.Rows[0].Delete();
            _dtbSource.AcceptChanges();
            return _dtbSource;
        }
        #endregion

        /// <summary>
        /// Edit Pdf file with Data Source from Data Table Source
        /// </summary>
        /// <param name="_PathFile"></param>
        /// <param name="_dtbSource"></param>
        public static void EditMultiPdf(string _PathFile, System.Data.DataTable _dtbSource)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(_PathFile);

                #region 20161206 - BotJava - Edit font
                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                string arialuniTff = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                                     "ARIALUNI.TTF");
                BaseFont bf = BaseFont.CreateFont(arialuniTff, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                iTextSharp.text.Font blackFont = new iTextSharp.text.Font(bf, 12);
                #endregion

                using (MemoryStream stream = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(bytes);
                    using (PdfStamper stamper = new PdfStamper(reader, stream))
                    {
                        int _tempk = 0;
                        int pages = reader.NumberOfPages;
                        for (int i = 1; i <= pages; i++)
                        {

                            #region 20161206 - BotJava - Insert data for first 注文書
                            // Insert 棚番号
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase(_dtbSource.Rows[i - 1 + _tempk]["棚番号"].ToString(), blackFont), 500f, 575f, 0);
                            // Insert 出庫番号
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase(_dtbSource.Rows[i - 1 + _tempk]["組込番号"].ToString(), blackFont), 430f, 510f, 0);

                            #endregion

                            #region 20161206 - BotJava - Insert data for second 注文書
                            if ((i + _tempk) < _dtbSource.Rows.Count)
                            {
                                //Insert 棚番号
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase(_dtbSource.Rows[i + _tempk]["棚番号"].ToString(), blackFont), 500f, 287f, 0);
                                //Insert 出庫番号
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_CENTER, new Phrase(_dtbSource.Rows[i + _tempk]["組込番号"].ToString(), blackFont), 430f, 225f, 0);
                            }
                            #endregion

                            _tempk++;
                        }
                    }
                    bytes = stream.ToArray();
                }
                File.WriteAllBytes(_PathFile, bytes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void KillAllProccessByName(string _Name)
        {
            var processes = from p in Process.GetProcessesByName(_Name)
                            select p;

            foreach (var process in processes)
            {
                if (process.ProcessName == _Name)
                    process.Kill();
                if (process.ProcessName.StartsWith("AcroRd32.exe"))
                    process.Kill();
            }
        }

        public static void Print(string file, string printer)
        {
            try
            {
                Process.Start(
                   Registry.LocalMachine.OpenSubKey(
                        @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                        @"\App Paths\AcroRd32.exe").GetValue("").ToString(),
                   string.Format("/h /t \"{0}\" \"{1}\"", file, printer));
            }
            catch { }
        }

        public static void PrintPDFFile(string _PDFPath)
        {
            Process.Start("LPR -S printerdnsalias -P raw '" + _PDFPath + "'");
        }

        public static System.Data.DataTable AutoFind組込(System.Data.DataTable _dtbSeihin, System.Data.DataTable _dtbBuhin)
        {
            #region 20161223 - BotFjP - 日付と図面番号で 順番 
            // DataView _dvSeihin = new DataView(_dtbSeihin);
            _dtbSeihin.DefaultView.Sort = "納期,図面番号";
            _dtbSeihin = _dtbSeihin.DefaultView.ToTable();

            //DataView _dvBuhin = new DataView(_dtbBuhin);
            _dtbBuhin.DefaultView.Sort = "納期,図面番号";
            _dtbBuhin = _dtbBuhin.DefaultView.ToTable();

            for (int i = 0; i < _dtbBuhin.Rows.Count - 1; i++)
            {
                _dtbSeihin.Rows[i]["組込番号"] = _dtbBuhin.Rows[i]["組込番号"].ToString();
            }
            _dtbSeihin.AcceptChanges();
            #endregion

            #region 20161223 - BotFjP - add column 棚番号　注文番号
            _dtbSeihin.Columns.Add("注文番号", typeof(string));
            _dtbSeihin.Columns.Add("棚番号", typeof(string));
            #endregion
            return _dtbSeihin;

        }

        #region 20170105 - HonC - Get only BC row
        public static System.Data.DataTable GetOnlyBCData(System.Data.DataTable _dtbSource)
        {
            string[] _listparam = { "M","B"};           // MF__ B___
            if (_dtbSource.Rows.Count > 0)
            {
                foreach (DataRow _row in _dtbSource.Rows)
                {
                    if (!(_row["図面番号"].ToString().Length == 6) ||(_listparam.Contains( _row["図面番号"].ToString().PadLeft(1))))
                    {
                        _row.Delete();
                    }
                }
                _dtbSource.AcceptChanges();
            }
            return _dtbSource;
        }
        #endregion

    }
}
