using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using SocketIOClient;
using NetworkDataStuct;

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
            this._initListener();
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

        private void _initListener()
        {
            this.socket.On("loginSucceed", this.onLoginSucceed);
        }

        public void connect()
        {
            this.socket.ConnectAsync();
        }

        public void emit(string ev, object msg)
        {
            this.socket.EmitAsync(ev, msg);
        }

        private void onLoginSucceed(SocketIOResponse res)
        {
            Debug.Log(res);
            Debug.Log(res.GetValue<DataLoginSucceed>());
            DataLoginSucceed data = JsonUtility.FromJson<DataLoginSucceed>(res.ToString());
            Debug.Log(data.id);
        }
    }
}