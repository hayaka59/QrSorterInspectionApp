using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterSimulatorApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // バージョン表示
                LblVersion.Text = PubConstClass.DEF_VERSION;
                PubConstClass.objSyncHist = new object();
                CommonModule.OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓");
                CommonModule.OutPutLogFile("【" + "検査アプリシミュレータ" + "】を起動しました。");
                CommonModule.OutPutLogFile("■検査アプリバージョン「" + PubConstClass.DEF_VERSION + "」");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MainForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                //CommonModule.OutPutLogFile("ログイン画面からQRソータ検査アプリの終了");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
