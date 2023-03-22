using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using SocketIOClient;

namespace Network
{
    public class NetHandler
    {
        private string URL = "ws://localhost:3231";
        private int PORT = -1;
        private static NetHandler instance = null;
        public static NetHandler getInstance()
        {
            if (instance == null)
            {
                instance = new NetHandler();
                return instance;
            }

            return instance;
        }


        private SocketIO socket = null;

        public NetHandler()
        {
            this._initSocket();
        }

        private void _initSocket(string path = null, int Port = 0)
        {
            string url = path ?? this.URL;
            this.socket = new SocketIO(url);
            this.socket.OnConnected += (sender, ev) =>
            {
                Debug.Log("SERVER CONNECTED");
            };
        }

        public void connect()
        {
            this.socket.ConnectAsync();
        }

        public void emit(object msg)
        {
            string json = JsonUtility.ToJson(msg);
            Debug.Log(json);
            this.socket.EmitAsync("onLogin", json);
        }

    }
}