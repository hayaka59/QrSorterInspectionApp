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
    public partial class RegisterAccountForm : Form
    {
        public RegisterAccountForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("SV・OP設定画面を表示しました");

                #region SV・OP一覧のヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvAccount.View = View.Details;
                ColumnHeader col1 = new ColumnHeader();
                ColumnHeader col2 = new ColumnHeader();
                ColumnHeader col3 = new ColumnHeader();
                col1.Text = "ID";
                col2.Text = "名前";
                col3.Text = "権限";
                col1.TextAlign = HorizontalAlignment.Center;
                col2.TextAlign = HorizontalAlignment.Center;
                col3.TextAlign = HorizontalAlignment.Center;
                col1.Width = 150;         // 
                col2.Width = 200;         // 
                col3.Width = 150;         // 
                ColumnHeader[] colHeaderOK = new[] { col1, col2, col3 };
                LsvAccount.Columns.AddRange(colHeaderOK);
                #endregion

                CmbAuthority.Items.Clear();
                CmbAuthority.Items.Add("OP");
                CmbAuthority.Items.Add("SV");
                CmbAuthority.SelectedIndex = 1;

                DisplayAccount("taro toppan", "凸版 太郎", "SV");
                DisplayAccount("admin", "システム管理者", "SV");
                DisplayAccount("id001", "〇〇 〇〇", "OP");
                DisplayAccount("id002", "〇〇 〇〇", "OP");

            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "【RegisterAccountForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// アカウントの表示処理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="kengen"></param>
        private void DisplayAccount(string id, string name, string kengen)
        {
            try
            {
                string[] col = new string[3];
                ListViewItem itm;

                col[0] = id;
                col[1] = name;
                col[2] = kengen;

                // データの表示
                itm = new ListViewItem(col);
                LsvAccount.Items.Add(itm);
                LsvAccount.Items[LsvAccount.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvAccount.Select();
                LsvAccount.Items[LsvAccount.Items.Count - 1].EnsureVisible();

                if (LsvAccount.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 3; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvAccount.Items[LsvAccount.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayAccount】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// 「保存」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSave_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
