using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using DarkRift;
using DarkRift.Client;
using Scripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Networking
{
    public class NetworkManager
    {
        public static NetworkManager instance;
        private DarkRiftClient client;
        public bool matchConnected = false;

        public static NetworkManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NetworkManager();
                }
                return instance;
            }
        }

        private NetworkManager()
        {
            client = new DarkRiftClient();
        }

        public ConnectionState ConnectionState
        {
            get
            {
                return client.ConnectionState;
            }
        }

        public bool IsConnected
        {
            get
            {
                return client.ConnectionState == ConnectionState.Connected;
            }
        }

        public bool Connect()
        {
            if (client.ConnectionState == DarkRift.ConnectionState.Connecting) 
            {
                return false;
            }
            if(client.ConnectionState == DarkRift.ConnectionState.Connected)
            {
                return true;
            }
            try
            {
                client.Connect(IPAddress.Parse("148.255.110.94"), 4296, DarkRift.IPVersion.IPv4);
                return true;
            }
            catch (Exception)
            {

            }
            return false;
           
        }


        public void MessageToServer(string name)
        {
            if (IsConnected)
            {
                using ( DarkRiftWriter writer = DarkRiftWriter.Create() )
                {
                    writer.Write(name);

                    using(Message message = Message.Create((ushort)tags.Tag.SET_NAME, writer))
                    {
                        //reliable   = TCP
                        //unreliable = UDP
                        client.SendMessage(message, SendMode.Reliable);
                    }
                }
            }
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            switch ((tags.Tag)e.Tag)
            {
                case tags.Tag.MATCH_CONNECTED:
                    using(Message msg = e.GetMessage())
                    {
                        using(DarkRiftReader reader = msg.GetReader())
                        {
                            ushort matchID = reader.ReadUInt16();

                            // This Match is NOT for regex, it is referencing 
                            // the Match model 
                            
                            Match.currentMatch = new Match(matchID);

                            
                          
                        }
                    }
                    
                    break;
            }
        }

        public void MessageSpaceTaken(ushort spaceClicked, ushort matchId)
        {
            using(DarkRiftWriter writer = DarkRiftWriter.Create())
            {
                writer.Write(matchId);
                writer.Write(spaceClicked);

                using(Message message = Message.Create((ushort)tags.Tag.SPACE_TAKEN, writer))
                {
                    client.SendMessage(message, SendMode.Reliable);
                }
            }
        }
    }
}

