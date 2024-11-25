using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterSimulatorApp
{
    public partial class MainForm : Form
    {
        private delegate void Delegate_RcvDataToTextBox(string data);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // バージョン表示
                LblVersion.Text = PubConstClass.DEF_VERSION;
                PubConstClass.objSyncHist = new object();
                CommonModule.OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓");
                CommonModule.OutPutLogFile("【" + "シミュレータ" + "】を起動しました。");
                CommonModule.OutPutLogFile("■シミュレータ★バージョン「" + PubConstClass.DEF_VERSION + "」");

                CommonModule.ReadSystemDefinition();
                String sTitle = "";
                #region シリアルポートの設定
                // データ受信イベントの設定
                SerialPortQr.DataReceived += new SerialDataReceivedEventHandler(SerialPortQr_DataReceived);
                // シリアルポート名の設定
                SerialPortQr.PortName = PubConstClass.pblComPort;
                sTitle += PubConstClass.pblComPort + "／";
                // シリアルポートの通信速度指定
                switch (PubConstClass.pblComSpeed)
                {
                    case "0":
                        {
                            SerialPortQr.BaudRate = 4800;
                            sTitle += "4800bps／";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.BaudRate = 9600;
                            sTitle += "9600bps／";
                            break;
                        }

                    case "2":
                        {
                            SerialPortQr.BaudRate = 19200;
                            sTitle += "19200bps／";
                            break;
                        }

                    case "3":
                        {
                            SerialPortQr.BaudRate = 38400;
                            sTitle += "38400bps／";
                            break;
                        }

                    case "4":
                        {
                            SerialPortQr.BaudRate = 57600;
                            sTitle += "57600bps／";
                            break;
                        }

                    case "5":
                        {
                            SerialPortQr.BaudRate = 115200;
                            sTitle += "115200bps／";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.BaudRate = 38400;
                            break;
                        }
                }
                // シリアルポートのパリティ指定
                switch (PubConstClass.pblComParityVar)
                {
                    case "0":
                        {
                            SerialPortQr.Parity = Parity.Odd;
                            sTitle += "奇数／";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.Parity = Parity.Even;
                            sTitle += "偶数／";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.Parity = Parity.Even;
                            break;
                        }
                }
                // シリアルポートのパリティ有無
                if (PubConstClass.pblComIsParity == "0")
                {
                    SerialPortQr.Parity = Parity.None;
                    sTitle += "パリティ無し／";
                }                    
                // シリアルポートのビット数指定
                switch (PubConstClass.pblComDataLength)
                {
                    case "0":
                        {
                            SerialPortQr.DataBits = 8;
                            sTitle += "8ビット／";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.DataBits = 7;
                            sTitle += "7ビット／";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.DataBits = 8;
                            break;
                        }
                }
                // シリアルポートのストップビット指定
                switch (PubConstClass.pblComStopBit)
                {
                    case "0":
                        {
                            SerialPortQr.StopBits = StopBits.One;
                            sTitle += "ストップビット１ ］";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.StopBits = StopBits.Two;
                            sTitle += "ストップビット２ ］";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.StopBits = StopBits.One;
                            break;
                        }
                }
                #endregion

                //this.Text = "【メインメニュー画面】 ［ " + sTitle;
                PubConstClass.pblMainFormTitle = "【メインメニュー画面】 ［ " + sTitle;

                CmbJudge.Items.Clear();
                CmbJudge.Items.Add("OK");
                CmbJudge.Items.Add("NG");
                CmbJudge.SelectedIndex = 0;

                CmbErrorCode.Items.Clear();
                CmbErrorCode.Items.Add("000");
                CmbErrorCode.Items.Add("100");
                CmbErrorCode.Items.Add("200");
                CmbErrorCode.Items.Add("300");
                CmbErrorCode.SelectedIndex = 0;

                CmbTray.Items.Clear();
                CmbTray.Items.Add("1");
                CmbTray.Items.Add("2");
                CmbTray.Items.Add("3");
                CmbTray.Items.Add("4");
                CmbTray.Items.Add("5");
                CmbTray.SelectedIndex = 0;

                // シリアルポートのオープン
                SerialPortQr.Open();
                LblError.Visible = false;

            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
                LblError.Visible = true;
                MessageBox.Show(ex.Message, "【MainForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「終了」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("シミュレーターの終了");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// データ受信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void SerialPortQr_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data;
            object[] args = new object[1];

            data = "";

            try
            {
                // シリアルポートをオープンしていない場合、処理を行わない。
                if (SerialPortQr.IsOpen == false)
                    return;
                // <CR>まで読み込む
                data = SerialPortQr.ReadTo("\r");

                // 受信データの格納
                BeginInvoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), data.ToString() + "\r");
            }
            catch (TimeoutException)
            {
                // ディスカードするデータ
                CommonModule.OutPutLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" + data);
            }
            catch (Exception ex)
            {
                CommonModule.OutPutLogFile("【SerialPortQr_DataReceived】" + ex.Message);
            }
        }

        /// <summary>
        /// 受信データによる各コマンド処理
        /// </summary>
        /// <param name="data">受信した文字列</param>
        /// <remarks></remarks>
        private void RcvDataToTextBox(string data)
        {
            string strMessage;

            try
            {
                CommonModule.OutPutLogFile("受信データ：" + data.Replace("\r", "<CR>"));

                if (data.Length < 9)
                {
                    //CommonModule.OutPutLogFile("■不正データ受信：" + data.Replace("\r", "<CR>"));
                    //return;
                }

                LsbRecvBox.Items.Add(data);
            }
            catch (Exception ex)
            {
                strMessage = "【RcvDataToTextBox】" + ex.Message;
                CommonModule.OutPutLogFile(strMessage);
                MessageBox.Show(strMessage, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「テストデータ送信」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendTestData_Click(object sender, EventArgs e)
        {
            try
            {
                string sData = TxtPropertyId.Text.Trim();
                sData += "1";
                sData += dtTimPickPostalDate.Value.ToString("yyyyMMdd");
                sData += TxtUniqueKey.Text.Replace("_"," ") + ",";

                sData += CmbJudge.Text + ",";
                sData += CmbErrorCode.Text + ",";
                sData += CmbTray.Text + ",";

                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(sData + "\r");
                SerialPortQr.Write(dat, 0, dat.GetLength(0));
                LsbSendBox.Items.Add(sData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSendTestData_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「設定」アイコン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMaintenance_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("「設定」アイコンクリック");
                MaintenanceForm form = new MaintenanceForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnMaintenance_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// メインフォームがアクティブになった時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            try
            {
                this.Text = PubConstClass.pblMainFormTitle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MainForm_Activated】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAutoSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (TimSendData.Enabled)
                {
                    TimSendData.Enabled = false;
                }
                else
                {
                    TimSendData.Interval = 300;
                    TimSendData.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnAutoSend_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimSendData_Tick(object sender, EventArgs e)
        {
            BtnSendTestData.PerformClick();
        }
    }
}
