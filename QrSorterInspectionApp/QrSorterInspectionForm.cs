using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterInspectionApp
{
    public partial class QrSorterInspectionForm : Form
    {
        private delegate void Delegate_RcvDataToTextBox(string data);

        private List<string> lstPastReceivedQrData = new List<string>();

        private string sDateOfReceipt;          // 受領日
        private string sNonDeliveryReason1;     // 不着事由１
        private string sNonDeliveryReason2;     // 不着事由２

        private int iOKCount = 0;               // OK用カウンタ
        private int iNGCount = 0;               // NG用カウンタ
        private int iBox1Count = 0;             // ボックス１用カウンタ
        private int iBox2Count = 0;             // ボックス２用カウンタ
        private int iBox3Count = 0;             // ボックス３用カウンタ
        private int iBox4Count = 0;             // ボックス４用カウンタ
        private int iBox5Count = 0;             // ボックス５用カウンタ
        private int intSesanCounter = 0;

        private string sJobFolderName;          // JOBフォルダ名       
        private string sFolderName1;            // グループ１フォルダ名
        private string sFolderName2;            // グループ２フォルダ名
        private string sFolderName3;            // グループ３フォルダ名
        private string sFolderName4;            // グループ４フォルダ名
        private string sFolderName5;            // グループ５フォルダ名        
        private string sFileNameForGroup1;      // グループ１操作ログファイル名
        private string sFileNameForGroup2;      // グループ２操作ログファイル名
        private string sFileNameForGroup3;      // グループ３操作ログファイル名
        private string sFileNameForGroup4;      // グループ４操作ログファイル名
        private string sFileNameForGroup5;      // グループ５操作ログファイル名
        private string sFileNameForAllItems;    // 全件用の操作ログファイル名
        private byte[] buffer = new byte[1024];
        private int bufferIndex = 0;

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
                // 年月日時分秒タイマーセット
                TimDateTime.Interval = 1000;
                TimDateTime.Enabled = true;

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
                colOK1.Width = 80;          // 
                colOK2.Width = 200;         // 
                colOK3.Width = 370;         // 
                colOK4.Width = 70;          // 
                colOK5.Width = 70;          // 
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
                colNG1.Width = 80;          // 
                colNG2.Width = 200;         // 
                colNG3.Width = 370;         // 
                colNG4.Width = 70;          // 
                colNG5.Width = 70;          // 
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
                #region QRフィーダーカウンタクリア
                LblTotalCount.Text = "0";   // 総数カウンタクリア
                LblOKCount.Text = "0";      // OKカウンタクリア
                LblNGCount.Text = "0";      // NGカウンタクリア
                #endregion
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
                #region ソーターポケットタイトルクリア
                LblBoxTitle1.Text = "";
                LblBoxTitle2.Text = "";
                LblBoxTitle3.Text = "";
                LblBoxTitle4.Text = "";
                LblBoxTitle5.Text = "";
                #endregion
                #region ソーターポケット数量クリア
                LblQuantity1.Text = "---";
                LblQuantity2.Text = "---";
                LblQuantity3.Text = "---";
                LblQuantity4.Text = "---";
                LblQuantity5.Text = "---";
                #endregion

                // 過去に受信したQRデータ一覧のクリア
                lstPastReceivedQrData.Clear();

                PubConstClass.sPrevDtpDateReceipt = "";  // 前回の受領日
                PubConstClass.sPrevNonDelivery1 = "";    // 前回の不着事由仕分け１
                PubConstClass.sPrevNonDelivery2 = "";    // 前回の不着事由仕分け２

                #region テスト確認用に過去に受信したQRデータ一覧（100万件）を作成する
        string s1 = DateTime.Now.ToString("yyyyMMdd");
                string s2 = DateTime.Now.ToString("yyMMdd");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                // 100万件の過去に受信したQRデータを作成する
                for (int iIndex = 1; iIndex <= 1000000; iIndex++)
                {
                    lstPastReceivedQrData.Add($"D86571{s1}-{s2}_{iIndex.ToString("000000000")}");
                }
                sw.Stop();
                CommonModule.OutPutLogFile($"■最初のQRデータ：{lstPastReceivedQrData[0]}");
                CommonModule.OutPutLogFile($"■最後のQRデータ：{lstPastReceivedQrData[lstPastReceivedQrData.Count-1]}");
                CommonModule.OutPutLogFile($"■{lstPastReceivedQrData.Count.ToString("#,###,##0")}件作成処理時間: {sw.Elapsed.TotalMilliseconds}ミリ秒");
                #endregion

                // 停止中
                SetStatus(0);
                // JOB選択ラベルクリア
                LblSelectedFile.Text = "";
                // 「検査開始」ボタン使用不可
                BtnStartInspection.Enabled = false;
                // 「設定」ボタン使用不可
                BtnSetting.Enabled = false;

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
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
                LblError.Visible = true;
                MessageBox.Show(ex.Message, "【QrSorterInspectionForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 検査ログフォルダの作成と検査ログファイル名の確保
        /// </summary>
        private void CreateInspectionLogFolder()
        {
            string sJobName;
            string sJobFolder;
            string sGrpFolder;
            string sReasonForNonDelivery1;
            string sReasonForNonDelivery2;
            string[] sArray;

            try
            {
                sArray = LblSelectedFile.Text.Split('.');
                // JOBフォルダ名
                sJobFolderName = sArray[0];
                // JOB名の取得
                if (sArray[0].Length > 16)
                {
                    // 16桁目までの切出
                    sJobName = sArray[0].Substring(0,16);
                }
                else
                {
                    // 先頭に「0」を付加して16桁とする
                    sJobName = sArray[0].PadLeft(16, '0');
                }
                // 不着事由１と２の取得
                sNonDeliveryReason1 = CmbNonDeliveryReasonSorting1.Text.Substring(0, 1);
                sNonDeliveryReason2 = CmbNonDeliveryReasonSorting2.Text.Substring(0, 1);
                sReasonForNonDelivery1 = "_" + sNonDeliveryReason1;
                sReasonForNonDelivery2 = "_" + sNonDeliveryReason2;
                // 受領日を取得
                sDateOfReceipt = DtpDateReceipt.Value.ToString("yyyyMMdd");
                string sDate = "_" + sDateOfReceipt + "_";

                string[] sFolderNameWork = new string[6];           // グループ１～５、リジェクト、フォルダ名        
                string[] sFileNameForGroupWork = new string[6];     // グループ１～５、リジェクト、操作ログファイル名

                // 現在の日付（年月日）を求める
                DateTime dtCurrent = DateTime.Now;
                // 現在日付から１秒～５秒を加算
                DateTime dtPostDate1 = dtCurrent.AddSeconds(1);
                DateTime dtPostDate2 = dtCurrent.AddSeconds(2);
                DateTime dtPostDate3 = dtCurrent.AddSeconds(3);
                DateTime dtPostDate4 = dtCurrent.AddSeconds(4);
                DateTime dtPostDate5 = dtCurrent.AddSeconds(5);
                sFileNameForAllItems = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtCurrent.ToString("yyyyMMddHHmmss") + "全件.csv";
                // グループ１～５の操作ログファイル名を取得
                sFileNameForGroupWork[0] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate1.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[1] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate2.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[2] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate3.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[3] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate4.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[4] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate5.ToString("yyyyMMddHHmmss") + ".csv";
                CommonModule.OutPutLogFile($"■sFileNameForGroupWork[0] = {sFileNameForGroupWork[0]}");
                CommonModule.OutPutLogFile($"■sFileNameForGroupWork[1] = {sFileNameForGroupWork[1]}");
                CommonModule.OutPutLogFile($"■sFileNameForGroupWork[2] = {sFileNameForGroupWork[2]}");
                CommonModule.OutPutLogFile($"■sFileNameForGroupWork[3] = {sFileNameForGroupWork[3]}");
                CommonModule.OutPutLogFile($"■sFileNameForGroupWork[4] = {sFileNameForGroupWork[4]}");

                sFileNameForGroupWork[5] = "リジェクト.csv";
                CommonModule.OutPutLogFile($"■sFileNameForGroupWork[5] = {sFileNameForGroupWork[5]}");

                // JOB名までのフォルダの存在チェックと作成
                sArray = LblSelectedFile.Text.Split('.');
                sJobFolder = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder) + sArray[0];
                if (Directory.Exists(sJobFolder) == false)
                {
                    Directory.CreateDirectory(sJobFolder);
                }
                
                // グループ１フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[0].Split(',');
                //sFolderName1 = "グループ１_" + sArray[0] + sArray[2];
                //sGrpFolder = sJobFolder + "\\" + sFolderName1;
                sFolderNameWork[0] = "グループ１_" + sArray[0] + sArray[2];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[0];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }
                
                // グループ２フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[1].Split(',');
                //sFolderName2 = "グループ２_" + sArray[0] + sArray[2];
                //sGrpFolder = sJobFolder + "\\" + sFolderName2;
                sFolderNameWork[1] = "グループ２_" + sArray[0] + sArray[2];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[1];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }
                // グループ３フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[2].Split(',');
                //sFolderName3 = "グループ３_" + sArray[0] + sArray[2];
                //sGrpFolder = sJobFolder + "\\" + sFolderName3;
                sFolderNameWork[2] = "グループ３_" + sArray[0] + sArray[2];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[2];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }
                // グループ４フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[3].Split(',');
                //sFolderName4 = "グループ４_" + sArray[0] + sArray[2];
                //sGrpFolder = sJobFolder + "\\" + sFolderName4;
                sFolderNameWork[3] = "グループ４_" + sArray[0] + sArray[2];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[3];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }

                // グループ５フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[4].Split(',');
                //sFolderName5 = "グループ５_" + sArray[0] + sArray[2];
                //sGrpFolder = sJobFolder + "\\" + sFolderName5;
                sFolderNameWork[4] = "グループ５_" + sArray[0] + sArray[2];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[4];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }

                sFolderNameWork[5] = "グループ６_リジェクト";

                //                 0    1              2  3  4   5      6 7 8      9 0 1            2  3 4       5  6  7 8 9  0  1  2  3  4  5 6 7                8 9                0 1        2 3                 4 5                 6 7  8                               
                //チューリッヒ⑧封書,封筒,2024年12月19日,ON,47,OFF,物件ID,1,5,届出日,6,8,ファイル区分,14,1,管理No.,15,10,1,2,ON,ON,ON,ON,ON,ON,1,1,コメリ①-1ハガキ,1,コメリ①-2ハガキ,2,武蔵野BK,3,西日本シティーBK1,4,西日本シティーBK2,5,50,50,50,50,50,ON,ON,ON,ON,ON,
                sArray = PubConstClass.lstJobEntryList[0].Split(',');

                sFolderName1 = sFolderNameWork[int.Parse(sArray[29]) - 1];
                sFolderName2 = sFolderNameWork[int.Parse(sArray[31]) - 1];
                sFolderName3 = sFolderNameWork[int.Parse(sArray[33]) - 1];
                sFolderName4 = sFolderNameWork[int.Parse(sArray[35]) - 1];
                sFolderName5 = sFolderNameWork[int.Parse(sArray[37]) - 1];
                sFileNameForGroup1 = sFileNameForGroupWork[int.Parse(sArray[29]) - 1];
                sFileNameForGroup2 = sFileNameForGroupWork[int.Parse(sArray[31]) - 1];
                sFileNameForGroup3 = sFileNameForGroupWork[int.Parse(sArray[33]) - 1];
                sFileNameForGroup4 = sFileNameForGroupWork[int.Parse(sArray[35]) - 1];
                sFileNameForGroup5 = sFileNameForGroupWork[int.Parse(sArray[37]) - 1];

                LblFdrInfo1.Text = sFolderName1;
                LblFdrInfo2.Text = sFolderName2;
                LblFdrInfo3.Text = sFolderName3;
                LblFdrInfo4.Text = sFolderName4;
                LblFdrInfo5.Text = sFolderName5;
                LblGrpInfo1.Text = sFileNameForGroup1;
                LblGrpInfo2.Text = sFileNameForGroup2;
                LblGrpInfo3.Text = sFileNameForGroup3;
                LblGrpInfo4.Text = sFileNameForGroup4;
                LblGrpInfo5.Text = sFileNameForGroup5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CreateInspectionLogFolder】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// 「検査開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartInspection_Click(object sender, EventArgs e)
        {
            try
            {

                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_a + "\r");
                SerialPortQr.Write(dat, 0, dat.GetLength(0));
                LblError.Visible = false;

                if (PubConstClass.sPrevDtpDateReceipt == "")
                {
                    CreateInspectionLogFolder();
                }
                else
                {
                    if (PubConstClass.sPrevDtpDateReceipt != DtpDateReceipt.Text ||
                        PubConstClass.sPrevNonDelivery1 != CmbNonDeliveryReasonSorting1.Text ||
                        PubConstClass.sPrevNonDelivery2 != CmbNonDeliveryReasonSorting2.Text)
                    {
                        MessageBox.Show("JOB設定が変更されました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CreateInspectionLogFolder();
                    }
                }
                
                PubConstClass.sPrevDtpDateReceipt = DtpDateReceipt.Text;                // 前回の受領日
                PubConstClass.sPrevNonDelivery1 = CmbNonDeliveryReasonSorting1.Text;    // 前回の不着事由仕分け１
                PubConstClass.sPrevNonDelivery2 = CmbNonDeliveryReasonSorting2.Text;    // 前回の不着事由仕分け２

                // 検査中
                //SetStatus(1);
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
                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_b + "\r");
                SerialPortQr.Write(dat, 0, dat.GetLength(0));
                LblError.Visible = false;
                
                // 停止中
                //SetStatus(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnStartInspection_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        BtnJobSelect.Enabled = true;
                        DtpDateReceipt.Enabled = true;
                        CmbNonDeliveryReasonSorting1.Enabled = true;
                        CmbNonDeliveryReasonSorting2.Enabled = true;
                        BtnSetting.Enabled = true;
                        BtnStartInspection.Enabled = true;

                        break;

                    case 1:
                        LblStatus.Text = "検査中";
                        LblStatus.BackColor = Color.LightGreen;
                        LblStatus.ForeColor = Color.Black;

                        BtnJobSelect.Enabled = false;
                        DtpDateReceipt.Enabled = false;
                        CmbNonDeliveryReasonSorting1.Enabled = false;
                        CmbNonDeliveryReasonSorting2.Enabled = false;
                        BtnSetting.Enabled = false;
                        BtnStartInspection.Enabled = false;

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
            if (LblFdrInfo1.Visible == false)
            {
                LblFdrInfo1.Visible = true;
                LblFdrInfo2.Visible = true;
                LblFdrInfo3.Visible = true;
                LblFdrInfo4.Visible = true;
                LblFdrInfo5.Visible = true;
                LblGrpInfo1.Visible = true;
                LblGrpInfo2.Visible = true;
                LblGrpInfo3.Visible = true;
                LblGrpInfo4.Visible = true;
                LblGrpInfo5.Visible = true;
            }
            else
            {
                LblFdrInfo1.Visible = false;
                LblFdrInfo2.Visible = false;
                LblFdrInfo3.Visible = false;
                LblFdrInfo4.Visible = false;
                LblFdrInfo5.Visible = false;
                LblGrpInfo1.Visible = false;
                LblGrpInfo2.Visible = false;
                LblGrpInfo3.Visible = false;
                LblGrpInfo4.Visible = false;
                LblGrpInfo5.Visible = false;
            }
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
                //PubConstClass.sJobFileNameFromInspectionForm = "";
                SettingForm form = new SettingForm();
                form.ShowDialog(this);

                #region ジョブ名
                // ジョブ登録リストファイル読込
                //CommonModule.ReadJobEntryListFile();
                //CmbJobName.Items.Clear();
                //foreach (var items in PubConstClass.lstJobEntryList)
                //{
                //    string[] sArray = items.Split(',');
                //    CmbJobName.Items.Add(sArray[0]);
                //}
                //CmbJobName.SelectedIndex = 0;
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
                CommonModule.OutPutLogFile($"受信データ：{data.Replace("\r", "<CR>")}");

                //if (data.Length < 9)
                //{
                //    CommonModule.OutPutLogFile("■不正データ受信：" + data.Replace("\r", "<CR>"));
                //    return;
                //}

                // 受信データの先頭１文字を取得
                string sCommandType = data.Substring(0, 1);
                switch (sCommandType)
                {
                    case "A":
                        // 開始コマンド
                        MyProcA();
                        break;

                    case "B":
                        // 停止コマンド
                        MyProcB();
                        break;

                    case "D":
                        // データコマンド
                        MyProcD(data);
                        break;

                    case "E":
                        // エラーコマンド
                        MyProcE(data);
                        break;

                    default:
                        // 未定義コマンド
                        CommonModule.OutPutLogFile($"未定義コマンドです：{data.Replace("\r", "<CR>")}");
                        break;
                }
            }
            catch (Exception ex)
            {
                strMessage = "【RcvDataToTextBox】" + ex.Message;
                CommonModule.OutPutLogFile(strMessage);
                MessageBox.Show(strMessage, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 開始コマンド処理
        /// </summary>
        private void MyProcA()
        {
            try
            {
                // 検査中
                SetStatus(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcA】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止コマンド処理
        /// </summary>
        private void MyProcB()
        {
            try
            {
                // 停止中
                SetStatus(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcB】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// エラーコマンド処理
        /// </summary>
        /// <param name="sData"></param>
        private void MyProcE(string sData)
        {
            try
            {
                LblError.Text = $"エラーコマンド「{sData.Replace("\r","<CR>")}」受信";
                LblError.Visible = true;

                // エラー
                SetStatus(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcE】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// データコマンドの処理
        /// </summary>
        /// <param name="sData"></param>
        private void MyProcD(string sData)
        {
            string[] col = new string[12];
            ListViewItem itm1;
            ListViewItem itm2;
            string[] strArray;
            string sNonDel;
            string sLogData = "";
            string sWriteDate;
            string sWriteTime;
            string sSaveFileName;

            try
            {
                sWriteDate = DateTime.Now.ToString("yyyy/MM/dd");
                sWriteTime = DateTime.Now.ToString("HH:mm:ss");

                intSesanCounter += 1;                
                // No.
                col[0] = intSesanCounter.ToString("00000");
                
                strArray = sData.Split(',');
                // 日時
                col[1] = sWriteDate + " " + sWriteTime;
                // 読取値（QRコード）
                col[2] = strArray[0].Trim();
                if (lstPastReceivedQrData.Count > 0)
                {
                    #region 重複チェック
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    bool bFind = lstPastReceivedQrData.Contains(strArray[0]);
                    sw.Stop();

                    if (bFind)
                    {
                        strArray[1] = "重複";
                        CommonModule.OutPutLogFile($"■重複データ：{strArray[0]}");
                    }
                    else
                    {
                        CommonModule.OutPutLogFile($"■最初のデータ：{lstPastReceivedQrData[0]}");
                        CommonModule.OutPutLogFile($"■最後のデータ：{lstPastReceivedQrData[lstPastReceivedQrData.Count - 1]}");                        
                    }
                    CommonModule.OutPutLogFile($"■{lstPastReceivedQrData.Count.ToString("#,###,##0")}件の検索処理時間: {sw.Elapsed.TotalMilliseconds}ミリ秒");
                    #endregion
                }

                lstPastReceivedQrData.Add(col[2]);
                // 判定（OK/NG）
                col[3] = strArray[1].Trim();
                // エラーコード
                //col[4] = strArray[2];                
                // 不着事由
                sNonDel = strArray[3].Trim().PadLeft(2,'0');                
                // トレイ情報
                col[4] = strArray[4].Trim();

                string sFolderName = "";
                string sFileName = "";

                switch (col[4])
                {
                    case "1":
                        iBox1Count++;
                        LblBox1.Text = iBox1Count.ToString("0");
                        LblPocket1.Text = col[2];
                        sFolderName = sFolderName1;
                        sFileName = sFileNameForGroup1;
                        break;
                    case "2":
                        iBox2Count++;
                        LblBox2.Text = iBox2Count.ToString("0");
                        LblPocket2.Text = col[2];
                        sFolderName = sFolderName2;
                        sFileName = sFileNameForGroup2;
                        break;
                    case "3":
                        iBox3Count++;
                        LblBox3.Text = iBox3Count.ToString("0");
                        LblPocket3.Text = col[2];
                        sFolderName = sFolderName3;
                        sFileName = sFileNameForGroup3;
                        break;
                    case "4":
                        iBox4Count++;
                        LblBox4.Text = iBox4Count.ToString("0");
                        LblPocket4.Text = col[2];
                        sFolderName = sFolderName4;
                        sFileName = sFileNameForGroup4;
                        break;
                    case "5":
                        iBox5Count++;
                        LblBox5.Text = iBox5Count.ToString("0");
                        LblPocket5.Text = col[2];
                        sFolderName = sFolderName5;
                        sFileName = sFileNameForGroup5;
                        break;
                    default:
                        break;
                }

                sLogData += sWriteDate + ",";                           // 日付
                sLogData += sWriteTime + ",";                           // 時刻
                sLogData += strArray[0].Trim() + ",";                   // 読取値
                sLogData += strArray[1].Trim() + ",";                   // 判定
                sLogData += sFileName + ",";                            // 正解データファイル名
                sLogData += sDateOfReceipt + ",";                       // 受領日
                sLogData += PubConstClass.sUserId + ",";                // 作業者情報                
                sLogData += strArray[0].Trim().Substring(0,5) + ",";    // 物件ID
                sLogData += strArray[2] + ",";                          // エラー
                sLogData += sNonDeliveryReason1 + ",";                  // 仕分１
                sLogData += sNonDeliveryReason2 + ",";                  // 仕分２

                // データの表示
                if (col[3] == "OK")
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

                    sSaveFileName = "";
                    sSaveFileName += CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder);
                    sSaveFileName += sJobFolderName + "\\";
                    sSaveFileName += sFolderName + "\\";
                    sSaveFileName += sFileName;
                    using (StreamWriter sw = new StreamWriter(sSaveFileName, true, Encoding.Default))
                    {
                        // OKデータのみを追加モードで書き込む
                        sw.WriteLine(sLogData);
                    }
                }
                else
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

                // 総数のカウント表示
                LblTotalCount.Text = (iOKCount + iNGCount).ToString("#,##0");

                sSaveFileName = "";
                sSaveFileName += CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder);
                sSaveFileName += sJobFolderName + "\\";
                //sSaveFileName += sFolderName + "\\";
                sSaveFileName += sFileNameForAllItems;
                using (StreamWriter sw = new StreamWriter(sSaveFileName, true, Encoding.Default))
                {
                    // 全件データを追加モードで書き込む
                    sw.WriteLine(sLogData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplaySeisanLogData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonModule.OutPutLogFile("【DisplaySeisanLogData】" + ex.Message);
            }
        }

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

        /// <summary>
        /// 「JOB選択」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJobSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                CommonModule.OutPutLogFile("■「JOB選択」ボタンクリック");
                // 初期表示するフォルダの指定（「空の文字列」の時は現在のディレクトリを表示）
                //ofd.InitialDirectory = @"C:\";
                // 「ファイルの種類」に表示される選択肢の指定
                ofd.Filter = "CSVファイル(*.csv;*.CSV)|*.csv;*.CSV|すべてのファイル(*.*)|*.*";
                // 「ファイルの種類」ではじめに「CSVファイル(*.csv;*.CSV)」を選択
                ofd.FilterIndex = 1;
                // タイトルを設定
                ofd.Title = "JOB設定ファイルを選択してください";
                // ダイアログボックスを閉じる前に現在のディレクトリを復元
                ofd.RestoreDirectory = true;
                // 存在しないファイルの名前が指定されたとき警告を表示
                ofd.CheckFileExists = true;
                // 存在しないパスが指定されたとき警告を表示
                ofd.CheckPathExists = true;
                // ダイアログを表示する
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 「OK」ボタンがクリック（選択されたファイル名を表示）
                    string sSelectedFile = ofd.FileName;
                    string[] sArray = sSelectedFile.Split('\\');
                    // ファイル名のみを表示する
                    LblSelectedFile.Text = sArray[sArray.Length - 1];
                    // ジョブ登録情報及びグループ１～５情報の読取り
                    CommonModule.ReadJobEntryListFile(sSelectedFile);
                    // 登録ジョブ項目を取得し表示
                    GetEntryInfoAndDisplay();
                    // 「検査開始」ボタン使用可
                    BtnStartInspection.Enabled = true;
                    // 「設定」ボタン使用可
                    BtnSetting.Enabled = true;
                    PubConstClass.sJobFileNameFromInspectionForm = sSelectedFile;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobSelect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetEntryInfoAndDisplay()
        {
            try
            {
                string[] sArray = PubConstClass.lstJobEntryList[0].Split(',');

                // 受領日
                DtpDateReceipt.Text = sArray[2];
                // 不着事由仕分①
                CmbNonDeliveryReasonSorting1.SelectedIndex = int.Parse(sArray[18]) - 1;
                // 不着事由仕分②
                CmbNonDeliveryReasonSorting2.SelectedIndex = int.Parse(sArray[19]) - 1;

                //TxtFileType.Text = "01";

                // 不着事由仕分①チェック  
                CmbNonDeliveryReasonSorting1.Enabled = sArray[20] == "ON";
                // 不着事由仕分②チェック
                CmbNonDeliveryReasonSorting2.Enabled = sArray[21] == "ON";

                //TxtSeqNum.Text = "0001";

                // ポケット①名称
                LblBoxTitle1.Text = "BOX_01 " + sArray[28];
                // ポケット②名称
                LblBoxTitle2.Text = "BOX_02 " + sArray[30];
                // ポケット③名称
                LblBoxTitle3.Text = "BOX_03 " + sArray[32];
                // ポケット④名称
                LblBoxTitle4.Text = "BOX_04 " + sArray[34];
                // ポケット⑤名称
                LblBoxTitle5.Text = "BOX_05 " + sArray[36];

                // ポケット１切替件数
                LblQuantity1.Text = sArray[43] == "ON" ? sArray[38] : "---";
                // ポケット２切替件数
                LblQuantity2.Text = sArray[44] == "ON" ? sArray[39] : "---";
                // ポケット３切替件数
                LblQuantity3.Text = sArray[45] == "ON" ? sArray[40] : "---";
                // ポケット４切替件数
                LblQuantity4.Text = sArray[46] == "ON" ? sArray[41] : "---";
                // ポケット５切替件数
                LblQuantity5.Text = sArray[47] == "ON" ? sArray[42] : "---";

                // ログ保存フォルダの確認
                //CheckAndCreateLogStorageFolder();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetEntryInfoAndDisplay】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
