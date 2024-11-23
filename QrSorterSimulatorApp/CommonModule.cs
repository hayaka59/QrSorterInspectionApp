using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterSimulatorApp
{
    internal class CommonModule
    {
        /// <summary>
        /// フォルダの末尾の「\」を保証する
        /// </summary>
        /// <param name="strCheckFolder">チェック対象のフォルダ名称</param>
        /// <returns>チェック後のフォルダ名称</returns>
        /// <remarks></remarks>
        public static string IncludeTrailingPathDelimiter(string strCheckFolder)
        {
            string IncludeTrailingPathDelimiter;
            try
            {
                if (strCheckFolder.Substring(strCheckFolder.Length - 1, 1) == @"\")
                    IncludeTrailingPathDelimiter = strCheckFolder;
                else
                    IncludeTrailingPathDelimiter = strCheckFolder + @"\";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【IncludeTrailingPathDelimiter】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            return IncludeTrailingPathDelimiter;
        }

        /// <summary>
        /// 操作履歴ログの書込処理
        /// </summary>
        /// <param name="strOutPutData">操作履歴メッセージ</param>
        /// <remarks></remarks>
        public static void OutPutLogFile(string strOutPutData)
        {
            string strOutPutFolder;
            string strOutPutFileName;
            string strYYYYMMDDvalue;
            string strHHMMSSvalue;
            string strPutMessage;

            lock ((PubConstClass.objSyncHist))
            {
                try
                {
                    DateTime dtNow = DateTime.Now;

                    // 指定した書式で日付を文字列に変換する
                    string strNowFormat = dtNow.ToString("yyyy/MM/dd HH:mm:ss");

                    {
                        var withBlock = DateTime.Now;
                        strYYYYMMDDvalue = string.Format("{0:D4}{1:D2}{2:D2}", withBlock.Year, withBlock.Month, withBlock.Day);
                        strHHMMSSvalue = string.Format("{0:D2}{1:D2}{2:D2}", withBlock.Hour, withBlock.Minute, withBlock.Second);
                    }

                    // 格納フォルダ名の設定
                    strOutPutFolder = IncludeTrailingPathDelimiter(Application.StartupPath) + @"OPHISTORYLOG\";
                    // 格納ファイル名の設定
                    strOutPutFileName = "操作履歴ログ_" + strYYYYMMDDvalue + ".LOG";

                    if (Directory.Exists(strOutPutFolder) == false)
                    {
                        // フォルダの作成
                        Directory.CreateDirectory(strOutPutFolder);
                        strPutMessage = strNowFormat + "【" + strOutPutFolder + "】フォルダを作成しました。";
                        // 追記モードで書き込む
                        using (StreamWriter sw = new StreamWriter(strOutPutFolder + strOutPutFileName, true, Encoding.Default))
                        {
                            sw.WriteLine(strPutMessage);
                        }
                    }

                    // 操作履歴ログに操作ログ内容を書き込む
                    strPutMessage = strNowFormat + "：" + strOutPutData;
                    // 追記モードで書き込む
                    using (StreamWriter sw = new StreamWriter(strOutPutFolder + strOutPutFileName, true, Encoding.Default))
                    {
                        sw.WriteLine(strPutMessage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "【OutPutLogFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
