namespace QrSorterInspectionApp
{
    partial class LogListForm
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
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblTitle = new System.Windows.Forms.Label();
            this.CmbLogType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LsvLogContent = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LsbLogList = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.LblLogFileCount = new System.Windows.Forms.Label();
            this.LblContentCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1758, 998);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(130, 25);
            this.LblVersion.TabIndex = 242;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnClose.Image = global::QrSorterInspectionApp.Properties.Resources.back_arrow;
            this.BtnClose.Location = new System.Drawing.Point(1547, 973);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(205, 50);
            this.BtnClose.TabIndex = 241;
            this.BtnClose.Text = "戻る";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(1, 1);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1909, 50);
            this.LblTitle.TabIndex = 240;
            this.LblTitle.Text = "ログ管理";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbLogType
            // 
            this.CmbLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLogType.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbLogType.FormattingEnabled = true;
            this.CmbLogType.IntegralHeight = false;
            this.CmbLogType.ItemHeight = 28;
            this.CmbLogType.Location = new System.Drawing.Point(278, 92);
            this.CmbLogType.Name = "CmbLogType";
            this.CmbLogType.Size = new System.Drawing.Size(299, 36);
            this.CmbLogType.TabIndex = 261;
            this.CmbLogType.SelectedIndexChanged += new System.EventHandler(this.CmbLogType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(108, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 36);
            this.label3.TabIndex = 260;
            this.label3.Text = "ログの種類";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsvLogContent
            // 
            this.LsvLogContent.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsvLogContent.FullRowSelect = true;
            this.LsvLogContent.GridLines = true;
            this.LsvLogContent.HideSelection = false;
            this.LsvLogContent.Location = new System.Drawing.Point(108, 452);
            this.LsvLogContent.Name = "LsvLogContent";
            this.LsvLogContent.Size = new System.Drawing.Size(1686, 488);
            this.LsvLogContent.TabIndex = 258;
            this.LsvLogContent.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(108, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1686, 31);
            this.label9.TabIndex = 259;
            this.label9.Text = "選択したログの内容";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(108, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1686, 31);
            this.label1.TabIndex = 262;
            this.label1.Text = "機械ログ一覧";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsbLogList
            // 
            this.LsbLogList.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbLogList.FormattingEnabled = true;
            this.LsbLogList.ItemHeight = 24;
            this.LsbLogList.Location = new System.Drawing.Point(108, 182);
            this.LsbLogList.Name = "LsbLogList";
            this.LsbLogList.Size = new System.Drawing.Size(1686, 220);
            this.LsbLogList.TabIndex = 263;
            this.LsbLogList.SelectedIndexChanged += new System.EventHandler(this.LsbLogList_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 28;
            this.comboBox1.Location = new System.Drawing.Point(69, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 36);
            this.comboBox1.TabIndex = 265;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePicker1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePicker1.Location = new System.Drawing.Point(67, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(171, 31);
            this.dateTimePicker1.TabIndex = 266;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 16);
            this.checkBox1.TabIndex = 267;
            this.checkBox1.Text = "含む";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(661, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 60);
            this.groupBox1.TabIndex = 268;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検査日付";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(242, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 24);
            this.label4.TabIndex = 269;
            this.label4.Text = "～";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePicker2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePicker2.Location = new System.Drawing.Point(271, 17);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(171, 31);
            this.dateTimePicker2.TabIndex = 268;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox2.Location = new System.Drawing.Point(592, 101);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(58, 20);
            this.checkBox2.TabIndex = 269;
            this.checkBox2.Text = "全件";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(1128, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 60);
            this.groupBox2.TabIndex = 270;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "不着事由";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(17, 26);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(46, 16);
            this.checkBox3.TabIndex = 267;
            this.checkBox3.Text = "含む";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // LblLogFileCount
            // 
            this.LblLogFileCount.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblLogFileCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblLogFileCount.ForeColor = System.Drawing.Color.White;
            this.LblLogFileCount.Location = new System.Drawing.Point(122, 157);
            this.LblLogFileCount.Name = "LblLogFileCount";
            this.LblLogFileCount.Size = new System.Drawing.Size(273, 23);
            this.LblLogFileCount.TabIndex = 271;
            this.LblLogFileCount.Text = "LblLogFileCount";
            this.LblLogFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblContentCount
            // 
            this.LblContentCount.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblContentCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblContentCount.ForeColor = System.Drawing.Color.White;
            this.LblContentCount.Location = new System.Drawing.Point(122, 427);
            this.LblContentCount.Name = "LblContentCount";
            this.LblContentCount.Size = new System.Drawing.Size(273, 23);
            this.LblContentCount.TabIndex = 272;
            this.LblContentCount.Text = "LblContentCount";
            this.LblContentCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.LblContentCount);
            this.Controls.Add(this.LblLogFileCount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LsbLogList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbLogType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LsvLogContent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログ参照";
            this.Load += new System.EventHandler(this.LogListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.ComboBox CmbLogType;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView LsvLogContent;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LsbLogList;
        internal System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label LblLogFileCount;
        private System.Windows.Forms.Label LblContentCount;
    }
}