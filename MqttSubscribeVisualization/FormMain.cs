/*
使用MQTTnet和SunnyUI开发的物联网MQTT协议教学工具，主要用于订阅主题消息的可视化呈现。

程序订阅了MqttTest/Topic1、MqttTest/Topic2 …… MqttTest/Topic12，共12个MQTT消息主题。

用于课堂上通过可视化大屏验证并演示学生通过开源硬件向MQTT服务器的相应的主题发布的消息。

1.MQTTnet是一个高性能的.NET库。用于连接MQTT服务器，订阅主题和向主题发布消息。

MQTTnet相关的资源链接：

GitHub：https://github.com/dotnet/MQTTnet
NuGet：https://www.nuget.org/packages/MQTTnet/

2.SunnyUI.NET是基于.NET框架的C# WinForm开源控件库、工具类库、扩展类库、多页面开发框架。用于简化可视化用户界面的设计。 

SunnyUI相关的网络链接：

帮助文档：https://gitee.com/yhuse/SunnyUI/wikis/pages
Gitee：https://gitee.com/yhuse/SunnyUI
GitHub：https://github.com/yhuse/SunnyUI
Nuget：https://www.nuget.org/packages/SunnyUI/

3.SIoT是一个为教育定制的跨平台的开源MQTT服务器程序。建议使用SIoT1.3作为MQTT服务器进行本示例程序的测试。

SIoT相关的网络链接：

使用手册：https://siot.readthedocs.io/zh-cn/latest/
Gitee：https://gitee.com/vvlink/SIoT
GitHub：https://github.com/vvlink/SIoT/
*/
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Sunny.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MqttSubscribeVisualization
{
    public partial class FormMain : UIForm
    {
        public static IMqttClient MqttClient;
        /// <summary>
        /// MQTT服务器的IP地址或域名
        /// </summary>
        public string Mqtt_Server = "127.0.0.1";
        /// <summary>
        /// MQTT服务器的端口，一般为1883
        /// </summary>
        public int Mqtt_Port = 1883;
        /// <summary>
        /// MQTT服务器的用户名
        /// </summary>
        public string Mqtt_UserName = "siot";
        /// <summary>
        /// MQTT服务器的密码
        /// </summary>
        public string Mqtt_PassWord = "dfrobot";
        /// <summary>
        /// MQTT客户端的ID
        /// </summary>
        public string Mqtt_ClientId = "MyClient";

        // 主题风格全局变量
        public UIStyle UiStyle = UIStyle.Blue;

        // 折线图数据点计数器
        public int IndexLineChart = 0;

        /// <summary>
        /// 使用指定的参数连接MQTT服务器
        /// </summary>
        public void MqttClientStart()
        {
            // MQTT连接参数
            var mqttClientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithTcpServer(Mqtt_Server, Mqtt_Port)	// MQTT服务器的IP和端口号
                .WithCredentials(Mqtt_UserName, Mqtt_PassWord)      // MQTT服务器的用户名和密码
                .WithClientId(Mqtt_ClientId + Guid.NewGuid().ToString("N"))	// 自动设置客户端ID的后缀，以免出现重复
                .WithCleanSession();

            var mqttClientOptions = mqttClientOptionsBuilder.Build();
            MqttClient = new MqttFactory().CreateMqttClient();

            // 客户端连接成功事件
            MqttClient.ConnectedAsync += MqttClient_ConnectedAsync;
            // 客户端连接关闭事件
            MqttClient.DisconnectedAsync += MqttClient_DisconnectedAsync;
            // 收到订阅消息事件
            MqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
            // 连接MQTT服务器
            try
            {
                MqttClient.ConnectAsync(mqttClientOptions);
            }
            catch (Exception ex)
            {
                this.Text = "MQTT订阅信息可视化 - " + ex.Message;
            }
        }

        /// <summary>
        /// 断开已经连接的MQTT服务器
        /// </summary>
        public void MqttClientStop()
        {
            if (MqttClient != null && MqttClient.IsConnected)
            {
                var mqttClientDisconnectOptions = new MqttFactory().CreateClientDisconnectOptionsBuilder().Build();
                MqttClient.DisconnectAsync(mqttClientDisconnectOptions, CancellationToken.None);
                MqttClient.Dispose();
                MqttClient = null;
            }
        }

        /// <summary>
        /// 当MQTT服务器连接被断开时发生的事件
        /// </summary>
        private Task MqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            this.Invoke(new Action(() =>
            {
                this.Text = "MQTT订阅信息可视化 - 没有连接到MQTT服务器，请先连接MQTT服务器";
            }));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 当MQTT服务器成功连接时发生的事件
        /// </summary>
        private Task MqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            this.Invoke(new Action(() =>
            {
                this.Text = "MQTT订阅信息可视化 - 成功连接到MQTT服务器";
            }));

            // 订阅消息主题
            // MqttQualityOfServiceLevel: （QoS）:
            // AtMostOnce 0: 最多一次，接收者不确认收到消息，并且消息不被发送者存储和重新发送提供与底层 TCP 协议相同的保证。
            // AtLeastOnce 1: 保证一条消息至少有一次会传递给接收方。发送方存储消息，直到它从接收方收到确认收到消息的数据包。一条消息可以多次发送或传递。
            // ExactlyOnce 2: 保证每条消息仅由预期的收件人接收一次。级别2是最安全和最慢的服务质量级别，保证由发送方和接收方之间的至少两个请求/响应（四次握手）。
            //MqttClient.SubscribeAsync("Project/Topic1", MqttQualityOfServiceLevel.AtLeastOnce);
            //MqttClient.SubscribeAsync("Project/Topic2", MqttQualityOfServiceLevel.AtLeastOnce);
            //MqttClient.SubscribeAsync("Project/Topic3", MqttQualityOfServiceLevel.AtLeastOnce);

            MqttClient.SubscribeAsync("MqttTest/Topic1", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic2", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic3", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic4", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic5", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic6", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic7", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic8", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic9", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic10", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic11", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("MqttTest/Topic12", MqttQualityOfServiceLevel.AtLeastOnce);

            return Task.CompletedTask;
        }

        /// <summary>
        /// 当从MQTT服务器收到订阅消息的事件
        /// </summary>
        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            this.Invoke(new Action(() =>
            {
                // 整理收到的订阅消息
                string topic = arg.ApplicationMessage.Topic.Split('/')[1].Trim();
                Int32.TryParse(arg.ApplicationMessage.ConvertPayloadToString(), out int value);
                DateTime dateTime = DateTime.Now;
                // 更新柱形图数据
                uiBarChart.Update(topic, 0, value);
                uiBarChart.Refresh();
                // 添加折线图数据
                this.uiLineChart.Option.AddData("Topic", IndexLineChart, value);
                // 设置X轴的显示范围为100个点以内的最新数据
                if (IndexLineChart > 100)
                {
                    this.uiLineChart.Option.XAxis.SetRange(IndexLineChart-100, IndexLineChart);
                }
                IndexLineChart++;
                // 更新折线图显示
                this.uiLineChart.Refresh();
            }));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 向MQTT服务器指定的主题发送消息
        /// </summary>
        /// <param name="mqttTopic">发布消息的主题</param>
        /// <param name="mqttMessage">发布消息的内容</param>
        public async void MqttClientPublishAsync(string mqttTopic, string mqttMessage)
        {
            using (var mqttPublishClient = new MqttFactory().CreateMqttClient())
            {
                var mqttPublishClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(Mqtt_Server, Mqtt_Port)    // MQTT服务器的IP和端口号
                    .WithCredentials(Mqtt_UserName, Mqtt_PassWord)      // MQTT服务器的用户名和密码
                    .WithClientId(Mqtt_ClientId + Guid.NewGuid().ToString("N"))   // 自动设置客户端ID的后缀，以免出现重复
                    .WithCleanSession()
                    .Build();

                try
                {
                    await mqttPublishClient.ConnectAsync(mqttPublishClientOptions, CancellationToken.None);

                    var mqttApplicationMessage = new MqttApplicationMessageBuilder()
                        .WithTopic(mqttTopic)           // 消息主题
                        .WithPayload(mqttMessage)       // 消息内容
                        .Build();

                    await mqttPublishClient.PublishAsync(mqttApplicationMessage, CancellationToken.None);

                    await mqttPublishClient.DisconnectAsync();
                }
                catch (Exception ex)
                {
                    this.Text = "MQTT订阅信息可视化 - " + ex.Message;
                }
            }
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //初始化柱形图
            UIBarOption optionBarChart = new UIBarOption
            {
                Title = new UITitle
                {
                    Text = "MQTT订阅主题（实时数据）"
                    //SubText = "BarChart"
                },

                //设置Legend
                Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal,
                    Top = UITopAlignment.Bottom,
                    Left = UILeftAlignment.Left,
                }
            };

            for (int i = 1; i <= 12; i++)
            {
                optionBarChart.Legend.AddData("Topic" + i.ToString().Trim());

                var series = new UIBarSeries
                {
                    Name = "Topic" + i.ToString().Trim(),
                    DecimalPlaces = 0 //数据显示小数位数
                };

                series.AddData(0);

                optionBarChart.Series.Add(series);
            }

            optionBarChart.XAxis.Data.Add("主题");
            optionBarChart.ToolTip.Visible = true;
            optionBarChart.YAxis.Scale = true;
            //optionBarChart.XAxis.Name = "主题";
            optionBarChart.XAxis.AxisLabel.Angle = 60;
            optionBarChart.YAxis.Name = "数值";
            //坐标轴显示小数位数
            optionBarChart.YAxis.AxisLabel.DecimalPlaces = 0;
            //optionBarChart.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "上限", Value = 12 });
            //optionBarChart.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Gold, Name = "下限", Value = -20 });
            //optionBarChart.ToolTip.AxisPointer.Type = UIAxisPointerType.Shadow;
            optionBarChart.ShowValue = true;
            uiBarChart.SetOption(optionBarChart);

            // 初始化折线图
            UILineOption optionLineChart = new UILineOption
            {
                // 设置标题
                Title = new UITitle
                {
                    Text = "MQTT订阅主题（趋势折线图）"
                    //SubText = "（环境温湿度测量数据）"
                }
            };

            // 新增曲线，并设置曲线显示最大点数，超过后自动清理
            optionLineChart.AddSeries(new UILineSeries("Topic")).SetMaxCount(101);
            // 坐标轴设置
            optionLineChart.XAxis.Name = "点数";
            optionLineChart.YAxis.Name = "数值";
            // 坐标轴显示小数位数
            optionLineChart.XAxis.AxisLabel.DecimalPlaces = 0;
            // 坐标轴显示小数位数
            optionLineChart.YAxis.AxisLabel.DecimalPlaces = 0;
            optionLineChart.ToolTip.Visible = true;
            this.uiLineChart.SetOption(optionLineChart);

            // 设置默认的主题风格
            UiStyle = UIStyle.DarkBlue;
            this.Style = UiStyle;
            this.uiLineChart.ChartStyleType = UIChartStyleType.LiveChart;
            this.uiLineChart.Style = UiStyle;
            this.uiBarChart.ChartStyleType = UIChartStyleType.LiveChart;
            this.uiBarChart.Style = UiStyle;
            this.uiContextMenuStrip.Style = UiStyle;
            this.uiBarChart.Refresh();
            this.uiLineChart.Refresh();

            // 可以在任意位置重新设置需要连接的MQTT服务参数
            Mqtt_Server = "127.0.0.1";
            Mqtt_Port = 1883;
            Mqtt_UserName = "siot";
            Mqtt_PassWord = "dfrobot";
            Mqtt_ClientId = "MyClient";

            // 折线图数据点计数器
            IndexLineChart = 0;

            // 使用MQTTnet连接MQTT服务器
            MqttClientStop();
            MqttClientStart();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MqttClientStop();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ToolStripMenuItemDark_Click(object sender, EventArgs e)
        {
            // 设置深色主题风格
            UiStyle = UIStyle.DarkBlue;
            this.Style = UiStyle;
            this.uiLineChart.ChartStyleType = UIChartStyleType.LiveChart;
            this.uiLineChart.Style = UiStyle;
            this.uiBarChart.ChartStyleType = UIChartStyleType.LiveChart;
            this.uiBarChart.Style = UiStyle;
            this.uiContextMenuStrip.Style = UiStyle;
            this.uiBarChart.Refresh();
            this.uiLineChart.Refresh();
        }

        private void ToolStripMenuItemLight_Click(object sender, EventArgs e)
        {
            // 设置浅色主题风格
            UiStyle = UIStyle.Blue;
            this.Style = UiStyle;
            this.uiLineChart.ChartStyleType = UIChartStyleType.Plain;
            this.uiLineChart.Style = UiStyle;
            this.uiBarChart.ChartStyleType = UIChartStyleType.Plain;
            this.uiBarChart.Style = UiStyle;
            this.uiContextMenuStrip.Style = UiStyle;
            this.uiBarChart.Refresh();
            this.uiLineChart.Refresh();
        }

        private void ToolStripMenuItemMqtt_Click(object sender, EventArgs e)
        {
            FormMqtt formMqtt = new FormMqtt(this);
            formMqtt.ShowDialog();
        }
    }
}
