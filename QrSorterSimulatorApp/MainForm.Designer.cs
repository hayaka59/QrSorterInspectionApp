namespace QrSorterSimulatorApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LsbRecvBox = new System.Windows.Forms.ListBox();
            this.LsbSendBox = new System.Windows.Forms.ListBox();
            this.SerialPortQr = new System.IO.Ports.SerialPort(this.components);
            this.LblError = new System.Windows.Forms.Label();
            this.BtnSendTestData = new System.Windows.Forms.Button();
            this.BtnMaintenance = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtPropertyId = new System.Windows.Forms.TextBox();
            this.dtTimPickPostalDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtUniqueKey = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CmbJudge = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CmbErrorCode = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CmbTray = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.TimSendData = new System.Windows.Forms.Timer(this.components);
            this.BtnAutoSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnd
            // 
            this.BtnEnd.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEnd.Location = new System.Drawing.Point(712, 504);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(146, 45);
            this.BtnEnd.TabIndex = 2;
            this.BtnEnd.Text = " 終了";
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(8, 524);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(130, 25);
            this.LblVersion.TabIndex = 11;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsbRecvBox
            // 
            this.LsbRecvBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbRecvBox.FormattingEnabled = true;
            this.LsbRecvBox.ItemHeight = 24;
            this.LsbRecvBox.Location = new System.Drawing.Point(12, 22);
            this.LsbRecvBox.Name = "LsbRecvBox";
            this.LsbRecvBox.Size = new System.Drawing.Size(549, 196);
            this.LsbRecvBox.TabIndex = 12;
            // 
            // LsbSendBox
            // 
            this.LsbSendBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbSendBox.FormattingEnabled = true;
            this.LsbSendBox.ItemHeight = 24;
            this.LsbSendBox.Location = new System.Drawing.Point(11, 22);
            this.LsbSendBox.Name = "LsbSendBox";
            this.LsbSendBox.Size = new System.Drawing.Size(549, 196);
            this.LsbSendBox.TabIndex = 13;
            // 
            // LblError
            // 
            this.LblError.BackColor = System.Drawing.Color.LightCoral;
            this.LblError.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError.ForeColor = System.Drawing.Color.Blue;
            this.LblError.Location = new System.Drawing.Point(144, 504);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(562, 45);
            this.LblError.TabIndex = 318;
            this.LblError.Text = "LblError";
            this.LblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblError.Visible = false;
            // 
            // BtnSendTestData
            // 
            this.BtnSendTestData.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSendTestData.Location = new System.Drawing.Point(58, 21);
            this.BtnSendTestData.Name = "BtnSendTestData";
            this.BtnSendTestData.Size = new System.Drawing.Size(221, 45);
            this.BtnSendTestData.TabIndex = 319;
            this.BtnSendTestData.Text = "テストデータ送信";
            this.BtnSendTestData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSendTestData.UseVisualStyleBackColor = true;
            this.BtnSendTestData.Click += new System.EventHandler(this.BtnSendTestData_Click);
            // 
            // BtnMaintenance
            // 
            this.BtnMaintenance.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnMaintenance.Image = global::QrSorterSimulatorApp.Properties.Resources.settei;
            this.BtnMaintenance.Location = new System.Drawing.Point(12, 21);
            this.BtnMaintenance.Name = "BtnMaintenance";
            this.BtnMaintenance.Size = new System.Drawing.Size(45, 45);
            this.BtnMaintenance.TabIndex = 320;
            this.BtnMaintenance.UseVisualStyleBackColor = true;
            this.BtnMaintenance.Click += new System.EventHandler(this.BtnMaintenance_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPropertyId);
            this.groupBox1.Location = new System.Drawing.Point(16, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 60);
            this.groupBox1.TabIndex = 321;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "物件ID（5桁）";
            // 
            // TxtPropertyId
            // 
            this.TxtPropertyId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPropertyId.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtPropertyId.Location = new System.Drawing.Point(6, 18);
            this.TxtPropertyId.MaxLength = 5;
            this.TxtPropertyId.Name = "TxtPropertyId";
            this.TxtPropertyId.Size = new System.Drawing.Size(81, 31);
            this.TxtPropertyId.TabIndex = 0;
            this.TxtPropertyId.Text = "D8657";
            this.TxtPropertyId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtTimPickPostalDate
            // 
            this.dtTimPickPostalDate.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtTimPickPostalDate.Location = new System.Drawing.Point(11, 23);
            this.dtTimPickPostalDate.Name = "dtTimPickPostalDate";
            this.dtTimPickPostalDate.Size = new System.Drawing.Size(126, 19);
            this.dtTimPickPostalDate.TabIndex = 322;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtTimPickPostalDate);
            this.groupBox2.Location = new System.Drawing.Point(129, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 60);
            this.groupBox2.TabIndex = 322;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "局出し日（8桁）";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtUniqueKey);
            this.groupBox3.Location = new System.Drawing.Point(16, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 60);
            this.groupBox3.TabIndex = 323;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ユニークキー（17桁）  \"_\"はスペース";
            // 
            // TxtUniqueKey
            // 
            this.TxtUniqueKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUniqueKey.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtUniqueKey.Location = new System.Drawing.Point(6, 18);
            this.TxtUniqueKey.MaxLength = 17;
            this.TxtUniqueKey.Name = "TxtUniqueKey";
            this.TxtUniqueKey.Size = new System.Drawing.Size(244, 31);
            this.TxtUniqueKey.TabIndex = 0;
            this.TxtUniqueKey.Text = "-SBZUNUKNMU______";
            this.TxtUniqueKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CmbJudge);
            this.groupBox4.Location = new System.Drawing.Point(16, 213);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(73, 60);
            this.groupBox4.TabIndex = 324;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "判定";
            // 
            // CmbJudge
            // 
            this.CmbJudge.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbJudge.FormattingEnabled = true;
            this.CmbJudge.Location = new System.Drawing.Point(6, 18);
            this.CmbJudge.Name = "CmbJudge";
            this.CmbJudge.Size = new System.Drawing.Size(56, 32);
            this.CmbJudge.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CmbErrorCode);
            this.groupBox5.Location = new System.Drawing.Point(107, 213);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(83, 60);
            this.groupBox5.TabIndex = 325;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "エラーコード";
            // 
            // CmbErrorCode
            // 
            this.CmbErrorCode.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbErrorCode.FormattingEnabled = true;
            this.CmbErrorCode.Location = new System.Drawing.Point(6, 18);
            this.CmbErrorCode.Name = "CmbErrorCode";
            this.CmbErrorCode.Size = new System.Drawing.Size(63, 32);
            this.CmbErrorCode.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CmbTray);
            this.groupBox6.Location = new System.Drawing.Point(205, 213);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(74, 60);
            this.groupBox6.TabIndex = 326;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "トレイ情報";
            // 
            // CmbTray
            // 
            this.CmbTray.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbTray.FormattingEnabled = true;
            this.CmbTray.Location = new System.Drawing.Point(6, 18);
            this.CmbTray.Name = "CmbTray";
            this.CmbTray.Size = new System.Drawing.Size(56, 32);
            this.CmbTray.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.LsbSendBox);
            this.groupBox7.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox7.Location = new System.Drawing.Point(298, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(570, 230);
            this.groupBox7.TabIndex = 327;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "送信データ";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.LsbRecvBox);
            this.groupBox8.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox8.Location = new System.Drawing.Point(298, 250);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(570, 230);
            this.groupBox8.TabIndex = 328;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "受信データ";
            // 
            // TimSendData
            // 
            this.TimSendData.Tick += new System.EventHandler(this.TimSendData_Tick);
            // 
            // BtnAutoSend
            // 
            this.BtnAutoSend.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnAutoSend.Location = new System.Drawing.Point(12, 446);
            this.BtnAutoSend.Name = "BtnAutoSend";
            this.BtnAutoSend.Size = new System.Drawing.Size(146, 45);
            this.BtnAutoSend.TabIndex = 329;
            this.BtnAutoSend.Text = "連続送信";
            this.BtnAutoSend.UseVisualStyleBackColor = true;
            this.BtnAutoSend.Click += new System.EventHandler(this.BtnAutoSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAutoSend);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnMaintenance);
            this.Controls.Add(this.BtnSendTestData);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnEnd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "■メインメニュー画面■";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEnd;
        internal System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.ListBox LsbRecvBox;
        private System.Windows.Forms.ListBox LsbSendBox;
        internal System.IO.Ports.SerialPort SerialPortQr;
        internal System.Windows.Forms.Label LblError;
        private System.Windows.Forms.Button BtnSendTestData;
        private System.Windows.Forms.Button BtnMaintenance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtPropertyId;
        private System.Windows.Forms.DateTimePicker dtTimPickPostalDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtUniqueKey;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CmbJudge;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox CmbErrorCode;
        private System.Windows.Forms.ComboBox CmbTray;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Timer TimSendData;
        private System.Windows.Forms.Button BtnAutoSend;
    }
}

