using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DouYinFetch.utils
{
    internal class ConfigProperties
    {

        public static string strPath = Application.StartupPath + "\\config.ini";

        //引入kernel32函数

        [DllImport("kernel32")] //读取INI文件
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]//向INI文件中写入数据
        public static extern long WritePrivateProfileString(string mpAppName, string mpKeyName, string mpDefault, string mpFileName);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">欲在其中查找条目的小节名称。这个字串不区分大小写。</param>
        /// <param name="key">欲获取的项名或条目名。这个字串不区分大小写。</param>
        /// <param name="def">指定的条目没有找到时返回的默认值。可设为空（""）</param>
        /// <param name="filePath">完整的INI文件名</param>
        /// <returns></returns>
        public static string GetINIFileString(string section, string key, string def, string filePath)
        {
            StringBuilder strTemp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, strTemp, 1024, filePath);
            return strTemp.ToString();
        }

        public static void CreateConfigINI()
        {
            if (!File.Exists(strPath))
            {
                //不存在就创建
                File.Create(strPath);
            }
        }

    }
}
