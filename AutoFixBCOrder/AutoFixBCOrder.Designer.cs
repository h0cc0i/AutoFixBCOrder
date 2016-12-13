namespace AutoFixBCOrder
{
    partial class AutoFixBCOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImportPdf = new System.Windows.Forms.Button();
            this.btnEditPDF = new System.Windows.Forms.Button();
            this.btnImportBCExcel = new System.Windows.Forms.Button();
            this.btnImportShukko = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgSourceTana = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgShukko = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgShuukko = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.get棚NoAnd組込ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSourceTana)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgShukko)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgShuukko)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tableLayoutPanel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(931, 40);
            this.pnlTop.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnImportPdf, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEditPDF, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImportBCExcel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImportShukko, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnImportPdf
            // 
            this.btnImportPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportPdf.ForeColor = System.Drawing.Color.Blue;
            this.btnImportPdf.Location = new System.Drawing.Point(23, 3);
            this.btnImportPdf.Name = "btnImportPdf";
            this.btnImportPdf.Size = new System.Drawing.Size(164, 34);
            this.btnImportPdf.TabIndex = 0;
            this.btnImportPdf.Text = "Import BC data";
            this.btnImportPdf.UseVisualStyleBackColor = true;
            this.btnImportPdf.Click += new System.EventHandler(this.btnImportPdf_Click);
            // 
            // btnEditPDF
            // 
            this.btnEditPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPDF.ForeColor = System.Drawing.Color.Blue;
            this.btnEditPDF.Location = new System.Drawing.Point(193, 3);
            this.btnEditPDF.Name = "btnEditPDF";
            this.btnEditPDF.Size = new System.Drawing.Size(164, 34);
            this.btnEditPDF.TabIndex = 1;
            this.btnEditPDF.Text = "Edit PDF";
            this.btnEditPDF.UseVisualStyleBackColor = true;
            this.btnEditPDF.Click += new System.EventHandler(this.btnEditPDF_Click);
            // 
            // btnImportBCExcel
            // 
            this.btnImportBCExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportBCExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportBCExcel.ForeColor = System.Drawing.Color.Blue;
            this.btnImportBCExcel.Location = new System.Drawing.Point(363, 3);
            this.btnImportBCExcel.Name = "btnImportBCExcel";
            this.btnImportBCExcel.Size = new System.Drawing.Size(164, 34);
            this.btnImportBCExcel.TabIndex = 2;
            this.btnImportBCExcel.Text = "Import BC Excel";
            this.btnImportBCExcel.UseVisualStyleBackColor = true;
            this.btnImportBCExcel.Click += new System.EventHandler(this.btnImportBCExcel_Click);
            // 
            // btnImportShukko
            // 
            this.btnImportShukko.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportShukko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportShukko.ForeColor = System.Drawing.Color.Blue;
            this.btnImportShukko.Location = new System.Drawing.Point(533, 3);
            this.btnImportShukko.Name = "btnImportShukko";
            this.btnImportShukko.Size = new System.Drawing.Size(164, 34);
            this.btnImportShukko.TabIndex = 3;
            this.btnImportShukko.Text = "Import 出庫番号";
            this.btnImportShukko.UseVisualStyleBackColor = true;
            this.btnImportShukko.Click += new System.EventHandler(this.btnImportShukko_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(703, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import 棚番号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlBot
            // 
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 336);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(931, 40);
            this.pnlBot.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dtgSourceTana);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 230);
            this.panel1.TabIndex = 2;
            // 
            // dtgSourceTana
            // 
            this.dtgSourceTana.AllowUserToAddRows = false;
            this.dtgSourceTana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSourceTana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSourceTana.Location = new System.Drawing.Point(0, 0);
            this.dtgSourceTana.Name = "dtgSourceTana";
            this.dtgSourceTana.RowTemplate.Height = 35;
            this.dtgSourceTana.Size = new System.Drawing.Size(913, 226);
            this.dtgSourceTana.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 272);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BC Excel file";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgShukko);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "出荷番号";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgShukko
            // 
            this.dtgShukko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgShukko.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgShukko.Location = new System.Drawing.Point(3, 3);
            this.dtgShukko.Name = "dtgShukko";
            this.dtgShukko.RowTemplate.Height = 21;
            this.dtgShukko.Size = new System.Drawing.Size(917, 230);
            this.dtgShukko.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgShuukko);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(923, 236);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "棚番号";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgShuukko
            // 
            this.dtgShuukko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgShuukko.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgShuukko.Location = new System.Drawing.Point(0, 0);
            this.dtgShuukko.Name = "dtgShuukko";
            this.dtgShuukko.RowTemplate.Height = 21;
            this.dtgShuukko.Size = new System.Drawing.Size(923, 236);
            this.dtgShuukko.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.get棚NoAnd組込ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // get棚NoAnd組込ToolStripMenuItem
            // 
            this.get棚NoAnd組込ToolStripMenuItem.Name = "get棚NoAnd組込ToolStripMenuItem";
            this.get棚NoAnd組込ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.get棚NoAnd組込ToolStripMenuItem.Text = "Get 棚No and 組込";
            this.get棚NoAnd組込ToolStripMenuItem.Click += new System.EventHandler(this.get棚NoAnd組込ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // AutoFixBCOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 376);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "AutoFixBCOrder";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AutoFixBCOrder_Load);
            this.pnlTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSourceTana)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgShukko)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgShuukko)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnImportPdf;
        private System.Windows.Forms.Button btnEditPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgSourceTana;
        private System.Windows.Forms.Button btnImportBCExcel;
        private System.Windows.Forms.Button btnImportShukko;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgShukko;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dtgShuukko;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem get棚NoAnd組込ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    }
}

