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
    }
}
