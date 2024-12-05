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
    public partial class MaintenanceForm : Form
    {
        public MaintenanceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblVersion.Text = PubConstClass.DEF_VERSION;
                CommonModule.OutPutLogFile("保守画面を表示しました");

                CommonModule.ReadSystemDefinition();

                // 号機名
                TxtMachineName.Text = PubConstClass.pblMachineName;

                #region ログ保存
                CmbSaveMonth.Items.Clear();
                for (int N = 1; N <= 36; N++)
                {
                    CmbSaveMonth.Items.Add(N.ToString() + "ヶ月");
                }                
                if (PubConstClass.pblSaveLogMonth != "")
                {
                    CmbSaveMonth.SelectedIndex = Convert.ToInt32(PubConstClass.pblSaveLogMonth) - 1;
                }
                else
                {
                    CmbSaveMonth.SelectedIndex = 0;
                }
                #endregion

                // ディスク空き容量チェック
                TxtHddSpace.Text = PubConstClass.pblHddSpace;

                // 内部実績ログ格納フォルダ
                TxtInternalTran.Text = PubConstClass.pblInternalTranFolder;

                // COMポート名
                CmbComPort.Items.Clear();
                for (int iIndex = 1; iIndex <= 15; iIndex++)
                    CmbComPort.Items.Add("COM" + Convert.ToString(iIndex));
                CmbComPort.SelectedIndex = Convert.ToInt32(PubConstClass.pblComPort.Substring(3, 1)) - 1;
                
                // COM通信速度
                CmbComSpeed.Items.Clear();
                CmbComSpeed.Items.Add("4800");
                CmbComSpeed.Items.Add("9600");
                CmbComSpeed.Items.Add("19200");
                CmbComSpeed.Items.Add("38400");
                CmbComSpeed.Items.Add("57600");
                CmbComSpeed.Items.Add("115200");
                CmbComSpeed.SelectedIndex = Convert.ToInt32(PubConstClass.pblComSpeed);
                
                // COMデータ長
                CmbComDataLength.Items.Clear();
                CmbComDataLength.Items.Add("8bit");
                CmbComDataLength.Items.Add("7bit");
                CmbComDataLength.SelectedIndex = Convert.ToInt32(PubConstClass.pblComDataLength);
                
                // COMパリティの有無
                CmbComIsParty.Items.Clear();
                CmbComIsParty.Items.Add("無効");
                CmbComIsParty.Items.Add("有効");
                CmbComIsParty.SelectedIndex = Convert.ToInt32(PubConstClass.pblComIsParity);
                
                // COMパリティ種別
                CmbComParityVar.Items.Clear();
                CmbComParityVar.Items.Add("奇数");
                CmbComParityVar.Items.Add("偶数");
                CmbComParityVar.SelectedIndex = Convert.ToInt32(PubConstClass.pblComParityVar);
                
                // COMストップビット
                CmbComStopBit.Items.Clear();
                CmbComStopBit.Items.Add("1bit");
                CmbComStopBit.Items.Add("2bit");
                CmbComStopBit.SelectedIndex = Convert.ToInt32(PubConstClass.pblComStopBit);

                // 不着事由情報ファイル読込
                CommonModule.ReadNonDeliveryList();
                // 仕分けマスタの内容表示
                NonDeliveryMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MaintenanceForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 「適用」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;

            try
            {
                dialogResult = MessageBox.Show("設定を保存しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    // 号機名称
                    PubConstClass.pblMachineName = TxtMachineName.Text;
                    // ディスク空き容量
                    PubConstClass.pblHddSpace = TxtHddSpace.Text;
                    // ログの保存期間
                    PubConstClass.pblSaveLogMonth = (CmbSaveMonth.SelectedIndex + 1).ToString();
                    
                    PubConstClass.pblComPort = CmbComPort.SelectedItem.ToString();
                    PubConstClass.pblComSpeed = CmbComSpeed.SelectedIndex.ToString();
                    PubConstClass.pblComDataLength = CmbComDataLength.SelectedIndex.ToString();
                    PubConstClass.pblComIsParity = CmbComIsParty.SelectedIndex.ToString();
                    PubConstClass.pblComParityVar = CmbComParityVar.SelectedIndex.ToString();
                    PubConstClass.pblComStopBit = CmbComStopBit.SelectedIndex.ToString();

                    // 内部実績ログ格納フォルダ
                    PubConstClass.pblInternalTranFolder = TxtInternalTran.Text;

                    // システム定義ファイルの書き込み処理
                    CommonModule.WriteSystemDefinition();

                    // ディスクの空き領域をチェック
                    CommonModule.CheckAvairableFreeSpace();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【BtnApply_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEncript_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;
                string outputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) + 
                                    PubConstClass.DEF_USER_ACCOUNT_ENC_FILE_NAME;
                // 8文字のキー（DESは64ビット長のキーを使用）
                string key = PubConstClass.DEF_DES_KEY;

                CommonModule.EncryptFile(inputFile, outputFile, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEncript_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「復号」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecript_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_ENC_FILE_NAME;
                string outputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;
                // 8文字のキー（DESは64ビット長のキーを使用）
                string key = PubConstClass.DEF_DES_KEY;

                CommonModule.DecryptFile(inputFile, outputFile, key);

                CommonModule.ReadUserAccountFile();

                TxtUserAccount.Text = "";
                foreach (var item in PubConstClass.lstUserAccount)
                {
                    TxtUserAccount.Text += item + Environment.NewLine;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDecript_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblVersion_DoubleClick(object sender, EventArgs e)
        {
            BtnDecript.Visible = true;
            TxtUserAccount.Visible = true;
        }

        private void LblVersion_Click(object sender, EventArgs e)
        {

        }

        private void BtnInternalTran_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            try
            {
                fbd.Description = "内部実績ログ格納フォルダを選択してください。";

                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.SelectedPath = PubConstClass.pblInternalTranFolder;

                // 新規フォルダ作成を表示
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog(this) == DialogResult.OK)
                    // 選択されたフォルダを表示する
                    TxtInternalTran.Text = fbd.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnInternalTran_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログデータ手動削除」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteLogData_Click(object sender, EventArgs e)
        {
            try
            {
                // 現在の日付（年月日）を求める
                DateTime dtCurrent = DateTime.Now;

                int intMinusMonth = CmbSaveMonth.SelectedIndex;
                // 現在日付から１ヶ月を減算
                DateTime dtPassDate = dtCurrent.AddMonths(-(intMinusMonth + 1));

                DialogResult dialogResult = MessageBox.Show($"現在の日付から{intMinusMonth + 1}ヶ月前は、{dtPassDate}です。" +
                                                            $"{Environment.NewLine}それ以前のデータを削除しますか？",
                                                            "確認", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                CommonModule.DeleteLogFiles(intMinusMonth + 1);

                MessageBox.Show("削除処理が完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【メンテンス画面】【BtnDeleteLogData_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 仕分けマスタの内容表示（テキスト及びリストビュー）
        /// </summary>
        private void NonDeliveryMaintenance()
        {
            string[] col = new string[10];
            string[] sAray;
            ListViewItem itm;

            try
            {
                // 仕分けマスタ（テキスト領域）にデータ表示
                TxtNonDelivery.Text = "";
                for (int iIndex = 0; iIndex < PubConstClass.lstNonDeliveryList.Count; iIndex++)
                {
                    if (iIndex == PubConstClass.lstNonDeliveryList.Count - 1)
                    {
                        TxtNonDelivery.Text += PubConstClass.lstNonDeliveryList[iIndex];
                    }
                    else
                    {
                        TxtNonDelivery.Text += PubConstClass.lstNonDeliveryList[iIndex] + Environment.NewLine;
                    }
                }

                // 仕分けマスタ（リストビュー領域）にデータ表示
                LblNonDelivery.Text = "仕分け一覧";

                // 仕分けマスタ表示ListViewのカラムヘッダー設定
                LstNonDelivery.View = View.Details;
                ColumnHeader col1 = new ColumnHeader();
                ColumnHeader col2 = new ColumnHeader();

                col1.Text = "番号";
                col2.Text = "仕分け項目";

                col1.TextAlign = HorizontalAlignment.Center;
                col2.TextAlign = HorizontalAlignment.Left;

                col1.Width = 70;    // 番号
                col2.Width = 250;   // 仕分け項目

                ColumnHeader[] colHeader = new[] { col1, col2 };
                LstNonDelivery.Columns.AddRange(colHeader);

                int iCount = 0;
                // 生協・デポ一覧ファイル格納リスト取得
                foreach (string sData in PubConstClass.lstNonDeliveryList)
                {
                    sAray = sData.Split(',');
                    col[0] = "　" + sAray[0];
                    col[1] = sAray[1];
                    iCount++;
                    // データの表示
                    itm = new ListViewItem(col);
                    LstNonDelivery.Items.Add(itm);
                    LstNonDelivery.Items[LstNonDelivery.Items.Count - 1].UseItemStyleForSubItems = false;
                    if (LstNonDelivery.Items.Count % 2 == 1)
                    {
                        for (int iIndex = 0; iIndex < 2; iIndex++)
                        {
                            // 奇数行の色反転
                            LstNonDelivery.Items[LstNonDelivery.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                        }
                    }
                }
                LblCount.Text = $"表示件数：{iCount} 件";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CoopDepoMaintenance】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「仕分けマスタの保存」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNonDeliverySave_Click(object sender, EventArgs e)
        {
            try
            {
                //// 生協・デポ入力データの妥当性チェック
                //bRet = CoopAndDepoInputValidation(TxtCoopDepo.Text);
                //if (!bRet)
                //{
                //    // 妥当性チェックエラー
                //    return;
                //}
                DialogResult dResult = MessageBox.Show("仕分けマスタファイルを保存しますか？", "保存確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult == DialogResult.No)
                {
                    // 保存しない
                    return;
                }
                // 仕分けマスタの書込
                CommonModule.WriteNonDeliveryList(TxtNonDelivery.Text);
                // 不着事由情報ファイルの読込
                CommonModule.ReadNonDeliveryList();
                LstNonDelivery.Clear();
                // 仕分けマスタの内容表示
                 NonDeliveryMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnNonDeliverySave_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
    }
}
