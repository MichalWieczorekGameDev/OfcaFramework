using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OfcaFramework.ScriptableWorkflow
{
    public class InputToScriptableEventBridge : MonoBehaviour
    {
        [Serializable]
        public class InputEventMapping
        {
            public InputActionReference inputAction;
            public ScriptableAnyEventInvoker scriptableEventInvoker;
        }

        [SerializeField] private List<InputEventMapping> eventMappings;

        private void OnEnable()
        {
            foreach (var mapping in eventMappings)
            {
                if (mapping.inputAction != null && mapping.scriptableEventInvoker != null)
                {
                    mapping.inputAction.action.performed += ctx => mapping.scriptableEventInvoker.InvokeOnValueChanged();
                }
            }
        }

        private void OnDisable()
        {
            foreach (var mapping in eventMappings)
            {
                if (mapping.inputAction != null && mapping.scriptableEventInvoker != null)
                {
                    mapping.inputAction.action.performed -= ctx => mapping.scriptableEventInvoker.InvokeOnValueChanged();
                }
            }
        }
    }
}
