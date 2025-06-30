using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public abstract class ScriptableVariableAdder<T> : MonoBehaviour
        {
            [SerializeField] protected ScriptableVariable<T> variable;

            [SerializeField] protected T valueToAdd;

            [ContextMenu("Add()")]
            public virtual void Add()
            {
            }
        }
    }
}
