using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InspectorButton : MonoBehaviour
{
    
    [SerializeField] public UnityEvent eventToInvoke;
    [HideInInspector]
    public string eventName = "Invoke";
    public void Invoke()
    {
        eventToInvoke?.Invoke();
    }

    private void OnValidate()
    {
        if (eventToInvoke != null)
        {
            eventName = eventToInvoke.GetPersistentMethodName(0);
        }
        else
        {
            eventName = "";
        }
    }
}
