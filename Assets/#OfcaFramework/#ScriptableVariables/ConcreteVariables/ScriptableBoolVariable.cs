using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewBoolVariable", menuName = "OfcaFramework/ScriptableVariable/ScriptableBoolVariable", order = 4)]
    public class ScriptableBoolVariable : ScriptableVariable<bool>
    {
#if ENABLE_INPUT_SYSTEM
        public enum InputMode
        {
            HoldButton,
            ChangeStateButton
        }

        [SerializeField]
        private InputMode inputMode = InputMode.HoldButton;

        public override void SetStringValue(string newValue)
        {
            Value = bool.Parse(newValue);
        }

        public override void ReadInput(InputAction.CallbackContext context)
        {
            switch (inputMode)
            {
                case InputMode.HoldButton:
                    if (context.started)
                    {
                        Value = true;
                    }
                    else if (context.canceled)
                    {
                        Value = false;
                    }
                    break;

                case InputMode.ChangeStateButton:
                    if (context.performed) // 'performed' to najlepszy moment na reakcjê na pojedyncze klikniêcie
                    {
                        Value = !Value;
                    }
                    break;
            }
        }
#endif
    }
}
