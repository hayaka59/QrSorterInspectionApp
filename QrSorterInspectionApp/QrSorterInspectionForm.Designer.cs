namespace QrSorterInspectionApp
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
            this.label6 = new System.Windows.Forms.Label();
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
            this.CmbJobName = new System.Windows.Forms.ComboBox();
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
            this.label15 = new System.Windows.Forms.Label();
            this.TxtFileType = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtSeqNum = new System.Windows.Forms.TextBox();
            this.SerialPortQr = new System.IO.Ports.SerialPort(this.components);
            this.LblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
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
            this.label8.Location = new System.Drawing.Point(95, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 36);
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
            this.label19.Location = new System.Drawing.Point(96, 236);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(170, 36);
            this.label19.TabIndex = 231;
            this.label19.Text = "仕分け②";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(95, 193);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(170, 36);
            this.label17.TabIndex = 230;
            this.label17.Text = "仕分け①";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DtpDateReceipt
            // 
            this.DtpDateReceipt.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DtpDateReceipt.Location = new System.Drawing.Point(264, 107);
            this.DtpDateReceipt.Name = "DtpDateReceipt";
            this.DtpDateReceipt.Size = new System.Drawing.Size(299, 36);
            this.DtpDateReceipt.TabIndex = 229;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(95, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 36);
            this.label6.TabIndex = 227;
            this.label6.Text = "JOB名";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label1.Location = new System.Drawing.Point(603, 66);
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
            this.label2.Location = new System.Drawing.Point(603, 107);
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
            this.label3.Location = new System.Drawing.Point(603, 151);
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
            this.label4.Location = new System.Drawing.Point(813, 66);
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
            this.label5.Location = new System.Drawing.Point(813, 107);
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
            this.label7.Location = new System.Drawing.Point(813, 151);
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
            this.LsvOKHistory.Location = new System.Drawing.Point(96, 355);
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
            this.LsvNGHistory.Location = new System.Drawing.Point(941, 355);
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
            this.label9.Location = new System.Drawing.Point(96, 324);
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
            this.label10.Location = new System.Drawing.Point(941, 324);
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
            this.LblStatus.Location = new System.Drawing.Point(1186, 65);
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
            this.LblQuantity3.Location = new System.Drawing.Point(1133, 863);
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
            this.LblBox3.Location = new System.Drawing.Point(957, 743);
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
            this.LblBox1.Location = new System.Drawing.Point(1515, 743);
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
            this.LblQuantity1.Location = new System.Drawing.Point(1692, 862);
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
            this.LblBox4.Location = new System.Drawing.Point(678, 743);
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
            this.LblQuantity5.Location = new System.Drawing.Point(570, 864);
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
            this.LblBox2.Location = new System.Drawing.Point(1236, 743);
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
            this.LblQuantity2.Location = new System.Drawing.Point(1407, 865);
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
            this.LblBoxTitle3.Location = new System.Drawing.Point(933, 705);
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
            this.LblBoxTitle1.Location = new System.Drawing.Point(1491, 705);
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
            this.LblBoxTitle2.Location = new System.Drawing.Point(1212, 705);
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
            this.LblBoxTitle4.Location = new System.Drawing.Point(654, 705);
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
            this.LblBoxEject.Location = new System.Drawing.Point(96, 733);
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
            this.label31.Location = new System.Drawing.Point(96, 704);
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
            this.label32.Location = new System.Drawing.Point(96, 673);
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
            this.label33.Location = new System.Drawing.Point(96, 293);
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
            this.LblPocket1.Location = new System.Drawing.Point(1491, 913);
            this.LblPocket1.Name = "LblPocket1";
            this.LblPocket1.Size = new System.Drawing.Size(280, 40);
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
            this.LblPocket2.Location = new System.Drawing.Point(1212, 913);
            this.LblPocket2.Name = "LblPocket2";
            this.LblPocket2.Size = new System.Drawing.Size(280, 40);
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
            this.LblPocket4.Location = new System.Drawing.Point(654, 913);
            this.LblPocket4.Name = "LblPocket4";
            this.LblPocket4.Size = new System.Drawing.Size(280, 40);
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
            this.LblPocket3.Location = new System.Drawing.Point(933, 913);
            this.LblPocket3.Name = "LblPocket3";
            this.LblPocket3.Size = new System.Drawing.Size(280, 40);
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
            this.LblTotalCount.Location = new System.Drawing.Point(710, 66);
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
            this.LblOKCount.Location = new System.Drawing.Point(710, 107);
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
            this.LblNGCount.Location = new System.Drawing.Point(710, 151);
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
            this.LblBoxTitle5.Location = new System.Drawing.Point(375, 705);
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
            this.LblBox5.Location = new System.Drawing.Point(399, 743);
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
            this.LblQuantity4.Location = new System.Drawing.Point(849, 866);
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
            this.CmbNonDeliveryReasonSorting2.Location = new System.Drawing.Point(265, 237);
            this.CmbNonDeliveryReasonSorting2.Name = "CmbNonDeliveryReasonSorting2";
            this.CmbNonDeliveryReasonSorting2.Size = new System.Drawing.Size(299, 36);
            this.CmbNonDeliveryReasonSorting2.TabIndex = 302;
            // 
            // CmbNonDeliveryReasonSorting1
            // 
            this.CmbNonDeliveryReasonSorting1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNonDeliveryReasonSorting1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbNonDeliveryReasonSorting1.FormattingEnabled = true;
            this.CmbNonDeliveryReasonSorting1.IntegralHeight = false;
            this.CmbNonDeliveryReasonSorting1.ItemHeight = 28;
            this.CmbNonDeliveryReasonSorting1.Location = new System.Drawing.Point(265, 193);
            this.CmbNonDeliveryReasonSorting1.Name = "CmbNonDeliveryReasonSorting1";
            this.CmbNonDeliveryReasonSorting1.Size = new System.Drawing.Size(299, 36);
            this.CmbNonDeliveryReasonSorting1.TabIndex = 301;
            // 
            // CmbJobName
            // 
            this.CmbJobName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbJobName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbJobName.FormattingEnabled = true;
            this.CmbJobName.IntegralHeight = false;
            this.CmbJobName.ItemHeight = 28;
            this.CmbJobName.Location = new System.Drawing.Point(265, 66);
            this.CmbJobName.Name = "CmbJobName";
            this.CmbJobName.Size = new System.Drawing.Size(299, 36);
            this.CmbJobName.TabIndex = 303;
            this.CmbJobName.SelectedIndexChanged += new System.EventHandler(this.CmbJobName_SelectedIndexChanged);
            // 
            // LblPocket5
            // 
            this.LblPocket5.BackColor = System.Drawing.Color.White;
            this.LblPocket5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPocket5.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblPocket5.ForeColor = System.Drawing.Color.Black;
            this.LblPocket5.Location = new System.Drawing.Point(375, 913);
            this.LblPocket5.Name = "LblPocket5";
            this.LblPocket5.Size = new System.Drawing.Size(280, 40);
            this.LblPocket5.TabIndex = 305;
            this.LblPocket5.Text = "ポケット５";
            this.LblPocket5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSetting
            // 
            this.BtnSetting.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSetting.Image = global::QrSorterInspectionApp.Properties.Resources.setting_small;
            this.BtnSetting.Location = new System.Drawing.Point(603, 237);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(215, 42);
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
            this.pictureBox4.Location = new System.Drawing.Point(1212, 734);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(280, 180);
            this.pictureBox4.TabIndex = 269;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(654, 734);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(280, 180);
            this.pictureBox3.TabIndex = 266;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::QrSorterInspectionApp.Properties.Resources.sorter_back_thin1;
            this.pictureBox2.Location = new System.Drawing.Point(1491, 734);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(280, 180);
            this.pictureBox2.TabIndex = 263;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::QrSorterInspectionApp.Properties.Resources.sorter_back_thin1;
            this.pictureBox1.Location = new System.Drawing.Point(933, 734);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 180);
            this.pictureBox1.TabIndex = 260;
            this.pictureBox1.TabStop = false;
            // 
            // BtnStopInspection
            // 
            this.BtnStopInspection.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStopInspection.Image = global::QrSorterInspectionApp.Properties.Resources.standing;
            this.BtnStopInspection.Location = new System.Drawing.Point(307, 969);
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
            this.BtnClose.Location = new System.Drawing.Point(518, 969);
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
            this.BtnStartInspection.Location = new System.Drawing.Point(96, 969);
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
            this.pictureBox5.Location = new System.Drawing.Point(375, 734);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(280, 180);
            this.pictureBox5.TabIndex = 288;
            this.pictureBox5.TabStop = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(95, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 36);
            this.label15.TabIndex = 307;
            this.label15.Text = "ファイル区分";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtFileType
            // 
            this.TxtFileType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFileType.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtFileType.Location = new System.Drawing.Point(264, 150);
            this.TxtFileType.Name = "TxtFileType";
            this.TxtFileType.Size = new System.Drawing.Size(300, 36);
            this.TxtFileType.TabIndex = 314;
            this.TxtFileType.Text = "TxtFileType";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(603, 194);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 36);
            this.label16.TabIndex = 315;
            this.label16.Text = "連番";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtSeqNum
            // 
            this.TxtSeqNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSeqNum.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtSeqNum.Location = new System.Drawing.Point(710, 194);
            this.TxtSeqNum.Name = "TxtSeqNum";
            this.TxtSeqNum.Size = new System.Drawing.Size(108, 36);
            this.TxtSeqNum.TabIndex = 316;
            this.TxtSeqNum.Text = "TxtSeqNum";
            this.TxtSeqNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblError
            // 
            this.LblError.BackColor = System.Drawing.Color.LightCoral;
            this.LblError.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError.ForeColor = System.Drawing.Color.Blue;
            this.LblError.Location = new System.Drawing.Point(766, 966);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(970, 62);
            this.LblError.TabIndex = 317;
            this.LblError.Text = "LblError";
            this.LblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblError.Visible = false;
            // 
            // QrSorterInspectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.TxtSeqNum);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TxtFileType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.BtnSetting);
            this.Controls.Add(this.LblPocket5);
            this.Controls.Add(this.CmbJobName);
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
            this.Controls.Add(this.label17);
            this.Controls.Add(this.DtpDateReceipt);
            this.Controls.Add(this.label6);
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        internal System.Windows.Forms.Label label6;
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
        internal System.Windows.Forms.ComboBox CmbJobName;
        internal System.Windows.Forms.Label LblPocket5;
        internal System.Windows.Forms.Button BtnSetting;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtFileType;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtSeqNum;
        internal System.IO.Ports.SerialPort SerialPortQr;
        internal System.Windows.Forms.Label LblError;
    }
}