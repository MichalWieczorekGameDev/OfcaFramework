using UnityEngine;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableVariableValueProcessor<T> : ScriptableObject
    {
        public virtual T Process(T value)
        {
            Debug.Log("The Process() function is not overridden in the inheriting class.");
            return value;
        }
    }
}

