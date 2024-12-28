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

        /// <summary>
        /// SV・OP画面
        /// </summary>
        public static List<string> lstUserAccount = new List<string>();         // ユーザーアカウント情報
        public const string DEF_FILENAME = "QrSorterInspectionApp.def";         // DEFファイル名称
        public const string DEF_USER_ACCOUNT_FILE_NAME = "UserAccount.txt";     // 復号化ユーザーアカウントファイル名
        public const string DEF_USER_ACCOUNT_ENC_FILE_NAME = "UserAccount.enc"; // 暗号化ユーザーアカウントファイル名
        public const string DEF_DES_KEY = "QRINSPCT";                           // 暗号・復号用キー（8文字）
        public static string sUserId;
        public static string sUserName;
        public static string sUserPassword;
        public static string sUserAuthority;

        /// <summary>
        /// 設定画面        
        /// </summary>
        public const string DEF_JOB_ENTRY_FILE_NAME = "JobEntryList.txt";       // 登録ジョブファイル名
        public const string DEF_NON_DELIVERY = "NonDeliveryReasonSorting.txt";  // 不着事由格納ファイル

        public static List<string> lstJobEntryList = new List<string>();        // 登録ジョブ情報
        public static List<string> lstGroupInfo = new List<string>();           // グループ１～５の情報
        public static List<string> lstPocketInfo = new List<string>();          // ポケット１～５の情報
        public static List<string> lstNonDeliveryList = new List<string>();     // 不着事由情報
        public static string sJobFileNameFromInspectionForm = "";               // 検査画面呼出時のジョブファイル名

        /// <summary>
        /// 検査画面
        /// </summary>
        public static string sPrevDtpDateReceipt = "";  // 前回の受領日
        public static string sPrevNonDelivery1 = "";    // 前回の不着事由仕分け１
        public static string sPrevNonDelivery2 = "";    // 前回の不着事由仕分け２

        /// <summary>
        /// 保守画面
        /// </summary>
        // 保守項目
        public const string DEF_MACHINE_NAME         = "号機名称";
        public const string DEF_LOGSAVE_MONTH        = "ログ保存期間";
        public const string DEF_HDD_SPACE            = "ディスク空き容量";
        public const string DEF_INTERNAL_TRAN_FOLDER = "内部実績ログ格納フォルダ";
        // COMポート１
        public const string DEF_COMPORT              = "COMポート名";
        public const string DEF_COM_SPEED            = "COM通信速度";
        public const string DEF_COM_DATA_LENGTH      = "COMデータ長";
        public const string DEF_COM_IS_PARITY        = "COMパリティ有無";
        public const string DEF_COM_PARITY_VAR       = "COMパリティ種別";
        public const string DEF_COM_STOPBIT          = "COMストップビット";
        // 保守項目
        public static string pblMachineName;            // 号機名                
        public static string pblSaveLogMonth;           // ログ保存期間
        public static string pblHddSpace;               // ディスク空き容量
        public static string pblInternalTranFolder;     // 内部実績ログ格納フォルダ
        // COMポート１
        public static string pblComPort;                // COMポート名
        public static string pblComSpeed;               // 通信速度
        public static string pblComDataLength;          // データ長（0：8bit／1：7bit）
        public static string pblComIsParity;            // パリティの有無（0：無効／1：有効）
        public static string pblComParityVar;           // パリティ種別（0：奇数／1：偶数）
        public static string pblComStopBit;             // ストップビット（0：1bit／1：2bit）
    }
}
