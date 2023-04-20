using System.Collections.Generic;
using System.Windows.Forms;

namespace DouYinFetch.subForm
{
    public partial class LiveHall : Form
    {
        public LiveHall()
        {
            InitializeComponent();
        }

        public LiveHall(Dictionary<string, object> roomInfoDics)
        {
            InitializeComponent();
            //对页面数据进行渲染
            showLiveContent(roomInfoDics);
        }

        private void showLiveContent(Dictionary<string, object> roomInfoDics)
        {
            Dictionary<string, string> partIds = (Dictionary<string, string>)roomInfoDics["categoryData"];
            //展示导航栏
            string contentUrl = "https://live.douyin.com/webcast/web/partition/detail/room/?aid=6383&count=12&offset=0&partition=591&partition_type=1";
        }
    }
}
