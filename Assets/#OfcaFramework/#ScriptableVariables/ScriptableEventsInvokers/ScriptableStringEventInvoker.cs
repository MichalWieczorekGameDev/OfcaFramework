using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableStringEventInvoker : ScriptableEventInvokerBase<int>
    {
        [ContextMenu("Invoke event")]
        public override void InvokeOnValueChanged()
        {
            base.InvokeOnValueChanged();
        }
    }
}
