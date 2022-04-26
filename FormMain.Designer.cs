namespace NuedcCompTestAutoScoring
{
    partial class FormMain
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
            this.dgvScoreDetail = new System.Windows.Forms.DataGridView();
            this.numScoreItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.grpScoreSetting = new System.Windows.Forms.GroupBox();
            this.btnImportScoreDetail = new System.Windows.Forms.Button();
            this.btnExportScoreDetail = new System.Windows.Forms.Button();
            this.btnTestMeasure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpEntries = new System.Windows.Forms.GroupBox();
            this.btnCopyExpr = new System.Windows.Forms.Button();
            this.btnImportEntries = new System.Windows.Forms.Button();
            this.btnExportEntries = new System.Windows.Forms.Button();
            this.btnEvalSelected = new System.Windows.Forms.Button();
            this.btnTestIns = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEntries = new System.Windows.Forms.DataGridView();
            this.numEntriesQuantity = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtHubPort = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoreDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScoreItemQuantity)).BeginInit();
            this.grpScoreSetting.SuspendLayout();
            this.grpEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEntriesQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvScoreDetail
            // 
            this.dgvScoreDetail.AllowUserToAddRows = false;
            this.dgvScoreDetail.AllowUserToDeleteRows = false;
            this.dgvScoreDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScoreDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvScoreDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScoreDetail.Location = new System.Drawing.Point(6, 46);
            this.dgvScoreDetail.Name = "dgvScoreDetail";
            this.dgvScoreDetail.RowTemplate.Height = 25;
            this.dgvScoreDetail.Size = new System.Drawing.Size(902, 194);
            this.dgvScoreDetail.TabIndex = 0;
            // 
            // numScoreItemQuantity
            // 
            this.numScoreItemQuantity.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numScoreItemQuantity.Location = new System.Drawing.Point(92, 17);
            this.numScoreItemQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScoreItemQuantity.Name = "numScoreItemQuantity";
            this.numScoreItemQuantity.Size = new System.Drawing.Size(64, 23);
            this.numScoreItemQuantity.TabIndex = 1;
            this.numScoreItemQuantity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numScoreItemQuantity.ValueChanged += new System.EventHandler(this.numScoreItemQuantity_ValueChanged);
            // 
            // grpScoreSetting
            // 
            this.grpScoreSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScoreSetting.Controls.Add(this.txtExtHubPort);
            this.grpScoreSetting.Controls.Add(this.btnImportScoreDetail);
            this.grpScoreSetting.Controls.Add(this.btnExportScoreDetail);
            this.grpScoreSetting.Controls.Add(this.btnTestMeasure);
            this.grpScoreSetting.Controls.Add(this.label3);
            this.grpScoreSetting.Controls.Add(this.label1);
            this.grpScoreSetting.Controls.Add(this.dgvScoreDetail);
            this.grpScoreSetting.Controls.Add(this.numScoreItemQuantity);
            this.grpScoreSetting.Location = new System.Drawing.Point(3, 3);
            this.grpScoreSetting.Name = "grpScoreSetting";
            this.grpScoreSetting.Size = new System.Drawing.Size(914, 246);
            this.grpScoreSetting.TabIndex = 2;
            this.grpScoreSetting.TabStop = false;
            this.grpScoreSetting.Text = "评分细则";
            // 
            // btnImportScoreDetail
            // 
            this.btnImportScoreDetail.Location = new System.Drawing.Point(248, 16);
            this.btnImportScoreDetail.Name = "btnImportScoreDetail";
            this.btnImportScoreDetail.Size = new System.Drawing.Size(80, 23);
            this.btnImportScoreDetail.TabIndex = 3;
            this.btnImportScoreDetail.Text = "从文件导入";
            this.btnImportScoreDetail.UseVisualStyleBackColor = true;
            this.btnImportScoreDetail.Click += new System.EventHandler(this.btnImportScoreDetail_Click);
            // 
            // btnExportScoreDetail
            // 
            this.btnExportScoreDetail.Location = new System.Drawing.Point(162, 16);
            this.btnExportScoreDetail.Name = "btnExportScoreDetail";
            this.btnExportScoreDetail.Size = new System.Drawing.Size(80, 23);
            this.btnExportScoreDetail.TabIndex = 3;
            this.btnExportScoreDetail.Text = "导出为文件";
            this.btnExportScoreDetail.UseVisualStyleBackColor = true;
            this.btnExportScoreDetail.Click += new System.EventHandler(this.btnExportScoreDetail_Click);
            // 
            // btnTestMeasure
            // 
            this.btnTestMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestMeasure.Location = new System.Drawing.Point(796, 16);
            this.btnTestMeasure.Name = "btnTestMeasure";
            this.btnTestMeasure.Size = new System.Drawing.Size(112, 23);
            this.btnTestMeasure.TabIndex = 2;
            this.btnTestMeasure.Text = "测试选中的评分项";
            this.btnTestMeasure.UseVisualStyleBackColor = true;
            this.btnTestMeasure.Click += new System.EventHandler(this.btnTestMeasure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "评分项数量：";
            // 
            // grpEntries
            // 
            this.grpEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEntries.Controls.Add(this.btnCopyExpr);
            this.grpEntries.Controls.Add(this.btnImportEntries);
            this.grpEntries.Controls.Add(this.btnExportEntries);
            this.grpEntries.Controls.Add(this.btnEvalSelected);
            this.grpEntries.Controls.Add(this.btnTestIns);
            this.grpEntries.Controls.Add(this.label2);
            this.grpEntries.Controls.Add(this.dgvEntries);
            this.grpEntries.Controls.Add(this.numEntriesQuantity);
            this.grpEntries.Location = new System.Drawing.Point(3, 3);
            this.grpEntries.Name = "grpEntries";
            this.grpEntries.Size = new System.Drawing.Size(914, 315);
            this.grpEntries.TabIndex = 3;
            this.grpEntries.TabStop = false;
            this.grpEntries.Text = "待测作品";
            // 
            // btnCopyExpr
            // 
            this.btnCopyExpr.Location = new System.Drawing.Point(322, 16);
            this.btnCopyExpr.Name = "btnCopyExpr";
            this.btnCopyExpr.Size = new System.Drawing.Size(112, 23);
            this.btnCopyExpr.TabIndex = 5;
            this.btnCopyExpr.Text = "复制公式到所有行";
            this.btnCopyExpr.UseVisualStyleBackColor = true;
            this.btnCopyExpr.Click += new System.EventHandler(this.btnCopyExpr_Click);
            // 
            // btnImportEntries
            // 
            this.btnImportEntries.Location = new System.Drawing.Point(236, 16);
            this.btnImportEntries.Name = "btnImportEntries";
            this.btnImportEntries.Size = new System.Drawing.Size(80, 23);
            this.btnImportEntries.TabIndex = 4;
            this.btnImportEntries.Text = "从文件导入";
            this.btnImportEntries.UseVisualStyleBackColor = true;
            this.btnImportEntries.Click += new System.EventHandler(this.btnImportEntries_Click);
            // 
            // btnExportEntries
            // 
            this.btnExportEntries.Location = new System.Drawing.Point(150, 16);
            this.btnExportEntries.Name = "btnExportEntries";
            this.btnExportEntries.Size = new System.Drawing.Size(80, 23);
            this.btnExportEntries.TabIndex = 4;
            this.btnExportEntries.Text = "导出为文件";
            this.btnExportEntries.UseVisualStyleBackColor = true;
            this.btnExportEntries.Click += new System.EventHandler(this.btnExportEntries_Click);
            // 
            // btnEvalSelected
            // 
            this.btnEvalSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEvalSelected.Location = new System.Drawing.Point(796, 16);
            this.btnEvalSelected.Name = "btnEvalSelected";
            this.btnEvalSelected.Size = new System.Drawing.Size(112, 23);
            this.btnEvalSelected.TabIndex = 3;
            this.btnEvalSelected.Text = "对选中的作品评分";
            this.btnEvalSelected.UseVisualStyleBackColor = true;
            this.btnEvalSelected.Click += new System.EventHandler(this.btnEvalSelected_Click);
            // 
            // btnTestIns
            // 
            this.btnTestIns.Location = new System.Drawing.Point(440, 16);
            this.btnTestIns.Name = "btnTestIns";
            this.btnTestIns.Size = new System.Drawing.Size(96, 23);
            this.btnTestIns.TabIndex = 2;
            this.btnTestIns.Text = "测试仪器连接";
            this.btnTestIns.UseVisualStyleBackColor = true;
            this.btnTestIns.Click += new System.EventHandler(this.btnTestIns_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "作品数量：";
            // 
            // dgvEntries
            // 
            this.dgvEntries.AllowUserToAddRows = false;
            this.dgvEntries.AllowUserToDeleteRows = false;
            this.dgvEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntries.Location = new System.Drawing.Point(6, 46);
            this.dgvEntries.Name = "dgvEntries";
            this.dgvEntries.Size = new System.Drawing.Size(902, 263);
            this.dgvEntries.TabIndex = 0;
            // 
            // numEntriesQuantity
            // 
            this.numEntriesQuantity.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numEntriesQuantity.Location = new System.Drawing.Point(80, 17);
            this.numEntriesQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEntriesQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEntriesQuantity.Name = "numEntriesQuantity";
            this.numEntriesQuantity.Size = new System.Drawing.Size(64, 23);
            this.numEntriesQuantity.TabIndex = 1;
            this.numEntriesQuantity.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numEntriesQuantity.ValueChanged += new System.EventHandler(this.numEntriesQuantity_ValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpScoreSetting);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpEntries);
            this.splitContainer1.Size = new System.Drawing.Size(920, 577);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "外部集线板端口：";
            // 
            // txtExtHubPort
            // 
            this.txtExtHubPort.Location = new System.Drawing.Point(444, 16);
            this.txtExtHubPort.Name = "txtExtHubPort";
            this.txtExtHubPort.Size = new System.Drawing.Size(56, 23);
            this.txtExtHubPort.TabIndex = 4;
            this.txtExtHubPort.Text = "COM3";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "FormMain";
            this.Text = "全国大学生电子设计竞赛综合测试评分";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoreDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScoreItemQuantity)).EndInit();
            this.grpScoreSetting.ResumeLayout(false);
            this.grpScoreSetting.PerformLayout();
            this.grpEntries.ResumeLayout(false);
            this.grpEntries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEntriesQuantity)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvScoreDetail;
        private NumericUpDown numScoreItemQuantity;
        private GroupBox grpScoreSetting;
        private Label label1;
        private GroupBox grpEntries;
        private Label label2;
        private DataGridView dgvEntries;
        private NumericUpDown numEntriesQuantity;
        private SplitContainer splitContainer1;
        private Button btnTestIns;
        private Button btnTestMeasure;
        private Button btnEvalSelected;
        private Button btnExportScoreDetail;
        private Button btnImportScoreDetail;
        private Button btnImportEntries;
        private Button btnExportEntries;
        private Button btnCopyExpr;
        private TextBox txtExtHubPort;
        private Label label3;
    }
}