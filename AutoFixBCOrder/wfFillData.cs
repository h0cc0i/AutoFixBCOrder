using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace AutoFixBCOrder
{
    public partial class wfFillData : Form
    {
        #region Define Variable
        System.Data.DataTable _dtbSource;
        System.Data.DataTable _dtbParam;

        DataTable _dtbSeihin;
        DataTable _dtbBuhin;
        DataTable _dtbJuchuu;
        DataTable _dtbSourceTana;
        DataTable _dtbSourceExcel; // List 図面番号　と　注文番号　Convert from PDf file
        string _newPathPdf = string.Empty;
        string _PathSourcePDF = string.Empty;
        string _outputPDF = string.Empty;
        List<string> _listPDF = new List<string>();
        #endregion
        public wfFillData()
        {
            InitializeComponent();
        }

        #region 20161213 - BotFJP Event btnSource click
        private void btnSource_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    #region 20161220 - BotFjP - Get Data BC Source Excel from Excel
                    _dtbSourceExcel = Common.CustomGetDataTable(_of.FileName);

                    //20161206 - BotJava - add column for datatable
                    _dtbSourceExcel.Columns.Add("組込番号", typeof(String));
                    _dtbSourceExcel.Columns.Add("棚番号", typeof(String));
                    dtgSource.DataSource = _dtbSourceExcel;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 20161213 - BotFJP - Event btnParam click
        private void btnParam_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            prBar.Maximum = 100;
            prBar.Value = 0;
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = true;

                // Read multiple file Excel
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _listPDF = new List<string>();
                    _dtbSeihin = new DataTable();
                    _dtbBuhin = new DataTable();
                    _dtbJuchuu = new DataTable();

                    Cursor.Current = Cursors.WaitCursor;
                    #region 20161220 - BotFjP - Auto Get Data form Excel to Data Table
                    timer1.Enabled = true;
                    timer1.Start();
                    for (int i = 0; i < _of.FileNames.Count(); i++)
                    {
                        if (_of.FileNames[i].Contains("製品負荷"))
                        {
                            System.Data.DataTable _dtbTemp = Common.GetDataTable(_of.FileNames[i]);
                            _dtbSeihin = SeihinAutoFixExcelFileCSVConvertXLS(_dtbTemp);
                            lbnMessage.Text = "処理中。。。";
                            for (int j = 0; j < 20; j++)
                            {
                                timer1.Tick += new EventHandler(timer1_Tick);
                            }
                        }
                        else if (_of.FileNames[i].Contains("部品負荷"))
                        {
                            _dtbBuhin = BuhinAutoFixExcelFileCSVConvertXLS(Common.GetDataTable(_of.FileNames[i]));
                            lbnMessage.Text = "処理中。。。";
                            for (int j = 0; j < 20; j++)
                            {
                                timer1.Tick += new EventHandler(timer1_Tick);
                            }
                        }
                        else if (_of.FileNames[i].Contains("受注"))
                        {
                            _dtbJuchuu = Common.GetDataTable(_of.FileNames[i]);
                            var _ListParam = new int[] { 0, 12, 17, 21 };
                            _dtbJuchuu = Common.XLSDataToDataTableFormat(_dtbJuchuu, _ListParam);
                            lbnMessage.Text = "処理中。。。";
                            for (int j = 0; j < 20; j++)
                            {
                                timer1.Tick += new EventHandler(timer1_Tick);
                            }
                        }
                        else if (_of.FileNames[i].Contains(".pdf"))
                        {
                            _PathSourcePDF = _of.FileNames[i].ToString();
                            lbnMessage.Text = "処理中。。。";

                            // => import to list pdf for execute multi pdf
                            
                            _listPDF.Add(_PathSourcePDF);


                            for (int j = 0; j < 20; j++)
                            {
                                timer1.Tick += new EventHandler(timer1_Tick);
                            }
                        }
                        else
                        {
                            #region 20161220 - BotFjP - Get Data BC Source Excel from Excel
                            //_dtbSourceExcel = Common.CustomGetDataTable(_of.FileNames[i]);
                            _dtbSourceExcel = Common.ReadPDFToDataTable("");

                            ////20161206 - BotJava - add column for datatable
                            //_dtbSourceExcel.Columns.Add("組込番号", typeof(String));
                            //_dtbSourceExcel.Columns.Add("棚番号", typeof(String));
                            //dtgSource.DataSource = _dtbSourceExcel;
                            #endregion
                            lbnMessage.Text = "処理中。。。";
                            for (int j = 0; j < 20; j++)
                            {
                                timer1.Tick += new EventHandler(timer1_Tick);
                            }
                        }
                    }
                    #endregion

                    #region 20170116 - BotFJP - Get 注文番号　and MergePDF
                    _dtbSourceExcel = new DataTable();
                    //read each item int listPDF
                    foreach (var item in _listPDF)
                    {
                        _dtbSourceExcel.Merge(Common.ReadPDFToDataTable(item));
                    }

                    //Merge PDF
                    _PathSourcePDF = Common.MergePDF(_listPDF, @"C:\Users\HonC\Desktop\MergePDF.pdf");

                    _dtbSourceExcel.Columns.Add("組込番号", typeof(String));
                    _dtbSourceExcel.Columns.Add("棚番号", typeof(String));
                    dtgSource.DataSource = _dtbSourceExcel;
                    #endregion

                    #region 20161223 - BotFJP - Set Data Table 図面番号　受注番号　組込番号 to Data Table Param
                    _dtbParam = Common.AutoFind組込(Common.GetOnlyBCData(_dtbSeihin), Common.GetOnlyBCData(_dtbBuhin));
                    #endregion

                    #region Get 注文番号　to dtb Param
                    for (int i = _dtbParam.Rows.Count - 1; i >= 0; i--)
                    {
                        for (int j = _dtbJuchuu.Rows.Count - 1; j >= 0; j--)
                        {
                            if (_dtbParam.Rows[i]["受注番号"].ToString() == _dtbJuchuu.Rows[j]["受注番号"].ToString())
                            {
                                _dtbParam.Rows[i]["注文番号"] = _dtbJuchuu.Rows[j]["注文番号"].ToString();
                            }
                        }
                    }
                    #endregion

                    #region 20161219 - BotFJP - Get 棚番号 to dtb Param
                    if (_dtbSourceTana != null)
                    {
                        for (int i = 0; i < _dtbParam.Rows.Count; i++)
                        {
                            for (int j = 0; j < _dtbSourceTana.Rows.Count; j++)
                            {
                                if (_dtbParam.Rows[i]["図面番号"].ToString() == _dtbSourceTana.Rows[j]["部品図番"].ToString())
                                {
                                    _dtbParam.Rows[i]["棚番号"] = _dtbSourceTana.Rows[j]["棚番号"].ToString();
                                    break;
                                }
                                else
                                {
                                    if (j == (_dtbSourceTana.Rows.Count - 1))
                                    {
                                        _dtbParam.Rows[i]["棚番号"] = "なし";
                                    }
                                }
                            }
                        }
                        _dtbParam.AcceptChanges();
                    }
                    #endregion

                    #region 20161219 - BotFJP - Compare dtb Param and dtb Source => output: dtbSource
                    for (int i = 0; i < _dtbSourceExcel.Rows.Count; i++)
                    {
                        for (int j = 0; j < _dtbParam.Rows.Count; j++)
                        {
                            if (_dtbSourceExcel.Rows[i]["注文番号"].ToString() == _dtbParam.Rows[j]["注文番号"].ToString())
                            {
                                _dtbSourceExcel.Rows[i]["棚番号"] = _dtbParam.Rows[j]["棚番号"].ToString();
                                _dtbSourceExcel.Rows[i]["組込番号"] = _dtbParam.Rows[j]["組込番号"].ToString();
                                break;
                            }
                        }
                        _dtbSourceExcel.AcceptChanges();
                        dtgSource.DataSource = _dtbSourceExcel;
                    }
                    #endregion
                    for (int i = 0; i < _of.FileNames.Count(); i++)
                    {
                        if (_of.FileNames[i].Contains(".pdf"))
                        {
                            _newPathPdf = _of.FileNames[i].ToString();

                        }
                    }

                    lbnMessage.Text = "出来ました。";
                    prBar.Value = 0;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Common.KillAllProccessByName("EXCEL");
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 20161213 - BotFJP - Event btnFull click
        private void btnFill_Click(object sender, EventArgs e)
        {
            #region 20161220 - BotFjP - Edit Pdf with data Table Param is Data Source
            string _newPathPdf = string.Empty;
            //Create save file Dialog
            SaveFileDialog _savefile = new SaveFileDialog();
            _savefile.DefaultExt = "pdf";
            _savefile.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (_savefile.ShowDialog() == DialogResult.OK)
            {
                _newPathPdf = _savefile.FileName;
                System.IO.File.Copy(_PathSourcePDF, _newPathPdf);
            }
            Common.EditMultiPdf(_newPathPdf, _dtbSourceExcel);
            #endregion
        }
        #endregion

        #region 20161213 - BotFJP - AutoFillToDataTable
        /// Input  : have 2 table and multiple column
        /// Output : auto search and fill columns.
        ///             If 1 - 1    => okie
        ///             IF 1 - many =>      0001    MF1234      555666
        ///                                 0002    MF1234      555667
        ///                                 0003    MF1234      555668
        public System.Data.DataTable AutoSearchAndFillDataTable(System.Data.DataTable _dtbSource, System.Data.DataTable _dtbParam)
        {


            for (int i = 0; i <= _dtbSource.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= _dtbParam.Rows.Count - 1; j++)
                {
                    if ((_dtbSource.Rows[i]["KeyData"].ToString() == _dtbParam.Rows[j]["KeyData"].ToString()) && (_dtbParam.Rows[j]["Status"].ToString() == "true"))
                    {
                        _dtbSource.Rows[i]["組込番号"] = _dtbParam.Rows[j]["組込番号"].ToString();
                        _dtbParam.Rows[j]["Status"] = "false";
                        break;
                    }
                }
            }
            return _dtbSource;
        }


        #endregion

        #region 20161213 - BotFJP - Auto Fix Name File Excel
        /// input : csv file -> convert to xls Excel 2003
        public DataTable AutoFixExcel(DataTable _dtb)
        {
            //base on 受注モニター
            #region 20161213 - BotFJP - Auto Delete Column Not Use
            for (int i = _dtb.Columns.Count - 1; i > 0; i--)
            {
                if (new int[] { 24, 25, 28, 33, 35 }.Contains(i))
                    continue;
                else
                    _dtb.Columns.RemoveAt(i);
            }
            _dtb.AcceptChanges();
            #endregion

            #region 20161213 - BotFJP - Auto Fix Column Name
            _dtb.Columns[0].ColumnName = "Ahihi";
            _dtb.Columns[1].ColumnName = "図面番号";
            _dtb.Columns[2].ColumnName = "数";
            _dtb.Columns[3].ColumnName = "納期";
            _dtb.Columns[4].ColumnName = "注文番号";
            _dtb.Columns[5].ColumnName = "受注番号";
            #endregion

            #region 20161213 - BotFJP - Edit 図面番号
            for (int i = _dtb.Rows.Count - 1; i >= 0; i--)
            {
                _dtb.Rows[i]["図面番号"] = _dtb.Rows[i]["図面番号"].ToString().Split(' ')[0];
            }
            #endregion

            return _dtb;
        }
        #endregion

        #region 20161214 - BotFJP - Auto Fix Excel File Base by Excel 5.0
        public System.Data.DataTable AutoFixExcelFileMonitor(System.Data.DataTable _dtbSource)
        {
            #region 20161214 - BotFJP - Delete first 6 row
            for (int i = 0; i < 6; i++)
            {
                _dtbSource.Rows[i].Delete();
            }
            _dtbSource.AcceptChanges();
            #endregion

            #region 20161214 - BotFJP - Delete Columns not use
            for (int i = _dtbSource.Columns.Count - 1; i >= 0; i--)
            {
                if (new[] { 0, 7, 12, 17, 21 }.Contains(i))
                {
                    switch (i)
                    {
                        case 0:
                            {
                                _dtbSource.Columns[0].ColumnName = "図面番号";
                                break;
                            }
                        case 7:
                            {
                                _dtbSource.Columns[7].ColumnName = "受注数";
                                break;
                            }
                        case 12:
                            {
                                _dtbSource.Columns[12].ColumnName = "納期";
                                break;
                            }
                        case 17:
                            {
                                _dtbSource.Columns[17].ColumnName = "注文番号";
                                break;
                            }
                        case 21:
                            {
                                _dtbSource.Columns[21].ColumnName = "受注番号";
                                break;
                            }
                        default:
                            break;
                    }
                    _dtbSource.Rows[0].Delete();
                }
                else
                    _dtbSource.Columns.RemoveAt(i);
            }
            _dtbSource.AcceptChanges();
            #endregion

            #region 20161214 - BotFJP  - Delete row has value is nothing
            foreach (DataRow _row in _dtbSource.Rows)
            {
                if (String.IsNullOrEmpty(_row["受注数"].ToString()))
                    _row.Delete();
                else
                {
                    _row["図面番号"] = _row["図面番号"].ToString().Split(' ')[0];
                }

            }
            _dtbSource.AcceptChanges();
            #endregion
            return _dtbSource;
        }
        #endregion

        #region 20161214 - BotFJP - Auto Fix Excel 製品 File Base by csv -> xls
        public System.Data.DataTable SeihinAutoFixExcelFileCSVConvertXLS(System.Data.DataTable _dtbExec)
        {
            #region 20161214 - BotFJP - Delete columns not use
            for (int i = _dtbExec.Columns.Count - 1; i >= 0; i--)
            {
                if (new[] { 29, 31, 34 }.Contains(i))
                {
                    continue;
                }
                else
                    _dtbExec.Columns.RemoveAt(i);
            }

            _dtbExec.Columns[0].ColumnName = "納期";
            _dtbExec.Columns[1].ColumnName = "図面番号";
            //部品=>組込番号          製品=>受注番号
            _dtbExec.Columns[2].ColumnName = "受注番号";
            _dtbExec.Columns.Add("組込番号", typeof(string));
            _dtbExec.AcceptChanges();

            #endregion

            #region 20161214 - BotFJP - Fix data 納期                 Meo dc
            //foreach (DataRow _row in _dtbSource.Rows)
            //{
            //    _row["納期"] = DateTime.Parse(_row["納期"].ToString()).ToString("MM/dd");
            //}
            //_dtbSource.AcceptChanges();
            #endregion
            return _dtbExec;
        }
        #endregion

        #region 20161214 - BotFJP - Auto Fix Excel 部品 File Base by csv -> xls
        public System.Data.DataTable BuhinAutoFixExcelFileCSVConvertXLS(System.Data.DataTable _dtbSource)
        {
            #region 20161214 - BotFJP - Delete columns not use
            for (int i = _dtbSource.Columns.Count - 1; i >= 0; i--)
            {
                if (new[] { 29, 31, 33 }.Contains(i))
                {
                    continue;
                }
                else
                    _dtbSource.Columns.RemoveAt(i);
            }

            _dtbSource.Columns[0].ColumnName = "納期";
            _dtbSource.Columns[2].ColumnName = "図面番号";
            //部品=>組込番号          製品=>受注番号
            _dtbSource.Columns[1].ColumnName = "組込番号";

            _dtbSource.AcceptChanges();

            #endregion

            #region 20161214 - BotFJP - Fix data 納期         
            //IF 納期 月　1,2 => Replace 年 = 年 + 1      
            foreach (DataRow _row in _dtbSource.Rows)
            {
                if (new string[] { "1", "2" }.Contains(_row["納期"].ToString().Split('/')[0]))
                {
                    _row["納期"] = _row["納期"].ToString().Replace("2016", "2017");
                }
            }
            _dtbSource.AcceptChanges();
            #endregion

            #region 20161214 - BotFJP - Add column Status and 注文番号
            DataColumn _newcol = new DataColumn("Status", typeof(string));
            _newcol.DefaultValue = "True";
            _dtbSource.Columns.Add(_newcol);
            _dtbSource.AcceptChanges();

            #endregion
            return _dtbSource;
        }
        #endregion

        #region 20161214 - BotFJP - Compare Data From 製品負荷 and 部品負荷
        public DataTable CompareDataAndFormat(DataTable _dtbSeihin, DataTable _dtbBuhin)
        {
            for (int i = _dtbSeihin.Rows.Count - 1; i >= 0; i--)
            {
                for (int j = _dtbBuhin.Rows.Count - 1; j >= 0; j--)
                {
                    if (_dtbBuhin.Rows[j]["Status"].ToString() == "True")
                    {
                        if ((_dtbSeihin.Rows[i]["納期"].ToString() == _dtbBuhin.Rows[j]["納期"].ToString()) &&
                        (_dtbSeihin.Rows[i]["図面番号"].ToString().Trim() == _dtbBuhin.Rows[j]["図面番号"].ToString().Trim()))
                        {
                            //Get Data 組込番号 for dtb製品
                            _dtbSeihin.Rows[i]["組込番号"] = _dtbBuhin.Rows[j]["組込番号"].ToString();
                            //Set data Status -> False for dtb部品
                            _dtbBuhin.Rows[j]["Status"] = "False";
                        }
                    }
                    else
                        continue;
                }
            }
            _dtbSeihin.Columns.Add("注文番号", typeof(string));
            _dtbSeihin.Columns.Add("棚番号", typeof(string));
            _dtbSeihin.AcceptChanges();
            return _dtbSeihin;
        }
        #endregion

        private void wfFillData_Load(object sender, EventArgs e)
        {
            try
            {
                #region Load 棚番号List from directory

                string _PathTana = Directory.GetCurrentDirectory() + "/Source棚.xlsx";
                if (!File.Exists(_PathTana))
                {
                    //2016/10/17 HonC : ask for add DefineListBeckMan
                    DialogResult _dlgask = MessageBox.Show("インポート棚番号リストよろしいですか ?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (_dlgask == DialogResult.Yes)
                    {
                        OpenFileDialog _of = new OpenFileDialog();
                        _of.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
                        _of.Multiselect = false;
                        if (_of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            // copy ListDefineBC to Current Directory
                            //System.IO.File.Copy(_of.FileName, _PathTana, true);
                            //File.SetAttributes(_PathTana, FileAttributes.Normal);
                            #region 20161220 - BotFjP - change method copy file source 棚
                            File.Move(_of.FileName, _PathTana);
                            #endregion
                        }
                    }
                }

                #region 20161219 - BotFJP - Load data 棚番号 from Source
                System.Data.DataTable _dtbTemp = Common.GetDataTable(_PathTana);
                _dtbSourceTana = Common.AutoFixColumnName(_dtbTemp);
                _dtbSourceTana.Columns[2].ColumnName = "棚番号";
                #endregion

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 20161220 - BotFjP - Event when click button 印刷
        private void btnIn_Click(object sender, EventArgs e)
        {
            //  Common.PrintPDFFile(_PathSource);
            OpenFileDialog _of = new OpenFileDialog();
            _of.Filter = "All Files (*.*)|*.*";
            _of.FilterIndex = 1;
            _of.Multiselect = true;
            List<string> _ListPDF = new List<string>();

            if (_of.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in _of.FileNames)
                {
                    if (item.Contains(".pdf"))
                    {
                        _ListPDF.Add(item);
                    }
                }

                Common.MergePDF(_ListPDF, @"C:\Users\HonC\Desktop\MergePDF.pdf");
            }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prBar.Value = e.ProgressPercentage;
            prBar.Text = e.ProgressPercentage.ToString();
        }

        #region 20161221 - BotFjP - Function use thread and run proccess bar
        private void Caculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        public void DoWork(IProgress<int> progress)
        {
            for (int j = 0; j < 1000; j++)
            {
                Caculate(j);
                if (progress != null)
                {
                    progress.Report((j + 1) * 100 / 1000);
                }
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (prBar.Value != 100)
            {
                prBar.Value++;
            }
            else
                timer1.Stop();
        }
    }
}


