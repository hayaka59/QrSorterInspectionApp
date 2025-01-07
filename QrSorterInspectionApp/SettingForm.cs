using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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
                CmbReadingFunction.Items.Add("読取無し");
                CmbReadingFunction.SelectedIndex = 0;
                #endregion
                
                #region QR桁数
                RchTxtQrInfo.Text = "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567";
                #endregion
               
                #region ソーター設定画面
                SetGroupItem(CmbGroup1);
                SetGroupItem(CmbGroup2);
                SetGroupItem(CmbGroup3);
                SetGroupItem(CmbGroup4);
                SetGroupItem(CmbGroup5);
                CmbGroup1.SelectedIndex = 0;
                CmbGroup2.SelectedIndex = 0;
                CmbGroup3.SelectedIndex = 0;
                CmbGroup4.SelectedIndex = 0;
                CmbGroup5.SelectedIndex = 0;
                CmbGroup6.Items.Add("リジェクト");
                CmbGroup6.SelectedIndex = 0;
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

                // 設定画面の項目クリア
                ClearDisplayData();
                // 選択中ジョブフィル名クリア
                LblSelectedFile.Text = "";
                BtnAdd.Enabled = true;          // 「新規保存」ボタン使用不可
                BtnUpdate.Enabled = true;       // 「保存」　　ボタン使用可
                BtnDelete.Enabled = false;      // 「削除」　　ボタン使用不可
                BtnCopyItem.Enabled = false;    // 「項目コピー」ボタン使用不可
                BtnPasteItem.Enabled = false;   // 「項目貼付け」ボタン使用不可

                if (PubConstClass.sJobFileNameFromInspectionForm != "")
                {
                    LblTitle.Text = $"設定（検査画面からの呼出／{PubConstClass.sUserAuthority}ユーザー：{PubConstClass.sUserId}）";
                    string[] sArray = PubConstClass.sJobFileNameFromInspectionForm.Split('\\');
                    // ファイル名のみを表示する
                    LblSelectedFile.Text = sArray[sArray.Length - 1];
                    // ジョブ登録情報及びグループ１～５情報の読取り
                    CommonModule.ReadJobEntryListFile(PubConstClass.sJobFileNameFromInspectionForm);
                    // 登録ジョブ項目を取得し表示
                    GetEntryJobItem(0);
                    BtnJobSelect.Enabled = false;   // 「JOB選択」　 ボタン使用不可
                    BtnAdd.Enabled = false;         // 「新規保存」　ボタン使用不可
                    BtnUpdate.Enabled = true;       // 「保存」　　　ボタン使用可                    
                    BtnDelete.Enabled = false;      // 「削除」　　　ボタン使用不可
                    // ユーザー権限で設定画面の使用項目を制限する
                    DisableScreen();
                }
                else
                {
                    LblTitle.Text = "設定";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SettingForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ユーザー権限で設定画面の使用項目を制限する
        /// </summary>
        private void DisableScreen()
        {
            try
            {
                if (PubConstClass.sUserAuthority == "OP")
                {
                    // OPユーザーの場合は参照モード
                    // QRフィーダー設定使用不可
                    GrpFeederSetting.Enabled = false;
                    // ソーター設定使用不可
                    GrpSorterSetting.Enabled = false;
                }
                else
                {
                    // SVユーザーの場合は下記の項目を使用不可
                    // JOB選択ボタン使用不可
                    BtnJobSelect.Enabled = false;
                    // 項目コピーボタン使用不可
                    BtnCopyItem.Enabled = false;
                    // 項目貼付けボタン使用不可
                    BtnPasteItem.Enabled = false;
                    // 新規保存ボタン使用不可
                    BtnAdd.Enabled = false;
                    // 削除ボタン使用不可
                    BtnDelete.Enabled = false;
                    // JOB名テキスト入力不可
                    TxtJobName.Enabled = false;
                    // 媒体選択コンボボックス使用不可
                    CmbMedia.Enabled = false;
                    // ソーター設定使用不可
                    GrpSorterSetting.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisableScreen】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 登録ジュブ項目を取得し表示する
        /// </summary>
        /// <param name="iJobIndex"></param>
        private void GetEntryJobItem(int iJobIndex)
        {
            string[] sArray;

            try
            {
                CmbGroup1.SelectedIndex = 5;
                CmbGroup2.SelectedIndex = 5;
                CmbGroup3.SelectedIndex = 5;
                CmbGroup4.SelectedIndex = 5;
                CmbGroup5.SelectedIndex = 5;

                int iIndex = 0;
                sArray = PubConstClass.lstJobEntryList[iJobIndex].Split(',');
                // JOB名
                TxtJobName.Text = sArray[iIndex++];
                // 媒体
                CmbMedia.Text = sArray[iIndex++];
                // 受領日
                DtpDateReceipt.Text = sArray[iIndex++];
                // 受領日入力
                CmbDateReceipt.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // QR桁数
                NumUpDwnQrAllDigit.Value = decimal.Parse(sArray[iIndex++]);
                // 読取チェック
                CmbReadCheck.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // QR読取項目①
                TxtQrReadItem1.Text = sArray[iIndex++];
                LblBox1QrReadItem1.Text = TxtQrReadItem1.Text;
                NmUpDnPropertyIdStart.Value = decimal.Parse(sArray[iIndex++]);
                NmUpDnPropertyIdKeta.Value = decimal.Parse(sArray[iIndex++]);
                // QR読取項目②
                TxtQrReadItem2.Text = sArray[iIndex++];
                LblBox1QrReadItem2.Text = TxtQrReadItem2.Text;
                NmUpDnPostalDateStart.Value = decimal.Parse(sArray[iIndex++]);
                NmUpDnPostalDateKeta.Value = decimal.Parse(sArray[iIndex++]);
                // QR読取項目③
                TxtQrReadItem3.Text = sArray[iIndex++];
                LblBox1QrReadItem3.Text = TxtQrReadItem3.Text;
                NmUpDnFileTypeStart.Value = decimal.Parse(sArray[iIndex++]);
                NmUpDnFileTypeKeta.Value = decimal.Parse(sArray[iIndex++]);
                // QR読取項目④
                TxtQrReadItem4.Text = sArray[iIndex++];
                LblBox1QrReadItem4.Text = TxtQrReadItem4.Text;
                NmUpDnManagementNoStart.Value = decimal.Parse(sArray[iIndex++]);
                NmUpDnManagementNoKeta.Value = decimal.Parse(sArray[iIndex++]);

                // 重複検査
                CmbDuplication.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // Wフィード検査
                CmbDoubleFeed.SelectedIndex = sArray[iIndex++].Trim() == "ON"? 0 : 1;
                // 超音波検知
                CmbUltrasonicDetection.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // 桁数チェック
                CmbCheckNumberOfDigits.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // ログ作成条件
                CmbLogCreationConditions.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;
                // 読取機能
                CmbReadingFunction.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;

                iIndex = 0;
                sArray = PubConstClass.lstPocketInfo[0].Split(',');
                // ポケット①：名称
                TxtPocketName1.Text = sArray[iIndex++].Trim();
                // ポケット①：グループID
                CmbGroup1.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;
                // ポケット②：名称
                TxtPocketName2.Text = sArray[iIndex++].Trim();
                // ポケット②：グループID
                CmbGroup2.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;
                // ポケット③：名称
                TxtPocketName3.Text = sArray[iIndex++].Trim();
                // ポケット③：グループID
                CmbGroup3.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;
                // ポケット④：名称
                TxtPocketName4.Text = sArray[iIndex++].Trim();
                // ポケット④：グループID
                CmbGroup4.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;
                // ポケット⑤：名称
                TxtPocketName5.Text = sArray[iIndex++].Trim();
                // ポケット⑤：グループID
                CmbGroup5.SelectedIndex = int.Parse(sArray[iIndex++].Trim()) - 1;
                // ポケット①切替件数
                TxtQuantity1.Text = sArray[iIndex++].Trim();
                // ポケット②切替件数
                TxtQuantity2.Text = sArray[iIndex++].Trim();
                // ポケット③切替件数
                TxtQuantity3.Text = sArray[iIndex++].Trim();
                // ポケット④切替件数
                TxtQuantity4.Text = sArray[iIndex++].Trim();
                // ポケット⑤切替件数
                TxtQuantity5.Text = sArray[iIndex++].Trim();
                // ポケット①切替件数チェック
                CmbQuantOnOff1.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // ポケット②切替件数チェック
                CmbQuantOnOff2.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // ポケット③切替件数チェック
                CmbQuantOnOff3.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // ポケット④切替件数チェック
                CmbQuantOnOff4.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;
                // ポケット⑤切替件数チェック
                CmbQuantOnOff5.SelectedIndex = sArray[iIndex++].Trim() == "ON" ? 0 : 1;



                sArray = PubConstClass.lstGroupInfo[0].Split(',');
                TxtGroup1.Text = sArray[0];
                TxtBoxQrItem11.Text = sArray[1];
                TxtBoxQrItem21.Text = sArray[2];
                TxtBoxQrItem31.Text = sArray[3];
                TxtBoxQrItem41.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[1].Split(',');
                TxtGroup2.Text = sArray[0];
                TxtBoxQrItem12.Text = sArray[1];
                TxtBoxQrItem22.Text = sArray[2];
                TxtBoxQrItem32.Text = sArray[3];
                TxtBoxQrItem42.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[2].Split(',');
                TxtGroup3.Text = sArray[0];
                TxtBoxQrItem13.Text = sArray[1];
                TxtBoxQrItem23.Text = sArray[2];
                TxtBoxQrItem33.Text = sArray[3];
                TxtBoxQrItem43.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[3].Split(',');
                TxtGroup4.Text = sArray[0];
                TxtBoxQrItem14.Text = sArray[1];
                TxtBoxQrItem24.Text = sArray[2];
                TxtBoxQrItem34.Text = sArray[3];
                TxtBoxQrItem44.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[4].Split(',');
                TxtGroup5.Text = sArray[0];
                TxtBoxQrItem15.Text = sArray[1];
                TxtBoxQrItem25.Text = sArray[2];
                TxtBoxQrItem35.Text = sArray[3];
                TxtBoxQrItem45.Text = sArray[4];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【GetEntryJobItem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 
        /// </summary>
        /// <param name="sFileName"></param>
        /// <param name="sFeederData"></param>
        /// <param name="sPocketData"></param>
        private void WriteNewJobFile(string sFileName ,string sFeederData, string sPocketData)
        {
            string sPutDataPath = "";

            try
            {
                sPutDataPath += CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath);
                sPutDataPath += "\\JOB\\";
                sPutDataPath += sFileName;

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sPutDataPath, false, Encoding.Default))
                {
                    // フィーダー設定データ書込
                    sw.WriteLine(sFeederData);
                    // ポケット設定データ書込
                    sw.WriteLine(sPocketData);
                    // グループ設定データ書込
                    if (PubConstClass.lstGroupInfo.Count == 0)
                    {
                        string sDummyData = ",,,,,";
                        sw.WriteLine(sDummyData);
                        sw.WriteLine(sDummyData);
                        sw.WriteLine(sDummyData);
                        sw.WriteLine(sDummyData);
                        sw.WriteLine(sDummyData);
                    }
                    else
                    {
                        sw.WriteLine(PubConstClass.lstGroupInfo[0]);
                        sw.WriteLine(PubConstClass.lstGroupInfo[1]);
                        sw.WriteLine(PubConstClass.lstGroupInfo[2]);
                        sw.WriteLine(PubConstClass.lstGroupInfo[3]);
                        sw.WriteLine(PubConstClass.lstGroupInfo[4]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WriteNewJobFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                               
                // ソーター設定のQR読取項目①～⑤名称更新
                LblBox1QrReadItem1.Text = TxtQrReadItem1.Text;
                LblBox1QrReadItem2.Text = TxtQrReadItem2.Text;
                LblBox1QrReadItem3.Text = TxtQrReadItem3.Text;
                LblBox1QrReadItem4.Text = TxtQrReadItem4.Text;

                return sData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetAllJobEntryData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private string GetPocketData()
        {
            string sData = "";

            try
            {
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
                MessageBox.Show(ex.Message, "【GetPocketData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return sData;
            }
        }

        /// <summary>
        /// 「新規追加」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show($"ジョブデータを新規追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                // 設定画面の項目クリア
                ClearDisplayData();
                
                PubConstClass.lstGroupInfo.Clear();

                // 選択中ジョブフィル名クリア
                LblSelectedFile.Text = "";
                BtnAdd.Enabled = false;     // 「新規保存」ボタン使用不可
                BtnUpdate.Enabled = true;   // 「保存」　　ボタン使用可
                BtnDelete.Enabled = false;  // 「削除」　　ボタン使用不可
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
                if (TxtJobName.Text.Trim() == "")
                {
                    MessageBox.Show("JOB名を入力して下さい", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if(LblSelectedFile.Text.Trim() == "")
                    {
                        LblSelectedFile.Text = TxtJobName.Text + ".csv";
                    }
                }
                
                string sMessage = GetJobEntryData();
                DialogResult dialogResult = MessageBox.Show($"下記ジョブデータを更新しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (LblSelectedFile.Text != (TxtJobName.Text + ".csv"))
                {
                    string sPutDataPath = "";
                    sPutDataPath += CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath);
                    sPutDataPath += "\\JOB\\";
                    sPutDataPath += LblSelectedFile.Text;
                    File.Delete(sPutDataPath);
                    LblSelectedFile.Text = TxtJobName.Text + ".csv";
                }

                // 全てのジョブ登録データ名称の取得
                string sFeederData = GetAllJobEntryData();

                string sPocketData = GetPocketData();

                // グループ１情報取得
                PubConstClass.lstGroupInfo[0] = "";
                PubConstClass.lstGroupInfo[0] += TxtGroup1.Text + ",";
                PubConstClass.lstGroupInfo[0] += TxtBoxQrItem11.Text + ",";
                PubConstClass.lstGroupInfo[0] += TxtBoxQrItem21.Text + ",";
                PubConstClass.lstGroupInfo[0] += TxtBoxQrItem31.Text + ",";
                PubConstClass.lstGroupInfo[0] += TxtBoxQrItem41.Text + ",";
                // グループ２情報取得
                PubConstClass.lstGroupInfo[1] = "";
                PubConstClass.lstGroupInfo[1] += TxtGroup2.Text + ",";
                PubConstClass.lstGroupInfo[1] += TxtBoxQrItem12.Text + ",";
                PubConstClass.lstGroupInfo[1] += TxtBoxQrItem22.Text + ",";
                PubConstClass.lstGroupInfo[1] += TxtBoxQrItem32.Text + ",";
                PubConstClass.lstGroupInfo[1] += TxtBoxQrItem42.Text + ",";
                // グループ３情報取得
                PubConstClass.lstGroupInfo[2] = "";
                PubConstClass.lstGroupInfo[2] += TxtGroup3.Text + ",";
                PubConstClass.lstGroupInfo[2] += TxtBoxQrItem13.Text + ",";
                PubConstClass.lstGroupInfo[2] += TxtBoxQrItem23.Text + ",";
                PubConstClass.lstGroupInfo[2] += TxtBoxQrItem33.Text + ",";
                PubConstClass.lstGroupInfo[2] += TxtBoxQrItem43.Text + ",";
                // グループ４情報取得
                PubConstClass.lstGroupInfo[3] = "";
                PubConstClass.lstGroupInfo[3] += TxtGroup4.Text + ",";
                PubConstClass.lstGroupInfo[3] += TxtBoxQrItem14.Text + ",";
                PubConstClass.lstGroupInfo[3] += TxtBoxQrItem24.Text + ",";
                PubConstClass.lstGroupInfo[3] += TxtBoxQrItem34.Text + ",";
                PubConstClass.lstGroupInfo[3] += TxtBoxQrItem44.Text + ",";
                // グループ５情報取得
                PubConstClass.lstGroupInfo[4] = "";
                PubConstClass.lstGroupInfo[4] += TxtGroup5.Text + ",";
                PubConstClass.lstGroupInfo[4] += TxtBoxQrItem15.Text + ",";
                PubConstClass.lstGroupInfo[4] += TxtBoxQrItem25.Text + ",";
                PubConstClass.lstGroupInfo[4] += TxtBoxQrItem35.Text + ",";
                PubConstClass.lstGroupInfo[4] += TxtBoxQrItem45.Text + ",";
                // ジョブファイルの保存
                WriteNewJobFile(LblSelectedFile.Text, sFeederData, sPocketData);
                // グループ名の更新
                // 現在の選択インデックスを保持
                int iIndex1 = CmbGroup1.SelectedIndex;
                int iIndex2 = CmbGroup2.SelectedIndex;
                int iIndex3 = CmbGroup3.SelectedIndex;
                int iIndex4 = CmbGroup4.SelectedIndex;
                int iIndex5 = CmbGroup5.SelectedIndex;
                // イジェクトを選択する
                CmbGroup1.SelectedIndex = 5;
                CmbGroup2.SelectedIndex = 5;
                CmbGroup3.SelectedIndex = 5;
                CmbGroup4.SelectedIndex = 5;
                CmbGroup5.SelectedIndex = 5;
                // 元の選択インデックスへ戻す
                CmbGroup1.SelectedIndex = iIndex1;
                CmbGroup2.SelectedIndex = iIndex2;
                CmbGroup3.SelectedIndex = iIndex3;
                CmbGroup4.SelectedIndex = iIndex4;
                CmbGroup5.SelectedIndex = iIndex5;

                BtnAdd.Enabled = true;      // 「新規保存」ボタン使用可
                BtnUpdate.Enabled = true;   // 「保存」　　ボタン使用可
                BtnDelete.Enabled = true;   // 「削除」　　ボタン使用可
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
                if (LblSelectedFile.Text.Trim() == "")
                {
                    MessageBox.Show("JOBを選択して下さい", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    return;
                }

                //string sMessage = GetJobEntryData();
                DialogResult dialogResult = MessageBox.Show($"JOB設定ファイル（{LblSelectedFile.Text}）を削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (File.Exists(sSelectedFile))
                {
                    File.Delete(sSelectedFile);
                    ClearDisplayData();
                    CommonModule.OutPutLogFile($"JOB設定ファイル（{sSelectedFile}）を削除しました");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 設定画面の項目をクリアする
        /// </summary>
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
                TxtQrReadItem1.Text = "";
                NmUpDnPropertyIdStart.Value = 1;
                NmUpDnPropertyIdKeta.Value = 1;
                // QR読取項目②
                TxtQrReadItem2.Text = "";
                NmUpDnPostalDateStart.Value = 1;
                NmUpDnPostalDateKeta.Value = 1;
                // QR読取項目③
                TxtQrReadItem3.Text = "";
                NmUpDnFileTypeStart.Value = 1;
                NmUpDnFileTypeKeta.Value = 1;
                // QR読取項目④
                TxtQrReadItem4.Text = "";
                NmUpDnManagementNoStart.Value = 1;
                NmUpDnManagementNoKeta.Value = 1;
                                
                // 選択ジョブファイル名クリア
                LblSelectedFile.Text = "";
                // グループ１～５のQR読取項目①名クリア
                TxtBoxQrItem11.Text = "";
                TxtBoxQrItem12.Text = "";
                TxtBoxQrItem13.Text = "";
                TxtBoxQrItem14.Text = "";
                TxtBoxQrItem15.Text = "";
                // グループ１～５のQR読取項目②名クリア
                TxtBoxQrItem21.Text = "";
                TxtBoxQrItem22.Text = "";
                TxtBoxQrItem23.Text = "";
                TxtBoxQrItem24.Text = "";
                TxtBoxQrItem25.Text = "";
                // グループ１～５のQR読取項目③名クリア
                TxtBoxQrItem31.Text = "";
                TxtBoxQrItem32.Text = "";
                TxtBoxQrItem33.Text = "";
                TxtBoxQrItem34.Text = "";
                TxtBoxQrItem35.Text = "";
                // グループ１～５のQR読取項目④名クリア
                TxtBoxQrItem41.Text = "";
                TxtBoxQrItem42.Text = "";
                TxtBoxQrItem43.Text = "";
                TxtBoxQrItem44.Text = "";
                TxtBoxQrItem45.Text = "";
                // ポケット名称クリア
                TxtPocketName1.Text = "";
                TxtPocketName2.Text = "";
                TxtPocketName3.Text = "";
                TxtPocketName4.Text = "";
                TxtPocketName5.Text = "";
                // グループ１～５のグループ名クリア
                TxtGroup1.Text = "";
                TxtGroup2.Text = "";
                TxtGroup3.Text = "";
                TxtGroup4.Text = "";
                TxtGroup5.Text = "";
                // ポケット①～⑤のグループ名クリア
                LblGroup1.Text = "";
                LblGroup2.Text = "";
                LblGroup3.Text = "";
                LblGroup4.Text = "";
                LblGroup5.Text = "";
                // ポケット切替件数クリア
                TxtQuantity1.Text = "0";
                TxtQuantity2.Text = "0";
                TxtQuantity3.Text = "0";
                TxtQuantity4.Text = "0";
                TxtQuantity5.Text = "0";
                // ポケット切替件数ON/OFFクリア
                CmbQuantOnOff1.Text = "OFF";
                CmbQuantOnOff2.Text = "OFF";
                CmbQuantOnOff3.Text = "OFF";
                CmbQuantOnOff4.Text = "OFF";
                CmbQuantOnOff5.Text = "OFF";

                // 「保存」ボタンを使用不可とする
                BtnUpdate.Enabled = false;
                // 「削除」ボタンを使用不可とする
                BtnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ClearDisplayData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string sSelectedFile = "";

        private void BtnJobSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                CommonModule.OutPutLogFile("■「JO選択」ボタンクリック");
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
                    sSelectedFile = ofd.FileName;
                    string[] sArray= sSelectedFile.Split('\\');
                    // ファイル名のみを表示する
                    LblSelectedFile.Text = sArray[sArray.Length - 1];
                    // ジョブ登録情報及びグループ１～５情報の読取り
                    CommonModule.ReadJobEntryListFile(sSelectedFile);
                    // 登録ジョブ項目を取得し表示
                    GetEntryJobItem(0);

                    BtnAdd.Enabled = true;          // 「新規保存」　ボタン使用可
                    BtnUpdate.Enabled = true;       // 「保存」　　　ボタン使用可                    
                    BtnDelete.Enabled = true;       // 「削除」　　　ボタン使用可
                    BtnCopyItem.Enabled = true;     // 「項目コピー」ボタン使用可
                    if (lstCopyItem.Count > 0)
                    {
                        BtnPasteItem.Enabled = true;    // 「項目貼付け」ボタン使用可能
                    }
                    else
                    {
                        BtnPasteItem.Enabled = false;   // 「項目貼付け」ボタン使用不可
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobSelect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PubConstClass.lstGroupInfo.Count == 0 || CmbGroup1.SelectedIndex > 4)
            {
                LblGroup1.Text = "リジェクト";
                return;
            }
            string[] sArray = PubConstClass.lstGroupInfo[CmbGroup1.SelectedIndex].Split(',');
            LblGroup1.Text = sArray[0];
        }

        private void CmbGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PubConstClass.lstGroupInfo.Count == 0 || CmbGroup2.SelectedIndex > 4)
            {
                LblGroup2.Text = "リジェクト";
                return;
            }
            string[] sArray = PubConstClass.lstGroupInfo[CmbGroup2.SelectedIndex].Split(',');
            LblGroup2.Text = sArray[0];

        }

        private void CmbGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PubConstClass.lstGroupInfo.Count == 0 || CmbGroup3.SelectedIndex > 4)
            {
                LblGroup3.Text = "リジェクト";
                return;
            }

            string[] sArray = PubConstClass.lstGroupInfo[CmbGroup3.SelectedIndex].Split(',');
            LblGroup3.Text = sArray[0];

        }

        private void CmbGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PubConstClass.lstGroupInfo.Count == 0 || CmbGroup4.SelectedIndex > 4)
            {
                LblGroup4.Text = "リジェクト";
                return;
            }

            string[] sArray = PubConstClass.lstGroupInfo[CmbGroup4.SelectedIndex].Split(',');
            LblGroup4.Text = sArray[0];

        }

        private void CmbGroup5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PubConstClass.lstGroupInfo.Count == 0 || CmbGroup5.SelectedIndex > 4)
            {
                LblGroup5.Text = "リジェクト";
                return;
            }

            string[] sArray = PubConstClass.lstGroupInfo[CmbGroup5.SelectedIndex].Split(',');
            LblGroup5.Text = sArray[0];

        }

        private List<string> lstCopyItem = new List<string>();
        private List<string> lstCopyGroupInfo = new List<string>();

        /// <summary>
        /// 「項目コピー」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCopyItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("表示項目をコピーしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                // 「項目貼付け」ボタン使用可
                BtnPasteItem.Enabled = true;

                lstCopyItem.Clear();
                lstCopyItem.Add(CmbMedia.Text);
                lstCopyItem.Add(DtpDateReceipt.Text);
                lstCopyItem.Add(CmbDateReceipt.Text);

                #region QR読取項目①～④
                lstCopyItem.Add(CmbReadCheck.Text);
                lstCopyItem.Add(TxtQrReadItem1.Text);
                lstCopyItem.Add(NmUpDnPropertyIdStart.Value.ToString());
                lstCopyItem.Add(NmUpDnPropertyIdKeta.Value.ToString());
                lstCopyItem.Add(TxtQrReadItem2.Text);
                lstCopyItem.Add(NmUpDnPostalDateStart.Value.ToString());
                lstCopyItem.Add(NmUpDnPostalDateKeta.Value.ToString());
                lstCopyItem.Add(TxtQrReadItem3.Text);
                lstCopyItem.Add(NmUpDnFileTypeStart.Value.ToString());
                lstCopyItem.Add(NmUpDnFileTypeKeta.Value.ToString());
                lstCopyItem.Add(TxtQrReadItem4.Text);
                lstCopyItem.Add(NmUpDnManagementNoStart.Value.ToString());
                lstCopyItem.Add(NmUpDnManagementNoKeta.Value.ToString());
                #endregion

                lstCopyItem.Add(CmbDuplication.Text);
                lstCopyItem.Add(CmbDoubleFeed.Text);
                lstCopyItem.Add(CmbUltrasonicDetection.Text);
                lstCopyItem.Add(CmbCheckNumberOfDigits.Text);
                lstCopyItem.Add(CmbLogCreationConditions.Text);
                lstCopyItem.Add(CmbReadingFunction.Text);

                #region ポケット①～⑤
                lstCopyItem.Add(TxtPocketName1.Text);
                lstCopyItem.Add(TxtPocketName2.Text);
                lstCopyItem.Add(TxtPocketName3.Text);
                lstCopyItem.Add(TxtPocketName4.Text);
                lstCopyItem.Add(TxtPocketName5.Text);
                #endregion
                #region グループ①～⑤
                lstCopyItem.Add(LblGroup1.Text);
                lstCopyItem.Add(LblGroup2.Text);
                lstCopyItem.Add(LblGroup3.Text);
                lstCopyItem.Add(LblGroup4.Text);
                lstCopyItem.Add(LblGroup5.Text);
                #endregion
                #region ポケット切替件数①～⑤
                lstCopyItem.Add(TxtQuantity1.Text);
                lstCopyItem.Add(TxtQuantity2.Text);
                lstCopyItem.Add(TxtQuantity3.Text);
                lstCopyItem.Add(TxtQuantity4.Text);
                lstCopyItem.Add(TxtQuantity5.Text);
                #endregion
                #region ポケット切替件数ON/OFF①～⑤
                lstCopyItem.Add(CmbQuantOnOff1.Text);
                lstCopyItem.Add(CmbQuantOnOff2.Text);
                lstCopyItem.Add(CmbQuantOnOff3.Text);
                lstCopyItem.Add(CmbQuantOnOff4.Text);
                lstCopyItem.Add(CmbQuantOnOff5.Text);
                #endregion

                #region グループ情報①～⑤
                lstCopyGroupInfo.Clear();
                lstCopyGroupInfo.Add(PubConstClass.lstGroupInfo[0]);
                lstCopyGroupInfo.Add(PubConstClass.lstGroupInfo[1]);
                lstCopyGroupInfo.Add(PubConstClass.lstGroupInfo[2]);
                lstCopyGroupInfo.Add(PubConstClass.lstGroupInfo[3]);
                lstCopyGroupInfo.Add(PubConstClass.lstGroupInfo[4]);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnCopyItem_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「項目貼付け」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPasteItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("コピーした項目を表示項目として貼り付けますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
               
                int iIndex = 0;
                CmbMedia.Text = lstCopyItem[iIndex++];
                DtpDateReceipt.Text = lstCopyItem[iIndex++];
                CmbDateReceipt.Text = lstCopyItem[iIndex++];

                #region QR読取項目①～④
                CmbReadCheck.Text = lstCopyItem[iIndex++]; 
                TxtQrReadItem1.Text = lstCopyItem[iIndex++];
                NmUpDnPropertyIdStart.Value = int.Parse(lstCopyItem[iIndex++]);
                NmUpDnPropertyIdKeta.Value = int.Parse(lstCopyItem[iIndex++]);
                TxtQrReadItem2.Text = lstCopyItem[iIndex++];
                NmUpDnPostalDateStart.Value = int.Parse(lstCopyItem[iIndex++]);
                NmUpDnPostalDateKeta.Value = int.Parse(lstCopyItem[iIndex++]);
                TxtQrReadItem3.Text = lstCopyItem[iIndex++];
                NmUpDnFileTypeStart.Value = int.Parse(lstCopyItem[iIndex++]);
                NmUpDnFileTypeKeta.Value = int.Parse(lstCopyItem[iIndex++]);
                TxtQrReadItem4.Text = lstCopyItem[iIndex++];
                NmUpDnManagementNoStart.Value = int.Parse(lstCopyItem[iIndex++]);
                NmUpDnManagementNoKeta.Value = int.Parse(lstCopyItem[iIndex++]);
                #endregion

                CmbDuplication.Text = lstCopyItem[iIndex++];
                CmbDoubleFeed.Text = lstCopyItem[iIndex++];
                CmbUltrasonicDetection.Text = lstCopyItem[iIndex++];
                CmbCheckNumberOfDigits.Text = lstCopyItem[iIndex++];
                CmbLogCreationConditions.Text = lstCopyItem[iIndex++];
                CmbReadingFunction.Text = lstCopyItem[iIndex++];

                #region ポケット①～⑤
                TxtPocketName1.Text = lstCopyItem[iIndex++];
                TxtPocketName2.Text = lstCopyItem[iIndex++];
                TxtPocketName3.Text = lstCopyItem[iIndex++];
                TxtPocketName4.Text = lstCopyItem[iIndex++];
                TxtPocketName5.Text = lstCopyItem[iIndex++];
                #endregion
                #region グループ①～⑤
                LblGroup1.Text = lstCopyItem[iIndex++];
                LblGroup2.Text = lstCopyItem[iIndex++];
                LblGroup3.Text = lstCopyItem[iIndex++];
                LblGroup4.Text = lstCopyItem[iIndex++];
                LblGroup5.Text = lstCopyItem[iIndex++];
                #endregion
                #region ポケット切替件数①～⑤
                TxtQuantity1.Text = lstCopyItem[iIndex++];
                TxtQuantity2.Text = lstCopyItem[iIndex++];
                TxtQuantity3.Text = lstCopyItem[iIndex++];
                TxtQuantity4.Text = lstCopyItem[iIndex++];
                TxtQuantity5.Text = lstCopyItem[iIndex++];
                #endregion
                #region ポケット切替件数ON/OFF①～⑤
                CmbQuantOnOff1.Text = lstCopyItem[iIndex++];
                CmbQuantOnOff2.Text = lstCopyItem[iIndex++];
                CmbQuantOnOff3.Text = lstCopyItem[iIndex++];
                CmbQuantOnOff4.Text = lstCopyItem[iIndex++];
                CmbQuantOnOff5.Text = lstCopyItem[iIndex++];
                #endregion
                #region グループ情報①～⑤
                PubConstClass.lstGroupInfo.Clear();
                PubConstClass.lstGroupInfo.Add(lstCopyGroupInfo[0]);
                PubConstClass.lstGroupInfo.Add(lstCopyGroupInfo[1]);
                PubConstClass.lstGroupInfo.Add(lstCopyGroupInfo[2]);
                PubConstClass.lstGroupInfo.Add(lstCopyGroupInfo[3]);
                PubConstClass.lstGroupInfo.Add(lstCopyGroupInfo[4]);
                #endregion
                
                string[] sArray = PubConstClass.lstGroupInfo[0].Split(',');
                TxtGroup1.Text = sArray[0];
                TxtBoxQrItem11.Text = sArray[1];
                TxtBoxQrItem21.Text = sArray[2];
                TxtBoxQrItem31.Text = sArray[3];
                TxtBoxQrItem41.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[1].Split(',');
                TxtGroup2.Text = sArray[0];
                TxtBoxQrItem12.Text = sArray[1];
                TxtBoxQrItem22.Text = sArray[2];
                TxtBoxQrItem32.Text = sArray[3];
                TxtBoxQrItem42.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[2].Split(',');
                TxtGroup3.Text = sArray[0];
                TxtBoxQrItem13.Text = sArray[1];
                TxtBoxQrItem23.Text = sArray[2];
                TxtBoxQrItem33.Text = sArray[3];
                TxtBoxQrItem43.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[3].Split(',');
                TxtGroup4.Text = sArray[0];
                TxtBoxQrItem14.Text = sArray[1];
                TxtBoxQrItem24.Text = sArray[2];
                TxtBoxQrItem34.Text = sArray[3];
                TxtBoxQrItem44.Text = sArray[4];

                sArray = PubConstClass.lstGroupInfo[4].Split(',');
                TxtGroup5.Text = sArray[0];
                TxtBoxQrItem15.Text = sArray[1];
                TxtBoxQrItem25.Text = sArray[2];
                TxtBoxQrItem35.Text = sArray[3];
                TxtBoxQrItem45.Text = sArray[4];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPasteItem_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
