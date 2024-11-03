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

                RchTxtQrInfo.Text = "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567890";
                RchTxtQrInfo.Text += "1234567";
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
                sArray = LsbJobListSorter.Text.Split(' ');
                LblJobName.Text = sArray[0];
                LblMedia.Text = sArray[1];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbJobList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Test(object sender, EventArgs e)
        {
            try
            {
                // QR全体
                RchTxtQrInfo.Select(0, RchTxtQrInfo.Text.Length);
                RchTxtQrInfo.SelectionBackColor = Color.White;
                RchTxtQrInfo.SelectionColor = Color.Black;

                // ファクトリー番号
                RchTxtQrInfo.SelectionStart = decimal.ToInt32(numericUpDown1.Value) - 1;
                RchTxtQrInfo.SelectionLength = decimal.ToInt32(numericUpDown2.Value);
                RchTxtQrInfo.SelectionBackColor = Color.LightPink;
                RchTxtQrInfo.SelectionColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【Test】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
