using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace QrSorterInspectionApp
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("設定画面を表示しました");

                #region 媒体
                CmbMedia.Items.Clear();
                CmbMedia.Items.Add("ハガキ");
                CmbMedia.Items.Add("封筒");
                CmbMedia.SelectedIndex = 0;
                #endregion
                
                // 重複検査
                SetComboOnOff(CmbDuplication);
                // Ｗフィード検査
                SetComboOnOff(CmbDoubleFeed);
                // 受領日入力
                SetComboOnOff(CmbDateReceipt);
                // 読取チェック
                SetComboOnOff(CmbReadCheck);
                // 超音波検知
                SetComboOnOff(CmbUltrasonicDetection);
                // 桁数チェック
                SetComboOnOff(CmbCheckNumberOfDigits);
                
                #region ログ作成条件
                CmbLogCreationConditions.Items.Clear();
                CmbLogCreationConditions.Items.Add("ポケット単位");
                CmbLogCreationConditions.Items.Add("全件");
                CmbLogCreationConditions.SelectedIndex = 0;
                #endregion
                
                #region 読取機能
                CmbReadingFunction.Items.Clear();
                CmbReadingFunction.Items.Add("QR");
                CmbReadingFunction.Items.Add("NW7");
                CmbReadingFunction.Items.Add("CODE39");
                CmbReadingFunction.Items.Add("CODE128");
                CmbReadingFunction.Items.Add("JAN");
                CmbReadingFunction.SelectedIndex = 0;
                #endregion
                
                #region QR桁数
                RchTxtQrInfo.Text = "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567";
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
                SetComboOnOff(CmbNonDeliveryOnOff1);
                SetComboOnOff(CmbNonDeliveryOnOff2);
                #endregion

                #region ソーター設定画面
                SetGroupItem(CmbGroup);
                CmbGroup.Items.RemoveAt(5);
                SetGroupItem(CmbGroup1);
                SetGroupItem(CmbGroup2);
                SetGroupItem(CmbGroup3);
                SetGroupItem(CmbGroup4);
                SetGroupItem(CmbGroup5);
                CmbGroup.SelectedIndex = 0;
                CmbGroup1.SelectedIndex = 0;
                CmbGroup2.SelectedIndex = 0;
                CmbGroup3.SelectedIndex = 2;
                CmbGroup4.SelectedIndex = 3;
                CmbGroup5.SelectedIndex = 4;
                TxtPocketName1.Text = "コメリ";
                TxtPocketName2.Text = "コメリ";
                TxtPocketName3.Text = "武蔵野BK";
                TxtPocketName4.Text = "西日本シティーBK";
                TxtPocketName5.Text = "リジェクト";
                #endregion

                #region 数量（ポケット切替件数）
                TxtQuantity1.Text = "0";
                TxtQuantity2.Text = "0";
                TxtQuantity3.Text = "0";
                TxtQuantity4.Text = "0";
                TxtQuantity5.Text = "0";
                SetComboOnOff(CmbQuantOnOff1);
                SetComboOnOff(CmbQuantOnOff2);
                SetComboOnOff(CmbQuantOnOff3);
                SetComboOnOff(CmbQuantOnOff4);
                SetComboOnOff(CmbQuantOnOff5);
                #endregion

                ClearDisplayData();
                // ジョブ登録リストファイル読込
                CommonModule.ReadJobEntryListFile();
                // JOB一覧表示
                DisplayJobName();
                // QR桁数情報色の設定
                SetColorForQrData(sender, e);

                if (PubConstClass.lstJobEntryList.Count == 0)
                {
                    // ジョブ登録件数が「0」の場合は「更新」「削除」ボタンは使用不可
                    BtnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SettingForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ON/OFF」のコンボボックス設定
        /// </summary>
        /// <param name="comboBox"></param>
        private void SetComboOnOff(ComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                comboBox.Items.Add("ON");
                comboBox.Items.Add("OFF");
                comboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetComboOnOff】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ソーター設定のグループコンボボックス設定
        /// </summary>
        /// <param name="comboBox"></param>
        private void SetGroupItem(ComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                comboBox.Items.Add("グループ1");
                comboBox.Items.Add("グループ2");
                comboBox.Items.Add("グループ3");
                comboBox.Items.Add("グループ4");
                comboBox.Items.Add("グループ5");
                comboBox.Items.Add("リジェクト");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetGroupItem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// JOB名称一覧表示
        /// </summary>
        private void DisplayJobName()
        {
            try
            {
                string[] sArray;
                LsbJobListFeeder.Items.Clear();
                if (PubConstClass.lstJobEntryList.Count == 0)
                {
                    return;
                }
                foreach (var item in PubConstClass.lstJobEntryList)
                {
                    sArray = item.Split(',');
                    // JOB名称のセット
                    LsbJobListFeeder.Items.Add(sArray[1]);
                }
                LsbJobListFeeder.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayJobName】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// ジョブ名称一覧リスト選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbJobListFeeder_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEntryJobItem(LsbJobListFeeder.SelectedIndex);
        }

        // フォルダ作成日時
        private string sFolderCreationDateAndTime = "";
        
        /// <summary>
        /// 登録ジュブ項目を取得し表示する
        /// </summary>
        /// <param name="iJobIndex"></param>
        private void GetEntryJobItem(int iJobIndex)
        {
            string[] sArray;

            try
            {
                int iIndex = 0;
                sArray = PubConstClass.lstJobEntryList[iJobIndex].Split(',');
                // フォルダ作成日時
                sFolderCreationDateAndTime = sArray[iIndex];
                iIndex++;
                // JOB名
                TxtJobName.Text = sArray[iIndex];
                iIndex++;
                // 媒体
                CmbMedia.Text = sArray[iIndex];
                iIndex++;
                // 受領日
                DtpDateReceipt.Text = sArray[iIndex];
                iIndex++;
                // 受領日入力
                CmbDateReceipt.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // QR桁数
                NumUpDwnQrAllDigit.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                // 読取チェック
                CmbReadCheck.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;                
                // QR読取項目①
                TxtQrReadItem1.Text = sArray[iIndex];
                iIndex++;
                NmUpDnPropertyIdStart.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                NmUpDnPropertyIdKeta.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                // QR読取項目②
                TxtQrReadItem2.Text = sArray[iIndex];
                iIndex++;
                NmUpDnPostalDateStart.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                NmUpDnPostalDateKeta.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                // QR読取項目③
                TxtQrReadItem3.Text = sArray[iIndex];
                iIndex++;
                NmUpDnFileTypeStart.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                NmUpDnFileTypeKeta.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                // QR読取項目④
                TxtQrReadItem4.Text = sArray[iIndex];
                iIndex++;
                NmUpDnManagementNoStart.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                NmUpDnManagementNoKeta.Value = decimal.Parse(sArray[iIndex]);
                iIndex++;
                // 仕分け①
                CmbNonDeliveryReasonSorting1.SelectedIndex = int.Parse(sArray[iIndex]) - 1;
                iIndex++;
                // 仕分け②
                CmbNonDeliveryReasonSorting2.SelectedIndex = int.Parse(sArray[iIndex]) - 1;
                iIndex++;
                // 仕分け①チェック
                CmbNonDeliveryOnOff1.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // 仕分け②チェック
                CmbNonDeliveryOnOff2.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // 重複検査
                CmbDuplication.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // Wフィード検査
                CmbDoubleFeed.SelectedIndex = sArray[iIndex].Trim() == "ON"? 0 : 1;
                iIndex++;
                // 超音波検知
                CmbUltrasonicDetection.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // 桁数チェック
                CmbCheckNumberOfDigits.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // ログ作成条件
                CmbLogCreationConditions.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // 読取機能
                CmbReadingFunction.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // ポケット①：名称
                TxtPocketName1.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット①：グループID
                CmbGroup1.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // ポケット②：名称
                TxtPocketName2.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット②：グループID
                CmbGroup2.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // ポケット③：名称
                TxtPocketName3.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット③：グループID
                CmbGroup3.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // ポケット④：名称
                TxtPocketName4.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット④：グループID
                CmbGroup4.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // ポケット⑤：名称
                TxtPocketName5.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット⑤：グループID
                CmbGroup5.SelectedIndex = int.Parse(sArray[iIndex].Trim()) - 1;
                iIndex++;
                // ポケット①切替件数
                TxtQuantity1.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット②切替件数
                TxtQuantity2.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット③切替件数
                TxtQuantity3.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット④切替件数
                TxtQuantity4.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット⑤切替件数
                TxtQuantity5.Text = sArray[iIndex].Trim();
                iIndex++;
                // ポケット①切替件数チェック
                CmbQuantOnOff1.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // ポケット②切替件数チェック
                CmbQuantOnOff2.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // ポケット③切替件数チェック
                CmbQuantOnOff3.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // ポケット④切替件数チェック
                CmbQuantOnOff4.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;
                // ポケット⑤切替件数チェック
                CmbQuantOnOff5.SelectedIndex = sArray[iIndex].Trim() == "ON" ? 0 : 1;
                iIndex++;

                // グループ１～４を更新する
                CmbGroup.SelectedIndex = 1;
                CmbGroup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetEntryJobItem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// QR桁数情報色の設定
        /// </summary>
        private void SetColorForQrData(object sender, EventArgs e)
        {
            try
            {
                SetColorForQrDataSub(RchTxtQrInfo);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetColorForQrData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// QR桁数情報色の設定（サブ）
        /// </summary>
        /// <param name="richTextBox"></param>
        private void SetColorForQrDataSub(RichTextBox richTextBox)
        {
            try
            {
                // QR全体
                richTextBox.Select(0, RchTxtQrInfo.Text.Length);
                richTextBox.SelectionBackColor = Color.White;
                richTextBox.SelectionColor = Color.Black;
                // 物件ID
                richTextBox.SelectionStart = decimal.ToInt32(NmUpDnPropertyIdStart.Value) - 1;
                richTextBox.SelectionLength = decimal.ToInt32(NmUpDnPropertyIdKeta.Value);
                richTextBox.SelectionBackColor = Color.LimeGreen;
                richTextBox.SelectionColor = Color.Black;
                // 局出し日
                richTextBox.SelectionStart = decimal.ToInt32(NmUpDnPostalDateStart.Value) - 1;
                richTextBox.SelectionLength = decimal.ToInt32(NmUpDnPostalDateKeta.Value);
                richTextBox.SelectionBackColor = Color.SkyBlue;
                richTextBox.SelectionColor = Color.Black;
                // ファイル区分
                richTextBox.SelectionStart = decimal.ToInt32(NmUpDnFileTypeStart.Value) - 1;
                richTextBox.SelectionLength = decimal.ToInt32(NmUpDnFileTypeKeta.Value);
                richTextBox.SelectionBackColor = Color.Orange;
                richTextBox.SelectionColor = Color.Black;
                // 物件ID
                richTextBox.SelectionStart = decimal.ToInt32(NmUpDnManagementNoStart.Value) - 1;
                richTextBox.SelectionLength = decimal.ToInt32(NmUpDnManagementNoKeta.Value);
                richTextBox.SelectionBackColor = Color.Red;
                richTextBox.SelectionColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetColorForQrData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NumUpDwnQrAllDigit_ValueChanged(object sender, EventArgs e)
        {
            string sData = "";
            try
            {
                //                 1         2         3         4         5
                sData += "12345678901234567890123456789012345678901234567890";
                sData += "12345678901234567890123456789012345678901234567890";
                sData += "12345678901234567890123456789012345678901234567890";
                RchTxtQrInfo.Text = sData.Substring(0, decimal.ToInt32(NumUpDwnQrAllDigit.Value));                

                SetColorForQrData(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【NumUpDwnQrAllDigit_ValueChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ジョブ登録リストファイルの書込み
        /// </summary>
        private void WriteJobEntryListFile()
        {
            string sPutDataPath;

            try
            {
                sPutDataPath = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_JOB_ENTRY_FILE_NAME;

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sPutDataPath, false, Encoding.Default))
                {
                    foreach (var item in PubConstClass.lstJobEntryList)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WriteJobEntryListFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ジョブ名の重複チェック
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        private bool CheckDuplicateJobName(string jobName)
        {
            try
            {
                bool iFind = false;
                foreach(var item in PubConstClass.lstJobEntryList)
                {
                    string[] sArray = item.Split(',');
                    if (sArray[0].Trim() == jobName) {
                        iFind = true;
                    }
                }
                if (iFind)
                {
                    // 重複あり
                    return true;
                }
                else
                {
                    // 重複なし
                    return false;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckFoDuplicateJobName】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // エラー発生時は重複ありで返却
                return true;
            }
        }

        /// <summary>
        /// ジョブ登録データ名称の取得
        /// </summary>
        /// <returns></returns>
        private string GetJobEntryData()
        {
            try
            {
                string sMessage = Environment.NewLine;
                sMessage += "JOB名 ：" + TxtJobName.Text + Environment.NewLine;
                sMessage += "媒体　：" + CmbMedia.Text + Environment.NewLine;
                sMessage += "受領日：" + DtpDateReceipt.Text + Environment.NewLine;
                return sMessage;             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetJobEntryData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>
        /// 全てのジョブ登録データ名称の取得
        /// </summary>
        /// <param name="iMode">0：追加／1：更新</param>
        /// <returns></returns>
        private string GetAllJobEntryData(int iMode)
        {
            try
            {
                string sData = "";
                // フォルダ作成日時
                if(iMode == 0)
                {
                    // 追加の場合はフォルダ作成日時を更新する
                    sFolderCreationDateAndTime = "JOB" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                sData += sFolderCreationDateAndTime + ",";
                // JOB名
                sData += TxtJobName.Text.Trim() + ",";
                // 媒体
                sData += CmbMedia.Text.Trim() + ",";
                // 受領日
                sData += DtpDateReceipt.Text.Trim() + ",";
                // 受領日入力
                sData += CmbDateReceipt.Text.Trim() + ","; ;
                // QR桁数
                sData += NumUpDwnQrAllDigit.Value.ToString() + ",";
                // 読取チェック
                sData += CmbReadCheck.Text.Trim() + ",";
                // QR読取項目①
                sData += TxtQrReadItem1.Text + ",";
                sData += NmUpDnPropertyIdStart.Value.ToString() + ",";
                sData += NmUpDnPropertyIdKeta.Value.ToString() + ",";
                // QR読取項目②
                sData += TxtQrReadItem2.Text + ",";
                sData += NmUpDnPostalDateStart.Value.ToString() + ",";
                sData += NmUpDnPostalDateKeta.Value.ToString() + ",";
                // QR読取項目③
                sData += TxtQrReadItem3.Text + ",";
                sData += NmUpDnFileTypeStart.Value.ToString() + ",";
                sData += NmUpDnFileTypeKeta.Value.ToString() + ",";
                // QR読取項目④
                sData += TxtQrReadItem4.Text + ",";
                sData += NmUpDnManagementNoStart.Value.ToString() + ",";
                sData += NmUpDnManagementNoKeta.Value.ToString() + ",";
                // 不着事由仕分け①
                sData += (CmbNonDeliveryReasonSorting1.SelectedIndex + 1).ToString() + ","; ;
                // 不着事由仕分け②
                sData += (CmbNonDeliveryReasonSorting2.SelectedIndex + 1).ToString() + ","; ;
                
                // 不着事由仕分け①チェック
                sData += CmbNonDeliveryOnOff1.Text.Trim() + ",";
                // 不着事由仕分け②チェック
                sData += CmbNonDeliveryOnOff2.Text.Trim() + ",";

                // 重複検査
                sData += CmbDuplication.Text + ","; ;
                // Wフィード検査
                sData += CmbDoubleFeed.Text + ","; ;
                // 超音波検知
                sData += CmbUltrasonicDetection.Text + ","; ;
                // 桁数チェック
                sData += CmbCheckNumberOfDigits.Text + ","; ;
                // ログ作成条件
                sData += (CmbLogCreationConditions.SelectedIndex + 1).ToString() + ","; ;
                // 読取機能
                sData += (CmbReadingFunction.SelectedIndex + 1).ToString() + ","; ;
                // ポケット①：名称
                sData += TxtPocketName1.Text.Trim() + ","; ;
                // ポケット①：グループID
                sData += (CmbGroup1.SelectedIndex + 1).ToString() + ","; ;
                // ポケット②：名称
                sData += TxtPocketName2.Text.Trim() + ","; ;
                // ポケット②：グループID
                sData += (CmbGroup2.SelectedIndex + 1).ToString() + ","; ;
                // ポケット③：名称
                sData += TxtPocketName3.Text.Trim() + ","; ;
                // ポケット③：グループID
                sData += (CmbGroup3.SelectedIndex + 1).ToString() + ","; ;
                // ポケット④：名称
                sData += TxtPocketName4.Text.Trim() + ","; ;
                // ポケット④：グループID
                sData += (CmbGroup4.SelectedIndex + 1).ToString() + ","; ;
                // ポケット⑤：名称
                sData += TxtPocketName5.Text.Trim() + ","; ;
                // ポケット⑤：グループID
                sData += (CmbGroup5.SelectedIndex + 1).ToString() + ","; ;

                // ポケット①切替件数
                sData += TxtQuantity1.Text.Trim() + ","; ;
                // ポケット②切替件数
                sData += TxtQuantity2.Text.Trim() + ","; ;
                // ポケット③切替件数
                sData += TxtQuantity3.Text.Trim() + ","; ;
                // ポケット④切替件数
                sData += TxtQuantity4.Text.Trim() + ","; ;
                // ポケット⑤切替件数
                sData += TxtQuantity5.Text.Trim() + ","; ;

                // ポケット切替件数①チェック
                sData += CmbQuantOnOff1.Text.Trim() + ",";
                // ポケット切替件数②チェック
                sData += CmbQuantOnOff2.Text.Trim() + ",";
                // ポケット切替件数③チェック
                sData += CmbQuantOnOff3.Text.Trim() + ",";
                // ポケット切替件数④チェック
                sData += CmbQuantOnOff4.Text.Trim() + ",";
                // ポケット切替件数⑤チェック
                sData += CmbQuantOnOff5.Text.Trim() + ",";

                return sData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetAllJobEntryData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>
        /// 「追加」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // JOB名の重複登録チェック
                bool bRet = CheckDuplicateJobName(TxtJobName.Text);
                if (bRet)
                {
                    MessageBox.Show($"ジョブ名「{TxtJobName.Text}」は既に存在します", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sMessage = GetJobEntryData();
                DialogResult dialogResult = MessageBox.Show($"下記ジョブデータを追加しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 全てのジョブ登録データ名称の取得
                string sData = GetAllJobEntryData(0);

                // ジョブ登録データの追加
                PubConstClass.lstJobEntryList.Add(sData);

                // ジョブ登録リストファイルの書込み
                WriteJobEntryListFile();

                // 新規ジョブのBOXファイルが存在するか確認
                string sFolder = "";
                string sJobFolder = "\\JOB\\";
                //sJobFolder += "JOB" + LsbJobListFeeder.Items.Count.ToString("00000") + "\\";
                sJobFolder += sFolderCreationDateAndTime + "\\";
                sFolder = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + sJobFolder;
                if (!Directory.Exists(sFolder))
                {
                    // フォルダを作成
                    Directory.CreateDirectory(sFolder);
                    // ファイルが無い場合は空ファイルを作成
                    File.Create(sFolder + "Box1List.txt").Close();
                    File.Create(sFolder + "Box2List.txt").Close();
                    File.Create(sFolder + "Box3List.txt").Close();
                    File.Create(sFolder + "Box4List.txt").Close();
                }

                // JOB一覧表示
                DisplayJobName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnAdd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「更新」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = GetJobEntryData();
                DialogResult dialogResult = MessageBox.Show($"下記ジョブデータを更新しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 全てのジョブ登録データ名称の取得
                string sData = GetAllJobEntryData(1);

                // ジョブ登録データの追加
                PubConstClass.lstJobEntryList[LsbJobListFeeder.SelectedIndex] = sData;

                // ジョブ登録リストファイルの書込み
                WriteJobEntryListFile();

                // JOB一覧表示
                DisplayJobName();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnUpdate_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「削除」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = GetJobEntryData();
                DialogResult dialogResult = MessageBox.Show($"下記ジョブデータを削除しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                PubConstClass.lstJobEntryList.RemoveAt(LsbJobListFeeder.SelectedIndex);
                if (PubConstClass.lstJobEntryList.Count == 0)
                {
                    BtnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                    ClearDisplayData();
                }
                // ジョブ登録リストファイルの書込み
                WriteJobEntryListFile();

                string sFolder = "";
                string sJobFolder = "\\JOB\\";
                sJobFolder += sFolderCreationDateAndTime + "\\";
                sFolder = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + sJobFolder;
                if (Directory.Exists(sFolder))
                {
                    // 存在する場合はフォルダを削除
                    Directory.Delete(sFolder, true);
                    CommonModule.OutPutLogFile("【BtnDelete_Click】削除フォルダ：" + sFolder);
                }

                // JOB一覧表示
                DisplayJobName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDisplayData()
        {
            try
            {
                // JOB名
                TxtJobName.Text = "";
                // 媒体
                CmbMedia.SelectedIndex = 0;
                // 受領日
                DtpDateReceipt.Text = DateTime.Now.ToString();
                // QR桁数
                NumUpDwnQrAllDigit.Value = 47;
                // 重複検査
                CmbDuplication.SelectedIndex = 0;
                // Wフィード検査
                CmbDoubleFeed.SelectedIndex = 0;
                // QR読取項目①
                TxtQrReadItem1.Text = "1";
                NmUpDnPropertyIdStart.Value = 1;
                NmUpDnPropertyIdKeta.Value = 1;
                // QR読取項目②
                TxtQrReadItem2.Text = "1";
                NmUpDnPostalDateStart.Value = 2;
                NmUpDnPostalDateKeta.Value = 1;
                // QR読取項目③
                TxtQrReadItem3.Text = "1";
                NmUpDnFileTypeStart.Value = 3;
                NmUpDnFileTypeKeta.Value = 1;
                // QR読取項目④
                TxtQrReadItem4.Text = "1";
                NmUpDnManagementNoStart.Value = 4;
                NmUpDnManagementNoKeta.Value = 1;
                // 仕分け①
                CmbNonDeliveryReasonSorting1.SelectedIndex = 0;
                // 仕分け②
                CmbNonDeliveryReasonSorting2.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ClearDisplayData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBoxQritem()
        {
            string[] sArray;

            try
            {
                LblBox1QrReadItem1.Text = "QR読取項目①：" + TxtQrReadItem1.Text;
                LblBox1QrReadItem2.Text = "QR読取項目②：" + TxtQrReadItem2.Text;
                LblBox1QrReadItem3.Text = "QR読取項目③：" + TxtQrReadItem3.Text;
                LblBox1QrReadItem4.Text = "QR読取項目④：" + TxtQrReadItem4.Text;
                sArray = PubConstClass.lstBoxList[LstBoxName.SelectedIndex].Split(',');
                TxtBoxName.Text = sArray[1];
                TxtBoxQrItem1.Text = sArray[2];
                TxtBoxQrItem2.Text = sArray[3];
                TxtBoxQrItem3.Text = sArray[4];
                TxtBoxQrItem4.Text = sArray[5];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayBoxQritem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBoxQritem();
        }

        private void CmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ボックス名リストファイルの読込
            ReadBoxListFile(CmbGroup.SelectedIndex);
            // リストボックス名一覧の表示
            DisplayListBox(LstBoxName);

            if (LstBoxName.Items.Count == 0)
            {
                BtnPocketUpdate.Enabled = false;
                BtnPcketDelete.Enabled = false;
            }
            else
            {
                BtnPocketUpdate.Enabled = true;
                BtnPcketDelete.Enabled = true;
            }
        }

        /// <summary>
        /// リストボックス名一覧の表示
        /// </summary>
        /// <param name="listBox"></param>
        private void DisplayListBox(ListBox listBox)
        {
            try
            {
                listBox.Items.Clear();
                if (PubConstClass.lstBoxList.Count == 0)
                {
                    // 登録データが無いので表示をクリア
                    TxtBoxName.Text = "";
                    TxtBoxQrItem1.Text = "";
                    TxtBoxQrItem2.Text = "";
                    TxtBoxQrItem3.Text = "";
                    TxtBoxQrItem4.Text = "";
                    return;
                }
                foreach (var item in PubConstClass.lstBoxList)
                {
                    String[] sArray = item.ToString().Split(',');
                    listBox.Items.Add(sArray[1]);
                }
                listBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayListBox】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ボックス名リストファイルの読込
        /// </summary>
        /// <param name="iGroupIndex"></param>
        private void ReadBoxListFile(int iGroupIndex)
        {
            string sReadDataPath;
            string sData;
            //int iJobIndex;
            try
            {
                if (sFolderCreationDateAndTime=="")
                {
                    return;
                }

                //if(LsbJobListFeeder.SelectedIndex == -1)
                //{
                //    iJobIndex = 1;
                //}
                //else
                //{
                //    iJobIndex = LsbJobListFeeder.SelectedIndex + 1;
                //}

                string sJobFolder = "\\JOB\\";
                //sJobFolder += "JOB" + iJobIndex.ToString("00000") + "\\";
                sJobFolder += sFolderCreationDateAndTime + "\\";

                sReadDataPath = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + sJobFolder;
                switch (iGroupIndex)
                {
                    case 0:
                        sReadDataPath += PubConstClass.DEF_BOX1_LIST_NAME;
                        break;
                    case 1:
                        sReadDataPath += PubConstClass.DEF_BOX2_LIST_NAME;
                        break;
                    case 2:
                        sReadDataPath += PubConstClass.DEF_BOX3_LIST_NAME;
                        break;
                    case 3:
                        sReadDataPath += PubConstClass.DEF_BOX4_LIST_NAME;
                        break;
                    case 4:
                        sReadDataPath += PubConstClass.DEF_BOX5_LIST_NAME;
                        break;
                    default:
                        sReadDataPath += sJobFolder + PubConstClass.DEF_BOX1_LIST_NAME;
                        break;
                }
                CommonModule.OutPutLogFile("【ReadBoxListFile】" + sReadDataPath);
                PubConstClass.lstBoxList.Clear();
                using (StreamReader sr = new StreamReader(sReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        PubConstClass.lstBoxList.Add(sData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadBoxListFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        private bool CheckDuplicateBoxName(string boxName)
        {
            try
            {
                bool iFind = false;
                foreach (var item in PubConstClass.lstBoxList)
                {
                    string[] sArray = item.Split(',');
                    if (sArray[1].Trim() == boxName)
                    {
                        iFind = true;
                    }
                }
                if (iFind)
                {
                    // 重複あり
                    return true;
                }
                else
                {
                    // 重複なし
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckDuplicateBoxName】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // エラー発生時は重複ありで返却
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private string GetBoxEntryData(TextBox textBox)
        {
            try
            {
                string sMessage = Environment.NewLine + Environment.NewLine;
                sMessage += "グループ項目：" + textBox.Text + Environment.NewLine;
                return sMessage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetBoxEntryData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private string GetAllBoxEntryData(int iNumber)
        {
            try
            {
                string sData = "";

                // グループ番号
                //sData += (PubConstClass.lstBoxList.Count + 1).ToString("000") + ",";
                sData += iNumber.ToString("000") + ",";

                // グループ項目名
                sData += TxtBoxName.Text.Trim() + ",";
                // QR読取項目①
                sData += TxtBoxQrItem1.Text + ",";
                // QR読取項目②
                sData += TxtBoxQrItem2.Text + ",";
                // QR読取項目③
                sData += TxtBoxQrItem3.Text + ",";
                // QR読取項目④
                sData += TxtBoxQrItem4.Text + ",";

                return sData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetAllBoxEntryData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void WriteBoxEntryListFile(int iGroupIndex)
        {
            string sReadDataPath;

            try
            {
                string sJobFolder = "\\JOB\\";
                //sJobFolder += "JOB" + (LsbJobListFeeder.SelectedIndex + 1).ToString("00000") + "\\";
                sJobFolder += sFolderCreationDateAndTime + "\\";
                sReadDataPath = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + sJobFolder;
                switch (iGroupIndex)
                {
                    case 0:
                        sReadDataPath += PubConstClass.DEF_BOX1_LIST_NAME;
                        break;
                    case 1:
                        sReadDataPath += PubConstClass.DEF_BOX2_LIST_NAME;
                        break;
                    case 2:
                        sReadDataPath += PubConstClass.DEF_BOX3_LIST_NAME;
                        break;
                    case 3:
                        sReadDataPath += PubConstClass.DEF_BOX4_LIST_NAME;
                        break;
                    case 4:
                        sReadDataPath += PubConstClass.DEF_BOX5_LIST_NAME;
                        break;
                    default:
                        sReadDataPath += sJobFolder + PubConstClass.DEF_BOX1_LIST_NAME;
                        break;
                }
                CommonModule.OutPutLogFile("【WriteBoxEntryListFile】" + sReadDataPath);
                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sReadDataPath, false, Encoding.Default))
                {
                    foreach (var item in PubConstClass.lstBoxList)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WriteBoxEntryListFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「追加」ボタン処理（ポケット①）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPocketAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // ボックス名リストファイルの読込
                ReadBoxListFile(CmbGroup.SelectedIndex);

                // BOX名の重複登録チェック
                bool bRet = CheckDuplicateBoxName(TxtBoxName.Text);
                if (bRet)
                {
                    MessageBox.Show($"ジョブ名「{TxtBoxName.Text}」は既に存在します", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sMessage = GetBoxEntryData(TxtBoxName);
                DialogResult dialogResult = MessageBox.Show($"下記データを追加しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 全てのグループ登録データの取得
                string sData = GetAllBoxEntryData(PubConstClass.lstBoxList.Count + 1);

                // グループ登録データの追加
                PubConstClass.lstBoxList.Add(sData);

                // グループ登録リストファイルの書込み
                WriteBoxEntryListFile(CmbGroup.SelectedIndex);

                // リストボックス名一覧の表示
                DisplayListBox(LstBoxName);

                // 「更新」「削除」ボタンの有効化
                BtnPocketUpdate.Enabled = true;
                BtnPcketDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPocketAdd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「更新」ボタン処理（グループ１～４）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPocketUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = GetBoxEntryData(TxtBoxName);
                DialogResult dialogResult = MessageBox.Show($"下記データを更新しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 全てのグループ登録データの取得
                string sData = GetAllBoxEntryData(LstBoxName.SelectedIndex + 1);

                // グループ登録データの更新
                PubConstClass.lstBoxList[LstBoxName.SelectedIndex] = sData;

                // グループ登録リストファイルの書込み
                WriteBoxEntryListFile(CmbGroup.SelectedIndex);

                // リストボックス名一覧の表示
                DisplayListBox(LstBoxName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPocketUpdate_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「削除」ボタン処理（グループ１～４）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPcketDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = GetBoxEntryData(TxtBoxName);
                DialogResult dialogResult = MessageBox.Show($"下記データを削除しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // グループ登録データの追加
                PubConstClass.lstBoxList.RemoveAt(LstBoxName.SelectedIndex);

                // グループ登録リストファイルの書込み
                WriteBoxEntryListFile(CmbGroup.SelectedIndex);

                // リストボックス名一覧の表示
                DisplayListBox(LstBoxName);

                if (LstBoxName.Items.Count == 0)
                {
                    BtnPocketUpdate.Enabled = false;
                    BtnPcketDelete.Enabled = false;
                }
                else
                {
                    BtnPocketUpdate.Enabled = true;
                    BtnPcketDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPcketDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {

        }
    }
}
