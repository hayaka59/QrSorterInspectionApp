using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                LblJobName.Text = "チューリッヒ";
                LblMedia.Text = "封筒";
                LsbJobListSorter.Items.Clear();
                LsbJobListSorter.Items.Add("テスト ハガキ");
                LsbJobListSorter.Items.Add("テスト 封筒");
                LsbJobListSorter.Items.Add("チューリッヒ① ハガキ");
                LsbJobListSorter.Items.Add("チューリッヒ① 封筒");
                LsbJobListSorter.SelectedIndex = 0;

                LsbJobListFeeder.Items.Clear();
                LsbJobListFeeder.Items.Add("テスト ハガキ");
                LsbJobListFeeder.Items.Add("テスト 封筒");
                LsbJobListFeeder.Items.Add("チューリッヒ① ハガキ");
                LsbJobListFeeder.Items.Add("チューリッヒ① 封筒");
                LsbJobListFeeder.SelectedIndex = 0;

                TxtJobName.Text = "チューリッヒ";
                CmbMedia.Items.Clear();
                CmbMedia.Items.Add("ハガキ");
                CmbMedia.Items.Add("封筒");
                CmbMedia.SelectedIndex = 0;

                CmbDuplication.Items.Clear();
                CmbDuplication.Items.Add("ON");
                CmbDuplication.Items.Add("OFF");
                CmbDuplication.SelectedIndex = 0;

                CmbDoubleFeed.Items.Clear();
                CmbDoubleFeed.Items.Add("ON");
                CmbDoubleFeed.Items.Add("OFF");
                CmbDoubleFeed.SelectedIndex = 0;

                RchTxtQrInfo.Text = "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567";
                RchTxtQrInfoForSorter.Text = RchTxtQrInfo.Text;

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

                SetColorForQrData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSetting_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sArray = LsbJobListSorter.Text.Split(' ');
                LblJobName.Text = sArray[0];
                LblMedia.Text = sArray[1];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbJobList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbJobListFeeder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] sArray;
            try
            {
                sArray = LsbJobListFeeder.Text.Split(' ');
                TxtJobName.Text = sArray[0];
                CmbMedia.Text = sArray[1];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbJobList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetColorForQrData()
        {
            try
            {
                SetColorForQrDataSub(RchTxtQrInfo);
                SetColorForQrDataSub(RchTxtQrInfoForSorter);

                //// QR全体
                //RchTxtQrInfo.Select(0, RchTxtQrInfo.Text.Length);
                //RchTxtQrInfo.SelectionBackColor = Color.White;
                //RchTxtQrInfo.SelectionColor = Color.Black;
                //// 物件ID
                //RchTxtQrInfo.SelectionStart = decimal.ToInt32(NmUpDnPropertyIdStart.Value) - 1;
                //RchTxtQrInfo.SelectionLength = decimal.ToInt32(NmUpDnPropertyIdKeta.Value);
                //RchTxtQrInfo.SelectionBackColor = Color.LimeGreen;
                //RchTxtQrInfo.SelectionColor = Color.Black;
                //// 局出し日
                //RchTxtQrInfo.SelectionStart = decimal.ToInt32(NmUpDnPostalDateStart.Value) - 1;
                //RchTxtQrInfo.SelectionLength = decimal.ToInt32(NmUpDnPostalDateKeta.Value);
                //RchTxtQrInfo.SelectionBackColor = Color.SkyBlue;
                //RchTxtQrInfo.SelectionColor = Color.Black;
                //// ファイル区分
                //RchTxtQrInfo.SelectionStart = decimal.ToInt32(NmUpDnFileTypeStart.Value) - 1;
                //RchTxtQrInfo.SelectionLength = decimal.ToInt32(NmUpDnFileTypeKeta.Value);
                //RchTxtQrInfo.SelectionBackColor = Color.Orange;
                //RchTxtQrInfo.SelectionColor = Color.Black;
                //// 物件ID
                //RchTxtQrInfo.SelectionStart = decimal.ToInt32(NmUpDnManagementNoStart.Value) - 1;
                //RchTxtQrInfo.SelectionLength = decimal.ToInt32(NmUpDnManagementNoKeta.Value);
                //RchTxtQrInfo.SelectionBackColor = Color.Red;
                //RchTxtQrInfo.SelectionColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetColorForQrData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
    }
}
