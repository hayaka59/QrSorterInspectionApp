using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrSorterSimulatorApp
{
    internal class PubConstClass
    {
        public const string CMD_SEND_a = "a";      // 
        public const string CMD_SEND_b = "b";      // 

        public const string CMD_RECIEVE_A = "A";   // 
        public const string CMD_RECIEVE_B = "B";   // 

        public const string DEF_VERSION = "Ver.0.0.0.0";            // バージョン情報（メジャー.マイナー.ビルド.リビジョン） 
        public static object objSyncHist;

        // 保守画面
        public const string DEF_MACHINE_NAME = "号機名称";
        public const string DEF_LOGSAVE_MONTH = "ログ保存期間";
        public const string DEF_HDD_SPACE = "ディスク空き容量";
        public const string DEF_INTERNAL_TRAN_FOLDER = "内部実績ログ格納フォルダ";
        // COMポート１
        public const string DEF_COMPORT = "COMポート名";
        public const string DEF_COM_SPEED = "COM通信速度";
        public const string DEF_COM_DATA_LENGTH = "COMデータ長";
        public const string DEF_COM_IS_PARITY = "COMパリティ有無";
        public const string DEF_COM_PARITY_VAR = "COMパリティ種別";
        public const string DEF_COM_STOPBIT = "COMストップビット";

        // 保守画面
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
