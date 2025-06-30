using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableAnyEventInvoker : MonoBehaviour
    {
        [SerializeField] private ScriptableBase scriptableBase;

        [ContextMenu("Force Invoke")]
        public void InvokeOnValueChanged()
        {
            if (scriptableBase is IForceInvokeable forceInvokeable)
            {
                forceInvokeable.ForceInvokeOnValueChanged();
            }
            else
            {
                Debug.LogWarning("The referenced ScriptableVariable does not implement IForceInvokeable.");
            }
        }
    }
}
