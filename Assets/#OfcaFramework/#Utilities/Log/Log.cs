using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace Utilities
    {
        public static class Log
        {
            /// <summary>
            /// Prints a log of the selected type (Normal/Error/Warning) in the console according to the message structure "Sender: message".
            /// </summary>
            /// <param name="_senderGameObject"></param>
            /// <param name="_message"></param>
            /// <param name="_logType"></param>
            public static void Print(GameObject _senderGameObject, string _message, LogType _logType)
            {
                if (_logType == LogType.Normal)
                {
                    Debug.Log($"<color=#5cdeff><b>[{_senderGameObject.name}]</b></color>: {_message}", _senderGameObject);
                }
                else if (_logType == LogType.Error)
                {
                    Debug.LogError($"<color=red><b>[{_senderGameObject.name}]</b></color>: {_message}", _senderGameObject);
                }
                else if (_logType == LogType.Warning)
                {
                    Debug.LogWarning($"<color=yellow><b>[{_senderGameObject.name}]</b></color>: {_message}", _senderGameObject);
                }
            }

            /// <summary>
            /// Writes out a log in the console according to the message structure "Sender: message".
            /// </summary>
            /// <param name="_senderGameObject"></param>
            /// <param name="_message"></param>
            public static void Print(GameObject _senderGameObject, string _message)
            {
                Debug.Log($"<color=#5cdeff><b>[{_senderGameObject.name}]</b></color>: {_message}", _senderGameObject);
            }

            /// <summary>
            /// Writes out a log in the console.
            /// </summary>
            /// <param name="_message"></param>
            public static void Print(string _message)
            {
                Debug.Log(_message);
            }
        }

        public enum LogType { Normal, Error, Warning }
    }
}