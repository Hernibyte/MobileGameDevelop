using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPlugin : MonoBehaviour {

    const string Plugin_name = "com.kre1zy.pllogger.PlLogger";
    static AndroidJavaClass _pluginClass = null;

    public static AndroidJavaClass pluginClass
    {
        get
        {
            if (_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(Plugin_name);
            }
            return _pluginClass;
        }
    }

    static AndroidJavaObject _pluginInstance = null;
    public AndroidJavaObject pluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                _pluginInstance = pluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }

    void sendLog(string msj)
    {
        pluginInstance.Call("sendLog", msj);
    }
    string getLog()
    {
        return pluginInstance.Call<string>("getAllLogs");
    }
}
