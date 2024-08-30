using Sunny.UI;
using System;

namespace MqttSubscribeVisualization
{
    public partial class FormMqtt : UIForm
    {
        public FormMain formMain;
        public FormMqtt(FormMain _formMain)
        {
            InitializeComponent();
            this.formMain = _formMain;
        }

        private void UiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UiButton1_Click(object sender, EventArgs e)
        {
            formMain.Mqtt_Server = uiTextBox1.Text.Trim();
            Int32.TryParse(uiTextBox2.Text, out int _mqttPort);
            formMain.Mqtt_Port = _mqttPort;
            formMain.Mqtt_UserName = uiTextBox3.Text.Trim();
            formMain.Mqtt_PassWord = uiTextBox4.Text.Trim();

            // 使用MQTTnet连接MQTT服务器
            formMain.MqttClientStop();
            formMain.MqttClientStart();

            this.Close();
        }

        private void FormMqtt_Load(object sender, EventArgs e)
        {
            //this.Style = formMain.UiStyle;
            //this.uiLabel1.Style = formMain.UiStyle;
            //this.uiLabel2.Style = formMain.UiStyle;
            //this.uiLabel3.Style = formMain.UiStyle;
            //this.uiLabel4.Style = formMain.UiStyle;
            //this.uiTextBox1.Style = formMain.UiStyle;
            //this.uiTextBox2.Style = formMain.UiStyle;
            //this.uiTextBox3.Style = formMain.UiStyle;
            //this.uiTextBox4.Style = formMain.UiStyle;
            //this.uiButton1.Style = formMain.UiStyle;
            //this.uiButton2.Style = formMain.UiStyle;
            //this.uiLine1.Style = formMain.UiStyle;
            this.uiTextBox1.Text = formMain.Mqtt_Server;
            this.uiTextBox2.Text = Convert.ToString(formMain.Mqtt_Port);
            this.uiTextBox3.Text = formMain.Mqtt_UserName;
            this.uiTextBox4.Text = formMain.Mqtt_PassWord;
        }
    }
}
