using OfcaFramework.ScriptableWorkflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableBoolListener : ScriptableVariableListener<bool>
        {
            protected override void OnValueChanged(bool newValue)
            {
                Debug.Log($"New Bool Value: {newValue}", gameObject);
            }
        }
    }
}

