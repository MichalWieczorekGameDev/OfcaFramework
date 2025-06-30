using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "OfcaFramework/ScriptableVariable/ScriptableIntVariable", order = 1)]
    public class ScriptableIntVariable : ScriptableVariable<int>
    {
        public override void SetStringValue(string newValue)
        {
            Value = int.Parse(newValue);
        }

#if ENABLE_INPUT_SYSTEM
        public override void ReadInput(InputAction.CallbackContext context)
        {
            Value = context.ReadValue<int>();
        }
#endif
    }
}
