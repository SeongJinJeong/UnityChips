using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class NetHandler : MonoBehaviour
{
    private string IP = "127.0.0.1";
    private string PORT = "3231";
    private static WebSocketSharp.WebSocket socket = null;
    
    public static WebSocket getInstance()
    {
        string IP = "127.0.0.1";
        string PORT = "3231";
        if (socket != null)
        {
            return socket;
        }

        socket = new WebSocket("ws://" + IP + ":" + PORT);
        socket.OnMessage += onMessage;
    }

    private static void onMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
    }
}
