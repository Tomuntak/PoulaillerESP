using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace PoulaillerMaquette.View
{

    /// <summary>
    /// Logique d'interaction pour uc_home
    /// </summary>
    public partial class uc_home : UserControl
    {
        public delegate void MyDelegate(string msg);
        MqttClient client;
        string lastmsg;
        string MsgGet;
        string Topic;
        private MyDelegate PassageInfo;
        int Timer = DateTime.Now.Second;
        int Timerfin;




        public uc_home()
        {
            InitializeComponent();
            client = new MqttClient(IPAddress.Parse("172.31.253.11")); //172.31.253.6 - 172.31.253.11 - 192.168.1.43 --> premiere = nathan / 2e = val / 3e = yvoire
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            client.Connect(Guid.NewGuid().ToString());
            client.Subscribe(new string[] { "d" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            client.Subscribe(new string[] { "s" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            PassageInfo = new MyDelegate(this.MiseAJour);
            lastmsg = "ro";

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

            lastmsg = Encoding.UTF8.GetString(e.Message);

            Topic = e.Topic;

            //****************************************** ligne a lock en cas de debug ********************************************************

            //string PorteRead = "Topic : " + e.Topic + " Message : " + MsgGet;

            //*******************************************************************************************************************************
            
            if(Topic == "s")
            {
                if (lastmsg == "rc")
                {                                      //variable message reçu == "o" pour pouvoir la réutiliser 

                    Lbl_porte.Dispatcher.Invoke(new Action(() => { Lbl_porte.Content = "FERMEE"; }));
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "fermeture ..."; }));
                    client.Publish("d", Encoding.UTF8.GetBytes("o")); //publie a val sur d que la porte est ouverte


                }
                else if(lastmsg == "ro")
                {
                    lastmsg = "c";
                    Lbl_porte.Dispatcher.Invoke(new Action(() => { Lbl_porte.Content = "OUVERT"; }));
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "ouverture ..."; }));
                    client.Publish("d", Encoding.UTF8.GetBytes("c"));

                }
                chiendegarde2();
            }


            //TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "topic : " + Topic + " / message : " + lastmsg; }));

        }


        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {

        }

        void EnvoiPorte()
        {
            if (lastmsg == "rc")
            {
                client.Publish("d", Encoding.UTF8.GetBytes("o")); //publie a val sur d que la porte est ouverte
                MsgGet = "ouvrir";
            }
            else
            {
                client.Publish("d", Encoding.UTF8.GetBytes("c"));
                MsgGet = "fermer";
            }
            sendChienDeGarde();
        }
        


        void MiseAJour(string t)
        {
            TB_sub.Text = t;
        }


        void sendChienDeGarde()
        {
            TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "en attente ..."; }));

            if (MsgGet == "ouvrir")
            {
                lastmsg = "ro";
            }
            else if(MsgGet == "fermer")
            {
                lastmsg = "rc";
            }
            else
            {
                Timerfin = Timer+30;
                if (Timer == Timerfin)
                {
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "attention, l'information n'à pas été reçue !"; }));
                }
            }
        }

        void chiendegarde2()
        {
            if(lastmsg == "d")
            {
                TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "topic : " + Topic + " / message : " + lastmsg; }));
            }
        }


        void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
