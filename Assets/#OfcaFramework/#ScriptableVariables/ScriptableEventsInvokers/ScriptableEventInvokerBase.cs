using UnityEngine;
using OfcaFramework.ScriptableWorkflow;

namespace OfcaFramework.ScriptableWorkflow
{
    public abstract class ScriptableEventInvokerBase<T> : MonoBehaviour
    {
        [SerializeField] private ScriptableVariable<T> scriptableVariable;

        [ContextMenu("Invoke event")]
        public virtual void InvokeOnValueChanged()
        {
            if (scriptableVariable != null)
            {
                scriptableVariable.ForceInvokeOnValueChanged();
            }
            else
            {
                Debug.LogWarning("ScriptableVariable reference is missing in ScriptableEventInvoker.");
            }
        }
    }
}
