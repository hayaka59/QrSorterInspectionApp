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
    public partial class LogListForm : Form
    {
        public LogListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogListForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("ログ画面を表示しました");

                CmbLogType.Items.Clear();
                CmbLogType.Items.Add("機械ログ");
                CmbLogType.Items.Add("検査ログ");
                CmbLogType.SelectedIndex = 0;

                LblContent.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LogListForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Owner.Show();
                Owner.Refresh();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnClose_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbLogType.SelectedIndex == 0) {
                    LsbLogList.Items.Clear();
                    LsbLogList.Items.Add("機械ログ_2024年10月28日_XXXXXXXXXXXX");
                    LsbLogList.Items.Add("機械ログ_2024年10月29日_YYYYYYYYYYYY");
                    LsbLogList.Items.Add("機械ログ_2024年10月30日_ZZZZZZZZZZZZ");

                }
                else
                {
                    LsbLogList.Items.Clear();
                    LsbLogList.Items.Add("検査ログ_2024年10月28日_09時01分12秒");
                    LsbLogList.Items.Add("検査ログ_2024年10月29日_09時02分24秒");
                    LsbLogList.Items.Add("検査ログ_2024年10月30日_09時03分40秒");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbLogType_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LsbLogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LsbLogList.SelectedItem == null)
                {
                    return;
                }
                string SelectFileName = LsbLogList.SelectedItems[0].ToString();
                LblContent.Text = "選択したファイル（" + SelectFileName + "）" + Environment.NewLine + "の内容を表示する";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbLogList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
