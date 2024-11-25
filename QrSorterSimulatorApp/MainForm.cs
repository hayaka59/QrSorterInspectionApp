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
                CommonModule.OutPutLogFile("【" + "検査アプリシミュレータ" + "】を起動しました。");
                CommonModule.OutPutLogFile("■検査アプリバージョン「" + PubConstClass.DEF_VERSION + "」");


                PubConstClass.pblComPort = "COM4";
                PubConstClass.pblComSpeed = "3";
                PubConstClass.pblComParityVar = "1";
                PubConstClass.pblComIsParity = "1";
                PubConstClass.pblComDataLength = "0";
                PubConstClass.pblComStopBit = "0";


                #region シリアルポートの設定
                // データ受信イベントの設定
                SerialPortQr.DataReceived += new SerialDataReceivedEventHandler(SerialPortQr_DataReceived);
                // シリアルポート名の設定
                SerialPortQr.PortName = PubConstClass.pblComPort;
                // シリアルポートの通信速度指定
                switch (PubConstClass.pblComSpeed)
                {
                    case "0":
                        {
                            SerialPortQr.BaudRate = 4800;
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.BaudRate = 9600;
                            break;
                        }

                    case "2":
                        {
                            SerialPortQr.BaudRate = 19200;
                            break;
                        }

                    case "3":
                        {
                            SerialPortQr.BaudRate = 38400;
                            break;
                        }

                    case "4":
                        {
                            SerialPortQr.BaudRate = 57600;
                            break;
                        }

                    case "5":
                        {
                            SerialPortQr.BaudRate = 115200;
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
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.Parity = Parity.Even;
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
                    SerialPortQr.Parity = Parity.None;
                // シリアルポートのビット数指定
                switch (PubConstClass.pblComDataLength)
                {
                    case "0":
                        {
                            SerialPortQr.DataBits = 8;
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.DataBits = 7;
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
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.StopBits = StopBits.Two;
                            break;
                        }

                    default:
                        {
                            SerialPortQr.StopBits = StopBits.One;
                            break;
                        }
                }
                #endregion

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

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                //CommonModule.OutPutLogFile("ログイン画面からQRソータ検査アプリの終了");
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
                //data = SerialPortQr.ReadTo(ControlChars.Cr.ToString());
                data = SerialPortQr.ReadTo("\r");

                //if (data.IndexOf("?") > 0)
                //{
                //    CommonModule.OutPutLogFile("■受信（パリティエラー）：" + data.ToString() + "<CR>");
                //    BeginInvoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), "パリティエラー：" + "data.ToString" + ControlChars.Cr);
                //}

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
                    CommonModule.OutPutLogFile("■不正データ受信：" + data.Replace("\r", "<CR>"));
                    return;
                }

                LsbRecvBox.Items.Add(data);
                //DisplaySeisanLogData(data);
            }
            catch (Exception ex)
            {
                strMessage = "【RcvDataToTextBox】" + ex.Message;
                CommonModule.OutPutLogFile(strMessage);
                MessageBox.Show(strMessage, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int intSesanCounter = 0;

        private void DisplaySeisanLogData(string sData)
        {
            string[] col = new string[12];
            ListViewItem itm1;
            ListViewItem itm2;
            string[] strArray;

            try
            {
                intSesanCounter += 1;
                // No.
                col[0] = intSesanCounter.ToString("000000");

                strArray = sData.Split(',');
                // 日時
                col[1] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                // QRコード
                col[2] = strArray[0];
                // トレイ
                col[3] = strArray[1];
                // 備考
                col[4] = strArray[2];

                //// データの表示
                //itm1 = new ListViewItem(col);
                //LsvOKHistory.Items.Add(itm1);
                //LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].UseItemStyleForSubItems = false;
                //LsvOKHistory.Select();
                //LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].EnsureVisible();

                //itm2 = new ListViewItem(col);
                //LsvNGHistory.Items.Add(itm2);
                //LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].UseItemStyleForSubItems = false;
                //LsvNGHistory.Select();
                //LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].EnsureVisible();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplaySeisanLogData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonModule.OutPutLogFile("【DisplaySeisanLogData】" + ex.Message);
            }
        }

        private void BtnSendTestData_Click(object sender, EventArgs e)
        {
            try
            {
                string sData = "1234567890,abcedfg,ABCDEFG,hijklmn";
                // 
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(sData + "\r");
                SerialPortQr.Write(dat, 0, dat.GetLength(0));
                LsbSendBox.Items.Add(sData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSendTestData_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
