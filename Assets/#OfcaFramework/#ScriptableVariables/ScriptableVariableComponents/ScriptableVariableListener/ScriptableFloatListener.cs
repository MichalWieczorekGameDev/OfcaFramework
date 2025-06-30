using OfcaFramework.ScriptableWorkflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableFloatListener : ScriptableVariableListener<float>
        {
            protected override void OnValueChanged(float newValue)
            {
                Debug.Log($"New Float Value: {newValue}", gameObject);
            }
        }
    }
}

