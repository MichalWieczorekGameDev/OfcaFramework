#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using OfcaFramework.CustomDescription;



namespace OfcaFramework.TraitsWorkflow
{
    [CreateAssetMenu(fileName = "NewBaseTrait", menuName = "OfcaFramework/Traits/BaseTrait", order = 1)]
    public class Trait : ScriptableObject
    {
        private protected string traitName;

        public string TraitName
        {
#if UNITY_EDITOR
            get { return GetAssetFileName(); }
#endif
            set { traitName = value; }
        }

        public CustomDescriptionObject description;
#if UNITY_EDITOR
        public string GetAssetFileName()
        {
            string path = AssetDatabase.GetAssetPath(this);
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }
#endif
    }
}
