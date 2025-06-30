using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "OfcaFramework/ScriptableVariable/ScriptableStringVariable", order = 3)]
    public class ScriptableStringVariable : ScriptableVariable<string>
    {
        public override void SetStringValue(string newValue)
        {
            Value = newValue;
        }
    }
}