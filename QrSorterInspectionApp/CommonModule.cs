using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrSorterInspectionApp
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

        /// <summary>
        /// ジョブ登録リストファイルの読込
        /// </summary>
        public static void ReadJobEntryListFile()
        {
            string sReadDataPath;
            string sData;

            try
            {
                sReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_JOB_ENTRY_FILE_NAME;

                PubConstClass.lstJobEntryList.Clear();
                using (StreamReader sr = new StreamReader(sReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        PubConstClass.lstJobEntryList.Add(sData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadJobEntryListFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 暗号化されたユーザーアカウントファイルの読込
        /// </summary>
        public static void ReadEncodeUserAccountFile()
        {
            try
            {
                string inputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_ENC_FILE_NAME;
                string outputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;
                // 8文字のキー（DESは64ビット長のキーを使用）
                string key = PubConstClass.DEF_DES_KEY;
                // 暗号化されたユーザーアカウントファイルから平文のユーザーアカウントファイル作成
                CommonModule.DecryptFile(inputFile, outputFile, key);
                // 平文のユーザーアカウントファイルの読込
                ReadUserAccountFile();
                // 平文のユーザーアカウントファイルの削除
                File.Delete(outputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadEncodeUserAccountFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 平文のユーザーアカウントファイルの読込処理
        /// </summary>
        public static void ReadUserAccountFile()
        {
            string sReadDataPath;
            string sData;

            try
            {
                sReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;

                PubConstClass.lstUserAccount.Clear();
                using (StreamReader sr = new StreamReader(sReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        PubConstClass.lstUserAccount.Add(sData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadUserAccountFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 暗号化されたユーザーアカウントファイルの書込
        /// </summary>
        public static void WriteEncodeUserAccountFile()
        {
            try
            {
                // 平文のユーザーアカウントの作成
                WriteUserAccountFile();
                // 平文のユーザーアカウントファイルから暗号化されたユーザーアカウントを作成
                string inputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                    PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;
                string outputFile = CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath) +
                                    PubConstClass.DEF_USER_ACCOUNT_ENC_FILE_NAME;
                // 8文字のキー（DESは64ビット長のキーを使用）
                string key = PubConstClass.DEF_DES_KEY;
                CommonModule.EncryptFile(inputFile, outputFile, key);

                // 平文のユーザーアカウントファイルの削除
                File.Delete(inputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WriteEncodeUserAccountFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 平文のユーザーアカウントファイルの作成
        /// </summary>
        public static void WriteUserAccountFile()
        {
            string sPutDataPath;

            try
            {
                sPutDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_USER_ACCOUNT_FILE_NAME;

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sPutDataPath, false, Encoding.Default))
                {
                    foreach (var item in PubConstClass.lstUserAccount)
                    {
                        sw.WriteLine(item);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WriteUserAccountFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 平文ファイルを暗号化する
        /// </summary>
        /// <param name="inputFile">平文ファイル</param>
        /// <param name="outputFile">暗号化ファイル</param>
        /// <param name="key">キー（8桁）</param>
        public static void EncryptFile(string inputFile, string outputFile, string key)
        {
            try
            {
                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = Encoding.UTF8.GetBytes(key);
                    des.IV = Encoding.UTF8.GetBytes(key);

                    ICryptoTransform encryptor = des.CreateEncryptor();
                    using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cryptoStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                CommonModule.OutPutLogFile($"【暗号化】暗号化ファイルを作成しました：{outputFile}");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【EncryptFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 暗号化ファイルを復号化する
        /// </summary>
        /// <param name="inputFile">暗号ファイル</param>
        /// <param name="outputFile">平文ファイル</param>
        /// <param name="key"></param>
        public static void DecryptFile(string inputFile, string outputFile, string key)
        {
            try
            {
                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = Encoding.UTF8.GetBytes(key);
                    des.IV = Encoding.UTF8.GetBytes(key);

                    ICryptoTransform decryptor = des.CreateDecryptor();
                    using (CryptoStream cryptoStream = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsOutput.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                CommonModule.OutPutLogFile($"【復号化】平文ファイルを作成しました：{outputFile}");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DecryptFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
