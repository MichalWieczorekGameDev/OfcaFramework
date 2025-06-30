using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "OfcaFramework/ScriptableVariable/ScriptableFloatVariable", order = 2)]
    public class ScriptableFloatVariable : ScriptableVariable<float>
    {
        public override void SetStringValue(string newValue)
        {
            Value = float.Parse(newValue);
        }
#if ENABLE_INPUT_SYSTEM
        public override void ReadInput(InputAction.CallbackContext context)
        {
            Value = context.ReadValue<float>();
        }
#endif
    }
}