using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableFloatAdder : ScriptableVariableAdder<float>
    {
        [ContextMenu("Add()")]
        public override void Add()
        {
            if (variable != null)
            {
                variable.Value += valueToAdd;
            }
        }
    }
}
