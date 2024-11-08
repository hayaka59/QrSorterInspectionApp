using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrSorterInspectionApp
{
    internal class PubConstClass
    {

        public const string CMD_SEND_a = "a";      // 
        public const string CMD_SEND_b = "b";      // 

        public const string CMD_RECIEVE_A = "A";   // 
        public const string CMD_RECIEVE_B = "B";   // 

        public const string DEF_VERSION = "Ver.0.0.0.0";            // バージョン情報（メジャー.マイナー.ビルド.リビジョン） 
        public static object objSyncHist;

        public static List<string> lstUserAccount = new List<string>();         // ユーザーアカウント情報
        public const string DEF_USER_ACCOUNT_FILE_NAME = "UserAccount.txt";     // 復号化ユーザーアカウントファイル名
        public const string DEF_USER_ACCOUNT_ENC_FILE_NAME = "UserAccount.enc"; // 暗号化ユーザーアカウントファイル名
        public const string DEF_DES_KEY = "QRINSPCT";                           // 暗号・復号用キー（8文字）

        public static List<string> lstJobEntryList = new List<string>();        // ユーザーアカウント情報
        public const string DEF_JOB_ENTRY_FILE_NAME = "JobEntryList.txt";       // 復号化ユーザーアカウントファイル名

        public static string sUserId;
        public static string sUserName;
        public static string sUserPassword;
        public static string sUserAuthority;
    }
}
