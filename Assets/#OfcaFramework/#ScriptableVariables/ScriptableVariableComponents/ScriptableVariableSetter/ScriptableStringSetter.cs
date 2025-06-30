using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableStringSetter : ScriptableVariableSetter<string>
        {
            [Button("Set value")]
            public override void Set()
            {
                if (variable != null)
                {
                    variable.Value = valueToSet;
                }
            }
        }
    }
}