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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSource = new System.Windows.Forms.Button();
            this.btnParam = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpSource = new System.Windows.Forms.TabPage();
            this.tbpParam = new System.Windows.Forms.TabPage();
            this.dtgSource = new System.Windows.Forms.DataGridView();
            this.dtgParam = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpSource.SuspendLayout();
            this.tbpParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 40);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 40);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(888, 291);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSource, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnParam, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFill, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSource
            // 
            this.btnSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSource.ForeColor = System.Drawing.Color.Blue;
            this.btnSource.Location = new System.Drawing.Point(23, 3);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(144, 34);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Import Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnParam
            // 
            this.btnParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParam.ForeColor = System.Drawing.Color.Blue;
            this.btnParam.Location = new System.Drawing.Point(173, 3);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(144, 34);
            this.btnParam.TabIndex = 1;
            this.btnParam.Text = "Import Param";
            this.btnParam.UseVisualStyleBackColor = true;
            this.btnParam.Click += new System.EventHandler(this.btnParam_Click);
            // 
            // btnFill
            // 
            this.btnFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFill.ForeColor = System.Drawing.Color.Blue;
            this.btnFill.Location = new System.Drawing.Point(323, 3);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(144, 34);
            this.btnFill.TabIndex = 2;
            this.btnFill.Text = "Auto Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpSource);
            this.tabControl1.Controls.Add(this.tbpParam);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 291);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpSource
            // 
            this.tbpSource.Controls.Add(this.dtgSource);
            this.tbpSource.Location = new System.Drawing.Point(4, 32);
            this.tbpSource.Name = "tbpSource";
            this.tbpSource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSource.Size = new System.Drawing.Size(880, 255);
            this.tbpSource.TabIndex = 0;
            this.tbpSource.Text = "Data Source";
            this.tbpSource.UseVisualStyleBackColor = true;
            // 
            // tbpParam
            // 
            this.tbpParam.Controls.Add(this.dtgParam);
            this.tbpParam.Location = new System.Drawing.Point(4, 32);
            this.tbpParam.Name = "tbpParam";
            this.tbpParam.Padding = new System.Windows.Forms.Padding(3);
            this.tbpParam.Size = new System.Drawing.Size(880, 255);
            this.tbpParam.TabIndex = 1;
            this.tbpParam.Text = "Data Param";
            this.tbpParam.UseVisualStyleBackColor = true;
            // 
            // dtgSource
            // 
            this.dtgSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSource.Location = new System.Drawing.Point(3, 3);
            this.dtgSource.Name = "dtgSource";
            this.dtgSource.RowTemplate.Height = 21;
            this.dtgSource.Size = new System.Drawing.Size(874, 249);
            this.dtgSource.TabIndex = 0;
            // 
            // dtgParam
            // 
            this.dtgParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgParam.Location = new System.Drawing.Point(3, 3);
            this.dtgParam.Name = "dtgParam";
            this.dtgParam.RowTemplate.Height = 21;
            this.dtgParam.Size = new System.Drawing.Size(874, 249);
            this.dtgParam.TabIndex = 0;
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
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "wfFillData";
            this.Text = "wfFillData";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbpSource.ResumeLayout(false);
            this.tbpParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpSource;
        private System.Windows.Forms.DataGridView dtgSource;
        private System.Windows.Forms.TabPage tbpParam;
        private System.Windows.Forms.DataGridView dtgParam;
    }
}