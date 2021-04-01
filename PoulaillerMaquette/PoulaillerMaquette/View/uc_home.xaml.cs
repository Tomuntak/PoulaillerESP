using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace PoulaillerMaquette.View
{

    /// <summary>
    /// Logique d'interaction pour uc_home
    /// </summary>
    public partial class uc_home : UserControl
    {
        MqttClient client;
        string MsgGet;
        string Topic;



        public uc_home()
        {
            InitializeComponent();
            client = new MqttClient(IPAddress.Parse("172.31.253.11")); //172.31.253.6 - 172.31.253.11 --> premiere = nathan / 2e = val
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            client.Connect(Guid.NewGuid().ToString());
            client.Subscribe(new string[] { "d" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            client.Subscribe(new string[] { "s" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        }


        /**************************************************** publish sur MQTT ******************************************************************************/
        private void BTN_changeporte_Click(object sender, RoutedEventArgs e)
        {
            EnvoiPorte();
        }


        /************************************  fonction de traitement des messages /!\ reçus /!\  ***********************************************************/
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
            MsgGet = Encoding.UTF8.GetString(e.Message);
            Topic = e.Topic;
            //****************************************** ligne a lock en cas de debug ********************************************************
            //string PorteRead = "Topic : " + e.Topic + " Message : " + MsgGet;
            //*******************************************************************************************************************************


        }


        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {

        }

        void EnvoiPorte()
        {
            if (MsgGet == "c")
            {
                client.Publish("d", Encoding.UTF8.GetBytes("o"));
                MsgGet = "o";
                TB_sub.Text = "ouvert";
                //Lbl_porte.Background = ;
            }
            else
            {
                client.Publish("d", Encoding.UTF8.GetBytes("c"));
                MsgGet = "c";
                TB_sub.Text = "fermee";
            }
        }



    }
}
