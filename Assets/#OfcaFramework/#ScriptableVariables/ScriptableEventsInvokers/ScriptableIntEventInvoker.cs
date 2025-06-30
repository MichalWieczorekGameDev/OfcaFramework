using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableIntEventInvoker : ScriptableEventInvokerBase<int>
    {
        [ContextMenu("Invoke event")]
        public override void InvokeOnValueChanged()
        {
            base.InvokeOnValueChanged();
        }
    }
}
