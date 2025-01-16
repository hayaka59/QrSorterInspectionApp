using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterInspectionApp
{
    public partial class ErrorMessageForm : Form
    {
        private static ErrorMessageForm _singleInstance = new ErrorMessageForm();

        // シングルトンパターン
        public ErrorMessageForm()
        {
            InitializeComponent();
        }

        public static ErrorMessageForm GetInstance()
        {
            return _singleInstance;
        }

        public ErrorMessageForm(string sErrorData)
        {
            string[] sArray = sErrorData.Split(',');

            try
            {
                // エラー内容の表示
                LblTitle.Text = sArray[1];
                LblErrorMessage.Text = sArray[2];
                LblErrorNumber.Text = sArray[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー【ErrorMessageForm】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SetMessage(string sErrorData)
        {
            string[] sArray = sErrorData.Split(',');

            try
            {
                // エラー内容の表示
                LblTitle.Text = sArray[1];
                LblErrorMessage.Text = sArray[2];
                LblErrorNumber.Text = sArray[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー【SetMessage】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Log.OutPutLogFile(TraceEventType.Information, "■エラー情報読み込み開始");

            //if (LblTitle.Text == "ログエラー")
            //{
            //    return;
            //}

            //LblTitle.Text = "未定義エラー";
            //LblErrorMessage.Text = _errNumber.ToString() + " エラー";

            //for (int N = 0; N < ClassErrorManager.errorFileData.Count; N++)
            //{
            //    string[] items = ClassErrorManager.errorFileData[N].Split(',');
            //    if (!Int32.TryParse(items[0], out int errCode))
            //    {
            //        continue;
            //    }
            //    if (Int32.Parse(items[0]) == _errNumber)
            //    {
            //        // エラー番号
            //        LblErrorNumber.Text = _errNumber.ToString();
            //        // 2列目：エラータイトル
            //        LblTitle.Text = items[1];
            //        // 3列目：エラーメッセージ
            //        LblErrorMessage.Text = items[2];
            //        break;
            //    }
            //}
            //Log.OutPutLogFile(TraceEventType.Information, "■エラー情報読み込み完了");
        }

        private void ErrorMessageForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            // エラーリセットコマンド送信（d）            
            //ClassEquipment.SendSetting_f();
            PubConstClass.bIsOpenErrorMessage = false;
            this.Hide();
        }

        /// <summary>
        /// 「✕」ボタンの無効化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorMessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LblTitle.Text = "";
            e.Cancel = true;
        }

        private void ErrorMessageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //LblTitle.Text = "";
        }
    }
}
