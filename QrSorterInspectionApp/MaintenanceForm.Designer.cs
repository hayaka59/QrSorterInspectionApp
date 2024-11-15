namespace QrSorterInspectionApp
{
    partial class MaintenanceForm
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
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.GroupBox11 = new System.Windows.Forms.GroupBox();
            this.CmbSaveMonth = new System.Windows.Forms.ComboBox();
            this.BtnDeleteLogData = new System.Windows.Forms.Button();
            this.Label36 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.CmbComParityVar = new System.Windows.Forms.ComboBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.CmbComIsParty = new System.Windows.Forms.ComboBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.CmbComStopBit = new System.Windows.Forms.ComboBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.CmbComDataLength = new System.Windows.Forms.ComboBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.CmbComSpeed = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.CmbComPort = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.GroupBox12 = new System.Windows.Forms.GroupBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.TxtHddSpace = new System.Windows.Forms.TextBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtMachineName = new System.Windows.Forms.TextBox();
            this.Label32 = new System.Windows.Forms.Label();
            this.TxtUserAccount = new System.Windows.Forms.TextBox();
            this.BtnDecript = new System.Windows.Forms.Button();
            this.BtnEncript = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.GroupBox11.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(-2, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1909, 50);
            this.LblTitle.TabIndex = 239;
            this.LblTitle.Text = "保守";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1762, 1007);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(130, 25);
            this.LblVersion.TabIndex = 241;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblVersion.Click += new System.EventHandler(this.LblVersion_Click);
            this.LblVersion.DoubleClick += new System.EventHandler(this.LblVersion_DoubleClick);
            // 
            // GroupBox11
            // 
            this.GroupBox11.Controls.Add(this.CmbSaveMonth);
            this.GroupBox11.Controls.Add(this.BtnDeleteLogData);
            this.GroupBox11.Controls.Add(this.Label36);
            this.GroupBox11.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox11.Location = new System.Drawing.Point(598, 213);
            this.GroupBox11.Name = "GroupBox11";
            this.GroupBox11.Size = new System.Drawing.Size(328, 142);
            this.GroupBox11.TabIndex = 247;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "ログ保存";
            // 
            // CmbSaveMonth
            // 
            this.CmbSaveMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSaveMonth.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbSaveMonth.FormattingEnabled = true;
            this.CmbSaveMonth.IntegralHeight = false;
            this.CmbSaveMonth.Location = new System.Drawing.Point(108, 31);
            this.CmbSaveMonth.Name = "CmbSaveMonth";
            this.CmbSaveMonth.Size = new System.Drawing.Size(199, 32);
            this.CmbSaveMonth.TabIndex = 90;
            // 
            // BtnDeleteLogData
            // 
            this.BtnDeleteLogData.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDeleteLogData.Image = global::QrSorterInspectionApp.Properties.Resources.trash_icon;
            this.BtnDeleteLogData.Location = new System.Drawing.Point(19, 73);
            this.BtnDeleteLogData.Name = "BtnDeleteLogData";
            this.BtnDeleteLogData.Size = new System.Drawing.Size(288, 48);
            this.BtnDeleteLogData.TabIndex = 89;
            this.BtnDeleteLogData.Text = "ログデータ手動削除";
            this.BtnDeleteLogData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteLogData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeleteLogData.UseVisualStyleBackColor = true;
            // 
            // Label36
            // 
            this.Label36.BackColor = System.Drawing.Color.Blue;
            this.Label36.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label36.ForeColor = System.Drawing.Color.White;
            this.Label36.Location = new System.Drawing.Point(19, 31);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(89, 31);
            this.Label36.TabIndex = 88;
            this.Label36.Text = "保存期間";
            this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.CmbComParityVar);
            this.GroupBox7.Controls.Add(this.Label27);
            this.GroupBox7.Controls.Add(this.CmbComIsParty);
            this.GroupBox7.Controls.Add(this.Label26);
            this.GroupBox7.Controls.Add(this.CmbComStopBit);
            this.GroupBox7.Controls.Add(this.Label28);
            this.GroupBox7.Controls.Add(this.CmbComDataLength);
            this.GroupBox7.Controls.Add(this.Label24);
            this.GroupBox7.Controls.Add(this.CmbComSpeed);
            this.GroupBox7.Controls.Add(this.Label6);
            this.GroupBox7.Controls.Add(this.CmbComPort);
            this.GroupBox7.Controls.Add(this.Label23);
            this.GroupBox7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox7.Location = new System.Drawing.Point(976, 117);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(330, 261);
            this.GroupBox7.TabIndex = 246;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "RS-232C設定";
            // 
            // CmbComParityVar
            // 
            this.CmbComParityVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComParityVar.FormattingEnabled = true;
            this.CmbComParityVar.Location = new System.Drawing.Point(187, 172);
            this.CmbComParityVar.Name = "CmbComParityVar";
            this.CmbComParityVar.Size = new System.Drawing.Size(121, 32);
            this.CmbComParityVar.TabIndex = 97;
            // 
            // Label27
            // 
            this.Label27.BackColor = System.Drawing.Color.Blue;
            this.Label27.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label27.ForeColor = System.Drawing.Color.White;
            this.Label27.Location = new System.Drawing.Point(23, 174);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(163, 30);
            this.Label27.TabIndex = 96;
            this.Label27.Text = "パリティ種別";
            this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComIsParty
            // 
            this.CmbComIsParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComIsParty.FormattingEnabled = true;
            this.CmbComIsParty.Location = new System.Drawing.Point(187, 137);
            this.CmbComIsParty.Name = "CmbComIsParty";
            this.CmbComIsParty.Size = new System.Drawing.Size(121, 32);
            this.CmbComIsParty.TabIndex = 95;
            // 
            // Label26
            // 
            this.Label26.BackColor = System.Drawing.Color.Blue;
            this.Label26.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label26.ForeColor = System.Drawing.Color.White;
            this.Label26.Location = new System.Drawing.Point(23, 138);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(163, 30);
            this.Label26.TabIndex = 94;
            this.Label26.Text = "パリティ無効／有効";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComStopBit
            // 
            this.CmbComStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComStopBit.FormattingEnabled = true;
            this.CmbComStopBit.Location = new System.Drawing.Point(186, 210);
            this.CmbComStopBit.Name = "CmbComStopBit";
            this.CmbComStopBit.Size = new System.Drawing.Size(121, 32);
            this.CmbComStopBit.TabIndex = 93;
            // 
            // Label28
            // 
            this.Label28.BackColor = System.Drawing.Color.Blue;
            this.Label28.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label28.ForeColor = System.Drawing.Color.White;
            this.Label28.Location = new System.Drawing.Point(22, 210);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(163, 30);
            this.Label28.TabIndex = 92;
            this.Label28.Text = "ストップビット";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComDataLength
            // 
            this.CmbComDataLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComDataLength.FormattingEnabled = true;
            this.CmbComDataLength.Location = new System.Drawing.Point(186, 102);
            this.CmbComDataLength.Name = "CmbComDataLength";
            this.CmbComDataLength.Size = new System.Drawing.Size(121, 32);
            this.CmbComDataLength.TabIndex = 87;
            // 
            // Label24
            // 
            this.Label24.BackColor = System.Drawing.Color.Blue;
            this.Label24.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label24.ForeColor = System.Drawing.Color.White;
            this.Label24.Location = new System.Drawing.Point(22, 103);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(163, 30);
            this.Label24.TabIndex = 86;
            this.Label24.Text = "データ長";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComSpeed
            // 
            this.CmbComSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComSpeed.FormattingEnabled = true;
            this.CmbComSpeed.Location = new System.Drawing.Point(186, 67);
            this.CmbComSpeed.Name = "CmbComSpeed";
            this.CmbComSpeed.Size = new System.Drawing.Size(121, 32);
            this.CmbComSpeed.TabIndex = 85;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Blue;
            this.Label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(22, 68);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(163, 30);
            this.Label6.TabIndex = 84;
            this.Label6.Text = "通信速度";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComPort
            // 
            this.CmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComPort.FormattingEnabled = true;
            this.CmbComPort.Location = new System.Drawing.Point(186, 31);
            this.CmbComPort.Name = "CmbComPort";
            this.CmbComPort.Size = new System.Drawing.Size(121, 32);
            this.CmbComPort.TabIndex = 83;
            // 
            // Label23
            // 
            this.Label23.BackColor = System.Drawing.Color.Blue;
            this.Label23.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label23.ForeColor = System.Drawing.Color.White;
            this.Label23.Location = new System.Drawing.Point(22, 33);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(163, 30);
            this.Label23.TabIndex = 82;
            this.Label23.Text = "ポート";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox12
            // 
            this.GroupBox12.Controls.Add(this.TxtPassword);
            this.GroupBox12.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox12.Location = new System.Drawing.Point(598, 471);
            this.GroupBox12.Name = "GroupBox12";
            this.GroupBox12.Size = new System.Drawing.Size(328, 80);
            this.GroupBox12.TabIndex = 245;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "パスワード設定";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtPassword.Location = new System.Drawing.Point(32, 31);
            this.TxtPassword.MaxLength = 10;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(260, 31);
            this.TxtPassword.TabIndex = 0;
            this.TxtPassword.Text = "0000";
            this.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.TxtHddSpace);
            this.GroupBox6.Controls.Add(this.Label29);
            this.GroupBox6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox6.Location = new System.Drawing.Point(598, 375);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(328, 75);
            this.GroupBox6.TabIndex = 244;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "ディスク空き容量チェック";
            // 
            // TxtHddSpace
            // 
            this.TxtHddSpace.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtHddSpace.Location = new System.Drawing.Point(23, 33);
            this.TxtHddSpace.MaxLength = 4;
            this.TxtHddSpace.Name = "TxtHddSpace";
            this.TxtHddSpace.Size = new System.Drawing.Size(85, 31);
            this.TxtHddSpace.TabIndex = 90;
            this.TxtHddSpace.Text = "30";
            this.TxtHddSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label29
            // 
            this.Label29.BackColor = System.Drawing.Color.Transparent;
            this.Label29.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label29.ForeColor = System.Drawing.Color.Black;
            this.Label29.Location = new System.Drawing.Point(114, 34);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(178, 30);
            this.Label29.TabIndex = 89;
            this.Label29.Text = "ＧＢ未満で警告を表示";
            this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.TxtMachineName);
            this.GroupBox5.Controls.Add(this.Label32);
            this.GroupBox5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox5.Location = new System.Drawing.Point(598, 117);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(328, 75);
            this.GroupBox5.TabIndex = 243;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "号機名";
            // 
            // TxtMachineName
            // 
            this.TxtMachineName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtMachineName.Location = new System.Drawing.Point(108, 27);
            this.TxtMachineName.MaxLength = 100;
            this.TxtMachineName.Name = "TxtMachineName";
            this.TxtMachineName.Size = new System.Drawing.Size(199, 31);
            this.TxtMachineName.TabIndex = 89;
            this.TxtMachineName.Text = "1号機";
            this.TxtMachineName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label32
            // 
            this.Label32.BackColor = System.Drawing.Color.Blue;
            this.Label32.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label32.ForeColor = System.Drawing.Color.White;
            this.Label32.Location = new System.Drawing.Point(19, 27);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(89, 31);
            this.Label32.TabIndex = 88;
            this.Label32.Text = "号機名称";
            this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtUserAccount
            // 
            this.TxtUserAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserAccount.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtUserAccount.Location = new System.Drawing.Point(598, 647);
            this.TxtUserAccount.Multiline = true;
            this.TxtUserAccount.Name = "TxtUserAccount";
            this.TxtUserAccount.Size = new System.Drawing.Size(688, 324);
            this.TxtUserAccount.TabIndex = 252;
            this.TxtUserAccount.Visible = false;
            // 
            // BtnDecript
            // 
            this.BtnDecript.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDecript.Image = global::QrSorterInspectionApp.Properties.Resources.decrypt;
            this.BtnDecript.Location = new System.Drawing.Point(598, 600);
            this.BtnDecript.Name = "BtnDecript";
            this.BtnDecript.Size = new System.Drawing.Size(316, 45);
            this.BtnDecript.TabIndex = 251;
            this.BtnDecript.Text = "ファイルの復号化";
            this.BtnDecript.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDecript.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDecript.UseVisualStyleBackColor = true;
            this.BtnDecript.Visible = false;
            this.BtnDecript.Click += new System.EventHandler(this.BtnDecript_Click);
            // 
            // BtnEncript
            // 
            this.BtnEncript.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEncript.Image = global::QrSorterInspectionApp.Properties.Resources.encrypt;
            this.BtnEncript.Location = new System.Drawing.Point(970, 600);
            this.BtnEncript.Name = "BtnEncript";
            this.BtnEncript.Size = new System.Drawing.Size(316, 45);
            this.BtnEncript.TabIndex = 250;
            this.BtnEncript.Text = "ファイルの暗号化";
            this.BtnEncript.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEncript.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEncript.UseVisualStyleBackColor = true;
            this.BtnEncript.Visible = false;
            this.BtnEncript.Click += new System.EventHandler(this.BtnEncript_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnApply.Image = global::QrSorterInspectionApp.Properties.Resources.check;
            this.BtnApply.Location = new System.Drawing.Point(98, 907);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(166, 50);
            this.BtnApply.TabIndex = 242;
            this.BtnApply.Text = "適用";
            this.BtnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnClose.Image = global::QrSorterInspectionApp.Properties.Resources.back_arrow;
            this.BtnClose.Location = new System.Drawing.Point(1561, 907);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(205, 50);
            this.BtnClose.TabIndex = 240;
            this.BtnClose.Text = "戻る";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // MaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.TxtUserAccount);
            this.Controls.Add(this.BtnDecript);
            this.Controls.Add(this.BtnEncript);
            this.Controls.Add(this.GroupBox11);
            this.Controls.Add(this.GroupBox7);
            this.Controls.Add(this.GroupBox12);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保守画面";
            this.Load += new System.EventHandler(this.MaintenanceForm_Load);
            this.GroupBox11.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Button BtnApply;
        internal System.Windows.Forms.GroupBox GroupBox11;
        internal System.Windows.Forms.ComboBox CmbSaveMonth;
        internal System.Windows.Forms.Button BtnDeleteLogData;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.ComboBox CmbComStopBit;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.ComboBox CmbComDataLength;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.ComboBox CmbComSpeed;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox CmbComPort;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.GroupBox GroupBox12;
        internal System.Windows.Forms.TextBox TxtPassword;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.TextBox TxtHddSpace;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.TextBox TxtMachineName;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.ComboBox CmbComParityVar;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.ComboBox CmbComIsParty;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.Button BtnEncript;
        internal System.Windows.Forms.Button BtnDecript;
        private System.Windows.Forms.TextBox TxtUserAccount;
    }
}