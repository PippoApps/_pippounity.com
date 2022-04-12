using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPippoUnity
{
    private string _debugId;
    //private MonoBehaviour _managedObj;
    public SystemPippoUnity(string debugId)
    {
        //_managedObj = obj;
        _debugId = debugId;
        L("System initialized.");
    }
    public void L(string log)
    {
        Debug.Log(_debugId + ">\t" + log);
    }
    public void EE(string log)
    {
        Debug.Log(_debugId + ">\t" + log);
    }
    public void WW(string log)
    {
        Debug.Log(_debugId + ">\t" + log);
    }
}
