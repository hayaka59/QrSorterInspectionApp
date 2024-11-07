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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;

                PubConstClass.objSyncHist = new object();

                CommonModule.OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓");
                CommonModule.OutPutLogFile("【" + "QRソータ検査アプリバージョン" + "】を起動しました。");
                CommonModule.OutPutLogFile("■QRソータ検査アプリバージョン「" + PubConstClass.DEF_VERSION + "」");

                CommonModule.ReadUserAccountFile();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "【LoginForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログイン」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■「ログイン」ボタンクリック");

                bool bRet = CheckUserAndPassword();
                if (!bRet)
                {
                    CommonModule.OutPutLogFile("■ログインエラー");
                    return;
                }
                CommonModule.OutPutLogFile("■ログイン成功");

                TxtUserId.Text = "";
                TxtPassword.Text = "";
                TxtPassword.PasswordChar = '*';
                BtnPassword.Image = Properties.Resources.password_open;

                MenuForm form = new MenuForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnLogin_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「終了」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {            
            try
            {
                CommonModule.OutPutLogFile("ログイン画面からQRソータ検査アプリの終了");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckUserAndPassword()
        {
            try
            {
                string[] sArray;
                bool bRet = false;
                foreach (var item in PubConstClass.lstUserAccount)
                {
                    sArray = item.Split(',');
                    if (sArray[0] == TxtUserId.Text)
                    {
                        if (sArray[3] == TxtPassword.Text)
                        {
                            PubConstClass.sUserId = sArray[0];
                            PubConstClass.sUserName = sArray[1];
                            PubConstClass.sUserAuthority = sArray[2];
                            PubConstClass.sUserPassword = sArray[3];
                            bRet = true;                            
                        }
                        else
                        {
                            bRet = false;
                            MessageBox.Show("パスワードが違います","警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);                                                    
                        }
                        return bRet;
                    }
                }
                if (!bRet)
                {
                    MessageBox.Show("IDが違います", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return bRet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckUserAndPassword】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPassword_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "【BtnPassword_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
