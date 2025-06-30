using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableFloatEventInvoker : ScriptableEventInvokerBase<int>
    {
        [ContextMenu("Invoke event")]
        public override void InvokeOnValueChanged()
        {
            base.InvokeOnValueChanged();
        }
    }
}
