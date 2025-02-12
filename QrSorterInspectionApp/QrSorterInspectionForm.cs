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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterInspectionApp
{
    public partial class QrSorterInspectionForm : Form
    {
        private delegate void Delegate_RcvDataToTextBox(string data);

        private List<string> lstPastReceivedQrData = new List<string>();

        private string sDateOfReceipt;          // 受領日
        private bool   bDateOfReceipt;          // 受領日入力
        private string sNonDeliveryReason1;     // 不着事由１
        private string sNonDeliveryReason2;     // 不着事由２
        private int    iStatus;                 // 検査中ステータス

        private int iOKCount = 0;               // OK用カウンタ
        private int iNGCount = 0;               // NG用カウンタ
        private int iBox1Count = 0;             // ボックス１用カウンタ
        private int iBox2Count = 0;             // ボックス２用カウンタ
        private int iBox3Count = 0;             // ボックス３用カウンタ
        private int iBox4Count = 0;             // ボックス４用カウンタ
        private int iBox5Count = 0;             // ボックス５用カウンタ
        private int iBoxECount = 0;             // ボックス（Eject）用カウンタ
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

        private string OK_FOLDER_NAME = "QRソーター設定検査ログ（OKのみ）\\";
        private string ALL_FOLDER_NAME = "QRソーター設定検査ログ（全件）\\";

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
                LblPocketEject.Text = "";
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

                LblQrReadData.Text = "";
                // 過去に受信したQRデータ一覧のクリア
                lstPastReceivedQrData.Clear();

                PubConstClass.sPrevDtpDateReceipt = "";  // 前回の受領日
                PubConstClass.sPrevNonDelivery1 = "";    // 前回の不着事由仕分け１
                PubConstClass.sPrevNonDelivery2 = "";    // 前回の不着事由仕分け２

                #region テスト確認用に過去に受信したQRデータ一覧（100万件）を作成する
                //string s1 = DateTime.Now.ToString("yyyyMMdd");
                //string s2 = DateTime.Now.ToString("yyMMdd");
                //Stopwatch sw = new Stopwatch();
                //sw.Start();
                //// 100万件の過去に受信したQRデータを作成する
                //for (int iIndex = 1; iIndex <= 1000000; iIndex++)
                //{
                //    lstPastReceivedQrData.Add($"D86571{s1}-{s2}_{iIndex:000000000}");
                //}
                //sw.Stop();
                //CommonModule.OutPutLogFile($"最初のQRデータ：{lstPastReceivedQrData[0]}");
                //CommonModule.OutPutLogFile($"最後のQRデータ：{lstPastReceivedQrData[lstPastReceivedQrData.Count-1]}");
                //CommonModule.OutPutLogFile($"{lstPastReceivedQrData.Count:#,###,##0}件作成処理時間: {sw.Elapsed.TotalMilliseconds}ミリ秒");
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
                    //// 先頭に「0」を付加して16桁とする
                    //sJobName = sArray[0].PadLeft(16, '0');
                    // 後ろに「0」を付加して16桁とする
                    sJobName = sArray[0].PadRight(16, '0');
                }
                // 不着事由１と２の取得
                sNonDeliveryReason1 = CmbNonDeliveryReasonSorting1.Text.Substring(0, 1);
                sNonDeliveryReason2 = CmbNonDeliveryReasonSorting2.Text.Substring(0, 1);
                sReasonForNonDelivery1 = "_" + sNonDeliveryReason1;
                sReasonForNonDelivery2 = "_" + sNonDeliveryReason2;
                // 受領日を取得
                sDateOfReceipt = DtpDateReceipt.Value.ToString("yyyyMMdd");
                string sDate = "_" + sDateOfReceipt + "_";

                string[] sGroupName = new string[6];                // グループ名
                string[] sFolderNameWork = new string[6];           // グループ１～５、リジェクト、フォルダ名        
                string[] sFileNameForGroupWork = new string[6];     // グループ１～５、リジェクト、操作ログファイル名

                //// 現在の日付（年月日）を求める
                //DateTime dtCurrent = DateTime.Now;
                //// 現在日付から１秒～５秒を加算
                //DateTime dtPostDate1 = dtCurrent.AddSeconds(1);
                //DateTime dtPostDate2 = dtCurrent.AddSeconds(2);
                //DateTime dtPostDate3 = dtCurrent.AddSeconds(3);
                //DateTime dtPostDate4 = dtCurrent.AddSeconds(4);
                //DateTime dtPostDate5 = dtCurrent.AddSeconds(5);
                //DateTime dtPostDate6 = dtCurrent.AddSeconds(6);
                //sFileNameForAllItems = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtCurrent.ToString("yyyyMMddHHmmss") + "全件.csv";
                //// グループ１～５の操作ログファイル名を取得
                //sFileNameForGroupWork[0] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate1.ToString("yyyyMMddHHmmss") + ".csv";
                //sFileNameForGroupWork[1] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate2.ToString("yyyyMMddHHmmss") + ".csv";
                //sFileNameForGroupWork[2] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate3.ToString("yyyyMMddHHmmss") + ".csv";
                //sFileNameForGroupWork[3] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate4.ToString("yyyyMMddHHmmss") + ".csv";
                //sFileNameForGroupWork[4] = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate5.ToString("yyyyMMddHHmmss") + ".csv";
                //sFileNameForGroupWork[5] = "リジェクト".PadRight(16,'0') + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate6.ToString("yyyyMMddHHmmss") + ".csv";
                //CommonModule.OutPutLogFile($"sFileNameForGroupWork[0] = {sFileNameForGroupWork[0]}");
                //CommonModule.OutPutLogFile($"sFileNameForGroupWork[1] = {sFileNameForGroupWork[1]}");
                //CommonModule.OutPutLogFile($"sFileNameForGroupWork[2] = {sFileNameForGroupWork[2]}");
                //CommonModule.OutPutLogFile($"sFileNameForGroupWork[3] = {sFileNameForGroupWork[3]}");
                //CommonModule.OutPutLogFile($"sFileNameForGroupWork[4] = {sFileNameForGroupWork[4]}");
                //CommonModule.OutPutLogFile($"sFileNameForGroupWork[5] = {sFileNameForGroupWork[5]}");


                // JOB名までのフォルダ（全件）の存在チェックと作成
                sArray = LblSelectedFile.Text.Split('.');                
                sJobFolder = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder) +
                            ALL_FOLDER_NAME + sArray[0];
                if (Directory.Exists(sJobFolder) == false)
                {
                    Directory.CreateDirectory(sJobFolder);
                }
                // グループ６フォルダ（リジェクト用）の存在チェックと作成
                // 全件フォルダの配下に作成する
                sGroupName[5] = "リジェクト";
                sFolderNameWork[5] = "6_リジェクト";
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[5];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }

                // JOB名までのフォルダ（OKのみ）の存在チェックと作成
                sJobFolder = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder) + 
                            OK_FOLDER_NAME + sArray[0];
                if (Directory.Exists(sJobFolder) == false)
                {
                    Directory.CreateDirectory(sJobFolder);
                }
                // グループ６フォルダ（リジェクト用）の存在チェックと作成
                // 全件フォルダの配下に作成する                
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[5];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }

                // グループ１フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[0].Split(',');
                sGroupName[0] = sArray[0];
                sFolderNameWork[0] = "1_" + sArray[0];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[0];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }                
                // グループ２フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[1].Split(',');
                sGroupName[1] = sArray[0];
                sFolderNameWork[1] = "2_" + sArray[0];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[1];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }
                // グループ３フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[2].Split(',');                
                sGroupName[2] = sArray[0];
                sFolderNameWork[2] = "3_" + sArray[0];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[2];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }
                // グループ４フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[3].Split(',');
                sGroupName[3] = sArray[0];
                sFolderNameWork[3] = "4_" + sArray[0];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[3];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }
                // グループ５フォルダの存在チェックと作成
                sArray = PubConstClass.lstGroupInfo[4].Split(',');
                sGroupName[4] = sArray[0];
                sFolderNameWork[4] = "5_" + sArray[0];
                sGrpFolder = sJobFolder + "\\" + sFolderNameWork[4];
                if (Directory.Exists(sGrpFolder) == false)
                {
                    Directory.CreateDirectory(sGrpFolder);
                }

                //             0 1              2 3        4 5                  6 7                  8 9  0
                //コメリ①ハガキ,1,コメリ②ハガキ,2,武蔵野BK,3,西日本シティーBK①,4,西日本シティーBK②,5,50,50,50,50,50,ON,ON,ON,ON,ON,
                sArray = PubConstClass.lstPocketInfo[0].Split(',');

                // 現在の日付（年月日）を求める
                DateTime dtCurrent = DateTime.Now;
                // 現在日付から１秒～５秒を加算
                DateTime dtPostDate1 = dtCurrent.AddSeconds(1);
                DateTime dtPostDate2 = dtCurrent.AddSeconds(2);
                DateTime dtPostDate3 = dtCurrent.AddSeconds(3);
                DateTime dtPostDate4 = dtCurrent.AddSeconds(4);
                DateTime dtPostDate5 = dtCurrent.AddSeconds(5);
                DateTime dtPostDate6 = dtCurrent.AddSeconds(6);
                sFileNameForAllItems = sJobName + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtCurrent.ToString("yyyyMMddHHmmss") + "全件.csv";
                // グループ１～５の操作ログファイル名を取得
                sFileNameForGroupWork[0] = sGroupName[0] + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate1.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[1] = sGroupName[1] + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate2.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[2] = sGroupName[2] + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate3.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[3] = sGroupName[3] + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate4.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[4] = sGroupName[4] + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate5.ToString("yyyyMMddHHmmss") + ".csv";
                sFileNameForGroupWork[5] = "リジェクト".PadRight(16, '0') + sReasonForNonDelivery1 + sReasonForNonDelivery2 + sDate + dtPostDate6.ToString("yyyyMMddHHmmss") + ".csv";
                CommonModule.OutPutLogFile($"グループ１ = {sFileNameForGroupWork[0]}");
                CommonModule.OutPutLogFile($"グループ２ = {sFileNameForGroupWork[1]}");
                CommonModule.OutPutLogFile($"グループ３ = {sFileNameForGroupWork[2]}");
                CommonModule.OutPutLogFile($"グループ４ = {sFileNameForGroupWork[3]}");
                CommonModule.OutPutLogFile($"グループ５ = {sFileNameForGroupWork[4]}");
                CommonModule.OutPutLogFile($"リジェクト = {sFileNameForGroupWork[5]}");

                sFolderName1 = sFolderNameWork[int.Parse(sArray[1]) - 1];
                sFolderName2 = sFolderNameWork[int.Parse(sArray[3]) - 1];
                sFolderName3 = sFolderNameWork[int.Parse(sArray[5]) - 1];
                sFolderName4 = sFolderNameWork[int.Parse(sArray[7]) - 1];
                sFolderName5 = sFolderNameWork[int.Parse(sArray[9]) - 1];
                sFileNameForGroup1 = sFileNameForGroupWork[int.Parse(sArray[1]) - 1];
                sFileNameForGroup2 = sFileNameForGroupWork[int.Parse(sArray[3]) - 1];
                sFileNameForGroup3 = sFileNameForGroupWork[int.Parse(sArray[5]) - 1];
                sFileNameForGroup4 = sFileNameForGroupWork[int.Parse(sArray[7]) - 1];
                sFileNameForGroup5 = sFileNameForGroupWork[int.Parse(sArray[9]) - 1];
                CommonModule.OutPutLogFile($"ポケット１割当グループ名 = {sFileNameForGroup1}");
                CommonModule.OutPutLogFile($"ポケット２割当グループ名 = {sFileNameForGroup2}");
                CommonModule.OutPutLogFile($"ポケット３割当グループ名 = {sFileNameForGroup3}");
                CommonModule.OutPutLogFile($"ポケット４割当グループ名 = {sFileNameForGroup4}");
                CommonModule.OutPutLogFile($"ポケット５割当グループ名 = {sFileNameForGroup5}");

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
            try
            {
                if (LblSelectedFile.Text.Trim() != "")
                {
                    DialogResult dialogResult= MessageBox.Show("メニュー画面に戻りますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Cancel) {
                        // キャンセル
                        return;
                    }
                }
                // メニュー画面へ戻る
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnClose_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (bIsReset)
                {
                    bIsReset = false;
                    // シリアルデータ送信
                    SendSerialData(PubConstClass.CMD_SEND_d);
                    LblError.Visible = false;
                    // 停止中
                    SetStatus(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【TimDateTime_Tick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// シリアルデータ送信処理
        /// </summary>
        /// <param name="sData"></param>
        private void SendSerialData(string sData)
        {
            try
            {
                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(sData + "\r");
                SerialPortQr.Write(dat, 0, dat.GetLength(0));
                CommonModule.OutPutLogFile($"〓送信データ：{sData}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SendSerialData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // シリアルデータ送信
                SendSerialData(PubConstClass.CMD_SEND_b);
                // 検査開始時のチェック
                CheckStartUp();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "【BtnStartInspection_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 検査開始時のチェック
        /// </summary>
        private void CheckStartUp()
        {
            try
            {
                // エラー状況の非表示
                LblError.Visible = false;

                if (PubConstClass.sPrevDtpDateReceipt == "")
                {
                    // １回目の検査開始処理
                    CreateInspectionLogFolder();
                }
                else
                {
                    if (PubConstClass.sPrevDtpDateReceipt != DtpDateReceipt.Text ||
                        PubConstClass.sPrevNonDelivery1 != CmbNonDeliveryReasonSorting1.Text ||
                        PubConstClass.sPrevNonDelivery2 != CmbNonDeliveryReasonSorting2.Text)
                    {
                        // 受領日または不着事由仕分け１、２が変更された。
                        MessageBox.Show("JOB設定が変更されました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CreateInspectionLogFolder();
                    }
                }
                // 設定値の保存
                PubConstClass.sPrevDtpDateReceipt = DtpDateReceipt.Text;                // 前回の受領日
                PubConstClass.sPrevNonDelivery1 = CmbNonDeliveryReasonSorting1.Text;    // 前回の不着事由仕分け１
                PubConstClass.sPrevNonDelivery2 = CmbNonDeliveryReasonSorting2.Text;    // 前回の不着事由仕分け２
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckStartUp】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // シリアルデータ送信
                SendSerialData(PubConstClass.CMD_SEND_c);
                LblError.Visible = false;

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
                iStatus = status;

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
                        BtnClose.Enabled = true;                        
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
                        BtnClose.Enabled = false;
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
                CommonModule.OutPutLogFile("検査画面：「設定」ボタンクリック");
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
                data = SerialPortQr.ReadTo("\r");
                // 受信データの格納
                BeginInvoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), data.ToString() + "\r");
            }
            catch (TimeoutException)
            {
                // ディスカードするデータ
                CommonModule.OutPutLogFile("データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" + data);
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
                CommonModule.OutPutLogFile($"■受信データ：{data.Replace("\r", "<CR>")}");

                // 受信データの先頭１文字を取得
                string sCommandType = data.Substring(0, 1);
                switch (sCommandType)
                {
                    case PubConstClass.CMD_RECIEVE_A:
                        // JOB設定情報の送信
                        MyProcJobInfomation();
                        break;

                    case PubConstClass.CMD_RECIEVE_B:
                        // 開始コマンド
                        MyProcStart();
                        break;

                    case PubConstClass.CMD_RECIEVE_C:
                        // 停止コマンド
                        MyProcStop();
                        break;

                    case PubConstClass.CMD_RECIEVE_D:
                        // データコマンド
                        // 先頭2文字（D,）を取り除く
                        MyProcData(data.Substring(2, data.Length - 2));
                        break;

                    case PubConstClass.CMD_RECIEVE_E:
                        // エラーコマンド
                        MyProcError(data);
                        break;

                    case PubConstClass.CMD_RECIEVE_L:
                        // QR読取り直後データコマンド
                        MyProcQrData(data.Substring(2, data.Length - 2));
                        break;

                    case PubConstClass.CMD_RECIEVE_T:
                        // DIP-SW 情報送信
                        MyProcDipSw();
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
        /// JOB設定情報の送信
        /// </summary>
        private void MyProcJobInfomation()
        {
            string sData;
            
            try
            {
                if (LblSelectedFile.Text.Trim() == "")
                {
                    // JOBが未選択
                    // シリアルデータ送信
                    SendSerialData(PubConstClass.CMD_SEND_e);
                }
                else
                {
                    // フィーダー設定情報
                    string[] sArrayJob = PubConstClass.lstJobEntryList[0].Split(',');
                    //                    0      1             2   3  4   5      6 7 8      9 0 1            2  3 4      5   6  7  8  9  0  1 2 3  
                    // チューリッヒ１ハガキ,ハガキ,2025年1月10日,OFF,47,OFF,物件ID,1,5,届出日,6,8,ファイル区分,14,1,管理No.,15,10,ON,ON,ON,ON,1,1,
                    sData = PubConstClass.CMD_SEND_a + ",";
                    sData += sArrayJob[1] == "ハガキ" ? "0" : "1";    // (01) 媒体           ：1桁
                    sData += ",";
                    sData += sArrayJob[4].PadLeft(2, '0');            // (02) QR桁数         ：2桁
                    sData += ","; 
                    sData += sArrayJob[5] == "OFF" ? "0" : "1";       // (03) 読取チェック   ：1桁
                    sData += ","; 
                    sData += sArrayJob[7].PadLeft(2, '0');            // (04) QR読取項目1開始：2桁
                    sData += ","; 
                    sData += sArrayJob[8].PadLeft(2, '0');            // (05) QR読取項目1桁数：2桁                    
                    sData += ","; 
                    sData += sArrayJob[10].PadLeft(2, '0');           // (06) QR読取項目2開始：2桁
                    sData += ","; 
                    sData += sArrayJob[11].PadLeft(2, '0');           // (07) QR読取項目2桁数：2桁                    
                    sData += ","; 
                    sData += sArrayJob[13].PadLeft(2, '0');           // (08) QR読取項目3開始：2桁
                    sData += ","; 
                    sData += sArrayJob[14].PadLeft(2, '0');           // (09) QR読取項目3桁数：2桁                    
                    sData += ","; 
                    sData += sArrayJob[16].PadLeft(2, '0');           // (10) QR読取項目4開始：2桁
                    sData += ","; 
                    sData += sArrayJob[17].PadLeft(2, '0');           // (11) QR読取項目4桁数：2桁
                    sData += ",";
                    sData += sArrayJob[18] == "OFF" ? "0" : "1";      // (12) 重複検査　　　 ：1桁
                    sData += ",";
                    sData += sArrayJob[19] == "OFF" ? "0" : "1";      // (13) Ｗフィード検査 ：1桁
                    sData += ",";
                    sData += sArrayJob[20] == "OFF" ? "0" : "1";      // (14) 超音波検知　　 ：1桁
                    sData += ",";
                    sData += sArrayJob[21] == "OFF" ? "0" : "1";      // (15) 桁数チェック　 ：1桁
                    sData += ",";
                    sData += sArrayJob[22];                           // (16) 読取機能　　　 ：1桁

                    // シリアルデータ送信
                    SendSerialData(sData);
                    // コマンドは連続して送信しない
                    Thread.Sleep(50);
                    // ソーター設定のポケット１～５の情報を送信
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        MyprocPocket(iIndex);
                        // コマンドは連続して送信しない
                        Thread.Sleep(50);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcJobInfomation】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ソーター設定のポケット１～５の情報を送信
        /// </summary>
        /// <param name="iPocketNumber">0～4（ポケット１～５）</param>
        private void MyprocPocket(int iPocketNumber)
        {
            string sData;
            int iIndex;

            try
            {
                // ポケット設定情報
                string[] sArrayJob = PubConstClass.lstPocketInfo[0].Split(',');
                //              0 1              2 3        4 5                  6 7                  8 9  0  1  2  3  4  5  6  7  8  9
                // コメリ１ハガキ,1,コメリ２ハガキ,2,武蔵野BK,3,西日本シティーBK１,4,西日本シティーBK２,5,50,50,50,50,50,ON,ON,ON,ON,ON,

                iIndex = int.Parse(sArrayJob[iPocketNumber * 2 + 1]) - 1;

                string[] sArrayPocket = PubConstClass.lstGroupInfo[iIndex].Split(',');
                //        0     1        2 3          4
                // コメリ１,D4830,20241209,1,A123456789,
                // コメリ２,D4831,20241210,2,B123456789,
                // コメリ３,D4833,20241211,3,C123456789,
                // コメリ４,D4834,20241212,4,D123456789,
                // コメリ５,D4835,20241213,5,E123456789,

                sData = PubConstClass.CMD_SEND_f + ",";
                sData += (iPocketNumber + 1).ToString("0");                     // ポケット番号
                sData += ",";
                sData += sArrayPocket[1];                                       // 物件ID
                sData += ",";
                sData += sArrayPocket[2];                                       // 届出日
                sData += ",";
                sData += sArrayPocket[3];                                       // ファイル区分
                sData += ",";
                sData += sArrayPocket[4];                                       // 管理番号
                sData += ",";
                sData += sArrayJob[10 + iPocketNumber];                         // ポケット切替件数
                sData += ",";
                sData += sArrayJob[15 + iPocketNumber] == "OFF" ? "0": "1";     // ポケット切替ON/OFF
                // シリアルデータ送信
                SendSerialData(sData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyprocPocket】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 開始コマンド処理
        /// </summary>
        private void MyProcStart()
        {
            try
            {
                if (LblSelectedFile.Text.Trim() == "")
                {
                    // JOBが未選択
                    // シリアルデータ送信
                    SendSerialData(PubConstClass.CMD_SEND_e);
                    return;
                }
                // 検査中
                SetStatus(1);
                // 検査開始時のチェック
                CheckStartUp();
                // JOB設定情報の送信
                MyProcJobInfomation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcStart】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止コマンド処理
        /// </summary>
        private void MyProcStop()
        {
            try
            {
                // 停止中
                SetStatus(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcStop】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// エラーコマンド処理
        /// </summary>
        /// <param name="sData"></param>
        private void MyProcError(string sData)
        {
            string sErrorCode;

            try
            {
                LblError.Text = $"エラーコマンド「{sData.Replace("\r","<CR>")}」受信";
                LblError.Visible = true;

                // エラー
                SetStatus(2);

                sErrorCode = sData.Substring(2, 3);

                ErrorMessageForm form = ErrorMessageForm.GetInstance();
                //form.SetMessage($"{sData.Replace("\r", "<CR>")},{sData.Replace("\r", "<CR>")},{sData.Replace("\r", "<CR>")}");                
                if (PubConstClass.dicErrorCodeData.ContainsKey(sErrorCode))
                {
                    // 存在する場合
                    form.SetMessage($"{sErrorCode},{PubConstClass.dicErrorCodeData[sErrorCode]}");
                    CommonModule.OutPutLogFile($"エラー内容：{sErrorCode},{PubConstClass.dicErrorCodeData[sErrorCode]}");
                }
                else
                {
                    form.SetMessage($"{sErrorCode},未定義エラー番号,未定義のエラー番号です。");
                    CommonModule.OutPutLogFile($"エラー内容：{sErrorCode},未定義エラー番号,未定義のエラー番号です。");
                }

                if (!PubConstClass.bIsOpenErrorMessage)
                {
                    PubConstClass.bIsOpenErrorMessage = true;
                    // エラーダイアログ表示
                    form.ShowDialog();
                }
                else
                {
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcError】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// データコマンドの処理
        /// </summary>
        /// <param name="sData"></param>
        private void MyProcData(string sData)
        {
            string[] col = new string[12];
            ListViewItem itm1;
            ListViewItem itm2;
            string[] strArray;
            string sLogData = "";
            string sWriteDate;
            string sWriteTime;
            string sSaveFileName;
            string DQ = "\"";

            try
            {
                if (iStatus == 0)
                {
                    SendSerialData(PubConstClass.CMD_SEND_e);
                    return;
                }
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
                        CommonModule.OutPutLogFile($"重複データ：{strArray[0]}");
                    }
                    else
                    {
                        //CommonModule.OutPutLogFile($"最初のデータ：{lstPastReceivedQrData[0]}");
                        //CommonModule.OutPutLogFile($"最後のデータ：{lstPastReceivedQrData[lstPastReceivedQrData.Count - 1]}");                        
                    }
                    //CommonModule.OutPutLogFile($"{lstPastReceivedQrData.Count:#,###,##0}件の検索処理時間: {sw.Elapsed.TotalMilliseconds}ミリ秒");
                    #endregion
                }
                // 判定（OK/NG）
                col[3] = strArray[1].Trim() == "0" ? "OK": "NG";
                // トレイ情報
                col[4] = strArray[3].Trim();

                string sFolderName = "";
                string sFileName = "";

                switch (col[4])
                {
                    // トレイ情報の確認
                    case "1":
                        // ポケット１
                        iBox1Count++;
                        LblBox1.Text = iBox1Count.ToString("0");
                        LblPocket1.Text = col[2];
                        sFolderName = sFolderName1;
                        sFileName = sFileNameForGroup1;
                        break;
                    case "2":
                        // ポケット２
                        iBox2Count++;
                        LblBox2.Text = iBox2Count.ToString("0");
                        LblPocket2.Text = col[2];
                        sFolderName = sFolderName2;
                        sFileName = sFileNameForGroup2;
                        break;
                    case "3":
                        // ポケット３
                        iBox3Count++;
                        LblBox3.Text = iBox3Count.ToString("0");
                        LblPocket3.Text = col[2];
                        sFolderName = sFolderName3;
                        sFileName = sFileNameForGroup3;
                        break;
                    case "4":
                        // ポケット４
                        iBox4Count++;
                        LblBox4.Text = iBox4Count.ToString("0");
                        LblPocket4.Text = col[2];
                        sFolderName = sFolderName4;
                        sFileName = sFileNameForGroup4;
                        break;
                    case "5":
                        // ポケット５
                        iBox5Count++;
                        LblBox5.Text = iBox5Count.ToString("0");
                        LblPocket5.Text = col[2];
                        sFolderName = sFolderName5;
                        sFileName = sFileNameForGroup5;
                        break;
                    case "E":
                        // イジェクト
                        iBoxECount++;
                        LblBoxEject.Text = iBoxECount.ToString("0");
                        LblPocketEject.Text = col[2];
                        col[3]= "EJECT";
                        break;

                    default:
                        break;
                }
                sLogData += DQ + sWriteDate + DQ + ",";                             // 日付
                sLogData += DQ + sWriteTime + DQ + ",";                             // 時刻
                sLogData += DQ + DQ + ",";                                          // 期待値                       Null
                sLogData += DQ + strArray[0].Trim() + DQ + ",";                     // 読取値
                sLogData += DQ + col[3] + DQ + ",";                                 // 判定
                sLogData += DQ + sFileName + DQ + ",";                              // 正解データファイル名
                sLogData += DQ + DQ + ",";                                          // 重量期待値[g]				Null
                sLogData += DQ + DQ + ",";                                          // 重量測定値[g]				Null
                sLogData += DQ + DQ + ",";                                          // 重量公差						Null
                sLogData += DQ + DQ + ",";                                          // フラップ最大長[mm]			Null
                sLogData += DQ + DQ + ",";                                          // フラップ積算長[mm]			Null
                sLogData += DQ + DQ + ",";                                          // フラップ検出回数[回]			Null
                sLogData += DQ + DQ + ",";                                          // イベント（コメント）			Null
                sLogData += DQ + sDateOfReceipt + DQ + ",";                         // 受領日
                sLogData += DQ + PubConstClass.sUserId + DQ + ",";                  // 作業者情報                
                sLogData += DQ + strArray[0].Trim().Substring(0, 5) + DQ + ",";     // 物件ID
                sLogData += DQ + strArray[2] + DQ + ",";                            // エラー
                sLogData += DQ + DQ + ",";                                          // 生産管理番号					Null
                sLogData += DQ + sNonDeliveryReason1 + DQ + ",";                    // 仕分１
                sLogData += DQ + sNonDeliveryReason2 + DQ + ",";                    // 仕分２
                sLogData += DQ + DQ + ",";                                          // ファイル名（画像）			Null
                sLogData += DQ + DQ + ",";                                          // ファイルパス（画像）			Null
                sLogData += DQ + DQ + ",";                                          // 工場コード					Null

                // データの表示（判定が「OK」でトレイ情報が「E」以外）
                if (col[3] == "OK" && col[4] != "E")
                {
                    // 重複チェックの検査対象にする
                    lstPastReceivedQrData.Add(col[2]);
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
                    sSaveFileName += OK_FOLDER_NAME + sJobFolderName + "\\";
                    sSaveFileName += sFolderName + "\\";
                    sSaveFileName += sFileName;
                    // ヘッダー情報書込処理
                    if (!File.Exists(sSaveFileName))
                    {
                        using (StreamWriter sw = new StreamWriter(sSaveFileName, true, Encoding.Default))
                        {
                            // 書込ファイルが無かったらヘッダー情報を書込
                            sw.WriteLine(GetHederInfo());
                        }
                    }
                    // 検査データ書込処理
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
                sSaveFileName += ALL_FOLDER_NAME + sJobFolderName + "\\";
                sSaveFileName += sFileNameForAllItems;
                // ヘッダー情報書込処理
                if (!File.Exists(sSaveFileName))
                {
                    using (StreamWriter sw = new StreamWriter(sSaveFileName, true, Encoding.Default))
                    {
                        // 書込ファイルが無かったらヘッダー情報を書込
                        sw.WriteLine(GetHederInfo());
                    }
                }
                // 検査データ書込処理
                using (StreamWriter sw = new StreamWriter(sSaveFileName, true, Encoding.Default))
                {
                    // 全件データを追加モードで書き込む
                    sw.WriteLine(sLogData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonModule.OutPutLogFile("【MyProcData】" + ex.Message);
            }
        }

        /// <summary>
        /// QR読取り直後データの表示
        /// </summary>
        /// <param name="sData"></param>
        private void MyProcQrData(string sData)
        {
            try
            {
                LblQrReadData.Text = sData.Replace("\r","<CR>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcQrData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonModule.OutPutLogFile("【MyProcQrData】" + ex.Message);
            }
        }

        /// <summary>
        /// DIP-SW情報の送信
        /// </summary>
        private void MyProcDipSw()
        {
            string sData;

            try
            {
                sData = PubConstClass.CMD_SEND_t + "," + PubConstClass.pblDipSw;
                // シリアルデータ送信
                SendSerialData(sData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcQrData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonModule.OutPutLogFile("【MyProcQrData】" + ex.Message);
            }
        }

        /// <summary>
        /// ヘッダーデータの取得
        /// </summary>
        /// <returns></returns>
        private string GetHederInfo()
        {
            string sHeader = "";
            
            try
            {                
                sHeader += "\"日付\",";
                sHeader += "\"時刻\",";
                sHeader += "\"期待値\",";
                sHeader += "\"読取値\",";
                sHeader += "\"判定\",";
                sHeader += "\"正解データファイル名\",";
                sHeader += "\"重量期待値[g]\",";
                sHeader += "\"重量測定値[g]\",";
                sHeader += "\"重量公差\",";
                sHeader += "\"フラップ最大長[mm]\",";
                sHeader += "\"フラップ積算長[mm]\",";
                sHeader += "\"フラップ検出回数[回]\",";
                sHeader += "\"イベント（コメント）\",";
                sHeader += "\"受領日\",";
                sHeader += "\"作業員情報（機械情報）\",";
                sHeader += "\"物件情報（DPS/BPO/Broad等）\",";
                sHeader += "\"エラーコード\",";
                sHeader += "\"生産管理番号\",";
                sHeader += "\"仕分けコード１\",";
                sHeader += "\"仕分けコード２\",";
                sHeader += "\"ファイル名（画像）\",";
                sHeader += "\"ファイルパス（画像）\",";
                sHeader += "\"工場コード\",";
                return sHeader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetHederInfo】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return sHeader;
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
                CommonModule.OutPutLogFile("データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" + data);
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

                CommonModule.OutPutLogFile("「JOB選択」ボタンクリック");
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
                    // 受領日
                    DtpDateReceipt.Enabled = bDateOfReceipt;
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
            string[] sArray;
            try
            {
                sArray = PubConstClass.lstJobEntryList[0].Split(',');
                // 受領日
                DtpDateReceipt.Text = sArray[2];
                // 受領日入力
                bDateOfReceipt = sArray[3] == "ON";

                sArray = PubConstClass.lstPocketInfo[0].Split(',');
                // ポケット①名称
                LblBoxTitle1.Text = "【BOX1】 " + sArray[0];
                // ポケット②名称
                LblBoxTitle2.Text = "【BOX2】 " + sArray[2];
                // ポケット③名称
                LblBoxTitle3.Text = "【BOX3】 " + sArray[4];
                // ポケット④名称
                LblBoxTitle4.Text = "【BOX4】 " + sArray[6];
                // ポケット⑤名称
                LblBoxTitle5.Text = "【BOX5】 " + sArray[8];

                // ポケット１切替件数
                LblQuantity1.Text = sArray[15] == "ON" ? sArray[10] : "---";
                // ポケット２切替件数
                LblQuantity2.Text = sArray[16] == "ON" ? sArray[11] : "---";
                // ポケット３切替件数
                LblQuantity3.Text = sArray[17] == "ON" ? sArray[12] : "---";
                // ポケット４切替件数
                LblQuantity4.Text = sArray[18] == "ON" ? sArray[13] : "---";
                // ポケット５切替件数
                LblQuantity5.Text = sArray[19] == "ON" ? sArray[14] : "---";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetEntryInfoAndDisplay】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private static bool bIsReset = false;
        public static void SendResetCommand()
        {
            try
            {
                bIsReset = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SendResetCommand】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
