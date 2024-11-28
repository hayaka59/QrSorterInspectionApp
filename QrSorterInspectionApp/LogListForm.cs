using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

                #region 検査ログのヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvAccount.View = View.Details;
                ColumnHeader col01 = new ColumnHeader();
                ColumnHeader col02 = new ColumnHeader();
                ColumnHeader col03 = new ColumnHeader();
                ColumnHeader col04 = new ColumnHeader();
                ColumnHeader col05 = new ColumnHeader();
                ColumnHeader col06 = new ColumnHeader();
                ColumnHeader col07 = new ColumnHeader();
                ColumnHeader col08 = new ColumnHeader();
                ColumnHeader col09 = new ColumnHeader();
                ColumnHeader col10 = new ColumnHeader();
                ColumnHeader col11 = new ColumnHeader();
                col01.Text = "　　日付";
                col02.Text = "時刻";
                col03.Text = "読取値";
                col04.Text = "判定";
                col05.Text = "正解データファイル名";
                col06.Text = "受領日";
                //col07.Text = "作業員情報（機械情報）";
                col07.Text = "作業員情報";
                //col08.Text = "物件情報（DPS/BPO/Broad等）";
                col08.Text = "物件情報";
                col09.Text = "エラーコード";
                col10.Text = "仕分けコード①";
                col11.Text = "仕分けコード②";
                col01.TextAlign = HorizontalAlignment.Center;
                col02.TextAlign = HorizontalAlignment.Center;
                col03.TextAlign = HorizontalAlignment.Center;
                col04.TextAlign = HorizontalAlignment.Center;
                col05.TextAlign = HorizontalAlignment.Center;
                col06.TextAlign = HorizontalAlignment.Center;
                col07.TextAlign = HorizontalAlignment.Center;
                col08.TextAlign = HorizontalAlignment.Center;
                col09.TextAlign = HorizontalAlignment.Center;
                col10.TextAlign = HorizontalAlignment.Center;
                col11.TextAlign = HorizontalAlignment.Center;
                col01.Width = 130;         // 日付
                col02.Width = 130;         // 時刻
                col03.Width = 150;         // 読取値
                col04.Width = 150;         // 判定
                col05.Width = 180;         // 正解データファイル名
                col06.Width = 150;         // 受領日
                col07.Width = 150;         // 作業員情報（機械情報）
                col08.Width = 150;         // 物件情報（DPS/BPO/Broad等）
                col09.Width = 150;         // エラーコード
                col10.Width = 150;         // 仕分けコード①
                col11.Width = 150;         // 仕分けコード②
                ColumnHeader[] colHeaderOK = new[] { col01, col02, col03, col04, col05,
                                                     col06, col07, col08, col09, col10,
                                                     col11
                                                   };
                LsvAccount.Columns.AddRange(colHeaderOK);
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LogListForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string[] sArray;

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
                    // 検査ログ対象ファイルの取得
                    foreach (string sTranFile in Directory.GetFiles(CommonModule.IncludeTrailingPathDelimiter(
                                                                      PubConstClass.pblInternalTranFolder),
                                                                      "*", SearchOption.AllDirectories))
                    {
                        CommonModule.OutPutLogFile($"■検査ログ対象ファイル：{sTranFile}");
                        sArray = sTranFile.Split('\\');
                        //LsbLogList.Items.Add(sArray[sArray.Length - 1]);
                        LsbLogList.Items.Add(sTranFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbLogType_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int iPreviouslySelectedRow = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbLogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LsbLogList.SelectedItem == null)
                {
                    return;
                }
                if (iPreviouslySelectedRow == LsbLogList.SelectedIndex)
                {
                    // 選択業が変わらない場合は何もしない
                    return;
                }
                iPreviouslySelectedRow = LsbLogList.SelectedIndex;

                LsvAccount.Items.Clear();
                for (int i = 0; i < 100; i++)
                {
                    DisplayOneData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbLogList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOneData()
        {
            try
            {
                string[] col = new string[11];
                ListViewItem itm;

                col[0] = DateTime.Now.ToString("yyyy/MM/dd");
                col[1] = DateTime.Now.ToString("HH:mm:ss");
                col[2] = DateTime.Now.ToString("HHmmss-fff");
                col[3] = DateTime.Now.ToString("HHmmss-fff");
                col[4] = DateTime.Now.ToString("HHmmss-fff");
                col[5] = DateTime.Now.ToString("HHmmss-fff");
                col[6] = DateTime.Now.ToString("HHmmss-fff");
                col[7] = DateTime.Now.ToString("HHmmss-fff");
                col[8] = DateTime.Now.ToString("HHmmss-fff");
                col[9] = DateTime.Now.ToString("HHmmss-fff");
                col[10] = DateTime.Now.ToString("HHmmss-fff");

                // データの表示
                itm = new ListViewItem(col);
                LsvAccount.Items.Add(itm);
                LsvAccount.Items[LsvAccount.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvAccount.Select();
                LsvAccount.Items[LsvAccount.Items.Count - 1].EnsureVisible();

                if (LsvAccount.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 11; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvAccount.Items[LsvAccount.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayOneData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
    }
}
