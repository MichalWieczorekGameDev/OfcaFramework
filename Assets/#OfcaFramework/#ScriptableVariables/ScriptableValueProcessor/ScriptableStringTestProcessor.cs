using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewStringTestProcessor", menuName = "OfcaFramework/ScriptableStaticProcessors/ScriptableStringTestProcessor", order = 1)]
    public class ScriptableStringTestProcessor : ScriptableVariableValueProcessor<string>
    {
        public override string Process(string value)
        {
            return "test";
        }
    }
}