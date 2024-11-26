using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterInspectionApp
{
    public partial class QrSorterInspectionForm : Form
    {
        private delegate void Delegate_RcvDataToTextBox(string data);

        public QrSorterInspectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QrSorterInspectionForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("QRソーター検査画面を表示しました");

                #region OK履歴のヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvOKHistory.View = View.Details;                
                ColumnHeader colOK1 = new ColumnHeader();
                ColumnHeader colOK2 = new ColumnHeader();
                ColumnHeader colOK3 = new ColumnHeader();
                ColumnHeader colOK4 = new ColumnHeader();
                ColumnHeader colOK5 = new ColumnHeader();
                colOK1.Text = "No.";
                colOK2.Text = "日時";
                colOK3.Text = "読取値";
                colOK4.Text = "判定";
                colOK5.Text = "トレイ";
                colOK1.TextAlign = HorizontalAlignment.Center;
                colOK2.TextAlign = HorizontalAlignment.Center;
                colOK3.TextAlign = HorizontalAlignment.Center;
                colOK4.TextAlign = HorizontalAlignment.Center;
                colOK5.TextAlign = HorizontalAlignment.Center;
                colOK1.Width = 60;          // 
                colOK2.Width = 190;         // 
                colOK3.Width = 200;         // 
                colOK4.Width = 50;          // 
                colOK5.Width = 60;          // 
                ColumnHeader[] colHeaderOK = new[] { colOK1, colOK2, colOK3, colOK4, colOK5 };                
                LsvOKHistory.Columns.AddRange(colHeaderOK);
                #endregion

                #region NG履歴のヘッダー設定
                LsvNGHistory.View = View.Details;
                ColumnHeader colNG1 = new ColumnHeader();
                ColumnHeader colNG2 = new ColumnHeader();
                ColumnHeader colNG3 = new ColumnHeader();
                ColumnHeader colNG4 = new ColumnHeader();
                ColumnHeader colNG5 = new ColumnHeader();
                colNG1.Text = "No.";
                colNG2.Text = "日時";
                colNG3.Text = "読取値";
                colNG4.Text = "判定";
                colNG5.Text = "トレイ";
                colNG1.TextAlign = HorizontalAlignment.Center;
                colNG2.TextAlign = HorizontalAlignment.Center;
                colNG3.TextAlign = HorizontalAlignment.Center;
                colNG4.TextAlign = HorizontalAlignment.Center;
                colNG5.TextAlign = HorizontalAlignment.Center;
                colNG1.Width = 60;          // 
                colNG2.Width = 190;         // 
                colNG3.Width = 200;         // 
                colNG4.Width = 50;          // 
                colNG5.Width = 60;          // 
                ColumnHeader[] colHeaderNG = new[] { colNG1, colNG2, colNG3, colNG4, colNG5 };
                LsvNGHistory.Columns.AddRange(colHeaderNG);
                #endregion

                #region 不着事由区分
                CommonModule.ReadNonDeliveryList();
                CmbNonDeliveryReasonSorting1.Items.Clear();
                CmbNonDeliveryReasonSorting2.Items.Clear();
                foreach (string items in PubConstClass.lstNonDeliveryList)
                {
                    string[] sArray = items.Split(',');
                    CmbNonDeliveryReasonSorting1.Items.Add(sArray[0] + "：" + sArray[1]);
                    CmbNonDeliveryReasonSorting2.Items.Add(sArray[0] + "：" + sArray[1]);
                }
                CmbNonDeliveryReasonSorting1.SelectedIndex = 0;
                CmbNonDeliveryReasonSorting2.SelectedIndex = 0;
                #endregion                                

                #region ジョブ名
                // ジョブ登録リストファイル読込
                CommonModule.ReadJobEntryListFile();
                CmbJobName.Items.Clear();
                foreach (var items in PubConstClass.lstJobEntryList)
                {
                    string[] sArray = items.Split(',');
                    CmbJobName.Items.Add(sArray[1]);
                }
                CmbJobName.SelectedIndex = 0;
                #endregion

                // 年月日時分秒タイマーセット
                TimDateTime.Interval = 1000;
                TimDateTime.Enabled = true;

                LblTotalCount.Text = "0";   // 総数カウンタクリア
                LblOKCount.Text = "0";      // OKカウンタクリア
                LblNGCount.Text = "0";      // NGカウンタクリア

                #region ソーターポケットカウンタクリア
                LblBox1.Text = "0";
                LblBox2.Text = "0";
                LblBox3.Text = "0";
                LblBox4.Text = "0";
                LblBox5.Text = "0";
                LblBoxEject.Text = "0";
                #endregion

                #region ソーターポケット予測値クリア
                LblPocket1.Text = "";
                LblPocket2.Text = "";
                LblPocket3.Text = "";
                LblPocket4.Text = "";
                LblPocket5.Text = "";
                #endregion

                // 停止中
                SetStatus(0);

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

                // リストビューのダブルバッファを有効とする
                EnableDoubleBuffering(LsvOKHistory);
                EnableDoubleBuffering(LsvNGHistory);

                // ログ保存フォルダの確認
                CheckAndCreateLogStorageFolder();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
                LblError.Visible = true;
                MessageBox.Show(ex.Message, "【QrSorterInspectionForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ログ保存フォルダのチェック及び作成
        /// </summary>
        private void CheckAndCreateLogStorageFolder()
        {
            string sFolderPath;
            string sCurrentDate;

            try
            {
                sCurrentDate = DateTime.Now.ToString("yyyyMMdd");

                // 保守画面で指定したログフォルダ
                if (Directory.Exists(PubConstClass.pblInternalTranFolder) == false)
                {
                    Directory.CreateDirectory(PubConstClass.pblInternalTranFolder);
                }
                // 今日の日付のフォルダ
                sFolderPath = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder);
                sFolderPath += sCurrentDate;
                if (Directory.Exists(sFolderPath) == false)
                {
                    Directory.CreateDirectory(sFolderPath);
                }

                // 不着事由名称１のフォルダ
                sFolderPath = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder);
                sFolderPath += CommonModule.IncludeTrailingPathDelimiter(sCurrentDate);
                sFolderPath += CmbNonDeliveryReasonSorting1.Text;
                if (Directory.Exists(sFolderPath) == false)
                {
                    Directory.CreateDirectory(sFolderPath);
                }

                // 不着事由名称２のフォルダ
                sFolderPath = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder);
                sFolderPath += CommonModule.IncludeTrailingPathDelimiter(sCurrentDate);
                sFolderPath += CmbNonDeliveryReasonSorting2.Text;
                if (Directory.Exists(sFolderPath) == false)
                {
                    Directory.CreateDirectory(sFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckAndCreateLogStorageFolder】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveLogData(string sLogFilePath, string sData)
        {           
            try
            {
                //strPutDataPath = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_FILENAME;

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sLogFilePath, false, Encoding.Default))
                {
                    // 
                    sw.WriteLine(sData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WritetSystemDefinition】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// コントロールのDoubleBufferedプロパティをTrueにする
        /// </summary>
        /// <param name="control"></param>
        private void EnableDoubleBuffering(Control control)
        {
            control.GetType().InvokeMember("DoubleBuffered",
                                            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                            null/* TODO Change to default(_) if this is not a reference type */,
                                            control,
                                            new object[] { true }
                                            );
        }

        /// <summary>
        /// 「戻る」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Owner.Refresh();
            this.Dispose();
        }

        /// <summary>
        /// 現在日付と時刻の表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimDateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                // 現在時刻の表示
                LblDateTime.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【TimDateTime_Tick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int iOKCount = 0;
        private int iNGCount = 0;
        private int iBoxNumber = 1;

        private int iBox1Count = 0;
        private int iBox2Count = 0;
        private int iBox3Count = 0;
        private int iBox4Count = 0;
        private int iBox5Count = 0;

        /// <summary>
        /// 「検査開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartInspection_Click(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[10];
                ListViewItem itm;

                iOKCount++;
                LblOKCount.Text = iOKCount.ToString("#,##0");
                LblTotalCount.Text = (iOKCount + iNGCount).ToString("#,##0");
                col[0] = iOKCount.ToString("00000");
                col[1] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[2] = "QR" + iOKCount.ToString("000000000");
                col[3] = "トレイ１";
                col[4] = "---";

                if (iBoxNumber == 1)
                {
                    iBox1Count++;
                    LblBox1.Text = iBox1Count.ToString("0");
                    LblPocket1.Text = "QR" + iOKCount.ToString("000000000");
                }
                else if (iBoxNumber == 2)
                {
                    iBox2Count++;
                    LblBox2.Text = iBox2Count.ToString("0");
                    LblPocket2.Text = "QR" + iOKCount.ToString("000000000");
                }
                else if (iBoxNumber == 3)
                {
                    iBox3Count++;
                    LblBox3.Text = iBox3Count.ToString("0");
                    LblPocket3.Text = "QR" + iOKCount.ToString("000000000");
                }
                else if (iBoxNumber == 4) {
                    iBox4Count++;
                    LblBox4.Text = iBox4Count.ToString("0");
                    LblPocket4.Text = "QR" + iOKCount.ToString("000000000");
                }
                iBoxNumber++;
                if (iBoxNumber > 4) {
                    iBoxNumber = 1;
                }

                // データの表示
                itm = new ListViewItem(col);
                LsvOKHistory.Items.Add(itm);
                LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvOKHistory.Select();
                LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].EnsureVisible();

                if (LsvOKHistory.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }

                // 検査中
                SetStatus(1);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "【BtnStartInspection_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「検査終了」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopInspection_Click(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[10];
                ListViewItem itm;

                iNGCount++;
                LblTotalCount.Text = (iOKCount + iNGCount).ToString("#,##0");
                LblNGCount.Text = iNGCount.ToString("#,##0");
                LblBoxEject.Text = iNGCount.ToString("0");

                col[0] = iNGCount.ToString("00000");
                col[1] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[2] = "QR" + iNGCount.ToString("000000000");
                col[3] = "ﾌｨｰﾄﾞNG";
                col[4] = "---";

                // データの表示
                itm = new ListViewItem(col);
                LsvNGHistory.Items.Add(itm);
                LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvNGHistory.Select();
                LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].EnsureVisible();

                if (LsvNGHistory.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }

                // 停止中
                SetStatus(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnStartInspection_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ジョブ名選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbJobName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] sArray = PubConstClass.lstJobEntryList[CmbJobName.SelectedIndex].Split(',');
                
                // 受領日
                DtpDateReceipt.Text = sArray[3];
                // 不着事由仕分①
                CmbNonDeliveryReasonSorting1.SelectedIndex = int.Parse(sArray[19]) - 1;
                // 不着事由仕分②
                CmbNonDeliveryReasonSorting2.SelectedIndex = int.Parse(sArray[20]) - 1;

                TxtFileType.Text = "01";

                // 不着事由仕分①チェック  
                CmbNonDeliveryReasonSorting1.Enabled = sArray[21] == "ON";
                // 不着事由仕分②チェック
                CmbNonDeliveryReasonSorting2.Enabled = sArray[22] == "ON";

                TxtSeqNum.Text = "0001";
                    
                // ポケット①名称
                LblBoxTitle1.Text = "BOX_01 " + sArray[29];
                // ポケット②名称
                LblBoxTitle2.Text = "BOX_02 " + sArray[31];
                // ポケット③名称
                LblBoxTitle3.Text = "BOX_03 " + sArray[33];
                // ポケット④名称
                LblBoxTitle4.Text = "BOX_04 " + sArray[35];
                // ポケット⑤名称
                LblBoxTitle5.Text = "BOX_05 " + sArray[37];

                // ポケット１切替件数
                LblQuantity1.Text = sArray[44] == "ON" ? sArray[39]: "---";
                // ポケット２切替件数
                LblQuantity2.Text = sArray[45] == "ON" ? sArray[40] : "---";
                // ポケット３切替件数
                LblQuantity3.Text = sArray[46] == "ON" ? sArray[41] : "---";
                // ポケット４切替件数
                LblQuantity4.Text = sArray[47] == "ON" ? sArray[42] : "---";
                // ポケット５切替件数
                LblQuantity5.Text = sArray[48] == "ON" ? sArray[43] : "---";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbJobName_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ステータス表示
        /// </summary>
        /// <param name="status"></param>
        private void SetStatus(int status)
        {
            try
            {
                switch (status)
                {
                    case 0:
                        LblStatus.Text = "停止中";
                        LblStatus.BackColor = Color.LightGray;
                        LblStatus.ForeColor = Color.Black;
                        break;

                    case 1:
                        LblStatus.Text = "検査中";
                        LblStatus.BackColor = Color.LightGreen;
                        LblStatus.ForeColor = Color.Black;
                        break;

                    case 2:
                        LblStatus.Text = "エラー";
                        LblStatus.BackColor = Color.OrangeRed;
                        LblStatus.ForeColor = Color.White;
                        break;

                    default:
                        LblStatus.Text = "停止中";
                        LblStatus.BackColor = Color.LightGray;
                        LblStatus.ForeColor = Color.Black;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetStatus】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// バージョンボタンダブルクリック処理（デバッグ用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblVersion_DoubleClick(object sender, EventArgs e)
        {
            // 「エラー」のステータスとする 
            SetStatus(2);
        }

        /// <summary>
        /// 「設定」ボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■検査画面：「設定」ボタンクリック");
                SettingForm form = new SettingForm();
                form.ShowDialog(this);

                #region ジョブ名
                // ジョブ登録リストファイル読込
                CommonModule.ReadJobEntryListFile();
                CmbJobName.Items.Clear();
                foreach (var items in PubConstClass.lstJobEntryList)
                {
                    string[] sArray = items.Split(',');
                    CmbJobName.Items.Add(sArray[0]);
                }
                CmbJobName.SelectedIndex = 0;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetStatus】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 検査装置からのデータ受信処理
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

                DisplaySeisanLogData(data);
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
                // 読取値（QRコード）
                col[2] = strArray[0].Trim();
                // 判定（OK/NG）
                col[3] = strArray[1].Trim();
                // エラーコード
                //col[4] = strArray[2];
                // トレイ情報
                col[4] = strArray[3].Trim();

                // データの表示
                if (col[3] == "NG")
                {
                    // NGのカウント表示
                    iNGCount++;
                    LblNGCount.Text = iNGCount.ToString("#,##0");

                    itm2 = new ListViewItem(col);
                    LsvNGHistory.Items.Add(itm2);
                    LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].UseItemStyleForSubItems = false;
                    LsvNGHistory.Select();
                    LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].EnsureVisible();
                    if (LsvNGHistory.Items.Count % 2 == 1)
                    {
                        for (int iIndex = 0; iIndex < 5; iIndex++)
                        {
                            // 奇数行の色反転
                            LsvNGHistory.Items[LsvNGHistory.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                        }
                    }
                }
                else
                {
                    // OKのカウント表示
                    iOKCount++;
                    LblOKCount.Text = iOKCount.ToString("#,##0");

                    itm1 = new ListViewItem(col);
                    LsvOKHistory.Items.Add(itm1);
                    LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].UseItemStyleForSubItems = false;
                    LsvOKHistory.Select();
                    LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].EnsureVisible();

                    if (LsvOKHistory.Items.Count % 2 == 1)
                    {
                        for (int iIndex = 0; iIndex < 5; iIndex++)
                        {
                            // 奇数行の色反転
                            LsvOKHistory.Items[LsvOKHistory.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                        }
                    }

                    switch (col[4])
                    {
                        case "1":
                            iBox1Count++;
                            LblBox1.Text = iBox1Count.ToString("0");
                            LblPocket1.Text = col[2];
                            break;
                        case "2":
                            iBox2Count++;
                            LblBox2.Text = iBox2Count.ToString("0");
                            LblPocket2.Text = col[2];
                            break;
                        case "3":
                            iBox3Count++;
                            LblBox3.Text = iBox3Count.ToString("0");
                            LblPocket3.Text = col[2];
                            break;
                        case "4":
                            iBox4Count++;
                            LblBox4.Text = iBox4Count.ToString("0");
                            LblPocket4.Text = col[2];
                            break;
                        case "5":
                            iBox5Count++;
                            LblBox5.Text = iBox5Count.ToString("0");
                            LblPocket5.Text = col[2];
                            break;
                        default:
                            break;
                    }
                }

                // 総数のカウント表示
                LblTotalCount.Text = (iOKCount + iNGCount).ToString("#,##0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplaySeisanLogData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonModule.OutPutLogFile("【DisplaySeisanLogData】" + ex.Message);
            }
        }

        static byte[] buffer = new byte[1024];
        static int bufferIndex = 0;

        /// <summary>
        /// シリアルデータ受信イベント（漢字データ受信対応）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortQr_DataReceived_Kanji(object sender, SerialDataReceivedEventArgs e)
        {
            string data = "";

            try
            {
                // シリアルポートをオープンしていない場合、処理を行わない。
                if (SerialPortQr.IsOpen == false)
                    return;

                SerialPort sp = (SerialPort)sender;
                while (sp.BytesToRead > 0)
                {
                    byte b = (byte)sp.ReadByte();
                    buffer[bufferIndex++] = b;
                    // CRまで読み込む
                    if (b == '\r')
                    {
                        data = Encoding.GetEncoding("Shift_JIS").GetString(buffer, 0, bufferIndex);
                        Console.WriteLine("Data Received: " + data);
                        bufferIndex = 0;
                        BeginInvoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), data + "\r");
                    }
                }
            }
            catch (TimeoutException)
            {
                // ディスカードするデータ
                CommonModule.OutPutLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" + data);
            }
            catch (Exception ex)
            {
                CommonModule.OutPutLogFile("【SerialPortBcr_DataReceived】" + ex.Message);
            }
        }
    }
}
