using NetworkDataStuct;
using UnityEditor;
using UnityEngine;

public static class Util
{
    public static void logData<T>(SocketIOClient.SocketIOResponse data)
    {
        Debug.Log(Util.parseJson<T>(data.GetValue<string>()));
    }
    public static T parseJson<T>(string data)
    {
        return JsonUtility.FromJson<T>(data);
    }

    public static string toJson<T>(T data)
    {
        return JsonUtility.ToJson(data);
    }
}