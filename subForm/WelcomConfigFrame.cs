using DouYinFetch.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DouYinFetch.subForm
{
    public partial class WelcomConfigFrame : Form
    {
        public WelcomConfigFrame()
        {
            InitializeComponent();
            InitConfig();
        }

        private void InitConfig()
        {
            payLevelText.Text = ConfigProperties.GetINIFileString("comp", "payLevel","0", ConfigProperties.strPath);
            welcomeText.Text = ConfigProperties.GetINIFileString("comp", "welcomeText", "欢迎{user}进入直播间", ConfigProperties.strPath);
        }

        private void payLevelText_TextChanged(object sender, EventArgs e)
        {
            ConfigProperties.CreateConfigINI();
            ConfigProperties.WritePrivateProfileString("comp", "payLevel", payLevelText.Text, ConfigProperties.strPath);
        }

        private void welcomeText_TextChanged(object sender, EventArgs e)
        {
            ConfigProperties.CreateConfigINI();
            ConfigProperties.WritePrivateProfileString("comp", "welcomeText", welcomeText.Text, ConfigProperties.strPath);
        }
    }
}
