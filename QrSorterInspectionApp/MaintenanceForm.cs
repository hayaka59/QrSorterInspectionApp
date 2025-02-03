﻿using System;
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
    public partial class MaintenanceForm : Form
    {
        private delegate void Delegate_RcvDataToTextBox(string data);

        private string[] sDipSwitch = new string[16] {"1","0","1","0","1","0","1","0","1","0","1","0","1","0","1","0" };

        public MaintenanceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("保守画面を表示しました");

                CommonModule.ReadSystemDefinition();

                // 号機名
                TxtMachineName.Text = PubConstClass.pblMachineName;

                #region ログ保存
                CmbSaveMonth.Items.Clear();
                for (int N = 1; N <= 36; N++)
                {
                    CmbSaveMonth.Items.Add(N.ToString() + "ヶ月");
                }                
                if (PubConstClass.pblSaveLogMonth != "")
                {
                    CmbSaveMonth.SelectedIndex = Convert.ToInt32(PubConstClass.pblSaveLogMonth) - 1;
                }
                else
                {
                    CmbSaveMonth.SelectedIndex = 0;
                }
                #endregion

                // ディスク空き容量チェック
                TxtHddSpace.Text = PubConstClass.pblHddSpace;

                // 内部実績ログ格納フォルダ
                TxtInternalTran.Text = PubConstClass.pblInternalTranFolder;

                // COMポート名
                CmbComPort.Items.Clear();
                for (int iIndex = 1; iIndex <= 15; iIndex++)
                    CmbComPort.Items.Add("COM" + Convert.ToString(iIndex));
                CmbComPort.SelectedIndex = Convert.ToInt32(PubConstClass.pblComPort.Substring(3, 1)) - 1;
                
                // COM通信速度
                CmbComSpeed.Items.Clear();
                CmbComSpeed.Items.Add("4800");
                CmbComSpeed.Items.Add("9600");
                CmbComSpeed.Items.Add("19200");
                CmbComSpeed.Items.Add("38400");
                CmbComSpeed.Items.Add("57600");
                CmbComSpeed.Items.Add("115200");
                CmbComSpeed.SelectedIndex = Convert.ToInt32(PubConstClass.pblComSpeed);
                
                // COMデータ長
                CmbComDataLength.Items.Clear();
                CmbComDataLength.Items.Add("8bit");
                CmbComDataLength.Items.Add("7bit");
                CmbComDataLength.SelectedIndex = Convert.ToInt32(PubConstClass.pblComDataLength);
                
                // COMパリティの有無
                CmbComIsParty.Items.Clear();
                CmbComIsParty.Items.Add("無効");
                CmbComIsParty.Items.Add("有効");
                CmbComIsParty.SelectedIndex = Convert.ToInt32(PubConstClass.pblComIsParity);
                
                // COMパリティ種別
                CmbComParityVar.Items.Clear();
                CmbComParityVar.Items.Add("奇数");
                CmbComParityVar.Items.Add("偶数");
                CmbComParityVar.SelectedIndex = Convert.ToInt32(PubConstClass.pblComParityVar);
                
                // COMストップビット
                CmbComStopBit.Items.Clear();
                CmbComStopBit.Items.Add("1bit");
                CmbComStopBit.Items.Add("2bit");
                CmbComStopBit.SelectedIndex = Convert.ToInt32(PubConstClass.pblComStopBit);

                // 不着事由情報ファイル読込
                CommonModule.ReadNonDeliveryList();
                // 仕分けマスタの内容表示
                NonDeliveryMaintenance();

                // パネルDIPINFO
                string fileName = Application.StartupPath.ToString() + @"\PANELDIPINFO.txt";
                if (File.Exists(fileName))
                {
                    using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding(932)))
                    {
                        do
                        {
                            String line = sr.ReadLine();
                            String[] items = line.Split(',');
                            ListViewItem row = new ListViewItem(items)
                            {
                                UseItemStyleForSubItems = false
                            };
                            LstPanelDipInfo.Items.Add(row);

                        } while (!sr.EndOfStream);
                    }
                }

                // 「装置状態」タブの名称設定
                ReadInputAndOutputFileData();

                // 定義ファイルからのDIP SWの値を展開
                for (int iIndex = 0; iIndex < sDipSwitch.Length; iIndex++)
                {
                    sDipSwitch[iIndex] = PubConstClass.pblDipSw.Substring(iIndex, 1);
                }
                // DIP SW の状態を更新
                UpdateDipSwitchStatus();

                #region シリアルポートの設定
                // データ受信イベントの設定
                SerialPortMaint.DataReceived += new SerialDataReceivedEventHandler(SerialPortMaint_DataReceived);
                // シリアルポート名の設定
                SerialPortMaint.PortName = PubConstClass.pblComPort;
                // シリアルポートの通信速度指定
                switch (PubConstClass.pblComSpeed)
                {
                    case "0":
                        {
                            SerialPortMaint.BaudRate = 4800;
                            break;
                        }

                    case "1":
                        {
                            SerialPortMaint.BaudRate = 9600;
                            break;
                        }

                    case "2":
                        {
                            SerialPortMaint.BaudRate = 19200;
                            break;
                        }

                    case "3":
                        {
                            SerialPortMaint.BaudRate = 38400;
                            break;
                        }

                    case "4":
                        {
                            SerialPortMaint.BaudRate = 57600;
                            break;
                        }

                    case "5":
                        {
                            SerialPortMaint.BaudRate = 115200;
                            break;
                        }

                    default:
                        {
                            SerialPortMaint.BaudRate = 38400;
                            break;
                        }
                }
                // シリアルポートのパリティ指定
                switch (PubConstClass.pblComParityVar)
                {
                    case "0":
                        {
                            SerialPortMaint.Parity = Parity.Odd;
                            break;
                        }

                    case "1":
                        {
                            SerialPortMaint.Parity = Parity.Even;
                            break;
                        }

                    default:
                        {
                            SerialPortMaint.Parity = Parity.Even;
                            break;
                        }
                }
                // シリアルポートのパリティ有無
                if (PubConstClass.pblComIsParity == "0")
                    SerialPortMaint.Parity = Parity.None;
                // シリアルポートのビット数指定
                switch (PubConstClass.pblComDataLength)
                {
                    case "0":
                        {
                            SerialPortMaint.DataBits = 8;
                            break;
                        }

                    case "1":
                        {
                            SerialPortMaint.DataBits = 7;
                            break;
                        }

                    default:
                        {
                            SerialPortMaint.DataBits = 8;
                            break;
                        }
                }
                // シリアルポートのストップビット指定
                switch (PubConstClass.pblComStopBit)
                {
                    case "0":
                        {
                            SerialPortMaint.StopBits = StopBits.One;
                            break;
                        }

                    case "1":
                        {
                            SerialPortMaint.StopBits = StopBits.Two;
                            break;
                        }

                    default:
                        {
                            SerialPortMaint.StopBits = StopBits.One;
                            break;
                        }
                }
                #endregion
                // シリアルポートのオープン
                SerialPortMaint.Open();
                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_m + ",1" + "\r");
                SerialPortMaint.Write(dat, 0, dat.GetLength(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MaintenanceForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (SerialPortMaint.IsOpen)
                {
                    // 送信データのセット
                    byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_m + ",0" + "\r");
                    SerialPortMaint.Write(dat, 0, dat.GetLength(0));
                    // シリアルポートクローズ
                    SerialPortMaint.Close();
                }
                Owner.Show();
                Owner.Refresh();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnClose_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「適用」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;

            try
            {
                dialogResult = MessageBox.Show("設定を保存しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    // 号機名称
                    PubConstClass.pblMachineName = TxtMachineName.Text;
                    // ディスク空き容量
                    PubConstClass.pblHddSpace = TxtHddSpace.Text;
                    // ログの保存期間
                    PubConstClass.pblSaveLogMonth = (CmbSaveMonth.SelectedIndex + 1).ToString();
                    // DIP SW
                    PubConstClass.pblDipSw = "";
                    for (int iIndex = 0; iIndex < sDipSwitch.Length; iIndex++)
                    {
                        PubConstClass.pblDipSw += sDipSwitch[iIndex];
                    }
                    // 通信設定
                    PubConstClass.pblComPort = CmbComPort.SelectedItem.ToString();
                    PubConstClass.pblComSpeed = CmbComSpeed.SelectedIndex.ToString();
                    PubConstClass.pblComDataLength = CmbComDataLength.SelectedIndex.ToString();
                    PubConstClass.pblComIsParity = CmbComIsParty.SelectedIndex.ToString();
                    PubConstClass.pblComParityVar = CmbComParityVar.SelectedIndex.ToString();
                    PubConstClass.pblComStopBit = CmbComStopBit.SelectedIndex.ToString();

                    // 内部実績ログ格納フォルダ
                    PubConstClass.pblInternalTranFolder = TxtInternalTran.Text;

                    // システム定義ファイルの書き込み処理
                    CommonModule.WriteSystemDefinition();

                    // ディスクの空き領域をチェック
                    CommonModule.CheckAvairableFreeSpace();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【BtnApply_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEncript_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;
                string outputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + 
                                    PubConstClass.DEF_USER_ACCOUNT_ENC_FILE_NAME;
                // 8文字のキー（DESは64ビット長のキーを使用）
                string key = PubConstClass.DEF_DES_KEY;

                CommonModule.EncryptFile(inputFile, outputFile, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEncript_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「復号」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecript_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_ENC_FILE_NAME;
                string outputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;
                // 8文字のキー（DESは64ビット長のキーを使用）
                string key = PubConstClass.DEF_DES_KEY;

                CommonModule.DecryptFile(inputFile, outputFile, key);

                CommonModule.ReadUserAccountFile();

                TxtUserAccount.Text = "";
                foreach (var item in PubConstClass.lstUserAccount)
                {
                    TxtUserAccount.Text += item + Environment.NewLine;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDecript_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblVersion_DoubleClick(object sender, EventArgs e)
        {
            BtnDecript.Visible = true;
            TxtUserAccount.Visible = true;
        }

        private void LblVersion_Click(object sender, EventArgs e)
        {

        }

        private void BtnInternalTran_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            try
            {
                fbd.Description = "内部実績ログ格納フォルダを選択してください。";

                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.SelectedPath = PubConstClass.pblInternalTranFolder;

                // 新規フォルダ作成を表示
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog(this) == DialogResult.OK)
                    // 選択されたフォルダを表示する
                    TxtInternalTran.Text = fbd.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnInternalTran_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログデータ手動削除」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteLogData_Click(object sender, EventArgs e)
        {
            try
            {
                // 現在の日付（年月日）を求める
                DateTime dtCurrent = DateTime.Now;

                int intMinusMonth = CmbSaveMonth.SelectedIndex;
                // 現在日付から１ヶ月を減算
                DateTime dtPassDate = dtCurrent.AddMonths(-(intMinusMonth + 1));

                DialogResult dialogResult = MessageBox.Show($"現在の日付から{intMinusMonth + 1}ヶ月前は、{dtPassDate}です。" +
                                                            $"{Environment.NewLine}それ以前のデータを削除しますか？",
                                                            "確認", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                CommonModule.DeleteLogFiles(intMinusMonth + 1);

                MessageBox.Show("削除処理が完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【メンテンス画面】【BtnDeleteLogData_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 仕分けマスタの内容表示（テキスト及びリストビュー）
        /// </summary>
        private void NonDeliveryMaintenance()
        {
            string[] col = new string[10];
            string[] sAray;
            ListViewItem itm;

            try
            {
                // 仕分けマスタ（テキスト領域）にデータ表示
                TxtNonDelivery.Text = "";
                for (int iIndex = 0; iIndex < PubConstClass.lstNonDeliveryList.Count; iIndex++)
                {
                    if (iIndex == PubConstClass.lstNonDeliveryList.Count - 1)
                    {
                        TxtNonDelivery.Text += PubConstClass.lstNonDeliveryList[iIndex];
                    }
                    else
                    {
                        TxtNonDelivery.Text += PubConstClass.lstNonDeliveryList[iIndex] + Environment.NewLine;
                    }
                }

                // 仕分けマスタ（リストビュー領域）にデータ表示
                LblNonDelivery.Text = "仕分け一覧";

                // 仕分けマスタ表示ListViewのカラムヘッダー設定
                LstNonDelivery.View = View.Details;
                ColumnHeader col1 = new ColumnHeader();
                ColumnHeader col2 = new ColumnHeader();

                col1.Text = "番号";
                col2.Text = "仕分け項目";

                col1.TextAlign = HorizontalAlignment.Center;
                col2.TextAlign = HorizontalAlignment.Left;

                col1.Width = 70;    // 番号
                col2.Width = 250;   // 仕分け項目

                ColumnHeader[] colHeader = new[] { col1, col2 };
                LstNonDelivery.Columns.AddRange(colHeader);

                int iCount = 0;
                // 生協・デポ一覧ファイル格納リスト取得
                foreach (string sData in PubConstClass.lstNonDeliveryList)
                {
                    sAray = sData.Split(',');
                    col[0] = "　" + sAray[0];
                    col[1] = sAray[1];
                    iCount++;
                    // データの表示
                    itm = new ListViewItem(col);
                    LstNonDelivery.Items.Add(itm);
                    LstNonDelivery.Items[LstNonDelivery.Items.Count - 1].UseItemStyleForSubItems = false;
                    if (LstNonDelivery.Items.Count % 2 == 1)
                    {
                        for (int iIndex = 0; iIndex < 2; iIndex++)
                        {
                            // 奇数行の色反転
                            LstNonDelivery.Items[LstNonDelivery.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                        }
                    }
                }
                LblCount.Text = $"表示件数：{iCount} 件";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CoopDepoMaintenance】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「仕分けマスタの保存」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNonDeliverySave_Click(object sender, EventArgs e)
        {
            try
            {
                //// 生協・デポ入力データの妥当性チェック
                //bRet = CoopAndDepoInputValidation(TxtCoopDepo.Text);
                //if (!bRet)
                //{
                //    // 妥当性チェックエラー
                //    return;
                //}
                DialogResult dResult = MessageBox.Show("仕分けマスタファイルを保存しますか？", "保存確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dResult == DialogResult.No)
                {
                    // 保存しない
                    return;
                }
                // 仕分けマスタの書込
                CommonModule.WriteNonDeliveryList(TxtNonDelivery.Text);
                // 不着事由情報ファイルの読込
                CommonModule.ReadNonDeliveryList();
                LstNonDelivery.Clear();
                // 仕分けマスタの内容表示
                 NonDeliveryMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnNonDeliverySave_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        /// <summary>
        /// 入出力用ポート名の表示
        /// </summary>
        private void ReadInputAndOutputFileData()
        {
            try
            {
                String sBasePath = Application.StartupPath.ToString();
                String filePath = sBasePath + @"\InputName.txt";
                if (File.Exists(filePath))
                {
                    // ファイルが存在する場合は読み込む
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis")))
                    {
                        do
                        {
                            for (int N = 1; N <= 16; N++)
                            {
                                String s = sr.ReadLine();
                                switch (N)
                                {
                                    case 1:
                                        LblInputPortName1.Text = s;
                                        break;
                                    case 2:
                                        LblInputPortName2.Text = s;
                                        break;
                                    case 3:
                                        LblInputPortName3.Text = s;
                                        break;
                                    case 4:
                                        LblInputPortName4.Text = s;
                                        break;
                                    case 5:
                                        LblInputPortName5.Text = s;
                                        break;
                                    case 6:
                                        LblInputPortName6.Text = s;
                                        break;
                                    case 7:
                                        LblInputPortName7.Text = s;
                                        break;
                                    case 8:
                                        LblInputPortName8.Text = s;
                                        break;
                                    case 9:
                                        LblInputPortName9.Text = s;
                                        break;
                                    case 10:
                                        LblInputPortName10.Text = s;
                                        break;
                                    case 11:
                                        LblInputPortName11.Text = s;
                                        break;
                                    case 12:
                                        LblInputPortName12.Text = s;
                                        break;
                                    case 13:
                                        LblInputPortName13.Text = s;
                                        break;
                                    case 14:
                                        LblInputPortName14.Text = s;
                                        break;
                                    case 15:
                                        LblInputPortName15.Text = s;
                                        break;
                                    case 16:
                                        LblInputPortName16.Text = s;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;

                        } while (!sr.EndOfStream);
                    }
                }

                filePath = sBasePath + @"\OutputName.txt";
                if (File.Exists(filePath))
                {
                    // ファイルが存在する場合は読み込む
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("shift_jis")))
                    {
                        do
                        {
                            for (int N = 1; N <= 16; N++)
                            {
                                String s = sr.ReadLine();
                                switch (N)
                                {
                                    case 1:
                                        RdoOutPut1.Text = s;
                                        break;
                                    case 2:
                                        RdoOutPut2.Text = s;
                                        break;
                                    case 3:
                                        RdoOutPut3.Text = s;
                                        break;
                                    case 4:
                                        RdoOutPut4.Text = s;
                                        break;
                                    case 5:
                                        RdoOutPut5.Text = s;
                                        break;
                                    case 6:
                                        RdoOutPut6.Text = s;
                                        break;
                                    case 7:
                                        RdoOutPut7.Text = s;
                                        break;
                                    case 8:
                                        RdoOutPut8.Text = s;
                                        break;
                                    case 9:
                                        RdoOutPut9.Text = s;
                                        break;
                                    case 10:
                                        RdoOutPut10.Text = s;
                                        break;
                                    case 11:
                                        RdoOutPut11.Text = s;
                                        break;
                                    case 12:
                                        RdoOutPut12.Text = s;
                                        break;
                                    case 13:
                                        RdoOutPut13.Text = s;
                                        break;
                                    case 14:
                                        RdoOutPut14.Text = s;
                                        break;
                                    case 15:
                                        RdoOutPut15.Text = s;
                                        break;
                                    case 16:
                                        RdoOutPut16.Text = s;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;

                        } while (!sr.EndOfStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadInputAndOutputFileData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        private void SetDipSwitch(int row, string sDipSwitch, Button btnDipOn, Button btnDipOff)
        {
            if (sDipSwitch == "1")
            {
                btnDipOn.Visible = true;
                btnDipOff.Visible = false;
                LstPanelDipInfo.Items[row].SubItems[1].BackColor = Color.Yellow;
                LstPanelDipInfo.Items[row].SubItems[1].ForeColor = Color.Black;
                LstPanelDipInfo.Items[row].SubItems[2].BackColor = Color.White;
                LstPanelDipInfo.Items[row].SubItems[2].ForeColor = Color.Black;
            }
            else
            {
                btnDipOn.Visible = false;
                btnDipOff.Visible = true;
                LstPanelDipInfo.Items[row].SubItems[1].BackColor = Color.White;
                LstPanelDipInfo.Items[row].SubItems[1].ForeColor = Color.Black;
                LstPanelDipInfo.Items[row].SubItems[2].BackColor = Color.Yellow;
                LstPanelDipInfo.Items[row].SubItems[2].ForeColor = Color.Black;
            }
        }

        private void UpdateDipSwitchStatus()
        {
            try
            {
                SetDipSwitch(0, sDipSwitch[0], BtnDipOn1, BtnDipOff1);
                SetDipSwitch(1, sDipSwitch[1], BtnDipOn2, BtnDipOff2);
                SetDipSwitch(2, sDipSwitch[2], BtnDipOn3, BtnDipOff3);
                SetDipSwitch(3, sDipSwitch[3], BtnDipOn4, BtnDipOff4);
                SetDipSwitch(4, sDipSwitch[4], BtnDipOn5, BtnDipOff5);
                SetDipSwitch(5, sDipSwitch[5], BtnDipOn6, BtnDipOff6);
                SetDipSwitch(6, sDipSwitch[6], BtnDipOn7, BtnDipOff7);
                SetDipSwitch(7, sDipSwitch[7], BtnDipOn8, BtnDipOff8);
                SetDipSwitch(8, sDipSwitch[8], BtnDipOn9, BtnDipOff9);
                SetDipSwitch(9, sDipSwitch[9], BtnDipOn10, BtnDipOff10);
                SetDipSwitch(10, sDipSwitch[10], BtnDipOn11, BtnDipOff11);
                SetDipSwitch(11, sDipSwitch[11], BtnDipOn12, BtnDipOff12);
                SetDipSwitch(12, sDipSwitch[12], BtnDipOn13, BtnDipOff13);
                SetDipSwitch(13, sDipSwitch[13], BtnDipOn14, BtnDipOff14);
                SetDipSwitch(14, sDipSwitch[14], BtnDipOn15, BtnDipOff15);
                SetDipSwitch(15, sDipSwitch[15], BtnDipOn16, BtnDipOff16);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【メンテンス画面】【UpdateDipSwitchStatus】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDipOn1_Click(object sender, EventArgs e)
        {
            sDipSwitch[0] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff1_Click(object sender, EventArgs e)
        {
            sDipSwitch[0] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn2_Click(object sender, EventArgs e)
        {
            sDipSwitch[1] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff2_Click(object sender, EventArgs e)
        {
            sDipSwitch[1] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn3_Click(object sender, EventArgs e)
        {
            sDipSwitch[2] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff3_Click(object sender, EventArgs e)
        {
            sDipSwitch[2] = "1";
            UpdateDipSwitchStatus();

        }

        private void BtnDipOn4_Click(object sender, EventArgs e)
        {
            sDipSwitch[3] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff4_Click(object sender, EventArgs e)
        {
            sDipSwitch[3] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn5_Click(object sender, EventArgs e)
        {
            sDipSwitch[4] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff5_Click(object sender, EventArgs e)
        {
            sDipSwitch[4] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn6_Click(object sender, EventArgs e)
        {
            sDipSwitch[5] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff6_Click(object sender, EventArgs e)
        {
            sDipSwitch[5] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn7_Click(object sender, EventArgs e)
        {
            sDipSwitch[6] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff7_Click(object sender, EventArgs e)
        {
            sDipSwitch[6] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn8_Click(object sender, EventArgs e)
        {
            sDipSwitch[7] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff8_Click(object sender, EventArgs e)
        {
            sDipSwitch[7] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn9_Click(object sender, EventArgs e)
        {
            sDipSwitch[8] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff9_Click(object sender, EventArgs e)
        {
            sDipSwitch[8] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn10_Click(object sender, EventArgs e)
        {
            sDipSwitch[9] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff10_Click(object sender, EventArgs e)
        {
            sDipSwitch[9] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn11_Click(object sender, EventArgs e)
        {
            sDipSwitch[10] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff11_Click(object sender, EventArgs e)
        {
            sDipSwitch[10] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn12_Click(object sender, EventArgs e)
        {
            sDipSwitch[11] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff12_Click(object sender, EventArgs e)
        {
            sDipSwitch[11] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn13_Click(object sender, EventArgs e)
        {
            sDipSwitch[12] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff13_Click(object sender, EventArgs e)
        {
            sDipSwitch[12] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn14_Click(object sender, EventArgs e)
        {
            sDipSwitch[13] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff14_Click(object sender, EventArgs e)
        {
            sDipSwitch[13] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn15_Click(object sender, EventArgs e)
        {
            sDipSwitch[14] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff15_Click(object sender, EventArgs e)
        {
            sDipSwitch[14] = "1";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOn16_Click(object sender, EventArgs e)
        {
            sDipSwitch[15] = "0";
            UpdateDipSwitchStatus();
        }

        private void BtnDipOff16_Click(object sender, EventArgs e)
        {
            sDipSwitch[15] = "1";
            UpdateDipSwitchStatus();
        }

        /// <summary>
        /// 検査装置からのデータ受信処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void SerialPortMaint_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data;
            object[] args = new object[1];

            data = "";

            try
            {
                // シリアルポートをオープンしていない場合、処理を行わない。
                if (SerialPortMaint.IsOpen == false)
                    return;
                // <CR>まで読み込む
                data = SerialPortMaint.ReadTo("\r");

                // 受信データの格納
                BeginInvoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), data.ToString() + "\r");
            }
            catch (TimeoutException)
            {
                // ディスカードするデータ
                CommonModule.OutPutLogFile("【保守画面】データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" + data);
            }
            catch (Exception ex)
            {
                CommonModule.OutPutLogFile("【保守画面】SerialPortMaint_DataReceived" + ex.Message);
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
                CommonModule.OutPutLogFile($"【保守画面】受信データ：{data.Replace("\r", "<CR>")}");

                // 受信データの先頭１文字を取得
                string sCommandType = data.Substring(0, 1);
                switch (sCommandType)
                {
                    case PubConstClass.CMD_RECIEVE_K:
                        // I/O状態コマンド
                        MyProcIOStatus(data);
                        break;

                    case PubConstClass.CMD_RECIEVE_I:
                        // アワーメーター表示コマンド
                        MyProcHourMeter(data);
                        break;

                    case PubConstClass.CMD_RECIEVE_J:
                        // トータルカウンタ表示コマンド
                        MyProcTotalCounter(data);
                        break;

                    case PubConstClass.CMD_RECIEVE_T:
                        // DIP-SW情報要求コマンド
                        MyProcDipSw();
                        break;

                    default:
                        // 未定義コマンド
                        CommonModule.OutPutLogFile($"【保守画面】未定義コマンドです：{data.Replace("\r", "<CR>")}");
                        break;
                }
            }
            catch (Exception ex)
            {
                strMessage = "【保守画面】RcvDataToTextBox" + ex.Message;
                CommonModule.OutPutLogFile(strMessage);
                MessageBox.Show(strMessage, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        /// <summary>
        /// I/O状態表示コマンド処理
        /// </summary>
        /// <param name="data"></param>
        private void MyProcIOStatus(string data)
        {
            string sIndex;
            string sData;

            try
            {
                sIndex = data.Substring(1, 1);
                sData = data.Substring(2, data.Length - 2);
                switch (sIndex)
                {
                    case "0":
                        LblDispInPut1.Text = sData;
                        break;
                    case "1":
                        LblDispInPut2.Text = sData;
                        break;
                    case "2":
                        LblDispInPut3.Text = sData;
                        break;
                    case "3":
                        LblDispInPut4.Text = sData;
                        break;
                    case "4":
                        LblDispInPut5.Text = sData;
                        break;
                    case "5":
                        LblDispInPut6.Text = sData;
                        break;
                    case "6":
                        LblDispInPut7.Text = sData;
                        break;
                    case "7":
                        LblDispInPut8.Text = sData;
                        break;
                    case "8":
                        LblDispInPut9.Text = sData;
                        break;
                    case "9":
                        LblDispInPut10.Text = sData;
                        break;
                    case "A":
                        LblDispInPut11.Text = sData;
                        break;
                    case "B":
                        LblDispInPut12.Text = sData;
                        break;
                    case "C":
                        LblDispInPut13.Text = sData;
                        break;
                    case "D":
                        LblDispInPut14.Text = sData;
                        break;
                    case "E":
                        LblDispInPut15.Text = sData;
                        break;
                    case "F":
                        LblDispInPut16.Text = sData;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【保守画面】【MyProcIOStatus】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// アワーメーター表示処理
        /// </summary>
        /// <param name="data"></param>
        private void MyProcHourMeter(string data)
        {
            string sData;

            try
            {                
                sData = data.Substring(2, data.Length - 3);
                LblHourMeter.Text = sData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【保守画面】【MyProcHourMeter】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// トータルカウンタ表示処理
        /// </summary>
        /// <param name="data"></param>
        private void MyProcTotalCounter(string data)
        {
            string sData;

            try
            {
                sData = data.Substring(2, data.Length - 3);
                LblTotalCounter.Text = sData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【保守画面】【MyProcTotalCounter】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// DIP-SW情報送信
        /// </summary>
        private void MyProcDipSw()
        {
            string sData = "";
            try
            {
                sData = PubConstClass.CMD_SEND_t + ",";
                for (int iIndex = 0; iIndex < 16; iIndex++) {
                    sData += sDipSwitch[15 - iIndex];
                }
                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(sData + "\r");
                SerialPortMaint.Write(dat, 0, dat.GetLength(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【保守画面】【MyProcDipSw】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「クリア」ボタン処理（アワーメーター）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTimeClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Ctrlキーが押されているかのチェック
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    DialogResult dialogResult = MessageBox.Show("アワーメーターをクリアしますか？","確認",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        // 送信データのセット
                        byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_i + "\r");
                        SerialPortMaint.Write(dat, 0, dat.GetLength(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【保守画面】【BtnTimeClear_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「クリア」ボタン処理（トータルカウンタ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCounterClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Shiftキーが押されているかのチェック
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    DialogResult dialogResult = MessageBox.Show("トータルカウンタをクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        // 送信データのセット
                        byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(PubConstClass.CMD_SEND_j + "\r");
                        SerialPortMaint.Write(dat, 0, dat.GetLength(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【保守画面】【BtnCounterClear_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
