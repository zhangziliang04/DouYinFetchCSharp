using DouYinFetch;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Proto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/// WebSocket链接
public class WebSocketLink
{
    protected readonly Uri wssUrl = null;
    /// WebSocket客户端对象
    public ClientWebSocket client = null;
    protected readonly CancellationToken token;
    /// 接收WebSocket返回的信息数据
    protected WebSocketReceiveResult websocketReceiveResult = null;

    public WebSocketLink(string url, string ttwid)
    {
        wssUrl = new Uri(url);
        client = new ClientWebSocket();
        client.Options.SetRequestHeader("Cookie", "ttwid=" + ttwid);
        token = new CancellationToken();
    }

    /// <summary>
    /// gzip解压
    /// </summary>
    /// <param name="result">要解压的数据</param>
    /// <returns></returns>
    public byte[] uncompross(ByteString result)
    {
        using (MemoryStream dms = new MemoryStream())
        {
            using (MemoryStream cms = new MemoryStream(result.ToArray()))
            {
                using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(cms, System.IO.Compression.CompressionMode.Decompress))
                {
                    byte[] bytes = new byte[1024];
                    int len = 0;
                    //读取压缩流，同时会被解压
                    while ((len = gzip.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        dms.Write(bytes, 0, len);
                    }
                }
            }
            return dms.ToArray();
        }
    }

    /// <summary>
    /// 解析结果
    /// </summary>
    /// <param name="bytes">要解析的数据</param>
    protected virtual void ParseResult(byte[] bytes)
    {
        PushFrame pushFrame = PushFrame.Parser.ParseFrom(bytes);
        byte[] uzip = uncompross(pushFrame.Payload);
        Response response = Response.Parser.ParseFrom(uzip);
        RepeatedField<Message> messages = response.MessagesList;
        //发送ack心跳信息
        ackNeed(this.client, response, pushFrame);
        messages.ToList().ForEach(message =>
        {
            //消息处理
            messageHandle(message);
        });
    }

    /// <summary>
    /// 消息处理器
    /// </summary>
    /// <param name="message">消息体</param>
    private void messageHandle(Message message)
    {
        String method = message.Method;
        MessageEnum messageEnum;
        if (Enum.TryParse(method, out messageEnum)) {
            switch (messageEnum)
            {
                case MessageEnum.WebcastChatMessage:
                    ChatMessage chatMessage = ChatMessage.Parser.ParseFrom(message.Payload);
                    String content = chatMessage.Content;
                    User user = chatMessage.User;
                    AppendText(DouYinFetch.DouYinFetch.frame.danmuText, "[" + user.Nickname + "]:" + content + "\r\n");
                    break;
                case MessageEnum.WebcastMemberMessage:
                    MemberMessage memberMessage = MemberMessage.Parser.ParseFrom(message.Payload);
                    String nickname = memberMessage.User.Nickname;
                    UpdateText(DouYinFetch.DouYinFetch.frame.roomCountText, memberMessage.MemberCount.ToString());
                    AppendText(DouYinFetch.DouYinFetch.frame.peopleText, nickname + " 来了" + "\r\n");
                    break;
                default:
                    break;
            }
        }
    }


    /// <summary>
    /// 多线程之间使用委托修改标签文本
    /// </summary>
    /// <param name="label">标签对象</param>
    /// <param name="text">内容</param>
    private void UpdateText(Label label, string text)
    {
        if (label.InvokeRequired)
        {
            label.Invoke(new Action<System.Windows.Forms.Label, string>(UpdateText), label, text);
        }
        else
        {
            label.Text =text;
        }
    }

    /// <summary>
    /// 多线程之间使用委托追加文本
    /// </summary>
    /// <param name="textBox">文本框对象</param>
    /// <param name="text">内容</param>
    private void AppendText(System.Windows.Forms.TextBox textBox,string text)
    {
        if (textBox.InvokeRequired)
        {
            textBox.Invoke(new Action<System.Windows.Forms.TextBox,string>(AppendText), textBox,text);
        }
        else
        {
            textBox.AppendText(text);
        }
    }

    /// <summary>
    /// ack回应服务端
    /// </summary>
    /// <param name="client">客户端</param>
    /// <param name="response"></param>
    /// <param name="oldPushFrame"></param>
    private void ackNeed(ClientWebSocket client, Response response, PushFrame oldPushFrame)
    {
        if (response.NeedAck)
        {
            PushFrame pushFrame = new PushFrame();
            pushFrame.PayloadType = "ack";
            pushFrame.Payload = ByteString.CopyFromUtf8(response.InternalExt);
            pushFrame.Logid = oldPushFrame.Logid;
            client.SendAsync(new ArraySegment<byte>(pushFrame.ToByteArray()), WebSocketMessageType.Binary, true, token);
        }
    }

    /// 网络报错
    /// <param name="ex">错误信息</param>
    protected virtual void WebSocketError(Exception ex)
    {
        MessageBox.Show("出现错误:" + ex.Message);
        DouYinFetch.DouYinFetch.frame.listenButt.Enabled = true;
        client.Abort();
        client.Dispose();
        client = null;
    }

    /// <summary>
    /// 客户端连接服务端并接收数据
    /// </summary>
    public async void ConnectAuthReceive()
    {
        //try
        //{
            await client.ConnectAsync(wssUrl, token);//连接
                                                     //全部消息容器
            List<byte> bs = new List<byte>();
            //缓冲区
            var buffer = new byte[1024 * 4];
            //监听Socket信息
            WebSocketReceiveResult result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //是否关闭
            while (null !=client && client.State ==WebSocketState.Open )
            {
                //二进制消息
                if (result.MessageType == WebSocketMessageType.Binary)
                {
                    bs.AddRange(buffer.Take(result.Count));

                    //消息是否已接收完全
                    if (result.EndOfMessage)
                    {
                        //解析数据
                        ParseResult(bs.ToArray());
                        //清空消息容器
                        bs = new List<byte>();
                    }
                }
                //继续监听Socket信息
                result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
        //}
        //catch (Exception ex)
        //{
        //    WebSocketError(ex);
        //}
    }

    /// <summary>
    /// 关闭
    /// </summary>
    public async void Close()
    {
        if (client.State == WebSocketState.None)
        {
            MessageBox.Show("未建立链接！");
            return;
        }
        await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "正规闭包", token);
    }

    /// <summary>
    /// 终止
    /// </summary>
    public void Abort()
    {
        if (client.State == WebSocketState.None)
        {
            MessageBox.Show("未建立链接！");
            return;
        }
        client.Abort();
    }
}