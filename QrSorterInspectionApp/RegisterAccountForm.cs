using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QrSorterInspectionApp
{
    public partial class RegisterAccountForm : Form
    {
        public RegisterAccountForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
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

                DisplayAccountAll();

            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "【RegisterAccountForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAccountAll()
        {
            try
            {
                LsvAccount.Items.Clear();
                CommonModule.ReadUserAccountFile();
                foreach (var item in PubConstClass.lstUserAccount)
                {
                    string[] sArray = item.Split(',');
                    DisplayAccount(sArray[0], sArray[1], sArray[2]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayAccountAll】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetAcountData()
        {
            try
            {
                string sMessage = Environment.NewLine;
                sMessage += "ＩＤ：" + TxtId.Text + Environment.NewLine;
                sMessage += "名前：" + TxtName.Text + Environment.NewLine;
                sMessage += "権限：" + CmbAuthority.Text + Environment.NewLine;
                sMessage += "パスワード：" + TxtPassword.Text;
                return sMessage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetAcountData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "アカウントデータが取得できませんでした";
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
                string sMessage = GetAcountData();
                DialogResult dialogResult = MessageBox.Show($"下記アカウントを追加しますか？{sMessage}","確認",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 追加アカウントデータ作成
                string sData = "";
                sData += TxtId.Text + ",";
                sData += TxtName.Text + ",";
                sData += CmbAuthority.Text + ",";
                sData += TxtPassword.Text;
                // アカウントデータの追加
                PubConstClass.lstUserAccount.Add(sData);
                // ユーザーアカウントファイルに書込
                CommonModule.WriteUserAccountFile();
                // アカウントデータ表示
                DisplayAccountAll();
                // 最終行の選択とフォーカスセット
                int idx = LsvAccount.Items.Count - 1;
                LsvAccount.Items[idx].Selected = true;
                LsvAccount.Select();
                LsvAccount.Items[idx].Focused = true;
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
                string sMessage = GetAcountData();
                DialogResult dialogResult = MessageBox.Show($"下記アカウントで更新しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 更新アカウントデータ作成
                string sData = "";
                sData += TxtId.Text + ",";
                sData += TxtName.Text + ",";
                sData += CmbAuthority.Text + ",";
                sData += TxtPassword.Text;
                // アカウントデータの更新
                int idx = LsvAccount.SelectedItems[0].Index;
                PubConstClass.lstUserAccount[idx] = sData;
                // ユーザーアカウントファイルに書込
                CommonModule.WriteUserAccountFile();
                // アカウントデータ表示
                DisplayAccountAll();
                // 行選択とフォーカスセット
                LsvAccount.Items[idx].Selected = true;
                LsvAccount.Select();
                LsvAccount.Items[idx].Focused = true;
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
                string sMessage = GetAcountData();
                DialogResult dialogResult = MessageBox.Show($"下記アカウントを削除しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                // 選択行番号取得とデータ削除
                int idx = LsvAccount.SelectedItems[0].Index;                
                PubConstClass.lstUserAccount.RemoveAt(idx);
                // ユーザーアカウントファイルに書込
                CommonModule.WriteUserAccountFile();
                // アカウントデータ表示
                DisplayAccountAll();

                if (idx >= LsvAccount.Items.Count)
                {
                    idx = LsvAccount.Items.Count - 1;
                }
                // 行選択とフォーカスセット
                LsvAccount.Items[idx].Selected = true;
                LsvAccount.Select();
                LsvAccount.Items[idx].Focused = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LsvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // 選択項目があるかどうかを確認する
                if (LsvAccount.SelectedItems.Count == 0)
                {
                    // 選択項目がないので処理をせず抜ける
                    return;
                }

                int idx = LsvAccount.SelectedItems[0].Index;
                string[] sArray = PubConstClass.lstUserAccount[idx].Split(',');
                TxtId.Text = sArray[0];
                TxtName.Text = sArray[1];
                TxtPassword.Text = sArray[3];
                if (sArray[2] == "OP")
                {
                    // OP
                    CmbAuthority.SelectedIndex = 0;
                }
                else
                {
                    // SV
                    CmbAuthority.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPassword_Click(object sender, EventArgs e)
        {
            if (TxtPassword.PasswordChar.ToString() == "*")
            {
                TxtPassword.PasswordChar = '\0';
                BtnPassword.Image = Properties.Resources.password_close;
            }
            else
            {
                TxtPassword.PasswordChar = '*';
                BtnPassword.Image = Properties.Resources.password_open;
            }            
        }
    }
}
