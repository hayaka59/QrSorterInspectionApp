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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("メニュー画面を表示しました");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MenuForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログアウト」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Dispose();
        }

        /// <summary>
        /// 「終了」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            CommonModule.OutPutLogFile("メニュー画面からQRソータ検査アプリの終了");
            Owner.Dispose();
            this.Dispose();
        }

        /// <summary>
        /// 「設定」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■メニュー画面：「設定」ボタンクリック");
                SettingForm form = new SettingForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSetting_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「QRソーター検査」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQrSorterInspect_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■メニュー画面：「QRソーター検査」ボタンクリック");
                QrSorterInspectionForm form = new QrSorterInspectionForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnQrSorterInspect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「SV・OP設定」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAccountSet_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■メニュー画面：「SV・OP設定」ボタンクリック");
                RegisterAccountForm form = new RegisterAccountForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnAccountSet_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログ管理」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogManagement_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■メニュー画面：「ログ管理」ボタンクリック");
                LogListForm form = new LogListForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnLogManagement_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「保守」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMaintenance_Click(object sender, EventArgs e)
        {
            try
            {
                CommonModule.OutPutLogFile("■メニュー画面：「保守」ボタンクリック");
                MaintenanceForm form = new MaintenanceForm();
                form.Show(this);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnLogManagement_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
