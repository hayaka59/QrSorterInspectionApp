﻿namespace QrSorterInspectionApp
{
    partial class QrSorterInspectionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QrSorterInspectionForm));
            this.LblVersion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.DtpDateReceipt = new System.Windows.Forms.DateTimePicker();
            this.LblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LsvOKHistory = new System.Windows.Forms.ListView();
            this.LsvNGHistory = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.LblQuantity3 = new System.Windows.Forms.Label();
            this.LblBox3 = new System.Windows.Forms.Label();
            this.LblBox1 = new System.Windows.Forms.Label();
            this.LblQuantity1 = new System.Windows.Forms.Label();
            this.LblBox4 = new System.Windows.Forms.Label();
            this.LblQuantity5 = new System.Windows.Forms.Label();
            this.LblBox2 = new System.Windows.Forms.Label();
            this.LblQuantity2 = new System.Windows.Forms.Label();
            this.LblBoxTitle3 = new System.Windows.Forms.Label();
            this.LblBoxTitle1 = new System.Windows.Forms.Label();
            this.LblBoxTitle2 = new System.Windows.Forms.Label();
            this.LblBoxTitle4 = new System.Windows.Forms.Label();
            this.LblBoxEject = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.LblDateTime = new System.Windows.Forms.Label();
            this.TimDateTime = new System.Windows.Forms.Timer(this.components);
            this.LblPocket1 = new System.Windows.Forms.Label();
            this.LblPocket2 = new System.Windows.Forms.Label();
            this.LblPocket4 = new System.Windows.Forms.Label();
            this.LblPocket3 = new System.Windows.Forms.Label();
            this.LblTotalCount = new System.Windows.Forms.Label();
            this.LblOKCount = new System.Windows.Forms.Label();
            this.LblNGCount = new System.Windows.Forms.Label();
            this.LblBoxTitle5 = new System.Windows.Forms.Label();
            this.LblBox5 = new System.Windows.Forms.Label();
            this.LblQuantity4 = new System.Windows.Forms.Label();
            this.CmbNonDeliveryReasonSorting2 = new System.Windows.Forms.ComboBox();
            this.CmbNonDeliveryReasonSorting1 = new System.Windows.Forms.ComboBox();
            this.LblPocket5 = new System.Windows.Forms.Label();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnStopInspection = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnStartInspection = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.SerialPortQr = new System.IO.Ports.SerialPort(this.components);
            this.LblError = new System.Windows.Forms.Label();
            this.LblSelectedFile = new System.Windows.Forms.Label();
            this.BtnJobSelect = new System.Windows.Forms.Button();
            this.LblGrpInfo5 = new System.Windows.Forms.Label();
            this.LblGrpInfo4 = new System.Windows.Forms.Label();
            this.LblGrpInfo3 = new System.Windows.Forms.Label();
            this.LblGrpInfo2 = new System.Windows.Forms.Label();
            this.LblGrpInfo1 = new System.Windows.Forms.Label();
            this.LblFdrInfo1 = new System.Windows.Forms.Label();
            this.LblFdrInfo2 = new System.Windows.Forms.Label();
            this.LblFdrInfo3 = new System.Windows.Forms.Label();
            this.LblFdrInfo4 = new System.Windows.Forms.Label();
            this.LblFdrInfo5 = new System.Windows.Forms.Label();
            this.LblPocketEject = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblQrReadData = new System.Windows.Forms.Label();
            this.LblDuplicateCheck = new System.Windows.Forms.Label();
            this.LstSettingInfomation = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1753, 997);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(130, 25);
            this.LblVersion.TabIndex = 179;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblVersion.DoubleClick += new System.EventHandler(this.LblVersion_DoubleClick);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(96, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 36);
            this.label8.TabIndex = 228;
            this.label8.Text = "受領日";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(96, 257);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(192, 36);
            this.label19.TabIndex = 231;
            this.label19.Text = "不着事由仕分け２";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(96, 215);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 36);
            this.label17.TabIndex = 230;
            this.label17.Text = "不着事由仕分け１";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DtpDateReceipt
            // 
            this.DtpDateReceipt.Enabled = false;
            this.DtpDateReceipt.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DtpDateReceipt.Location = new System.Drawing.Point(289, 174);
            this.DtpDateReceipt.Name = "DtpDateReceipt";
            this.DtpDateReceipt.Size = new System.Drawing.Size(276, 36);
            this.DtpDateReceipt.TabIndex = 229;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(-1, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1909, 50);
            this.LblTitle.TabIndex = 235;
            this.LblTitle.Text = "QRフィーダー＆ソーター検査画面";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(599, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 36);
            this.label1.TabIndex = 236;
            this.label1.Text = "総数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(599, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 36);
            this.label2.TabIndex = 238;
            this.label2.Text = "OK";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(599, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 36);
            this.label3.TabIndex = 240;
            this.label3.Text = "NG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(809, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 36);
            this.label4.TabIndex = 242;
            this.label4.Text = "件";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(809, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 36);
            this.label5.TabIndex = 243;
            this.label5.Text = "件";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(809, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 36);
            this.label7.TabIndex = 244;
            this.label7.Text = "件";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsvOKHistory
            // 
            this.LsvOKHistory.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsvOKHistory.FullRowSelect = true;
            this.LsvOKHistory.GridLines = true;
            this.LsvOKHistory.HideSelection = false;
            this.LsvOKHistory.Location = new System.Drawing.Point(96, 365);
            this.LsvOKHistory.Name = "LsvOKHistory";
            this.LsvOKHistory.Size = new System.Drawing.Size(830, 300);
            this.LsvOKHistory.TabIndex = 245;
            this.LsvOKHistory.UseCompatibleStateImageBehavior = false;
            // 
            // LsvNGHistory
            // 
            this.LsvNGHistory.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsvNGHistory.FullRowSelect = true;
            this.LsvNGHistory.GridLines = true;
            this.LsvNGHistory.HideSelection = false;
            this.LsvNGHistory.Location = new System.Drawing.Point(941, 365);
            this.LsvNGHistory.Name = "LsvNGHistory";
            this.LsvNGHistory.Size = new System.Drawing.Size(830, 300);
            this.LsvNGHistory.TabIndex = 246;
            this.LsvNGHistory.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(96, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(830, 31);
            this.label9.TabIndex = 247;
            this.label9.Text = "OK履歴";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(941, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(830, 31);
            this.label10.TabIndex = 248;
            this.label10.Text = "NG履歴";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblStatus
            // 
            this.LblStatus.BackColor = System.Drawing.Color.LightGreen;
            this.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblStatus.Font = new System.Drawing.Font("メイリオ", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblStatus.ForeColor = System.Drawing.Color.Black;
            this.LblStatus.Location = new System.Drawing.Point(1186, 62);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(585, 208);
            this.LblStatus.TabIndex = 257;
            this.LblStatus.Text = "検査中";
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblQuantity3
            // 
            this.LblQuantity3.BackColor = System.Drawing.Color.White;
            this.LblQuantity3.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblQuantity3.ForeColor = System.Drawing.Color.Black;
            this.LblQuantity3.Location = new System.Drawing.Point(1133, 866);
            this.LblQuantity3.Name = "LblQuantity3";
            this.LblQuantity3.Size = new System.Drawing.Size(74, 42);
            this.LblQuantity3.TabIndex = 261;
            this.LblQuantity3.Text = "999";
            this.LblQuantity3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBox3
            // 
            this.LblBox3.BackColor = System.Drawing.Color.White;
            this.LblBox3.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBox3.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblBox3.Location = new System.Drawing.Point(957, 746);
            this.LblBox3.Name = "LblBox3";
            this.LblBox3.Size = new System.Drawing.Size(163, 104);
            this.LblBox3.TabIndex = 262;
            this.LblBox3.Text = "999";
            this.LblBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBox1
            // 
            this.LblBox1.BackColor = System.Drawing.Color.White;
            this.LblBox1.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblBox1.Location = new System.Drawing.Point(1515, 746);
            this.LblBox1.Name = "LblBox1";
            this.LblBox1.Size = new System.Drawing.Size(163, 104);
            this.LblBox1.TabIndex = 265;
            this.LblBox1.Text = "999";
            this.LblBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblQuantity1
            // 
            this.LblQuantity1.BackColor = System.Drawing.Color.White;
            this.LblQuantity1.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblQuantity1.ForeColor = System.Drawing.Color.Black;
            this.LblQuantity1.Location = new System.Drawing.Point(1692, 865);
            this.LblQuantity1.Name = "LblQuantity1";
            this.LblQuantity1.Size = new System.Drawing.Size(74, 45);
            this.LblQuantity1.TabIndex = 264;
            this.LblQuantity1.Text = "999";
            this.LblQuantity1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBox4
            // 
            this.LblBox4.BackColor = System.Drawing.Color.White;
            this.LblBox4.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBox4.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblBox4.Location = new System.Drawing.Point(678, 746);
            this.LblBox4.Name = "LblBox4";
            this.LblBox4.Size = new System.Drawing.Size(163, 104);
            this.LblBox4.TabIndex = 268;
            this.LblBox4.Text = "999";
            this.LblBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblQuantity5
            // 
            this.LblQuantity5.BackColor = System.Drawing.Color.White;
            this.LblQuantity5.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblQuantity5.ForeColor = System.Drawing.Color.Black;
            this.LblQuantity5.Location = new System.Drawing.Point(570, 867);
            this.LblQuantity5.Name = "LblQuantity5";
            this.LblQuantity5.Size = new System.Drawing.Size(83, 41);
            this.LblQuantity5.TabIndex = 267;
            this.LblQuantity5.Text = "999";
            this.LblQuantity5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBox2
            // 
            this.LblBox2.BackColor = System.Drawing.Color.White;
            this.LblBox2.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblBox2.Location = new System.Drawing.Point(1236, 746);
            this.LblBox2.Name = "LblBox2";
            this.LblBox2.Size = new System.Drawing.Size(163, 104);
            this.LblBox2.TabIndex = 271;
            this.LblBox2.Text = "999";
            this.LblBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblQuantity2
            // 
            this.LblQuantity2.BackColor = System.Drawing.Color.White;
            this.LblQuantity2.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblQuantity2.ForeColor = System.Drawing.Color.Black;
            this.LblQuantity2.Location = new System.Drawing.Point(1407, 868);
            this.LblQuantity2.Name = "LblQuantity2";
            this.LblQuantity2.Size = new System.Drawing.Size(83, 40);
            this.LblQuantity2.TabIndex = 270;
            this.LblQuantity2.Text = "999";
            this.LblQuantity2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBoxTitle3
            // 
            this.LblBoxTitle3.BackColor = System.Drawing.Color.SeaGreen;
            this.LblBoxTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoxTitle3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBoxTitle3.ForeColor = System.Drawing.Color.White;
            this.LblBoxTitle3.Location = new System.Drawing.Point(933, 708);
            this.LblBoxTitle3.Name = "LblBoxTitle3";
            this.LblBoxTitle3.Size = new System.Drawing.Size(280, 30);
            this.LblBoxTitle3.TabIndex = 272;
            this.LblBoxTitle3.Text = "LblBoxTitle3";
            this.LblBoxTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblBoxTitle1
            // 
            this.LblBoxTitle1.BackColor = System.Drawing.Color.SeaGreen;
            this.LblBoxTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoxTitle1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBoxTitle1.ForeColor = System.Drawing.Color.White;
            this.LblBoxTitle1.Location = new System.Drawing.Point(1491, 708);
            this.LblBoxTitle1.Name = "LblBoxTitle1";
            this.LblBoxTitle1.Size = new System.Drawing.Size(280, 30);
            this.LblBoxTitle1.TabIndex = 273;
            this.LblBoxTitle1.Text = "LblBoxTitle1";
            this.LblBoxTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblBoxTitle2
            // 
            this.LblBoxTitle2.BackColor = System.Drawing.Color.SeaGreen;
            this.LblBoxTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoxTitle2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBoxTitle2.ForeColor = System.Drawing.Color.White;
            this.LblBoxTitle2.Location = new System.Drawing.Point(1212, 708);
            this.LblBoxTitle2.Name = "LblBoxTitle2";
            this.LblBoxTitle2.Size = new System.Drawing.Size(280, 30);
            this.LblBoxTitle2.TabIndex = 275;
            this.LblBoxTitle2.Text = "LblBoxTitle2";
            this.LblBoxTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblBoxTitle4
            // 
            this.LblBoxTitle4.BackColor = System.Drawing.Color.SeaGreen;
            this.LblBoxTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoxTitle4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBoxTitle4.ForeColor = System.Drawing.Color.White;
            this.LblBoxTitle4.Location = new System.Drawing.Point(654, 708);
            this.LblBoxTitle4.Name = "LblBoxTitle4";
            this.LblBoxTitle4.Size = new System.Drawing.Size(280, 30);
            this.LblBoxTitle4.TabIndex = 274;
            this.LblBoxTitle4.Text = "LblBoxTitle4";
            this.LblBoxTitle4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblBoxEject
            // 
            this.LblBoxEject.BackColor = System.Drawing.Color.White;
            this.LblBoxEject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoxEject.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBoxEject.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblBoxEject.Location = new System.Drawing.Point(96, 736);
            this.LblBoxEject.Name = "LblBoxEject";
            this.LblBoxEject.Size = new System.Drawing.Size(280, 220);
            this.LblBoxEject.TabIndex = 276;
            this.LblBoxEject.Text = "999";
            this.LblBoxEject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Orange;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label31.ForeColor = System.Drawing.Color.OrangeRed;
            this.label31.Location = new System.Drawing.Point(96, 707);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(280, 30);
            this.label31.TabIndex = 277;
            this.label31.Text = "BOX リジェクト";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Violet;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(96, 676);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(1675, 32);
            this.label32.TabIndex = 278;
            this.label32.Text = "ソーターポケット";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Violet;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(96, 303);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(1675, 32);
            this.label33.TabIndex = 279;
            this.label33.Text = "QRフィーダー";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDateTime
            // 
            this.LblDateTime.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblDateTime.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblDateTime.ForeColor = System.Drawing.Color.Yellow;
            this.LblDateTime.Location = new System.Drawing.Point(1458, 8);
            this.LblDateTime.Name = "LblDateTime";
            this.LblDateTime.Size = new System.Drawing.Size(436, 35);
            this.LblDateTime.TabIndex = 280;
            this.LblDateTime.Text = "年月日時分秒";
            this.LblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimDateTime
            // 
            this.TimDateTime.Tick += new System.EventHandler(this.TimDateTime_Tick);
            // 
            // LblPocket1
            // 
            this.LblPocket1.BackColor = System.Drawing.Color.White;
            this.LblPocket1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocket1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocket1.ForeColor = System.Drawing.Color.Black;
            this.LblPocket1.Location = new System.Drawing.Point(1491, 916);
            this.LblPocket1.Name = "LblPocket1";
            this.LblPocket1.Size = new System.Drawing.Size(280, 50);
            this.LblPocket1.TabIndex = 281;
            this.LblPocket1.Text = "ポケット１";
            this.LblPocket1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPocket2
            // 
            this.LblPocket2.BackColor = System.Drawing.Color.White;
            this.LblPocket2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocket2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocket2.ForeColor = System.Drawing.Color.Black;
            this.LblPocket2.Location = new System.Drawing.Point(1212, 916);
            this.LblPocket2.Name = "LblPocket2";
            this.LblPocket2.Size = new System.Drawing.Size(280, 50);
            this.LblPocket2.TabIndex = 282;
            this.LblPocket2.Text = "ポケット２";
            this.LblPocket2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPocket4
            // 
            this.LblPocket4.BackColor = System.Drawing.Color.White;
            this.LblPocket4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocket4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocket4.ForeColor = System.Drawing.Color.Black;
            this.LblPocket4.Location = new System.Drawing.Point(654, 916);
            this.LblPocket4.Name = "LblPocket4";
            this.LblPocket4.Size = new System.Drawing.Size(280, 50);
            this.LblPocket4.TabIndex = 284;
            this.LblPocket4.Text = "ポケット４";
            this.LblPocket4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPocket3
            // 
            this.LblPocket3.BackColor = System.Drawing.Color.White;
            this.LblPocket3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocket3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocket3.ForeColor = System.Drawing.Color.Black;
            this.LblPocket3.Location = new System.Drawing.Point(933, 916);
            this.LblPocket3.Name = "LblPocket3";
            this.LblPocket3.Size = new System.Drawing.Size(280, 50);
            this.LblPocket3.TabIndex = 283;
            this.LblPocket3.Text = "ポケット３";
            this.LblPocket3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTotalCount
            // 
            this.LblTotalCount.BackColor = System.Drawing.Color.White;
            this.LblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTotalCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTotalCount.ForeColor = System.Drawing.Color.Black;
            this.LblTotalCount.Location = new System.Drawing.Point(706, 63);
            this.LblTotalCount.Name = "LblTotalCount";
            this.LblTotalCount.Size = new System.Drawing.Size(108, 36);
            this.LblTotalCount.TabIndex = 285;
            this.LblTotalCount.Text = "99,999";
            this.LblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOKCount
            // 
            this.LblOKCount.BackColor = System.Drawing.Color.White;
            this.LblOKCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblOKCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblOKCount.ForeColor = System.Drawing.Color.Black;
            this.LblOKCount.Location = new System.Drawing.Point(706, 104);
            this.LblOKCount.Name = "LblOKCount";
            this.LblOKCount.Size = new System.Drawing.Size(108, 36);
            this.LblOKCount.TabIndex = 286;
            this.LblOKCount.Text = "99,999";
            this.LblOKCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNGCount
            // 
            this.LblNGCount.BackColor = System.Drawing.Color.White;
            this.LblNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNGCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblNGCount.ForeColor = System.Drawing.Color.Black;
            this.LblNGCount.Location = new System.Drawing.Point(706, 148);
            this.LblNGCount.Name = "LblNGCount";
            this.LblNGCount.Size = new System.Drawing.Size(108, 36);
            this.LblNGCount.TabIndex = 287;
            this.LblNGCount.Text = "99,999";
            this.LblNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBoxTitle5
            // 
            this.LblBoxTitle5.BackColor = System.Drawing.Color.SeaGreen;
            this.LblBoxTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoxTitle5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBoxTitle5.ForeColor = System.Drawing.Color.White;
            this.LblBoxTitle5.Location = new System.Drawing.Point(375, 708);
            this.LblBoxTitle5.Name = "LblBoxTitle5";
            this.LblBoxTitle5.Size = new System.Drawing.Size(280, 30);
            this.LblBoxTitle5.TabIndex = 291;
            this.LblBoxTitle5.Text = "LblBoxTitle5";
            this.LblBoxTitle5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblBox5
            // 
            this.LblBox5.BackColor = System.Drawing.Color.White;
            this.LblBox5.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblBox5.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblBox5.Location = new System.Drawing.Point(399, 746);
            this.LblBox5.Name = "LblBox5";
            this.LblBox5.Size = new System.Drawing.Size(163, 104);
            this.LblBox5.TabIndex = 290;
            this.LblBox5.Text = "999";
            this.LblBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblQuantity4
            // 
            this.LblQuantity4.BackColor = System.Drawing.Color.White;
            this.LblQuantity4.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblQuantity4.ForeColor = System.Drawing.Color.Black;
            this.LblQuantity4.Location = new System.Drawing.Point(849, 869);
            this.LblQuantity4.Name = "LblQuantity4";
            this.LblQuantity4.Size = new System.Drawing.Size(83, 40);
            this.LblQuantity4.TabIndex = 289;
            this.LblQuantity4.Text = "999";
            this.LblQuantity4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbNonDeliveryReasonSorting2
            // 
            this.CmbNonDeliveryReasonSorting2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNonDeliveryReasonSorting2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbNonDeliveryReasonSorting2.FormattingEnabled = true;
            this.CmbNonDeliveryReasonSorting2.IntegralHeight = false;
            this.CmbNonDeliveryReasonSorting2.ItemHeight = 28;
            this.CmbNonDeliveryReasonSorting2.Location = new System.Drawing.Point(289, 258);
            this.CmbNonDeliveryReasonSorting2.Name = "CmbNonDeliveryReasonSorting2";
            this.CmbNonDeliveryReasonSorting2.Size = new System.Drawing.Size(276, 36);
            this.CmbNonDeliveryReasonSorting2.TabIndex = 302;
            // 
            // CmbNonDeliveryReasonSorting1
            // 
            this.CmbNonDeliveryReasonSorting1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNonDeliveryReasonSorting1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbNonDeliveryReasonSorting1.FormattingEnabled = true;
            this.CmbNonDeliveryReasonSorting1.IntegralHeight = false;
            this.CmbNonDeliveryReasonSorting1.ItemHeight = 28;
            this.CmbNonDeliveryReasonSorting1.Location = new System.Drawing.Point(289, 216);
            this.CmbNonDeliveryReasonSorting1.Name = "CmbNonDeliveryReasonSorting1";
            this.CmbNonDeliveryReasonSorting1.Size = new System.Drawing.Size(276, 36);
            this.CmbNonDeliveryReasonSorting1.TabIndex = 301;
            // 
            // LblPocket5
            // 
            this.LblPocket5.BackColor = System.Drawing.Color.White;
            this.LblPocket5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocket5.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocket5.ForeColor = System.Drawing.Color.Black;
            this.LblPocket5.Location = new System.Drawing.Point(375, 916);
            this.LblPocket5.Name = "LblPocket5";
            this.LblPocket5.Size = new System.Drawing.Size(280, 50);
            this.LblPocket5.TabIndex = 305;
            this.LblPocket5.Text = "ポケット５";
            this.LblPocket5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSetting
            // 
            this.BtnSetting.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSetting.Image = global::QrSorterInspectionApp.Properties.Resources.setting_small;
            this.BtnSetting.Location = new System.Drawing.Point(946, 189);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(178, 46);
            this.BtnSetting.TabIndex = 306;
            this.BtnSetting.Text = "設定";
            this.BtnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1212, 737);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(280, 180);
            this.pictureBox4.TabIndex = 269;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(654, 737);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(280, 180);
            this.pictureBox3.TabIndex = 266;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::QrSorterInspectionApp.Properties.Resources.sorter_back_thin1;
            this.pictureBox2.Location = new System.Drawing.Point(1491, 737);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(280, 180);
            this.pictureBox2.TabIndex = 263;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::QrSorterInspectionApp.Properties.Resources.sorter_back_thin1;
            this.pictureBox1.Location = new System.Drawing.Point(933, 737);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 180);
            this.pictureBox1.TabIndex = 260;
            this.pictureBox1.TabStop = false;
            // 
            // BtnStopInspection
            // 
            this.BtnStopInspection.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStopInspection.Image = global::QrSorterInspectionApp.Properties.Resources.standing;
            this.BtnStopInspection.Location = new System.Drawing.Point(313, 974);
            this.BtnStopInspection.Name = "BtnStopInspection";
            this.BtnStopInspection.Size = new System.Drawing.Size(205, 50);
            this.BtnStopInspection.TabIndex = 182;
            this.BtnStopInspection.Text = "検査終了";
            this.BtnStopInspection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnStopInspection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStopInspection.UseVisualStyleBackColor = true;
            this.BtnStopInspection.Click += new System.EventHandler(this.BtnStopInspection_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnClose.Image = global::QrSorterInspectionApp.Properties.Resources.back_arrow;
            this.BtnClose.Location = new System.Drawing.Point(1542, 974);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(205, 50);
            this.BtnClose.TabIndex = 181;
            this.BtnClose.Text = "戻る";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnStartInspection
            // 
            this.BtnStartInspection.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStartInspection.Image = global::QrSorterInspectionApp.Properties.Resources.running_icon;
            this.BtnStartInspection.Location = new System.Drawing.Point(102, 974);
            this.BtnStartInspection.Name = "BtnStartInspection";
            this.BtnStartInspection.Size = new System.Drawing.Size(205, 50);
            this.BtnStartInspection.TabIndex = 180;
            this.BtnStartInspection.Text = "検査開始";
            this.BtnStartInspection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnStartInspection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStartInspection.UseVisualStyleBackColor = true;
            this.BtnStartInspection.Click += new System.EventHandler(this.BtnStartInspection_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(375, 737);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(280, 180);
            this.pictureBox5.TabIndex = 288;
            this.pictureBox5.TabStop = false;
            // 
            // LblError
            // 
            this.LblError.BackColor = System.Drawing.Color.LightCoral;
            this.LblError.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError.ForeColor = System.Drawing.Color.Blue;
            this.LblError.Location = new System.Drawing.Point(538, 969);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(970, 62);
            this.LblError.TabIndex = 317;
            this.LblError.Text = "LblError";
            this.LblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblError.Visible = false;
            // 
            // LblSelectedFile
            // 
            this.LblSelectedFile.BackColor = System.Drawing.Color.White;
            this.LblSelectedFile.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblSelectedFile.ForeColor = System.Drawing.Color.Black;
            this.LblSelectedFile.Location = new System.Drawing.Point(97, 129);
            this.LblSelectedFile.Name = "LblSelectedFile";
            this.LblSelectedFile.Size = new System.Drawing.Size(462, 36);
            this.LblSelectedFile.TabIndex = 323;
            this.LblSelectedFile.Text = "LblSelectedFile";
            this.LblSelectedFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnJobSelect
            // 
            this.BtnJobSelect.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnJobSelect.Image = global::QrSorterInspectionApp.Properties.Resources.search_file;
            this.BtnJobSelect.Location = new System.Drawing.Point(96, 62);
            this.BtnJobSelect.Name = "BtnJobSelect";
            this.BtnJobSelect.Size = new System.Drawing.Size(469, 61);
            this.BtnJobSelect.TabIndex = 322;
            this.BtnJobSelect.Text = "JOB選択";
            this.BtnJobSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnJobSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnJobSelect.UseVisualStyleBackColor = true;
            this.BtnJobSelect.Click += new System.EventHandler(this.BtnJobSelect_Click);
            // 
            // LblGrpInfo5
            // 
            this.LblGrpInfo5.BackColor = System.Drawing.Color.Moccasin;
            this.LblGrpInfo5.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblGrpInfo5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGrpInfo5.Location = new System.Drawing.Point(375, 943);
            this.LblGrpInfo5.Name = "LblGrpInfo5";
            this.LblGrpInfo5.Size = new System.Drawing.Size(280, 35);
            this.LblGrpInfo5.TabIndex = 324;
            this.LblGrpInfo5.Text = "LblGrpInfo5";
            this.LblGrpInfo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrpInfo5.Visible = false;
            // 
            // LblGrpInfo4
            // 
            this.LblGrpInfo4.BackColor = System.Drawing.Color.Moccasin;
            this.LblGrpInfo4.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblGrpInfo4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGrpInfo4.Location = new System.Drawing.Point(655, 943);
            this.LblGrpInfo4.Name = "LblGrpInfo4";
            this.LblGrpInfo4.Size = new System.Drawing.Size(280, 35);
            this.LblGrpInfo4.TabIndex = 325;
            this.LblGrpInfo4.Text = "LblGrpInfo4";
            this.LblGrpInfo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrpInfo4.Visible = false;
            // 
            // LblGrpInfo3
            // 
            this.LblGrpInfo3.BackColor = System.Drawing.Color.Moccasin;
            this.LblGrpInfo3.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblGrpInfo3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGrpInfo3.Location = new System.Drawing.Point(934, 943);
            this.LblGrpInfo3.Name = "LblGrpInfo3";
            this.LblGrpInfo3.Size = new System.Drawing.Size(280, 35);
            this.LblGrpInfo3.TabIndex = 326;
            this.LblGrpInfo3.Text = "LblGrpInfo3";
            this.LblGrpInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrpInfo3.Visible = false;
            // 
            // LblGrpInfo2
            // 
            this.LblGrpInfo2.BackColor = System.Drawing.Color.Moccasin;
            this.LblGrpInfo2.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblGrpInfo2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGrpInfo2.Location = new System.Drawing.Point(1213, 943);
            this.LblGrpInfo2.Name = "LblGrpInfo2";
            this.LblGrpInfo2.Size = new System.Drawing.Size(280, 35);
            this.LblGrpInfo2.TabIndex = 327;
            this.LblGrpInfo2.Text = "LblGrpInfo2";
            this.LblGrpInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrpInfo2.Visible = false;
            // 
            // LblGrpInfo1
            // 
            this.LblGrpInfo1.BackColor = System.Drawing.Color.Moccasin;
            this.LblGrpInfo1.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblGrpInfo1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGrpInfo1.Location = new System.Drawing.Point(1492, 943);
            this.LblGrpInfo1.Name = "LblGrpInfo1";
            this.LblGrpInfo1.Size = new System.Drawing.Size(280, 35);
            this.LblGrpInfo1.TabIndex = 328;
            this.LblGrpInfo1.Text = "LblGrpInfo1";
            this.LblGrpInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblGrpInfo1.Visible = false;
            // 
            // LblFdrInfo1
            // 
            this.LblFdrInfo1.BackColor = System.Drawing.Color.Moccasin;
            this.LblFdrInfo1.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblFdrInfo1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblFdrInfo1.Location = new System.Drawing.Point(1492, 738);
            this.LblFdrInfo1.Name = "LblFdrInfo1";
            this.LblFdrInfo1.Size = new System.Drawing.Size(280, 21);
            this.LblFdrInfo1.TabIndex = 333;
            this.LblFdrInfo1.Text = "LblFdrInfo1";
            this.LblFdrInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFdrInfo1.Visible = false;
            // 
            // LblFdrInfo2
            // 
            this.LblFdrInfo2.BackColor = System.Drawing.Color.Moccasin;
            this.LblFdrInfo2.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblFdrInfo2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblFdrInfo2.Location = new System.Drawing.Point(1213, 738);
            this.LblFdrInfo2.Name = "LblFdrInfo2";
            this.LblFdrInfo2.Size = new System.Drawing.Size(280, 21);
            this.LblFdrInfo2.TabIndex = 332;
            this.LblFdrInfo2.Text = "LblFdrInfo2";
            this.LblFdrInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFdrInfo2.Visible = false;
            // 
            // LblFdrInfo3
            // 
            this.LblFdrInfo3.BackColor = System.Drawing.Color.Moccasin;
            this.LblFdrInfo3.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblFdrInfo3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblFdrInfo3.Location = new System.Drawing.Point(934, 738);
            this.LblFdrInfo3.Name = "LblFdrInfo3";
            this.LblFdrInfo3.Size = new System.Drawing.Size(280, 21);
            this.LblFdrInfo3.TabIndex = 331;
            this.LblFdrInfo3.Text = "LblFdrInfo3";
            this.LblFdrInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFdrInfo3.Visible = false;
            // 
            // LblFdrInfo4
            // 
            this.LblFdrInfo4.BackColor = System.Drawing.Color.Moccasin;
            this.LblFdrInfo4.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblFdrInfo4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblFdrInfo4.Location = new System.Drawing.Point(655, 738);
            this.LblFdrInfo4.Name = "LblFdrInfo4";
            this.LblFdrInfo4.Size = new System.Drawing.Size(280, 21);
            this.LblFdrInfo4.TabIndex = 330;
            this.LblFdrInfo4.Text = "LblFdrInfo4";
            this.LblFdrInfo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFdrInfo4.Visible = false;
            // 
            // LblFdrInfo5
            // 
            this.LblFdrInfo5.BackColor = System.Drawing.Color.Moccasin;
            this.LblFdrInfo5.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblFdrInfo5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblFdrInfo5.Location = new System.Drawing.Point(375, 738);
            this.LblFdrInfo5.Name = "LblFdrInfo5";
            this.LblFdrInfo5.Size = new System.Drawing.Size(280, 21);
            this.LblFdrInfo5.TabIndex = 329;
            this.LblFdrInfo5.Text = "LblFdrInfo5";
            this.LblFdrInfo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFdrInfo5.Visible = false;
            // 
            // LblPocketEject
            // 
            this.LblPocketEject.BackColor = System.Drawing.Color.White;
            this.LblPocketEject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocketEject.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocketEject.ForeColor = System.Drawing.Color.Black;
            this.LblPocketEject.Location = new System.Drawing.Point(96, 916);
            this.LblPocketEject.Name = "LblPocketEject";
            this.LblPocketEject.Size = new System.Drawing.Size(280, 50);
            this.LblPocketEject.TabIndex = 334;
            this.LblPocketEject.Text = "ポケットリジェクト";
            this.LblPocketEject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblQrReadData);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(597, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 64);
            this.groupBox1.TabIndex = 335;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR読取りデータ";
            // 
            // LblQrReadData
            // 
            this.LblQrReadData.BackColor = System.Drawing.Color.White;
            this.LblQrReadData.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblQrReadData.ForeColor = System.Drawing.Color.Black;
            this.LblQrReadData.Location = new System.Drawing.Point(8, 20);
            this.LblQrReadData.Name = "LblQrReadData";
            this.LblQrReadData.Size = new System.Drawing.Size(560, 35);
            this.LblQrReadData.TabIndex = 324;
            this.LblQrReadData.Text = "123456789*123456789*123456789*123456789*1234567";
            this.LblQrReadData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDuplicateCheck
            // 
            this.LblDuplicateCheck.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblDuplicateCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblDuplicateCheck.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblDuplicateCheck.ForeColor = System.Drawing.Color.Black;
            this.LblDuplicateCheck.Location = new System.Drawing.Point(599, 191);
            this.LblDuplicateCheck.Name = "LblDuplicateCheck";
            this.LblDuplicateCheck.Size = new System.Drawing.Size(215, 30);
            this.LblDuplicateCheck.TabIndex = 336;
            this.LblDuplicateCheck.Text = "LblDuplicateCheck";
            this.LblDuplicateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LstSettingInfomation
            // 
            this.LstSettingInfomation.BackColor = System.Drawing.SystemColors.Control;
            this.LstSettingInfomation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstSettingInfomation.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstSettingInfomation.FormattingEnabled = true;
            this.LstSettingInfomation.ItemHeight = 20;
            this.LstSettingInfomation.Location = new System.Drawing.Point(949, 51);
            this.LstSettingInfomation.Name = "LstSettingInfomation";
            this.LstSettingInfomation.Size = new System.Drawing.Size(231, 140);
            this.LstSettingInfomation.TabIndex = 337;
            // 
            // QrSorterInspectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.BtnSetting);
            this.Controls.Add(this.LstSettingInfomation);
            this.Controls.Add(this.LblDuplicateCheck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblPocketEject);
            this.Controls.Add(this.LblFdrInfo1);
            this.Controls.Add(this.LblFdrInfo2);
            this.Controls.Add(this.LblFdrInfo3);
            this.Controls.Add(this.LblFdrInfo4);
            this.Controls.Add(this.LblFdrInfo5);
            this.Controls.Add(this.LblGrpInfo1);
            this.Controls.Add(this.LblGrpInfo2);
            this.Controls.Add(this.LblGrpInfo3);
            this.Controls.Add(this.LblGrpInfo4);
            this.Controls.Add(this.LblGrpInfo5);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.LblSelectedFile);
            this.Controls.Add(this.BtnJobSelect);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblPocket5);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.CmbNonDeliveryReasonSorting2);
            this.Controls.Add(this.CmbNonDeliveryReasonSorting1);
            this.Controls.Add(this.LblBoxTitle5);
            this.Controls.Add(this.LblBox5);
            this.Controls.Add(this.LblQuantity4);
            this.Controls.Add(this.LblNGCount);
            this.Controls.Add(this.LblOKCount);
            this.Controls.Add(this.LblTotalCount);
            this.Controls.Add(this.LblPocket4);
            this.Controls.Add(this.LblPocket3);
            this.Controls.Add(this.LblPocket2);
            this.Controls.Add(this.LblPocket1);
            this.Controls.Add(this.LblDateTime);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.LblBoxEject);
            this.Controls.Add(this.LblBoxTitle2);
            this.Controls.Add(this.LblBoxTitle4);
            this.Controls.Add(this.LblBoxTitle1);
            this.Controls.Add(this.LblBoxTitle3);
            this.Controls.Add(this.LsvOKHistory);
            this.Controls.Add(this.LsvNGHistory);
            this.Controls.Add(this.LblBox2);
            this.Controls.Add(this.LblQuantity2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.LblBox4);
            this.Controls.Add(this.LblQuantity5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.LblBox1);
            this.Controls.Add(this.LblQuantity1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LblBox3);
            this.Controls.Add(this.LblQuantity3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DtpDateReceipt);
            this.Controls.Add(this.BtnStopInspection);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnStartInspection);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QrSorterInspectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QRフィーダー＆ソーター検査画面";
            this.Load += new System.EventHandler(this.QrSorterInspectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Button BtnStartInspection;
        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Button BtnStopInspection;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker DtpDateReceipt;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView LsvOKHistory;
        private System.Windows.Forms.ListView LsvNGHistory;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label LblQuantity3;
        internal System.Windows.Forms.Label LblBox3;
        internal System.Windows.Forms.Label LblBox1;
        internal System.Windows.Forms.Label LblQuantity1;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Label LblBox4;
        internal System.Windows.Forms.Label LblQuantity5;
        private System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.Label LblBox2;
        internal System.Windows.Forms.Label LblQuantity2;
        private System.Windows.Forms.PictureBox pictureBox4;
        internal System.Windows.Forms.Label LblBoxTitle3;
        internal System.Windows.Forms.Label LblBoxTitle1;
        internal System.Windows.Forms.Label LblBoxTitle2;
        internal System.Windows.Forms.Label LblBoxTitle4;
        internal System.Windows.Forms.Label LblBoxEject;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label label32;
        internal System.Windows.Forms.Label label33;
        internal System.Windows.Forms.Label LblDateTime;
        internal System.Windows.Forms.Timer TimDateTime;
        internal System.Windows.Forms.Label LblPocket1;
        internal System.Windows.Forms.Label LblPocket2;
        internal System.Windows.Forms.Label LblPocket4;
        internal System.Windows.Forms.Label LblPocket3;
        internal System.Windows.Forms.Label LblTotalCount;
        internal System.Windows.Forms.Label LblOKCount;
        internal System.Windows.Forms.Label LblNGCount;
        internal System.Windows.Forms.Label LblBoxTitle5;
        internal System.Windows.Forms.Label LblBox5;
        internal System.Windows.Forms.Label LblQuantity4;
        private System.Windows.Forms.PictureBox pictureBox5;
        internal System.Windows.Forms.ComboBox CmbNonDeliveryReasonSorting2;
        internal System.Windows.Forms.ComboBox CmbNonDeliveryReasonSorting1;
        internal System.Windows.Forms.Label LblPocket5;
        internal System.Windows.Forms.Button BtnSetting;
        internal System.IO.Ports.SerialPort SerialPortQr;
        internal System.Windows.Forms.Label LblError;
        internal System.Windows.Forms.Label LblSelectedFile;
        internal System.Windows.Forms.Button BtnJobSelect;
        internal System.Windows.Forms.Label LblGrpInfo5;
        internal System.Windows.Forms.Label LblGrpInfo4;
        internal System.Windows.Forms.Label LblGrpInfo3;
        internal System.Windows.Forms.Label LblGrpInfo2;
        internal System.Windows.Forms.Label LblGrpInfo1;
        internal System.Windows.Forms.Label LblFdrInfo1;
        internal System.Windows.Forms.Label LblFdrInfo2;
        internal System.Windows.Forms.Label LblFdrInfo3;
        internal System.Windows.Forms.Label LblFdrInfo4;
        internal System.Windows.Forms.Label LblFdrInfo5;
        internal System.Windows.Forms.Label LblPocketEject;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label LblQrReadData;
        internal System.Windows.Forms.Label LblDuplicateCheck;
        private System.Windows.Forms.ListBox LstSettingInfomation;
    }
}