using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFixBCOrder
{
    public partial class wfFillData : Form
    {
        #region Define Variable
        System.Data.DataTable _dtbSource;
        System.Data.DataTable _dtbParam;
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
                    _dtbSource = Common.GetDataTable(_of.FileName);
                    dtgSource.DataSource = AutoFixExcelFileMonitor(_dtbSource);
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
            DataTable _dtbSeihin;
            DataTable _dtbBuhin;
            DataTable _dtbJuchuu;
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = true;

                // Read multiple file Excel
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbSeihin = new DataTable();
                    _dtbBuhin = new DataTable();
                    _dtbJuchuu = new DataTable();

                    // dtb 製品負荷　＆＆　dtb 部品負荷
                    for (int i = 0; i < _of.FileNames.Count(); i++)
                    {
                        if (_of.FileNames[i].Contains("製品負荷"))
                        {
                            _dtbSeihin = SeihinAutoFixExcelFileCSVConvertXLS(Common.GetDataTable(_of.FileNames[i]));
                            dtgSource.DataSource = _dtbSeihin;
                        }
                        else if (_of.FileNames[i].Contains("部品負荷"))
                        {
                            _dtbBuhin = BuhinAutoFixExcelFileCSVConvertXLS(Common.GetDataTable(_of.FileNames[i]));
                            dtgParam.DataSource = _dtbBuhin;
                        }
                        else if (_of.FileNames[i].Contains("受注残"))
                        {

                        }
                    }
                    dtgSource.DataSource = CompareDataAndFormat(_dtbSeihin, _dtbBuhin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 20161213 - BotFJP - Event btnFull click
        private void btnFill_Click(object sender, EventArgs e)
        {
            try
            {
                dtgSource.DataSource = AutoSearchAndFillDataTable(_dtbSource, _dtbParam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        #region 20161213 - BotFJP - Event btnAutoFix click
        private void btnAutoFix_Click(object sender, EventArgs e)
        {
            try
            {
                dtgParam.DataSource = AutoFixExcel(_dtbSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
        public System.Data.DataTable SeihinAutoFixExcelFileCSVConvertXLS(System.Data.DataTable _dtbSource)
        {
            #region 20161214 - BotFJP - Delete columns not use
            for (int i = _dtbSource.Columns.Count - 1; i >= 0; i--)
            {
                if (new[] { 29, 31, 34 }.Contains(i))
                {
                    continue;
                }
                else
                    _dtbSource.Columns.RemoveAt(i);
            }

            _dtbSource.Columns[0].ColumnName = "納期";
            _dtbSource.Columns[1].ColumnName = "図面番号";
            //部品=>組込番号          製品=>受注番号
            _dtbSource.Columns[2].ColumnName = "受注番号";
            _dtbSource.Columns.Add("組込番号", typeof(string));
            _dtbSource.AcceptChanges();

            #endregion

            #region 20161214 - BotFJP - Fix data 納期                 Meo dc
            //foreach (DataRow _row in _dtbSource.Rows)
            //{
            //    _row["納期"] = DateTime.Parse(_row["納期"].ToString()).ToString("MM/dd");
            //}
            //_dtbSource.AcceptChanges();
            #endregion
            return _dtbSource;
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
                if (new string[] { "1","2"}.Contains(_row["納期"].ToString().Split('/')[0]))
                {
                    _row["納期"] = _row["納期"].ToString().Replace("2016", "2017");
                }
            }
            _dtbSource.AcceptChanges();
            #endregion

            #region 20161214 - BotFJP - Add column Status and Data
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
                        (_dtbSeihin.Rows[i]["図面番号"].ToString() == _dtbBuhin.Rows[j]["図面番号"].ToString()))
                        {
                            //Get Data 組込番号 for dtb製品
                            _dtbSeihin.Rows[i]["組込番号"] = _dtbBuhin.Rows[i]["組込番号"].ToString();
                            //Set data Status -> False for dtb部品
                            _dtbBuhin.Rows[j]["Status"] = "False";
                        }
                    }
                    else
                        continue;

                }
            }
            _dtbSeihin.AcceptChanges();
            return _dtbSeihin;
        }
        #endregion
    }
}

