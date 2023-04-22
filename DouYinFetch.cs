
using DouYinFetch.subForm;
using DouYinFetch.utils;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Proto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DouYinFetch
{
    public partial class DouYinFetch : Form
    {
        public static DouYinFetch frame = null;

        public static LiveHall liveHall = null;

        WebSocketLink webSocket = null;

        public static string token = null;

        public DouYinFetch()
        {
            frame = this;
            InitializeComponent();
            //初始化配置文件信息
            InitConfig();
        }

        private void InitConfig()
        {
            ConfigProperties.CreateConfigINI();
            string token = ConfigProperties.GetINIFileString("config", "token", null, ConfigProperties.strPath);
            danmuCheckBox.Checked =  ConfigProperties.GetINIFileString("comp", "danmuCB", "true", ConfigProperties.strPath) == "true"?true:false;
            peopleCheckBox.Checked = ConfigProperties.GetINIFileString("comp", "peopleCB", "true", ConfigProperties.strPath) == "true" ? true : false;
            WelcomeCheckBox.Checked = ConfigProperties.GetINIFileString("comp", "welcomeCB", "true", ConfigProperties.strPath) == "true" ? true : false;
            tokenText.Text = token;
            if(!string.IsNullOrEmpty(token))
            {
                GetUserInfo(token);
            }
        }

        public Dictionary<string, object> roomInfoDic = null;

        /// <summary>
        /// 初始化直播间信息
        /// </summary>
        /// <param name="roomInfoDic"></param>
        private void InitForm(Dictionary<string, object> roomInfoDic)
        {
            if (null != roomInfoDic && roomInfoDic.Count > 0)
            {
                this.nicknameText.Text = (string)roomInfoDic["nickName"];
                this.roomNameText.Text = (string)roomInfoDic["title"];
                this.roomCountText.Text = (string)roomInfoDic["displayValue"];
                this.avaterPic.ImageLocation = (string)roomInfoDic["avater"];
            }
        }

        private void initButt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roomUrlText.Text))
            {
                MessageBox.Show("请输入房间id", "错误");
                return;
            }
            string roomUrl = "https://live.douyin.com/" + roomUrlText.Text;
            roomInfoDic = fetchRoomId(roomUrl);
            if (null != roomInfoDic && null != roomInfoDic["roomId"] && null != roomInfoDic["ttwid"])
            {
                listenButt.Enabled = true;
                configBox.Enabled = true;
                listenButt.Enabled = true;
                danmuCheckBox.Enabled = true;
                peopleCheckBox.Enabled = true;
                WelcomeCheckBox.Enabled = true;
                InitForm(roomInfoDic);
                if (null != webSocket)
                {
                    ClientWebSocket client = webSocket.client;
                    client?.Dispose();
                }
                MessageBox.Show("初始化成功", "信息");
            }
            else
            {
                MessageBox.Show("初始化失败", "错误");
            }
        }

        /*
         通过直播间url抓取roomId和ttwid
         */
        public static Dictionary<string, object> fetchRoomId(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                Dictionary<string, object> roomInfo = new Dictionary<string, object>();
                request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookieContainer = new CookieContainer();
                System.Net.Cookie cookie = new System.Net.Cookie();
                cookie.Name = "__ac_nonce";
                cookie.Value = "063abcffa00ed8507d599";
                cookieContainer.Add(new Uri(url), cookie);
                request.CookieContainer = cookieContainer;
                request.Method = "GET";
                request.ServicePoint.ConnectionLimit = 3000;
                request.Host = "live.douyin.com";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.83 Safari/535.11";
                //获取返回结果
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                result = WebUtility.UrlDecode(result);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                HtmlNode roomNode = doc.GetElementbyId("RENDER_DATA");
                if (null != roomNode)
                {
                    //获取roomId和userUniqueId
                    string roomNodeInfo = roomNode.InnerText;
                    JObject roomObj = JObject.Parse(roomNodeInfo);
                    string roomId = (string)roomObj["app"]?["initialState"]?["roomStore"]?["roomInfo"]?["roomId"];
                    string title = (string)roomObj["app"]?["initialState"]?["roomStore"]?["roomInfo"]?["room"]?["title"];
                    string value = ((string)roomObj["app"]?["initialState"]?["roomStore"]?["roomInfo"]?["room"]?["room_view_stats"]?["display_value"]);
                    string displayValue = value != null ? value : "该主播已下线";
                    string nickName = (string)roomObj["app"]?["initialState"]?["roomStore"]?["roomInfo"]?["anchor"]?["nickname"];
                    string avater = (string)roomObj["app"]["initialState"]?["roomStore"]?["roomInfo"]?["anchor"]?["avatar_thumb"]?["url_list"][0];
                    string userUniqueId = (string)roomObj["app"]?["odin"]?["user_unique_id"];
                    //获取直播首页信息
                    JArray categoryDataArr = JArray.Parse(roomObj["app"]?["layoutData"]?["categoryTab"]?["categoryData"].ToString());
                    IEnumerator<JToken> categoryData = categoryDataArr.GetEnumerator();
                    roomInfo.Add("roomId", roomId);
                    roomInfo.Add("categoryData", categoryData);
                    roomInfo.Add("title", title);
                    roomInfo.Add("displayValue", displayValue);
                    roomInfo.Add("nickName", nickName);
                    roomInfo.Add("avater", avater);
                    roomInfo.Add("userUniqueId", userUniqueId);
                }
                //从cookie中获取ttwid
                string ttwid = response.Cookies["ttwid"].Value;
                roomInfo.Add("ttwid", ttwid);
                return roomInfo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                request.Abort();
                response.Close();
            }
        }

        private void DouYinFetch_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("是否退出?", "关闭提示", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void listenButt_Click(object sender, EventArgs e)
        {
            listenButt.Enabled = false;
            Task task = Task.Run(() =>
            {
                string roomId = (string)roomInfoDic["roomId"];
                string userUniqueId = (string)roomInfoDic["userUniqueId"];
                string ttwid = (string)roomInfoDic["ttwid"];
                //拼接wss链接
                Dictionary<string, string> wssDic = this.getWssUrl(ttwid, roomId);
                string wsUrl = wssDic["url"] + "?";
                string internalExt = wssDic["internalExt"];
                string req = "app_name=douyin_web&version_code=180800&webcast_sdk_version=1.3.0&update_version_code=1.3.0&compress=gzip&internal_ext=" + internalExt + "&cursor=d-1_u-1_h-1_t-1678883677711_r-1&host=https://live.douyin.com&aid=6383&live_id=1&did_rule=3&debug=false&maxCacheMessageNumber=20&endpoint=live_pc&support_wrds=1&im_path=/webcast/im/fetch/&user_unique_id=" + userUniqueId + "&device_platform=web&cookie_enabled=true&screen_width=1920&screen_height=1080&browser_language=zh-CN&browser_platform=Win32&browser_name=Mozilla&browser_online=true&tz_name=Asia/Shanghai&identity=audience&room_id=" + roomId + "&heartbeatDuration=0";
                //验签,先对这串数据进行md5加密后在走算法
                string sigStr = "live_id=1,aid=6383,version_code=180800,webcast_sdk_version=1.3.0,room_id=" + roomId + ",sub_room_id=,sub_channel_id=,did_rule=3,user_unique_id="
                        + userUniqueId + ",device_platform=web,device_type=,ac=,identity=audience";
                //md5加密
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(sigStr));
                sigStr = BitConverter.ToString(output).Replace("-", "").ToLower();
                string signature = this.getSignature("https://live.douyin.com", sigStr);
                req += "&signature=" + signature;
                string realUrl = wsUrl + req;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                //map.Add("Connection", "Upgrade");
                //map.Add("Upgrade", "websocket");
                dic.Add("Cookie", "ttwid=" + ttwid);
                webSocket = new WebSocketLink(realUrl, ttwid);
                webSocket.ConnectAuthReceive();
            });
        }


        /**
         * 获取wss链接
         */
        private Dictionary<string, string> getWssUrl(string ttwid, string roomId)
        {
            string url = "https://live.douyin.com/webcast/im/fetch/?version_code=180800&resp_content_type=protobuf&did_rule=3&device_id=&device_platform=web&cookie_enabled=true&screen_width=1536&screen_height=864&browser_language=zh-CN&browser_platform=Win32&browser_name=Mozilla&browser_version=5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.1587.57&browser_online=true&tz_name=Asia/Shanghai&aid=6383&live_id=1&app_name=douyin_web&debug=false&maxCacheMessageNumber=20&endpoint=live_pc&support_wrds=1&user_unique_id=7195428118517302842&identity=audience&room_id=" + roomId + "&last_rtt=0&fetch_rule=1&cursor=&internal_ext=";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Dictionary<string, string> returnDic = new Dictionary<string, string>();
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookieContainer = new CookieContainer();
                //string cookies = "ttwid=" + ttwid + "&sid_tt=" + "29929c8be74cfb131e91febc3e86681a";
                //cookieContainer.SetCookies(new Uri(url), cookies);
                System.Net.Cookie ttwidCookie = new System.Net.Cookie
                {
                    Name = "ttwid",
                    Value = ttwid
                };
                cookieContainer.Add(new Uri(url), ttwidCookie);
                System.Net.Cookie sidttCookie = new System.Net.Cookie
                {
                    Name = "sid_tt",
                    Value = "29929c8be74cfb131e91febc3e86681a"
                };
                cookieContainer.Add(new Uri(url), sidttCookie);
                request.CookieContainer = cookieContainer;
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.83 Safari/535.11";
                //获取返回结果
                response = (HttpWebResponse)request.GetResponse();
                Response douYinResponse = Response.Parser.ParseFrom(response.GetResponseStream());
                string pushServer = douYinResponse.PushServer;
                string InternalExt = douYinResponse.InternalExt;
                returnDic["url"] = pushServer;
                returnDic["internalExt"] = InternalExt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                request.Abort();
                response.Close();
            }
            return returnDic;
        }

        /**
         * 获取signature加签后的值
         */
        public string getSignature(string url, string param)
        {
            IWebDriver webDriver = null;
            try
            {
                ChromeOptions options = new ChromeOptions();
                // 不显示浏览器
                options.AddArgument("--headless");
                // GPU加速可能会导致Chrome出现黑屏及CPU占用率过高,所以禁用
                options.AddArgument("--disable-gpu");
                // 伪装user-agent
                options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                // 设置chrome启动时size大小
                options.AddArgument("--window-size=414,736");
                // 禁用图片
                options.AddUserProfilePreference("profile.default_content_setting_values.images", true);
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;//关闭黑色cmd窗口

                webDriver = new ChromeDriver(driverService, options);
                webDriver.Navigate().GoToUrl(url);
                //通过向页面插入js获取签名结果
                string js = "{\"X-MS-STUB\": \"" + param + "\" }";
                Dictionary<string, object> obj = (Dictionary<string, object>)((IJavaScriptExecutor)webDriver).ExecuteScript("return window.byted_acrawler.frontierSign(" + js + ")");
                return (string)obj["X-Bogus"];
            }
            finally
            {
                webDriver.Close();
                webDriver.Quit();
            }
        }

        private void liveHallButt_Click(object sender, EventArgs e)
        {
            if (null == liveHall)
            {
                if (null == roomInfoDic)
                {
                    roomInfoDic = fetchRoomId("https://live.douyin.com/" + roomUrlText.Text);
                }
                liveHall = new LiveHall();
                liveHall.Show();
            }
            else
            {
                liveHall.Show();
            }
        }

        private void selectLiveButt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择直播间");
            IWebDriver webDriver = null;
            string mess = null;
            try
            {
                ChromeOptions options = new ChromeOptions();
                // 不显示浏览器
                //options.AddArgument("--headless");
                // GPU加速可能会导致Chrome出现黑屏及CPU占用率过高,所以禁用
                options.AddArgument("--disable-gpu");
                // 伪装user-agent
                options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                // 设置chrome启动时size大小
                options.AddArgument("--window-size=1024,768");
                // 禁用图片
                options.AddUserProfilePreference("profile.default_content_setting_values.images", true);
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;//关闭黑色cmd窗口
                webDriver = new ChromeDriver(driverService, options);
                webDriver.Url = "https://live.douyin.com/";
                while (true)
                {
                    ReadOnlyCollection<string> handles = webDriver.WindowHandles;
                    ITargetLocator targetLocator = webDriver.SwitchTo();
                    if (!string.IsNullOrEmpty(handles.Last()))
                    {
                        webDriver = targetLocator.Window(handles.Last());
                        if (null != webDriver && webDriver.Url != "https://live.douyin.com/" && webDriver.Url.Contains("https://live.douyin.com/")
                            && !webDriver.Url.Contains("category") && !webDriver.Url.Contains("hot_live")
                            )
                        {
                            Thread.Sleep(1000);
                            roomUrlText.Text = webDriver.Url.Replace("https://live.douyin.com/", "");
                            mess = webDriver.Title;
                            break;
                        }
                    }

                }
            }
            catch (Exception exce)
            {
                MessageBox.Show("内部错误:" + exce.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Quit();
                MessageBox.Show("已选择:" + mess);
                initButt_Click(initButt, new EventArgs());
            }
        }

        private void roomNameText_MouseHover(object sender, EventArgs e)
        {
            ToolTip roomNameTip = new ToolTip();
            roomNameTip.AutoPopDelay = 3000;
            //是否球形展示
            roomNameTip.IsBalloon = true;
            roomNameTip.SetToolTip(this.roomNameText, this.roomNameText.Text);
        }

        private void roomIdText_MouseHover(object sender, EventArgs e)
        {
            ToolTip roomIdTip = new ToolTip();
            roomIdTip.AutoPopDelay = 3000;
            //是否球形展示
            roomIdTip.IsBalloon = true;
        }

        private void nicknameText_MouseHover(object sender, EventArgs e)
        {
            ToolTip nickNameTip = new ToolTip();
            nickNameTip.AutoPopDelay = 3000;
            //是否球形展示
            nickNameTip.IsBalloon = true;
            nickNameTip.SetToolTip(this.nicknameText, this.nicknameText.Text);
        }

        private void roomCountText_MouseHover(object sender, EventArgs e)
        {
            ToolTip roomCountTip = new ToolTip();
            roomCountTip.AutoPopDelay = 3000;
            //是否球形展示
            roomCountTip.IsBalloon = true;
            roomCountTip.SetToolTip(this.roomCountText, this.roomCountText.Text);
        }

        private void loginButt_Click(object sender, EventArgs e)
        {
            //sessionid_ss,sessionid,sid_tt,sid_guard是登陆的信息
            MessageBox.Show("请登录抖音");
            IWebDriver webDriver = null;
            try
            {
                ChromeOptions options = new ChromeOptions();
                // 不显示浏览器
                //options.AddArgument("--headless");
                // GPU加速可能会导致Chrome出现黑屏及CPU占用率过高,所以禁用
                options.AddArgument("--disable-gpu");
                // 伪装user-agent
                options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                // 设置chrome启动时size大小
                options.AddArgument("--window-size=1024,768");
                // 禁用图片
                options.AddUserProfilePreference("profile.default_content_setting_values.images", true);
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;//关闭黑色cmd窗口
                webDriver = new ChromeDriver(driverService, options);
                webDriver.Url = "https://live.douyin.com/";
                while (true)
                {
                    ReadOnlyCollection<string> handles = webDriver.WindowHandles;
                    ITargetLocator targetLocator = webDriver.SwitchTo();
                    if (!string.IsNullOrEmpty(handles.Last()))
                    {
                        webDriver = targetLocator.Window(handles.Last());
                        //获取cookie去进行登录
                        ReadOnlyCollection<OpenQA.Selenium.Cookie> cookies = webDriver.Manage().Cookies.AllCookies;
                        OpenQA.Selenium.Cookie[] cookiesArr = cookies.ToArray();
                        for (var i = 0; i < cookiesArr.Length; i++)
                        {
                            if (cookiesArr[i].Name == "sessionid")
                            {
                                token = cookiesArr[i].Value;
                                tokenText.Text = token;
                                //保存信息
                                ConfigProperties.CreateConfigINI();
                                ConfigProperties.WritePrivateProfileString("Config", "token", token, ConfigProperties.strPath);
                                break;
                            }
                        }
                        if (token != null) {
                            GetUserInfo(token);
                            break;
                        }
                    }

                }
            }
            catch (Exception exce)
            {
                MessageBox.Show("内部错误:" + exce.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Quit();
            }
        }

        private void GetUserInfo(string sessionid)
        {
            string url = "https://live.douyin.com/webcast/user/me/?aid=6383";
            HttpWebRequest request ;
            HttpWebResponse response ;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookieContainer = new CookieContainer();
                System.Net.Cookie sessionidCookie = new System.Net.Cookie
                {
                    Name = "sessionid",
                    Value = sessionid
                };
                cookieContainer.Add(new Uri(url), sessionidCookie);
                request.CookieContainer = cookieContainer;
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.83 Safari/535.11";
                //获取返回结果
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                result = WebUtility.UrlDecode(result);
                JObject UserInfoObj = JObject.Parse(result);
                int code = (int)UserInfoObj?["status_code"];
                if (code != 0)
                {
                    MessageBox.Show("登陆失败,请重新登录");
                    ConfigProperties.CreateConfigINI();
                    ConfigProperties.WritePrivateProfileString("config", "token", "", ConfigProperties.strPath);
                }
                else
                {
                    string NickName = (string)UserInfoObj?["data"]?["nickname"];
                    string Avater = (string)UserInfoObj?["data"]?["avatar_thumb"]?["url_list"]?[0];
                    string FollererCount = (string)UserInfoObj?["data"]?["follow_info"]?["follower_count_str"];
                    int sex = (int)UserInfoObj?["data"]?["gender"];
                    frame.usernameText.Text = NickName;
                    frame.userPic.ImageLocation = Avater;
                    frame.followText.Text = FollererCount;
                    if (sex == 0)
                    {
                        frame.sexText.Text = "女";
                    }
                    else if (sex == 1)
                    {
                        frame.sexText.Text = "男";
                    }
                    else {
                        frame.sexText.Text = "未知";
                    }
                }
            }
            catch (Exception exce)
            {


            }
        }

        private void WelcomeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigProperties.CreateConfigINI();
            ConfigProperties.WritePrivateProfileString("comp", "welcomeCB", WelcomeCheckBox.Checked?"true":"false", ConfigProperties.strPath);
        }

        private void WelcomeCheckBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip WelcomeTip = new ToolTip();
            WelcomeTip.AutoPopDelay = 3000;
            //是否球形展示
            WelcomeTip.IsBalloon = true;
            WelcomeTip.SetToolTip(this.WelcomeCheckBox, "对进入直播间的用户进行欢迎");
        }

        private void danmuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigProperties.CreateConfigINI();
            ConfigProperties.WritePrivateProfileString("comp","danmuCB",danmuCheckBox.Checked ? "true" : "false", ConfigProperties.strPath);
        }

        private void peopleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigProperties.CreateConfigINI();
            ConfigProperties.WritePrivateProfileString("comp", "peopleCB", peopleCheckBox.Checked ? "true" : "false", ConfigProperties.strPath);
        }
    }
}
