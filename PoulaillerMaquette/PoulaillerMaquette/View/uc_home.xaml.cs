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
        string etat;
        string Topic;
        private MyDelegate PassageInfo;
        private DispatcherTimer Timer;
        int nbPoules, nbPoulesMax;



        public uc_home()
        {
            InitializeComponent();
            client = new MqttClient(IPAddress.Parse("172.31.253.11")); //172.31.253.6 - 172.31.253.11 - 192.168.1.43 --> premiere = nathan / 2e = val / 3e = yvoire
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(30); //delay
            Timer.Tick += timer_Tick;
            Timer.Start(); 

            client.Connect(Guid.NewGuid().ToString());
            client.Subscribe(new string[] { "d" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            client.Subscribe(new string[] { "s" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            PassageInfo = new MyDelegate(this.MiseAJour);
            lastmsg = "ro";
            nbPoulesMax = 3;
            nbPoules = 1;

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
                    lastmsg = "ro";
                    Lbl_porte.Dispatcher.Invoke(new Action(() => { Lbl_porte.Content = "FERMEE"; }));
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "fermeture ..."; }));
                    client.Publish("d", Encoding.UTF8.GetBytes("o")); //publie a val sur d que la porte est ouverte


                }
                else if(lastmsg == "ro")
                {
                    lastmsg = "rc";
                    Lbl_porte.Dispatcher.Invoke(new Action(() => { Lbl_porte.Content = "OUVERT"; }));
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "ouverture ..."; }));
                    client.Publish("d", Encoding.UTF8.GetBytes("c"));

                }
            }
            else if(Topic == "p")
            {
                if(lastmsg == "e") 
                {
                    nbPoules = nbPoules + 1;
                }

                else
                {
                    nbPoules = nbPoules - 1;
                }
                Lbl_porte.Dispatcher.Invoke(new Action(() => { TB_NbPoule.Content = nbPoules + "/" + nbPoulesMax; }));
            }


            //TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "topic : " + Topic + " / message : " + lastmsg; }));

        }


        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {

        }

        void EnvoiPorte()
        {
            if (lastmsg == "ro")
            {
                client.Publish("d", Encoding.UTF8.GetBytes("o")); //publie a val sur d que la porte est ouverte
                etat = "ouvrir";
            }
            else
            {
                client.Publish("d", Encoding.UTF8.GetBytes("c"));
                etat = "fermer";
            }
            sendChienDeGarde();
        }
        


        void MiseAJour(string t)
        {
            TB_sub.Text = t;
        }


        void sendChienDeGarde() //attention, la syntaxe ne peux pas marcher et je dois revoir mon algo de cette partie, à revoir plus tard !
        {
            TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "en attente ..."; }));
            Timer.Start();


            if (etat == "ouvrir" || etat == "fermer")
            {
                lastmsg = "r";
            }

            else
            {

                //    if (Timer == Timer.Interval)
                //    {
                TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "attention, l'information n'à pas été reçue !"; }));
                //    }
            }
        }


        void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
