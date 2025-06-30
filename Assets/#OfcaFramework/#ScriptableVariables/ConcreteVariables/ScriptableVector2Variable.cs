using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewVector2Variable", menuName = "OfcaFramework/ScriptableVariable/ScriptableVector2Variable", order = 5)]
    public class ScriptableVector2Variable : ScriptableVariable<Vector2>
    {
#if ENABLE_INPUT_SYSTEM
        public override void ReadInput(InputAction.CallbackContext context)
        {
            Value = context.ReadValue<Vector2>();
        }
#endif
    }

}