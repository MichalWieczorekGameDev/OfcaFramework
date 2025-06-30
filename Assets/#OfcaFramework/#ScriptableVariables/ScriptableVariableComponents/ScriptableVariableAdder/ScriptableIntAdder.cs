using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableIntAdder : ScriptableVariableAdder<int>
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
}
