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
            this.cmbReasonForNonDelivery = new System.Windows.Forms.ComboBox();
            this.dtTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.ChkInspectionDate = new System.Windows.Forms.CheckBox();
            this.GrpInspectionDate = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.ChkAllItem = new System.Windows.Forms.CheckBox();
            this.GrpReasonForNonDelivery = new System.Windows.Forms.GroupBox();
            this.ChkReasonForNonDelivery = new System.Windows.Forms.CheckBox();
            this.LblLogFileCount = new System.Windows.Forms.Label();
            this.LblContentCount = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.GrpInspectionDate.SuspendLayout();
            this.GrpReasonForNonDelivery.SuspendLayout();
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
            // cmbReasonForNonDelivery
            // 
            this.cmbReasonForNonDelivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasonForNonDelivery.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbReasonForNonDelivery.FormattingEnabled = true;
            this.cmbReasonForNonDelivery.IntegralHeight = false;
            this.cmbReasonForNonDelivery.ItemHeight = 28;
            this.cmbReasonForNonDelivery.Location = new System.Drawing.Point(66, 13);
            this.cmbReasonForNonDelivery.Name = "cmbReasonForNonDelivery";
            this.cmbReasonForNonDelivery.Size = new System.Drawing.Size(242, 36);
            this.cmbReasonForNonDelivery.TabIndex = 265;
            // 
            // dtTimePickerFrom
            // 
            this.dtTimePickerFrom.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtTimePickerFrom.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtTimePickerFrom.Location = new System.Drawing.Point(67, 17);
            this.dtTimePickerFrom.Name = "dtTimePickerFrom";
            this.dtTimePickerFrom.Size = new System.Drawing.Size(171, 31);
            this.dtTimePickerFrom.TabIndex = 266;
            // 
            // ChkInspectionDate
            // 
            this.ChkInspectionDate.AutoSize = true;
            this.ChkInspectionDate.Location = new System.Drawing.Point(17, 26);
            this.ChkInspectionDate.Name = "ChkInspectionDate";
            this.ChkInspectionDate.Size = new System.Drawing.Size(46, 16);
            this.ChkInspectionDate.TabIndex = 267;
            this.ChkInspectionDate.Text = "含む";
            this.ChkInspectionDate.UseVisualStyleBackColor = true;
            // 
            // GrpInspectionDate
            // 
            this.GrpInspectionDate.Controls.Add(this.label4);
            this.GrpInspectionDate.Controls.Add(this.dtTimePickerTo);
            this.GrpInspectionDate.Controls.Add(this.ChkInspectionDate);
            this.GrpInspectionDate.Controls.Add(this.dtTimePickerFrom);
            this.GrpInspectionDate.Location = new System.Drawing.Point(661, 75);
            this.GrpInspectionDate.Name = "GrpInspectionDate";
            this.GrpInspectionDate.Size = new System.Drawing.Size(456, 60);
            this.GrpInspectionDate.TabIndex = 268;
            this.GrpInspectionDate.TabStop = false;
            this.GrpInspectionDate.Text = "検査日付";
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
            // dtTimePickerTo
            // 
            this.dtTimePickerTo.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtTimePickerTo.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtTimePickerTo.Location = new System.Drawing.Point(271, 17);
            this.dtTimePickerTo.Name = "dtTimePickerTo";
            this.dtTimePickerTo.Size = new System.Drawing.Size(171, 31);
            this.dtTimePickerTo.TabIndex = 268;
            // 
            // ChkAllItem
            // 
            this.ChkAllItem.AutoSize = true;
            this.ChkAllItem.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChkAllItem.Location = new System.Drawing.Point(592, 101);
            this.ChkAllItem.Name = "ChkAllItem";
            this.ChkAllItem.Size = new System.Drawing.Size(58, 20);
            this.ChkAllItem.TabIndex = 269;
            this.ChkAllItem.Text = "全件";
            this.ChkAllItem.UseVisualStyleBackColor = true;
            this.ChkAllItem.CheckedChanged += new System.EventHandler(this.ChkAllItem_CheckedChanged);
            // 
            // GrpReasonForNonDelivery
            // 
            this.GrpReasonForNonDelivery.Controls.Add(this.ChkReasonForNonDelivery);
            this.GrpReasonForNonDelivery.Controls.Add(this.cmbReasonForNonDelivery);
            this.GrpReasonForNonDelivery.Location = new System.Drawing.Point(1131, 75);
            this.GrpReasonForNonDelivery.Name = "GrpReasonForNonDelivery";
            this.GrpReasonForNonDelivery.Size = new System.Drawing.Size(317, 60);
            this.GrpReasonForNonDelivery.TabIndex = 270;
            this.GrpReasonForNonDelivery.TabStop = false;
            this.GrpReasonForNonDelivery.Text = "不着事由";
            // 
            // ChkReasonForNonDelivery
            // 
            this.ChkReasonForNonDelivery.AutoSize = true;
            this.ChkReasonForNonDelivery.Location = new System.Drawing.Point(17, 26);
            this.ChkReasonForNonDelivery.Name = "ChkReasonForNonDelivery";
            this.ChkReasonForNonDelivery.Size = new System.Drawing.Size(46, 16);
            this.ChkReasonForNonDelivery.TabIndex = 267;
            this.ChkReasonForNonDelivery.Text = "含む";
            this.ChkReasonForNonDelivery.UseVisualStyleBackColor = true;
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
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnUpdate.Image = global::QrSorterInspectionApp.Properties.Resources.update;
            this.BtnUpdate.Location = new System.Drawing.Point(1477, 86);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(170, 45);
            this.BtnUpdate.TabIndex = 273;
            this.BtnUpdate.Text = "更新";
            this.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // LogListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.LblContentCount);
            this.Controls.Add(this.LblLogFileCount);
            this.Controls.Add(this.GrpReasonForNonDelivery);
            this.Controls.Add(this.ChkAllItem);
            this.Controls.Add(this.GrpInspectionDate);
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
            this.GrpInspectionDate.ResumeLayout(false);
            this.GrpInspectionDate.PerformLayout();
            this.GrpReasonForNonDelivery.ResumeLayout(false);
            this.GrpReasonForNonDelivery.PerformLayout();
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
        internal System.Windows.Forms.ComboBox cmbReasonForNonDelivery;
        private System.Windows.Forms.DateTimePicker dtTimePickerFrom;
        private System.Windows.Forms.CheckBox ChkInspectionDate;
        private System.Windows.Forms.GroupBox GrpInspectionDate;
        private System.Windows.Forms.CheckBox ChkAllItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTimePickerTo;
        private System.Windows.Forms.GroupBox GrpReasonForNonDelivery;
        private System.Windows.Forms.CheckBox ChkReasonForNonDelivery;
        private System.Windows.Forms.Label LblLogFileCount;
        private System.Windows.Forms.Label LblContentCount;
        internal System.Windows.Forms.Button BtnUpdate;
    }
}