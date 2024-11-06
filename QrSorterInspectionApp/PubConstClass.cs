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
        public const string DEF_USER_ACCOUNT_FILE_NAME = "userAccount.txt";     // ユーザーアカウントファイル名

    }
}
