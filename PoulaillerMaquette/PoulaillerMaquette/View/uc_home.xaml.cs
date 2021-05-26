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


using PoulaillerMaquette.DAO;

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
        private System.Timers.Timer timer;
        int nbPoules, nbPoulesMax;
        private bool confirm, back = false;

        DAOPoules daopoule;

        public uc_home()
        {
            InitializeComponent();
            client = new MqttClient(IPAddress.Parse("172.31.253.11")); //172.31.253.6 - 172.31.253.11 - 192.168.1.43 --> premiere = nathan / 2e = val / 3e = yvoire
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;

            timer = new System.Timers.Timer(3000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;

            client.Connect(Guid.NewGuid().ToString());
            client.Subscribe(new string[] { "d" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            client.Subscribe(new string[] { "s" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            client.Subscribe(new string[] { "p" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

            PassageInfo = new MyDelegate(this.MiseAJour);
            lastmsg = "do";
            nbPoulesMax = 3;
            nbPoules = daopoule.pouletest();
            etat = "ouvert";

            daopoule = new DAOPoules();

            Lbl_porte.Dispatcher.Invoke(new Action(() => { TB_NbPoule.Content = nbPoules + "/" + nbPoulesMax; }));
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

            if (Topic == "s")
            {
                if (lastmsg == "dc")
                {                                      //variable message reçu == "o" pour pouvoir la réutiliser 
                    Lbl_porte.Dispatcher.Invoke(new Action(() => { Lbl_porte.Content = "FERMEE"; }));
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "porte fermée"; }));
                    etat = "fermer";
                    //client.Publish("d", Encoding.UTF8.GetBytes("o")); //publie a val sur d que la porte est ouverte


                }
                else if (lastmsg == "do")
                {
                    Lbl_porte.Dispatcher.Invoke(new Action(() => { Lbl_porte.Content = "OUVERT"; }));
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "porte ouverte."; }));
                    etat = "ouvert";
                    //client.Publish("d", Encoding.UTF8.GetBytes("c"));

                }
            }
            else if (Topic == "p")
            {
                if (lastmsg == "e")
                {
                    nbPoules = nbPoules + 1;
                    if (nbPoules == nbPoulesMax + 1)
                    {
                        TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "erreur, le nombre de poules ne correspond pas !"; }));
                        nbPoules = nbPoulesMax;
                    }
                }

                else
                {
                    nbPoules = nbPoules - 1;
                    if (nbPoules == -1)
                    {
                        TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "erreur, le nombre de poules ne correspond pas !"; }));
                        nbPoules = 0;
                    }
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
            if (etat == "ouvert")
            {
                if(nbPoules != nbPoulesMax)
                {
                    TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "ATTENTION ! Toutes les poules ne sont pas rentrées, \r\nfermer quand même ?"; }));
                    BTN_back.Visibility = Visibility.Visible;
                    BTN_confirm.Visibility = Visibility.Visible;
                    nbPouleDiff();
                }

            }
            else
            {
                client.Publish("d", Encoding.UTF8.GetBytes("o"));
                etat = "ouvrir";
                sendChienDeGarde();
            }

        }

        void nbPouleDiff()
        {
           

            if (confirm == true)
            {
                etat = "fermer";
                confirm = false;
                BTN_back.Visibility = Visibility.Hidden;
                BTN_confirm.Visibility = Visibility.Hidden;

                client.Publish("d", Encoding.UTF8.GetBytes("f")); //publie a val sur d que on force la porte à se fermer
                sendChienDeGarde();
            }
            else if(back == true)
            {
                back = false;
                BTN_back.Visibility = Visibility.Hidden;
                BTN_confirm.Visibility = Visibility.Hidden;
                TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "La porte reste ouverte en attendant les poules."; }));
            }
        }



        void MiseAJour(string t)
        {
            TB_sub.Text = t;
        }


        void sendChienDeGarde() 
        {
            TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "en attente ..."; }));
            timer.Start();
        }

        private void BTN_confirm_click(object sender, RoutedEventArgs e)
        {
            confirm = true;
            BTN_back.Visibility = Visibility.Hidden;
            BTN_confirm.Visibility = Visibility.Hidden;
            nbPouleDiff();
        }

        private void BTN_back_click(object sender, RoutedEventArgs e) 
        {
            back = true;
            BTN_back.Visibility = Visibility.Hidden;
            BTN_confirm.Visibility = Visibility.Hidden;
            nbPouleDiff();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (lastmsg == "r")
            {
                TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "message reçu par le moteur!"; }));

            }

            else
            {

                //    if (Timer == Timer.Interval)
                //    {
                TB_sub.Dispatcher.Invoke(new Action(() => { TB_sub.Text = "attention, l'information n'à pas été reçue !"; }));
                //    }
            }
        }
    }
}
