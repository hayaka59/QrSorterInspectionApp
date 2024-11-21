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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("メニュー画面を表示しました");

                CommonModule.ReadSystemDefinition();

                LblUserInfo.Text = "";
                LblUserInfo.Text += "ＩＤ：" + PubConstClass.sUserId + Environment.NewLine;
                LblUserInfo.Text += "名前：" + PubConstClass.sUserName + Environment.NewLine;
                LblUserInfo.Text += "権限：" + PubConstClass.sUserAuthority + Environment.NewLine;
                LblUserInfo.Text += "ＰＷ：" + PubConstClass.sUserPassword;

                if (PubConstClass.sUserAuthority=="OP")
                {
                    BtnSetting.Enabled = false;
                    BtnMaintenance.Enabled = false;
                }

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
            CommonModule.OutPutLogFile("■メニュー画面：「ログアウト」ボタンクリック");
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
            CommonModule.OutPutLogFile("■メニュー画面：「終了」ボタンクリック");
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

        /// <summary>
        /// バージョン表示ラベルのダブルクリック処理（デバッグ用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblVersion_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (LblUserInfo.Visible == false)
                {
                    LblUserInfo.Visible = true;
                }
                else
                {
                    LblUserInfo.Visible = false;
                }

                //string[] sArray;
                //List<string> readData= new List<string>();
                //string sDataAll;

                //readData.Clear();
                //CommonModule.OutPutLogFile("読込開始");
                //string strReadDataPath = "C:\\GreenCoop\\GREENCOOP_DATA\\4EFYK520P2【500万件データ】.CSV";
                //using (StreamReader sr = new StreamReader(strReadDataPath, Encoding.Default))
                //{
                //    sDataAll = sr.ReadToEnd();

                //    //while (!sr.EndOfStream)
                //    //{
                //    //    string sData = sr.ReadLine();
                //    //    readData.Add(sData);
                //    //}
                //}
                //CommonModule.OutPutLogFile("読込終了");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LblVersion_DoubleClick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
