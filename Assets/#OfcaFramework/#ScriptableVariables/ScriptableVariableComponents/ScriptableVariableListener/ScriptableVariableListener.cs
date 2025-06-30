using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public abstract class ScriptableVariableListener<T> : MonoBehaviour
        {
            [SerializeField] protected ScriptableVariable<T> variable;

            protected virtual void OnEnable()
            {
                if (variable != null)
                {
                    variable.OnValueChanged += OnValueChanged;
                }
            }

            protected virtual void OnDisable()
            {
                if (variable != null)
                    variable.OnValueChanged -= OnValueChanged;
            }

            protected abstract void OnValueChanged(T newValue);
        }
    }
}
