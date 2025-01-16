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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ErrorMessageForm GetInstance()
        {
            return _singleInstance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sErrorData"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sErrorData"></param>
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
