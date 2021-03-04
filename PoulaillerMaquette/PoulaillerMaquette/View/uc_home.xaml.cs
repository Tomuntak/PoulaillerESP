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

     

        public uc_home()
        {
            InitializeComponent();
            client = new MqttClient(IPAddress.Parse("172.31.253.11"));
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            client.Connect(Guid.NewGuid().ToString());
            client.Subscribe(new string[] { "etat/porte" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

        }

       /**************************************************** publish sur MQTT ******************************************************************************/
        private void BTN_changeporte_Click(object sender, RoutedEventArgs e)
        {
            client.Publish("etat/porte", Encoding.UTF8.GetBytes("porte2"));
        }


        //***********************************  fonction de traitement des messages reçus *******************************************************************//
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
            string MsgGet = Encoding.UTF8.GetString(e.Message);

            //******************************************ligne a lock en cas de debug ********************************************************
            string PorteRead = "Topic : " + e.Topic + " Message : " + MsgGet;
            //*******************************************************************************************************************************

            if(e.Topic == "etat/porte")
            {
                if (MsgGet == "Ouvert")
                {
                    TB_sub.Text = "ouvert";
                }
                else if (MsgGet == "ferme")
                {
                    TB_sub.Text = "fermée";
                }
            }
            

        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            
        }

    }
}
