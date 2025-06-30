using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    [CreateAssetMenu(fileName = "NewStringSaveDataPathProcessor", menuName = "OfcaFramework/ScriptableProcessors/StringSaveDataPathProcessor", order = 2)]
    public class ScriptableStringSaveDataPathProcessor : ScriptableVariableValueProcessor<string>
    {
        public override string Process(string value)
        {
            return Application.persistentDataPath;
        }
    }
}
