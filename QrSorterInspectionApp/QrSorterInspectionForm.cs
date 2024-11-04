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
    public partial class QrSorterInspectionForm : Form
    {
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
                colOK3.Text = "QRコード";
                colOK4.Text = "トレイ";
                colOK5.Text = "備考";
                colOK1.TextAlign = HorizontalAlignment.Center;
                colOK2.TextAlign = HorizontalAlignment.Center;
                colOK3.TextAlign = HorizontalAlignment.Center;
                colOK4.TextAlign = HorizontalAlignment.Center;
                colOK5.TextAlign = HorizontalAlignment.Center;
                colOK1.Width = 70;          // 
                colOK2.Width = 200;         // 
                colOK3.Width = 150;         // 
                colOK4.Width = 90;          // 
                colOK5.Width = 60;          // 
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
                colNG3.Text = "QRコード";
                colNG4.Text = "トレイ";
                colNG5.Text = "備考";
                colNG1.TextAlign = HorizontalAlignment.Center;
                colNG2.TextAlign = HorizontalAlignment.Center;
                colNG3.TextAlign = HorizontalAlignment.Center;
                colNG4.TextAlign = HorizontalAlignment.Center;
                colNG5.TextAlign = HorizontalAlignment.Center;
                colNG1.Width = 70;          // 
                colNG2.Width = 200;         // 
                colNG3.Width = 150;         // 
                colNG4.Width = 90;          // 
                colNG5.Width = 60;          // 
                ColumnHeader[] colHeaderNG = new[] { colNG1, colNG2, colNG3, colNG4, colNG5 };
                LsvNGHistory.Columns.AddRange(colHeaderNG);
                #endregion

                TimDateTime.Interval = 1000;
                TimDateTime.Enabled = true;

                LblBox1.Text = "0";
                LblBox2.Text = "0";
                LblBox3.Text = "0";
                LblBox4.Text = "0";
                LblBoxEject.Text = "0";

                LblTotalCount.Text = "0";
                LblOKCount.Text = "0";
                LblNGCount.Text = "0";
                
                LblPocket1.Text = "";
                LblPocket2.Text = "";
                LblPocket3.Text = "";
                LblPocket4.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【QrSorterInspectionForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【TimDateTime_Tick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimTestRun_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                TimTestRun.Enabled = false;
                MessageBox.Show(ex.Message, "【TimDateTime_Tick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int iOKCount = 0;
        private int iNGCount = 0;
        private int iBoxNumber = 1;

        private int iBox1Count = 0;
        private int iBox2Count = 0;
        private int iBox3Count = 0;
        private int iBox4Count = 0;

        private void BtnStartInspection_Click(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[10];
                ListViewItem itm;

                iOKCount++;
                LblOKCount.Text = iOKCount.ToString("#,##0");
                LblTotalCount.Text = (iOKCount + iNGCount).ToString("#,##0");
                col[0] = iOKCount.ToString("00000");
                col[1] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[2] = "QR" + iOKCount.ToString("000000000");
                col[3] = "トレイ１";
                col[4] = "---";

                if (iBoxNumber == 1)
                {
                    iBox1Count++;
                    LblBox1.Text = iBox1Count.ToString("0");
                    LblPocket1.Text = "QR" + iOKCount.ToString("000000000");
                }
                else if (iBoxNumber == 2)
                {
                    iBox2Count++;
                    LblBox2.Text = iBox2Count.ToString("0");
                    LblPocket2.Text = "QR" + iOKCount.ToString("000000000");
                }
                else if (iBoxNumber == 3)
                {
                    iBox3Count++;
                    LblBox3.Text = iBox3Count.ToString("0");
                    LblPocket3.Text = "QR" + iOKCount.ToString("000000000");
                }
                else if (iBoxNumber == 4) {
                    iBox4Count++;
                    LblBox4.Text = iBox4Count.ToString("0");
                    LblPocket4.Text = "QR" + iOKCount.ToString("000000000");
                }
                iBoxNumber++;
                if (iBoxNumber > 4) {
                    iBoxNumber = 1;
                }

                // データの表示
                itm = new ListViewItem(col);
                LsvOKHistory.Items.Add(itm);
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
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "【BtnStartInspection_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnStopInspection_Click(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[10];
                ListViewItem itm;

                iNGCount++;
                LblTotalCount.Text = (iOKCount + iNGCount).ToString("#,##0");
                LblNGCount.Text = iNGCount.ToString("#,##0");
                LblBoxEject.Text = iNGCount.ToString("0");

                col[0] = iNGCount.ToString("00000");
                col[1] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[2] = "QR" + iNGCount.ToString("000000000");
                col[3] = "ﾌｨｰﾄﾞNG";
                col[4] = "---";

                // データの表示
                itm = new ListViewItem(col);
                LsvNGHistory.Items.Add(itm);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnStartInspection_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
