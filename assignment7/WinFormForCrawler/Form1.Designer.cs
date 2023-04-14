namespace WinFormForCrawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.uRLInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uRLInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1561, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置初始URL";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(600, 95);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 37);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始爬取";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(154, 94);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(422, 38);
            this.txtURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入初始URL：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 226);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1561, 655);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已经爬取的URL和错误的URL信息";
            // 
            // dgvInfo
            // 
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.infoDataGridViewTextBoxColumn});
            this.dgvInfo.DataSource = this.uRLInfoBindingSource;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.Location = new System.Drawing.Point(3, 31);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersWidth = 62;
            this.dgvInfo.RowTemplate.Height = 32;
            this.dgvInfo.Size = new System.Drawing.Size(1555, 621);
            this.dgvInfo.TabIndex = 0;
            // 
            // uRLInfoBindingSource
            // 
            this.uRLInfoBindingSource.DataSource = typeof(SimpleCrawler.URLInfo);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "序号";
            this.noDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.Width = 160;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Url";
            this.dataGridViewTextBoxColumn1.HeaderText = "URL";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 800;
            // 
            // infoDataGridViewTextBoxColumn
            // 
            this.infoDataGridViewTextBoxColumn.DataPropertyName = "Info";
            this.infoDataGridViewTextBoxColumn.HeaderText = "状态信息";
            this.infoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.infoDataGridViewTextBoxColumn.Name = "infoDataGridViewTextBoxColumn";
            this.infoDataGridViewTextBoxColumn.Width = 700;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 881);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uRLInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private Label label1;
        private TextBox txtURL;
        private Button btnStart;
        private DataGridView dgvInfo;
        private BindingSource uRLInfoBindingSource;
        private DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn infoDataGridViewTextBoxColumn;
    }
}