using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        /// 
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
                #region 重複検査
                CmbDuplication.Items.Clear();
                CmbDuplication.Items.Add("ON");
                CmbDuplication.Items.Add("OFF");
                CmbDuplication.SelectedIndex = 0;
                #endregion
                #region Wフィード検査
                CmbDoubleFeed.Items.Clear();
                CmbDoubleFeed.Items.Add("ON");
                CmbDoubleFeed.Items.Add("OFF");
                CmbDoubleFeed.SelectedIndex = 0;
                #endregion
                #region QR桁数
                RchTxtQrInfo.Text = "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567";
                RchTxtQrInfoForSorter.Text = RchTxtQrInfo.Text;
                #endregion
                #region ポケット①②③④
                CmbPocket1.Items.Clear();
                CmbPocket2.Items.Clear();
                CmbPocket3.Items.Clear();
                CmbPocket4.Items.Clear();
                CmbPocket1.Items.Add("グループ1");
                CmbPocket1.Items.Add("グループ2");
                CmbPocket1.Items.Add("グループ3");
                CmbPocket1.Items.Add("グループ4");
                CmbPocket1.SelectedIndex = 0;
                CmbPocket2.Items.Add("グループ1");
                CmbPocket2.Items.Add("グループ2");
                CmbPocket2.Items.Add("グループ3");
                CmbPocket2.Items.Add("グループ4");
                CmbPocket2.SelectedIndex = 0;
                CmbPocket3.Items.Add("グループ1");
                CmbPocket3.Items.Add("グループ2");
                CmbPocket3.Items.Add("グループ3");
                CmbPocket3.Items.Add("グループ4");
                CmbPocket3.SelectedIndex = 0;
                CmbPocket4.Items.Add("グループ1");
                CmbPocket4.Items.Add("グループ2");
                CmbPocket4.Items.Add("グループ3");
                CmbPocket4.Items.Add("グループ4");
                CmbPocket4.SelectedIndex = 0;
                #endregion
                #region QR項目①②③④
                CmbQrItem1.Items.Clear();
                CmbQrItem2.Items.Clear();
                CmbQrItem3.Items.Clear();
                CmbQrItem4.Items.Clear();
                CmbQrItem1.Items.Add("物件ID");
                CmbQrItem1.Items.Add("局出し日");
                CmbQrItem1.Items.Add("ファイル区分");
                CmbQrItem1.Items.Add("管理No");
                CmbQrItem1.SelectedIndex = 0;
                CmbQrItem2.Items.Add("物件ID");
                CmbQrItem2.Items.Add("局出し日");
                CmbQrItem2.Items.Add("ファイル区分");
                CmbQrItem2.Items.Add("管理No");
                CmbQrItem2.SelectedIndex = 0;
                CmbQrItem3.Items.Add("物件ID");
                CmbQrItem3.Items.Add("局出し日");
                CmbQrItem3.Items.Add("ファイル区分");
                CmbQrItem3.Items.Add("管理No");
                CmbQrItem3.SelectedIndex = 0;
                CmbQrItem4.Items.Add("物件ID");
                CmbQrItem4.Items.Add("局出し日");
                CmbQrItem4.Items.Add("ファイル区分");
                CmbQrItem4.Items.Add("管理No");
                CmbQrItem4.SelectedIndex = 0;
                #endregion

                ClearDisplayData();
                // ジョブ登録リストファイル読込
                ReadJobEntryListFile();
                // JOB一覧表示
                DisplayJobName();
                // QR桁数情報色の設定
                SetColorForQrData();


                // TODO：ソーター設定画面設計の為
                CmbGroup1.Items.Clear();
                CmbGroup1.Items.Add("グループ1");
                CmbGroup1.Items.Add("グループ2");
                CmbGroup1.Items.Add("グループ3");
                CmbGroup1.Items.Add("グループ4");
                CmbGroup1.SelectedIndex = 0;

                CmbGroup2.Items.Clear();
                CmbGroup2.Items.Add("グループ1");
                CmbGroup2.Items.Add("グループ2");
                CmbGroup2.Items.Add("グループ3");
                CmbGroup2.Items.Add("グループ4");
                CmbGroup2.SelectedIndex = 0;

                CmbGroup3.Items.Clear();
                CmbGroup3.Items.Add("グループ1");
                CmbGroup3.Items.Add("グループ2");
                CmbGroup3.Items.Add("グループ3");
                CmbGroup3.Items.Add("グループ4");
                CmbGroup3.SelectedIndex = 0;

                CmbGroup4.Items.Clear();
                CmbGroup4.Items.Add("グループ1");
                CmbGroup4.Items.Add("グループ2");
                CmbGroup4.Items.Add("グループ3");
                CmbGroup4.Items.Add("グループ4");
                CmbGroup4.SelectedIndex = 0;


                if (PubConstClass.lstJobEntryList.Count == 0)
                {
                    BtnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSetting_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// JOB一覧表示
        /// </summary>
        private void DisplayJobName()
        {
            try
            {
                string[] sArray;
                LsbJobListFeeder.Items.Clear();
                LsbJobListSorter.Items.Clear();
                if (PubConstClass.lstJobEntryList.Count == 0)
                {
                    return;
                }
                foreach (var item in PubConstClass.lstJobEntryList)
                {
                    sArray = item.Split(',');
                    LsbJobListFeeder.Items.Add(sArray[0]);
                    LsbJobListSorter.Items.Add(sArray[0]);
                }
                LsbJobListFeeder.SelectedIndex = 0;
                LsbJobListSorter.SelectedIndex = 0;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbJobListSorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] sArray;
            try
            {
                sArray = PubConstClass.lstJobEntryList[LsbJobListSorter.SelectedIndex].Split(',');
                // JOB名
                LblJobName.Text = sArray[0];
                // 媒体
                LblMedia.Text = sArray[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbJobList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「QRフィーダー設定」タブのジョブ一覧リスト選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbJobListFeeder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] sArray;
            try
            {                
                sArray = PubConstClass.lstJobEntryList[LsbJobListFeeder.SelectedIndex].Split(',');
                // JOB名
                TxtJobName.Text = sArray[0];
                // 媒体
                CmbMedia.Text = sArray[1];
                // 受領日
                DtpDateReceipt.Text = sArray[2];
                // QR桁数
                NumUpDwnQrAllDigit.Value = decimal.Parse(sArray[3]);
                // 重複検査
                if (sArray[4].Trim() == "ON")
                {
                    CmbDuplication.SelectedIndex = 0;
                }
                else
                {
                    CmbDuplication.SelectedIndex = 1;
                }
                // Wフィード検査
                if (sArray[5].Trim() == "ON")
                {
                    CmbDoubleFeed.SelectedIndex = 0;
                }
                else
                {
                    CmbDoubleFeed.SelectedIndex = 1;
                }
                // QR読取項目①
                TxtQrReadItem1.Text = sArray[6];
                NmUpDnPropertyIdStart.Value = decimal.Parse(sArray[7]);
                NmUpDnPropertyIdKeta.Value = decimal.Parse(sArray[8]);
                // QR読取項目②
                TxtQrReadItem2.Text = sArray[9];
                NmUpDnPostalDateStart.Value = decimal.Parse(sArray[10]);
                NmUpDnPostalDateKeta.Value = decimal.Parse(sArray[11]);
                // QR読取項目③
                TxtQrReadItem3.Text = sArray[12];
                NmUpDnFileTypeStart.Value = decimal.Parse(sArray[13]);
                NmUpDnFileTypeKeta.Value = decimal.Parse(sArray[14]);
                // QR読取項目④
                TxtQrReadItem4.Text = sArray[15];
                NmUpDnManagementNoStart.Value = decimal.Parse(sArray[16]);
                NmUpDnManagementNoKeta.Value = decimal.Parse(sArray[17]);
                // 仕分け①
                TxtSorting1.Text = sArray[18];
                // 仕分け②
                TxtSorting2.Text = sArray[19];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbJobList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// QR桁数情報色の設定
        /// </summary>
        private void SetColorForQrData()
        {
            try
            {
                SetColorForQrDataSub(RchTxtQrInfo);
                SetColorForQrDataSub(RchTxtQrInfoForSorter);
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

        private void NmUpDnPropertyIdStart_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnPropertyIdKeta_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnPostalDateStart_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnPostalDateKeta_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnFileTypeStart_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnFileTypeKeta_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnManagementNoStart_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NmUpDnManagementNoKeta_ValueChanged(object sender, EventArgs e)
        {
            SetColorForQrData();
        }

        private void NumUpDwnQrAllDigit_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sData = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
                RchTxtQrInfo.Text = sData.Substring(0, decimal.ToInt32(NumUpDwnQrAllDigit.Value));
                RchTxtQrInfoForSorter.Text = sData.Substring(0, decimal.ToInt32(NumUpDwnQrAllDigit.Value));

                SetColorForQrData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetColorForQrData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ジョブ登録リストファイルの読込
        /// </summary>
        private void ReadJobEntryListFile()
        {
            string sReadDataPath;
            string sData;

            try
            {
                sReadDataPath = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_JOB_ENTRY_FILE_NAME;

                PubConstClass.lstJobEntryList.Clear();
                using (StreamReader sr = new StreamReader(sReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        PubConstClass.lstJobEntryList.Add(sData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadJobEntryListFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool CheckFoDuplicateJobName(string jobName)
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
        /// <returns></returns>
        private string GetAllJobEntryData()
        {
            try
            {
                string sData = "";
                // JOB名
                sData += TxtJobName.Text.Trim() + ",";
                // 媒体
                sData += CmbMedia.Text.Trim() + ",";
                // 受領日
                sData += DtpDateReceipt.Text.Trim() + ",";
                // QR桁数
                sData += NumUpDwnQrAllDigit.Value.ToString() + ",";
                // 重複検査
                sData += CmbDuplication.Text + ",";
                // Wフィード検査
                sData += CmbDoubleFeed.Text + ",";
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
                // 仕分け①
                sData += TxtSorting1.Text + ",";
                // 仕分け②
                sData += TxtSorting2.Text;

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
                bool bRet = CheckFoDuplicateJobName(TxtJobName.Text);
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
                string sData = GetAllJobEntryData();

                // ジョブ登録データの追加
                PubConstClass.lstJobEntryList.Add(sData);

                // ジョブ登録リストファイルの書込み
                WriteJobEntryListFile();

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
                string sData = GetAllJobEntryData();

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
                TxtSorting1.Text = "";
                // 仕分け②
                TxtSorting2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ClearDisplayData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBoxQritem(int iPocketNumber)
        {
            try
            {
                string[] sArray;

                switch (iPocketNumber)
                {
                    case 0:
                        LblBox1QrReadItem1.Text = "QR読取項目①：" + TxtQrReadItem1.Text;
                        LblBox1QrReadItem2.Text = "QR読取項目②：" + TxtQrReadItem2.Text;
                        LblBox1QrReadItem3.Text = "QR読取項目③：" + TxtQrReadItem3.Text;
                        LblBox1QrReadItem4.Text = "QR読取項目④：" + TxtQrReadItem4.Text;
                        sArray = PubConstClass.lstBoxList[LstBox1.SelectedIndex].Split(',');
                        TxtBox1Name.Text = sArray[1];
                        TxtBox1QrItem1.Text = sArray[2];
                        TxtBox1QrItem2.Text = sArray[3];
                        TxtBox1QrItem3.Text = sArray[4];
                        TxtBox1QrItem4.Text = sArray[5];
                        break;

                    case 1:
                        LblBox2QrReadItem1.Text = "QR読取項目①：" + TxtQrReadItem1.Text;
                        LblBox2QrReadItem2.Text = "QR読取項目②：" + TxtQrReadItem2.Text;
                        LblBox2QrReadItem3.Text = "QR読取項目③：" + TxtQrReadItem3.Text;
                        LblBox2QrReadItem4.Text = "QR読取項目④：" + TxtQrReadItem4.Text;
                        sArray = PubConstClass.lstBoxList[LstBox2.SelectedIndex].Split(',');
                        TxtBox2Name.Text = sArray[1];
                        TxtBox2QrItem1.Text = sArray[2];
                        TxtBox2QrItem2.Text = sArray[3];
                        TxtBox2QrItem3.Text = sArray[4];
                        TxtBox2QrItem4.Text = sArray[5];
                        break;

                    case 2:
                        LblBox3QrReadItem1.Text = "QR読取項目①：" + TxtQrReadItem1.Text;
                        LblBox3QrReadItem2.Text = "QR読取項目②：" + TxtQrReadItem2.Text;
                        LblBox3QrReadItem3.Text = "QR読取項目③：" + TxtQrReadItem3.Text;
                        LblBox3QrReadItem4.Text = "QR読取項目④：" + TxtQrReadItem4.Text;
                        sArray = PubConstClass.lstBoxList[LstBox3.SelectedIndex].Split(',');
                        TxtBox3Name.Text = sArray[1];
                        TxtBox3QrItem1.Text = sArray[2];
                        TxtBox3QrItem2.Text = sArray[3];
                        TxtBox3QrItem3.Text = sArray[4];
                        TxtBox3QrItem4.Text = sArray[5];
                        break;

                    case 3:
                        LblBox4QrReadItem1.Text = "QR読取項目①：" + TxtQrReadItem1.Text;
                        LblBox4QrReadItem2.Text = "QR読取項目②：" + TxtQrReadItem2.Text;
                        LblBox4QrReadItem3.Text = "QR読取項目③：" + TxtQrReadItem3.Text;
                        LblBox4QrReadItem4.Text = "QR読取項目④：" + TxtQrReadItem4.Text;
                        sArray = PubConstClass.lstBoxList[LstBox4.SelectedIndex].Split(',');
                        TxtBox4Name.Text = sArray[1];
                        TxtBox4QrItem1.Text = sArray[2];
                        TxtBox4QrItem2.Text = sArray[3];
                        TxtBox4QrItem3.Text = sArray[4];
                        TxtBox4QrItem4.Text = sArray[5];
                        break;

                    default:
                        LblBox1QrReadItem1.Text = "QR読取項目①：" + TxtQrReadItem1.Text;
                        LblBox1QrReadItem2.Text = "QR読取項目②：" + TxtQrReadItem2.Text;
                        LblBox1QrReadItem3.Text = "QR読取項目③：" + TxtQrReadItem3.Text;
                        LblBox1QrReadItem4.Text = "QR読取項目④：" + TxtQrReadItem4.Text;
                        sArray = PubConstClass.lstBoxList[LstBox1.SelectedIndex].Split(',');
                        TxtBox1Name.Text = sArray[1];
                        TxtBox1QrItem1.Text = sArray[2];
                        TxtBox1QrItem2.Text = sArray[3];
                        TxtBox1QrItem3.Text = sArray[4];
                        TxtBox1QrItem4.Text = sArray[5];
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayBoxQritem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBoxQritem(0);
        }

        private void LstBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBoxQritem(1);
        }

        private void LstBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBoxQritem(2);
        }

        private void LstBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBoxQritem(3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ボックス名リストファイルの読込
            ReadBoxListFile(CmbGroup1.SelectedIndex);
            // リストボックス名一覧の表示
            DisplayListBox(LstBox1);
        }

        private void CmbGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ボックス名リストファイルの読込
            ReadBoxListFile(CmbGroup2.SelectedIndex);
            // リストボックス名一覧の表示
            DisplayListBox(LstBox2);
        }

        private void CmbGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ボックス名リストファイルの読込
            ReadBoxListFile(CmbGroup3.SelectedIndex);
            // リストボックス名一覧の表示
            DisplayListBox(LstBox3);
        }

        private void CmbGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ボックス名リストファイルの読込
            ReadBoxListFile(CmbGroup4.SelectedIndex);
            // リストボックス名一覧の表示
            DisplayListBox(LstBox4);
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

            try
            {
                string sJobFolder = "\\JOB\\";
                sJobFolder += "JOB" + (LsbJobListFeeder.SelectedIndex + 1).ToString("00000") + "\\";
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
                    default:
                        sReadDataPath += sJobFolder + PubConstClass.DEF_BOX1_LIST_NAME;
                        break;
                }
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
        /// 「追加」ボタン処理（ポケット①）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPocketAdd1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPocketAdd1_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPocketUpdate1_Click(object sender, EventArgs e)
        {

        }

        private void BtnPcketDelete1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 「追加」ボタン処理（ポケット②）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPocketAdd2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPocketAdd2_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPocketUpdate2_Click(object sender, EventArgs e)
        {

        }

        private void BtnPcketDelete2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 「追加」ボタン処理（ポケット③）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPocketAdd3_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPocketAdd3_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPocketUpdate3_Click(object sender, EventArgs e)
        {

        }

        private void BtnPcketDelete3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 「追加」ボタン処理（ポケット④）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPocketAdd4_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPocketAdd4_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPocketUpdate4_Click(object sender, EventArgs e)
        {

        }

        private void BtnPcketDelete4_Click(object sender, EventArgs e)
        {

        }
    }
}
