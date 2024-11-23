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
        /// 不着事由情報ファイル読込
        /// </summary>
        public static void ReadNonDeliveryList()
        {
            string sReadDataPath;
            string sData;

            try
            {
                sReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_NON_DELIVERY;

                PubConstClass.lstNonDeliveryList.Clear();
                using (StreamReader sr = new StreamReader(sReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        PubConstClass.lstNonDeliveryList.Add(sData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadNonDeliveryList】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        /// <summary>
        /// システム定義ファイルの読込処理
        /// </summary>
        /// <remarks></remarks>
        public static void ReadSystemDefinition()
        {
            string strReadDataPath;
            string[] strArray;

            try
            {
                strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_FILENAME;

                using (StreamReader sr = new StreamReader(strReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        strArray = sr.ReadLine().Split(',');
                        switch (strArray[0])
                        {
                            // 号機名称
                            case PubConstClass.DEF_MACHINE_NAME:
                                {
                                    PubConstClass.pblMachineName = strArray[1];
                                    break;
                                }
                            // ログ保存期間
                            case PubConstClass.DEF_LOGSAVE_MONTH:
                                {
                                    PubConstClass.pblSaveLogMonth = strArray[1];
                                    break;
                                }
                            // ディスク空き容量
                            case PubConstClass.DEF_HDD_SPACE:
                                {
                                    PubConstClass.pblHddSpace = strArray[1];
                                    break;
                                }
                            // 内部実績ログ格納フォルダ
                            case PubConstClass.DEF_INTERNAL_TRAN_FOLDER:
                                {
                                    PubConstClass.pblInternalTranFolder = strArray[1];
                                    break;
                                }
                            // COMポート名
                            case PubConstClass.DEF_COMPORT:
                                {
                                    PubConstClass.pblComPort = strArray[1];
                                    break;
                                }
                            // COM通信速度
                            case PubConstClass.DEF_COM_SPEED:
                                {
                                    PubConstClass.pblComSpeed = strArray[1];
                                    break;
                                }
                            // COMデータ長
                            case PubConstClass.DEF_COM_DATA_LENGTH:
                                {
                                    PubConstClass.pblComDataLength = strArray[1];
                                    break;
                                }
                            // COMパリティ有無
                            case PubConstClass.DEF_COM_IS_PARITY:
                                {
                                    PubConstClass.pblComIsParity = strArray[1];
                                    break;
                                }
                            // COMパリティ種別
                            case PubConstClass.DEF_COM_PARITY_VAR:
                                {
                                    PubConstClass.pblComParityVar = strArray[1];
                                    break;
                                }
                            // COMストップビット
                            case PubConstClass.DEF_COM_STOPBIT:
                                {
                                    PubConstClass.pblComStopBit = strArray[1];
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadSystemDefinition】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// システム定義ファイルの書込処理
        /// </summary>
        /// <remarks></remarks>
        public static void WriteSystemDefinition()
        {
            string strPutDataPath;

            try
            {
                strPutDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_FILENAME;

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(strPutDataPath, false, Encoding.Default))
                {
                    // 号機名称
                    sw.WriteLine(PubConstClass.DEF_MACHINE_NAME + "," + PubConstClass.pblMachineName);
                    // ログ保存期間
                    sw.WriteLine(PubConstClass.DEF_LOGSAVE_MONTH + "," + PubConstClass.pblSaveLogMonth);
                    // ディスク空き容量
                    sw.WriteLine(PubConstClass.DEF_HDD_SPACE + "," + PubConstClass.pblHddSpace);
                    // 内部実績ログ格納フォルダ
                    sw.WriteLine(PubConstClass.DEF_INTERNAL_TRAN_FOLDER + "," + PubConstClass.pblInternalTranFolder);
                    // COMポート名
                    sw.WriteLine(PubConstClass.DEF_COMPORT + "," + PubConstClass.pblComPort);
                    // COM通信速度
                    sw.WriteLine(PubConstClass.DEF_COM_SPEED + "," + PubConstClass.pblComSpeed);
                    // COMデータ長
                    sw.WriteLine(PubConstClass.DEF_COM_DATA_LENGTH + "," + PubConstClass.pblComDataLength);
                    // COMパリティ有無
                    sw.WriteLine(PubConstClass.DEF_COM_IS_PARITY + "," + PubConstClass.pblComIsParity);
                    // COMパリティ種別
                    sw.WriteLine(PubConstClass.DEF_COM_PARITY_VAR + "," + PubConstClass.pblComParityVar);
                    // COMストップビット
                    sw.WriteLine(PubConstClass.DEF_COM_STOPBIT + "," + PubConstClass.pblComStopBit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WritetSystemDefinition】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// ディスクの空き領域をチェック
        /// </summary>
        /// <remarks></remarks>
        public static void CheckAvairableFreeSpace()
        {
            long lngAvailableValue;
            string strMessage;

            try
            {
                DriveInfo drive = new DriveInfo(PubConstClass.pblInternalTranFolder.Substring(0, 1));

                if (drive.IsReady == true)
                {
                    lngAvailableValue = drive.AvailableFreeSpace;

                    if ((lngAvailableValue / (double)1024 / 1024 / 1024) < Convert.ToDouble(PubConstClass.pblHddSpace))
                    {
                        strMessage = "ドライブ「" + PubConstClass.pblInternalTranFolder.Substring(0, 1) + "」の空き領域（" +
                            (lngAvailableValue / (double)1024 / 1024 / 1024).ToString("F1") + " GB）が、" + PubConstClass.pblHddSpace + " GB より少なくなっています。";
                        // MsgBox("空き領域：" & (lngAvailableValue / 1024 / 1024 / 1024).ToString & " GB")                        
                        MessageBox.Show(strMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckAvairableFreeSpace】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 指定した月より古い下記のファイルを削除する
        /// （１）内部実績ログ格納フォルダ
        /// （２）履歴履歴ログファイル
        /// </summary>
        /// <param name="intMinusMonth"></param>
        /// <remarks></remarks>
        public static void DeleteLogFiles(int intMinusMonth)
        {
            string[] strArray;
            string strCompDate;

            try
            {
                // 現在の日付（年月日）を求める
                DateTime dtCurrent = DateTime.Now;

                // 現在日付から指定月を減算
                DateTime dtPassDate = dtCurrent.AddMonths(-(intMinusMonth));

                if (Directory.Exists(IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder)) == false)
                {
                    OutPutLogFile("「" + IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder) + "」フォルダが存在しません。");
                }
                else
                {
                    // 削除対象ファイル（稼動ログ）の取得
                    foreach (string strDeleteFolder in Directory.GetDirectories(IncludeTrailingPathDelimiter(PubConstClass.pblInternalTranFolder),
                                                                                                             "*", SearchOption.TopDirectoryOnly))
                    {
                        // OutPutLogFile("ログファイル一覧取得：" & strDeleteFile)
                        strArray = strDeleteFolder.Split('\\');
                        // 「YYYYMMDD」部分を切り出す                    
                        strCompDate = strArray[strArray.Length - 1];
                        if (string.Compare(strCompDate, dtPassDate.ToString("yyyyMMdd")) < 0)
                        {
                            // ファイルを削除する
                            Directory.Delete(strDeleteFolder, true);
                            OutPutLogFile("【稼動ログ】削除対象ファイル（" + strDeleteFolder + "）を削除しました。");
                        }
                    }
                }

                // 削除対象ファイル（操作履歴ログ）の取得
                foreach (string strDeleteFile in Directory.GetFiles(IncludeTrailingPathDelimiter(Application.StartupPath) +
                                                                    @"OPHISTORYLOG\", "*.LOG", SearchOption.AllDirectories))
                {

                    // OutPutLogFile("ログファイル一覧取得：" & strDeleteFile)
                    strArray = strDeleteFile.Split('\\');
                    // 「YYYYMMDD」部分を切り出す
                    strCompDate = strArray[strArray.Length - 1].Substring(strArray[strArray.Length - 1].Length - 12, 8);
                    if (string.Compare(strCompDate, dtPassDate.ToString("yyyyMMdd")) < 0)
                    {
                        // ファイルを削除する
                        File.Delete(strDeleteFile);
                        OutPutLogFile("【操作履歴ログ】削除対象ファイル（" + strDeleteFile + "）を削除しました。");
                    }
                }
                OutPutLogFile("削除処理が完了しました。");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【DeleteLogFiles】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
