using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SautinSoft;

namespace AutoFixBCOrder
{
    public partial class AutoFixBCOrder : Form
    {
        #region  20161129 - BotJava - Define Variable
        string oldFile = "C:\\Users\\HonC\\Desktop\\FixBCOrder\\Test.pdf";
        string newFile = "C:\\Users\\HonC\\Desktop\\FixBCOrder\\newfile.pdf";

        System.Data.DataTable _dtbSourceTana;
        System.Data.DataTable _dtbBCExcel;
        System.Data.DataTable _dtbShukko;

        #endregion

        public AutoFixBCOrder()
        {
            InitializeComponent();
        }

        #region 20161129- BotJava - Import PDF CLick
        private void btnImportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    //20161207 - BotJava - Convert to Excel data
                    ConvertPdfToExcel(_of.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 20161129 - BotJava - Add Lib Read Pdf to text

        private string GetTextFromPDF(string _Path)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(_Path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            return text.ToString();
        }

        #endregion

        #region 20161129 - BotJava - Load Form
        private void AutoFixBCOrder_Load(object sender, EventArgs e)
        {
            try
            {
                #region 20161129 - BotJava - Auto Import SourceTana


                _dtbSourceTana = Common.GetDataTable("C:\\Users\\HonC\\Desktop\\FixBCOrder\\SourceTana.xls");
                for (int i = _dtbSourceTana.Columns.Count - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrEmpty(_dtbSourceTana.Rows[0][i].ToString()))
                    {
                        _dtbSourceTana.Columns[i].ColumnName = _dtbSourceTana.Rows[0][i].ToString();
                    }
                }
                _dtbSourceTana.Rows[0].Delete();
                _dtbSourceTana.AcceptChanges();
                // dtgSourceTana.DataSource = _dtbSourceTana;

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 20161129 - BotJava - Edit pdf Text with location and text
        // open the reader
        public void EditPDF()
        {
            PdfReader reader = new PdfReader(oldFile);
            iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
            iTextSharp.text.Document document = new iTextSharp.text.Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.BLACK);
            cb.SetFontAndSize(bf, 12);

            #region edit pdf in half 1
            // write the text in the pdf content
            cb.BeginText();
            string text = "507586";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 430, 510, 0);
            cb.EndText();
            cb.BeginText();
            text = "S1 - 4";
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 500, 574, 0);
            cb.EndText();
            #endregion

            #region edit pdf in half 2
            // write the text in the pdf content
            cb.BeginText();
            text = "chungDepZai";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 430, 225, 0);
            cb.EndText();
            cb.BeginText();
            text = "AAAAAAA";
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 500, 287, 0);
            cb.EndText();
            #endregion
            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }
        #endregion

        #region 20161129 - BotJava - Read 図面番号 in page ~
        public System.Data.DataTable Read図面番号(string _PathPDF)
        {
            System.Data.DataTable _dtb = new System.Data.DataTable();
            string _text = GetTextFromPDF(_PathPDF);

            return _dtb;
        }
        #endregion

        #region 20161129 - BotJava - EditPDF
        private void btnEditPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // EditPDF();
                EditMultiPdf(oldFile, _dtbBCExcel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 20161129 - BotJava - ImportBCExcelClick
        private void btnImportBCExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbBCExcel = Common.CustomGetDataTable(_of.FileName);

                    //20161206 - BotJava - add column for datatable
                    _dtbBCExcel.Columns.Add("組込番号", typeof(String));
                    _dtbBCExcel.Columns.Add("棚番号", typeof(String));
                    dtgSourceTana.DataSource = _dtbBCExcel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Custom get Excel File

        #endregion

        #region 20161130 - BotJava - Import 出庫番号

        private void btnImportShukko_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _of = new OpenFileDialog();
                _of.Filter = "All Files (*.*)|*.*";
                _of.FilterIndex = 1;
                _of.Multiselect = false;
                if (_of.ShowDialog() == DialogResult.OK)
                {
                    _dtbShukko = Common.GetDataTable(_of.FileName);


                    #region 20161201 - BotJava - Fix Format Excel -> change column name
                    for (int i = 0; i < _dtbShukko.Columns.Count; i++)
                    {
                        _dtbShukko.Columns[i].ColumnName = _dtbShukko.Rows[0][i].ToString();
                    }
                    _dtbShukko.Rows[0].Delete();
                    _dtbShukko.AcceptChanges();
                    #endregion

                    dtgShukko.DataSource = _dtbShukko;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #endregion

        #region 20161205 - BotJava - import 棚番号
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog _of = new OpenFileDialog();
            System.Data.DataTable _dtbTanaSource = new System.Data.DataTable();
            _of.Filter = "All Files (*.*)|*.*";
            _of.FilterIndex = 1;
            _of.Multiselect = false;
            if (_of.ShowDialog() == DialogResult.OK)
            {
                _dtbTanaSource = Common.GetDataTable(_of.FileName);


                #region 20161201 - BotJava - Fix Format Excel -> change column name
                for (int i = 0; i < _dtbTanaSource.Columns.Count - 1; i++)
                {
                    _dtbTanaSource.Columns[i].ColumnName = _dtbTanaSource.Rows[0][i].ToString();
                }
                _dtbTanaSource.Rows[0].Delete();
                _dtbTanaSource.AcceptChanges();
                #endregion

                dtgShukko.DataSource = _dtbTanaSource;
            }
        }
        #endregion

        #region 20161205 - BotJava - Execute dataTable to pdf change
        public void FixDesTable(System.Data.DataTable _dtbDes, System.Data.DataTable _dtbTana, System.Data.DataTable _dtbShukko)
        {
            //20161206 - BotJava - Check if dtb des is not null
            if (_dtbDes.Rows.Count > 0)
            {
                #region 20161206 - BotJava - 間に合う-> Get 棚番号
                if (_dtbTana.Rows.Count > 0)
                {
                    foreach (DataRow _rowDes in _dtbDes.Rows)
                    {
                        foreach (DataRow _rowTana in _dtbTana.Rows)
                        {
                            if (_rowDes["図面番号"].ToString() == _rowTana["図面番号"].ToString())
                            {
                                _rowDes["棚番号"] = _rowTana["棚番号"].ToString();
                                break;
                            }
                        }
                    }
                }
                #endregion

                #region 20161206 - BotJava - 間に合う -> get 出庫番号
                foreach (DataRow _rowDes in _dtbDes.Rows)
                {
                    foreach (DataRow _rowTana in _dtbTana.Rows)
                    {
                        if (_rowDes["注文№"].ToString() == _rowTana["注文№"].ToString())
                        {
                            _rowDes["棚番号"] = _rowTana["棚番号"].ToString();
                            break;
                        }
                    }
                }
                #endregion
            }
        }
        #endregion

        #region 20161126 - BotJava - Get 棚番号 and 組込番号

        private void get棚NoAnd組込ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow _rowBCExcel in _dtbBCExcel.Rows)
                {
                    foreach (DataRow _rowShukko in _dtbShukko.Rows)
                    {
                        if (_rowBCExcel["注文番号"].ToString() == _rowShukko["注文番号"].ToString())
                        {
                            _rowBCExcel["棚番号"] = _rowShukko["棚番号"].ToString();
                            _rowBCExcel["組込番号"] = _rowShukko["組込番号"].ToString();
                            break;
                        }
                    }
                }
                dtgSourceTana.DataSource = _dtbBCExcel;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region 20161206 - BotJava - Function auto fix Pdf with range
        public void EditPDFwithRange(string _pathfile, System.Data.DataTable _dtbSource)
        {
            PdfReader reader = new PdfReader(_pathfile);
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                //  string _newFile = "C:\\Users\\HonC\\Desktop\\FixBCOrder\\newfile" + i + ".pdf";

                iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(i);
                iTextSharp.text.Document document = new iTextSharp.text.Document(size);

                // open the writer
                FileStream fs = new FileStream(_pathfile, FileMode.Create, FileAccess.Write);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // the pdf content
                PdfContentByte cb = writer.DirectContent;

                #region 20161206 - BotJava  - Add font for data insert => font for UTF8 japanese

                // select the font properties
                string arialuniTff = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                                      "ARIALUNI.TTF");
                BaseFont bf = BaseFont.CreateFont(arialuniTff, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                #endregion

                //  BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 12);

                #region 20161206 - BotJava - Edit in half hight
                // write the text in the pdf content
                cb.BeginText();
                string text = _dtbSource.Rows[i - 1][3].ToString();
                // put the alignment and coordinates here
                cb.ShowTextAligned(1, text, 430, 510, 0);
                cb.EndText();
                cb.BeginText();
                text = _dtbSource.Rows[i - 1][4].ToString();
                // put the alignment and coordinates here
                cb.ShowTextAligned(2, text, 500, 575, 0);
                cb.EndText();
                #endregion

                #region 20161206 - BotJava - edit pdf in half 2
                // write the text in the pdf content
                cb.BeginText();
                text = _dtbSource.Rows[i][3].ToString();
                // put the alignment and coordinates here
                cb.ShowTextAligned(1, text, 430, 225, 0);
                cb.EndText();
                cb.BeginText();
                text = _dtbSource.Rows[i][4].ToString();
                // put the alignment and coordinates here
                cb.ShowTextAligned(2, text, 500, 287, 0);
                cb.EndText();
                #endregion

                // create the new page and add it to the pdf
                PdfImportedPage page = writer.GetImportedPage(reader, i);
                cb.AddTemplate(page, 0, 0);

                // close the streams and voilá the file should be changed :)
                document.Close();
                fs.Close();
                writer.Close();
            }
            reader.Close();

        }
        #endregion

        #region 20161206 - BotJava - Edit Multi page and keep source
        public void EditMultiPdf(string _PathFile, System.Data.DataTable _dtbSource)
        {
            byte[] bytes = File.ReadAllBytes(_PathFile);

            #region 20161206 - BotJava - Edit font
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
        #endregion

        #region 20161208 - BotJava - Convert pdf to Excel (table in pdf)
        public void ConvertPdfToExcel(string _PdfPath)
        {
            string _pathToExcel = System.IO.Path.ChangeExtension(_PdfPath, "xls");
            SautinSoft.PdfFocus fs = new PdfFocus();

            // 'true' = Convert all data to spreadsheet (tabular and even textual). 
            // 'false' = Skip textual data and convert only tabular (tables) data. 
            fs.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;
            fs.ExcelOptions.PreservePageLayout = true;

            fs.OpenPdf(_PdfPath);

            if (fs.PageCount > 0)
            {
                int result = fs.ToExcel(_pathToExcel);

                //Open a produced Excel workbook
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(_pathToExcel);
                }
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
            for (int i = 0; i < _dtbSource.Rows.Count - 1; i++)
            {
                for (int j = 0; j < _dtbParam.Rows.Count - 1; j++)
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
