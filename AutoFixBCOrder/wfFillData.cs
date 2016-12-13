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


                    #region 20161201 - BotJava - Fix Format Excel -> change column name
                    for (int i = 0; i < _dtbSource.Columns.Count; i++)
                    {
                        _dtbSource.Columns[i].ColumnName = _dtbSource.Rows[0][i].ToString();
                    }
                    _dtbSource.Rows[0].Delete();
                    _dtbSource.AcceptChanges();
                    #endregion

                    dtgSource.DataSource = _dtbSource;
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
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbParam = Common.GetDataTable(_of.FileName);

                    #region 20161201 - BotJava - Fix Format Excel -> change column name
                    for (int i = 0; i < _dtbParam.Columns.Count; i++)
                    {
                        _dtbParam.Columns[i].ColumnName = _dtbParam.Rows[0][i].ToString();
                    }
                    _dtbParam.Rows[0].Delete();
                    _dtbParam.AcceptChanges();
                    #endregion

                    #region 20161213 - BotFJP - Add columns Status for Table
                    _dtbParam.Columns.Add("Status", typeof(string));
                    for (int i = 0; i <= _dtbParam.Rows.Count - 1; i++)
                    {
                        _dtbParam.Rows[i]["Status"] = "true";
                    }
                    #endregion

                    

                    dtgParam.DataSource = _dtbParam;
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

    }
}
