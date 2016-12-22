namespace AutoFixBCOrder
{
    partial class wfFillData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfFillData));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnParam = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbnMessage = new System.Windows.Forms.Label();
            this.prBar = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgSource = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 44);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnParam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnIn, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnParam
            // 
            this.btnParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParam.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParam.ForeColor = System.Drawing.Color.Blue;
            this.btnParam.Image = global::AutoFixBCOrder.Properties.Resources.open_file_icon1;
            this.btnParam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParam.Location = new System.Drawing.Point(222, 3);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(144, 38);
            this.btnParam.TabIndex = 1;
            this.btnParam.Text = "　　インポート";
            this.btnParam.UseVisualStyleBackColor = true;
            this.btnParam.Click += new System.EventHandler(this.btnParam_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Blue;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(372, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 38);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "出力";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.Blue;
            this.btnIn.Image = global::AutoFixBCOrder.Properties.Resources.Zerode_Plump_Device_Printer;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(522, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(144, 38);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "印刷";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 326);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 45);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbnMessage, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.prBar, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(888, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(621, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 39);
            this.panel4.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 35);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "株式会社　玉吉製作所";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbnMessage
            // 
            this.lbnMessage.AutoSize = true;
            this.lbnMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbnMessage.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnMessage.ForeColor = System.Drawing.Color.Blue;
            this.lbnMessage.Location = new System.Drawing.Point(23, 0);
            this.lbnMessage.Name = "lbnMessage";
            this.lbnMessage.Size = new System.Drawing.Size(344, 45);
            this.lbnMessage.TabIndex = 1;
            this.lbnMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prBar
            // 
            this.prBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prBar.Location = new System.Drawing.Point(373, 3);
            this.prBar.Name = "prBar";
            this.prBar.Size = new System.Drawing.Size(242, 39);
            this.prBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prBar.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgSource);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(888, 282);
            this.panel3.TabIndex = 2;
            // 
            // dtgSource
            // 
            this.dtgSource.AllowUserToAddRows = false;
            this.dtgSource.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSource.Location = new System.Drawing.Point(0, 0);
            this.dtgSource.Name = "dtgSource";
            this.dtgSource.RowTemplate.Height = 30;
            this.dtgSource.Size = new System.Drawing.Size(888, 282);
            this.dtgSource.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // wfFillData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 371);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "wfFillData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.wfFillData_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView dtgSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbnMessage;
        private System.Windows.Forms.ProgressBar prBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}