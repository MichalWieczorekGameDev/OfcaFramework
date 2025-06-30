using OfcaFramework.ScriptableWorkflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableStringListener : ScriptableVariableListener<string>
        {
            protected override void OnValueChanged(string newValue)
            {
                Debug.Log($"New String Value: {newValue}", gameObject);
            }
        }
    }
}

