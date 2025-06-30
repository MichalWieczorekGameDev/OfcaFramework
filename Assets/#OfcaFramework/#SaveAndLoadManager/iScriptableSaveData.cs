using UnityEngine;
namespace OfcaFramework.SaveAndLoad
{
    public interface iScriptableSaveData
    {
        ScriptableSaveableContent SaveData();
        void LoadData(ScriptableSaveableContent scriptableSaveableContent);
    }

    [System.Serializable]
    public class ScriptableSaveableContent
    {
        [SerializeField] string variableName;
        [SerializeField] SaveAndLoadTraitBase trait;
        [SerializeField] string variableValue;

        public ScriptableSaveableContent(string variableName, SaveAndLoadTraitBase trait, string variableValue)
        {
            this.variableName = variableName;
            this.trait = trait;
            this.variableValue = variableValue;
        }

        public string GetVariableName()
        {
            return variableName;
        }

        public SaveAndLoadTraitBase GetTrait() { return trait; }

        public string GetVariableValue()
        {
            return variableValue;
        }
    }
}