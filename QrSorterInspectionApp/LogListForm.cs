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
                CmbLogType.SelectedIndex = 1;

                #region 検査ログのヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvLogContent.View = View.Details;
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
                col09.Text = "エラーCD";
                col10.Text = "仕分①";
                col11.Text = "仕分②";
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
                col01.Width = 120;         // 日付
                col02.Width = 100;         // 時刻
                col03.Width = 340;         // 読取値
                col04.Width = 80;          // 判定
                col05.Width = 340;         // 正解データファイル名
                col06.Width = 110;         // 受領日
                col07.Width = 130;         // 作業員情報（機械情報）
                col08.Width = 130;         // 物件情報（DPS/BPO/Broad等）
                col09.Width = 100;         // エラーコード
                col10.Width = 100;         // 仕分けコード①
                col11.Width = 100;         // 仕分けコード②
                ColumnHeader[] colHeaderOK = new[] { col01, col02, col03, col04, col05,
                                                     col06, col07, col08, col09, col10,
                                                     col11
                                                   };
                LsvLogContent.Columns.AddRange(colHeaderOK);
                #endregion

                #region 不着事由の項目設定
                CommonModule.ReadNonDeliveryList();
                cmbReasonForNonDelivery.Items.Clear();
                foreach(var items in PubConstClass.lstNonDeliveryList)
                {
                    cmbReasonForNonDelivery.Items.Add(items);
                }
                cmbReasonForNonDelivery.SelectedIndex = 0;
                #endregion

                ChkAllItem.Checked = true;

                LblLogFileCount.Text = "";
                LblContentCount.Text = "";
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

        // ログファイル一覧格納リスト
        private List<string> lstLogFileList = new List<string>();

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
                    lstLogFileList.Clear();
                    LsbLogList.Items.Clear();
                    // 検査ログ対象ファイルの取得
                    foreach (string sTranFile in Directory.GetFiles(CommonModule.IncludeTrailingPathDelimiter(
                                                                      PubConstClass.pblInternalTranFolder),
                                                                      "*", SearchOption.AllDirectories))
                    {
                        CommonModule.OutPutLogFile($"■検査ログ対象ファイル：{sTranFile}");
                        sArray = sTranFile.Split('\\');
                        LsbLogList.Items.Add(sArray[sArray.Length - 1]);
                        lstLogFileList.Add(sTranFile);
                    }
                    LblLogFileCount.Text= $"検査ログファイル件数：{LsbLogList.Items.Count.ToString("#,###")} 件";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbLogType_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private int iPreviouslySelectedRow = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbLogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sReadLogFile;
            string sData;
            try
            {
                if (LsbLogList.SelectedItem == null)
                {
                    return;
                }
                //if (iPreviouslySelectedRow == LsbLogList.SelectedIndex)
                //{
                //    // 選択行が変わらない場合は何もしない
                //    return;
                //}
                //iPreviouslySelectedRow = LsbLogList.SelectedIndex;

                LsvLogContent.Items.Clear();

                sReadLogFile = lstLogFileList[LsbLogList.SelectedIndex];

                PubConstClass.lstJobEntryList.Clear();
                using (StreamReader sr = new StreamReader(sReadLogFile, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        DisplayOneData(sData);                        
                    }
                }
                LblContentCount.Text = $"表示ログ件数：{LsvLogContent.Items.Count.ToString("#,###")} 件"; ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsbLogList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOneData(string sData)
        {
            try
            {
                string[] sArray = sData.Split(',');
                
                string[] col = new string[11];                                              
                ListViewItem itm;
                col[0] = sArray[0];
                col[1] = sArray[1];
                col[2] = sArray[2];
                col[3] = sArray[3];
                col[4] = sArray[4];
                col[5] = sArray[5];
                col[6] = sArray[6];
                col[7] = sArray[7];
                col[8] = sArray[8];
                col[9] = sArray[9];
                col[10] = sArray[10];

                // データの表示
                itm = new ListViewItem(col);
                LsvLogContent.Items.Add(itm);
                LsvLogContent.Items[LsvLogContent.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvLogContent.Select();
                LsvLogContent.Items[LsvLogContent.Items.Count - 1].EnsureVisible();

                if (LsvLogContent.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 11; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvLogContent.Items[LsvLogContent.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayOneData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkAllItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAllItem.Checked)
                {
                    GrpInspectionDate.Enabled = false;
                    GrpReasonForNonDelivery.Enabled = false;
                }
                else
                {
                    GrpInspectionDate.Enabled = true;
                    GrpReasonForNonDelivery.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ChkAllItem_CheckedChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
