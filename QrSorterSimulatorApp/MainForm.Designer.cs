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
            this.SuspendLayout();
            // 
            // BtnEnd
            // 
            this.BtnEnd.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEnd.Location = new System.Drawing.Point(590, 498);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(146, 45);
            this.BtnEnd.TabIndex = 2;
            this.BtnEnd.Text = " 終了";
            this.BtnEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(742, 518);
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
            this.LsbRecvBox.Location = new System.Drawing.Point(294, 21);
            this.LsbRecvBox.Name = "LsbRecvBox";
            this.LsbRecvBox.Size = new System.Drawing.Size(578, 220);
            this.LsbRecvBox.TabIndex = 12;
            // 
            // LsbSendBox
            // 
            this.LsbSendBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbSendBox.FormattingEnabled = true;
            this.LsbSendBox.ItemHeight = 24;
            this.LsbSendBox.Location = new System.Drawing.Point(294, 260);
            this.LsbSendBox.Name = "LsbSendBox";
            this.LsbSendBox.Size = new System.Drawing.Size(578, 220);
            this.LsbSendBox.TabIndex = 13;
            // 
            // LblError
            // 
            this.LblError.BackColor = System.Drawing.Color.LightCoral;
            this.LblError.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError.ForeColor = System.Drawing.Color.Blue;
            this.LblError.Location = new System.Drawing.Point(12, 498);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(572, 45);
            this.LblError.TabIndex = 318;
            this.LblError.Text = "LblError";
            this.LblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblError.Visible = false;
            // 
            // BtnSendTestData
            // 
            this.BtnSendTestData.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSendTestData.Location = new System.Drawing.Point(16, 260);
            this.BtnSendTestData.Name = "BtnSendTestData";
            this.BtnSendTestData.Size = new System.Drawing.Size(263, 45);
            this.BtnSendTestData.TabIndex = 319;
            this.BtnSendTestData.Text = "テストデータ送信";
            this.BtnSendTestData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSendTestData.UseVisualStyleBackColor = true;
            this.BtnSendTestData.Click += new System.EventHandler(this.BtnSendTestData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.ControlBox = false;
            this.Controls.Add(this.BtnSendTestData);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LsbSendBox);
            this.Controls.Add(this.LsbRecvBox);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnEnd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "■メインメニュー画面■";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
    }
}

