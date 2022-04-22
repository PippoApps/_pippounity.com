using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//namespace PippoUnity
//{

// This class is instantiated as _system in all GameObjects.
// Provides logging functionalities and else.
[DefaultExecutionOrder(-1002)]
public class SystemPippoUnity
{
        public static bool HAS_CONNECTION;
        private static int _mainCounter = 0;
        private string _debugId;
        //private MonoBehaviour _managedObj;
        public SystemPippoUnity(string debugId)
        {
            //_managedObj = obj;
            _debugId = "[" + debugId + "]";
            //L("System initialized.");
        }
        public void L(string log)
        {
            Debug.Log("\t[" + (_mainCounter++) + "]" + _debugId + "\t" + log);
        }
        public void E(string log)
        {
            L(log);
        }
        public void W(string log)
        {
            L(log);
        }
    }


//}