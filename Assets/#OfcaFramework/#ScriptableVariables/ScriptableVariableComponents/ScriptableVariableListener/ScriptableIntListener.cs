using OfcaFramework.ScriptableWorkflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableIntListener : ScriptableVariableListener<int>
        {
            protected override void OnValueChanged(int newValue)
            {
                Debug.Log($"New Int Value: {newValue}", gameObject);
            }
        }
    }
}
        
