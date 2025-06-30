using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableFloatSetter : ScriptableVariableSetter<float>
        {
            [ContextMenu("Set()")]
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