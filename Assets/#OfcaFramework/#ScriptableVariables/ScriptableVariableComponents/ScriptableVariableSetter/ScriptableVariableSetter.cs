using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public abstract class ScriptableVariableSetter<T> : MonoBehaviour
        {
            [SerializeField] protected ScriptableVariable<T> variable;

            [SerializeField] protected T valueToSet;

            [ContextMenu("Set()")]
            public virtual void Set()
            {
            }
        }
    }
}
