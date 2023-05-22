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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            btnStart = new Button();
            txtURL = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvInfo = new DataGridView();
            uRLInfoBindingSource = new BindingSource(components);
            noDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            infoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uRLInfoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStart);
            groupBox1.Controls.Add(txtURL);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1561, 226);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "配置初始URL";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(600, 95);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(135, 37);
            btnStart.TabIndex = 2;
            btnStart.Text = "开始爬取";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(154, 94);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(422, 38);
            txtURL.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 101);
            label1.Name = "label1";
            label1.Size = new Size(150, 27);
            label1.TabIndex = 0;
            label1.Text = "输入初始URL：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvInfo);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 226);
            groupBox2.Margin = new Padding(8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1561, 655);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "已经爬取的URL和错误的URL信息";
            // 
            // dgvInfo
            // 
            dgvInfo.AutoGenerateColumns = false;
            dgvInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInfo.Columns.AddRange(new DataGridViewColumn[] { noDataGridViewTextBoxColumn, dataGridViewTextBoxColumn1, infoDataGridViewTextBoxColumn });
            dgvInfo.DataSource = uRLInfoBindingSource;
            dgvInfo.Dock = DockStyle.Fill;
            dgvInfo.Location = new Point(3, 31);
            dgvInfo.Name = "dgvInfo";
            dgvInfo.RowHeadersWidth = 62;
            dgvInfo.RowTemplate.Height = 32;
            dgvInfo.Size = new Size(1555, 621);
            dgvInfo.TabIndex = 0;
            // 
            // uRLInfoBindingSource
            // 
            uRLInfoBindingSource.DataSource = typeof(SimpleCrawler.URLInfo);
            // 
            // noDataGridViewTextBoxColumn
            // 
            noDataGridViewTextBoxColumn.DataPropertyName = "No";
            noDataGridViewTextBoxColumn.HeaderText = "序号";
            noDataGridViewTextBoxColumn.MinimumWidth = 8;
            noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            noDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Url";
            dataGridViewTextBoxColumn1.HeaderText = "Url";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 600;
            // 
            // infoDataGridViewTextBoxColumn
            // 
            infoDataGridViewTextBoxColumn.DataPropertyName = "Info";
            infoDataGridViewTextBoxColumn.HeaderText = "返回信息";
            infoDataGridViewTextBoxColumn.MinimumWidth = 8;
            infoDataGridViewTextBoxColumn.Name = "infoDataGridViewTextBoxColumn";
            infoDataGridViewTextBoxColumn.Width = 800;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1561, 881);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)uRLInfoBindingSource).EndInit();
            ResumeLayout(false);
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