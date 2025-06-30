using UnityEngine;
using UnityEditor;

namespace OfcaFramework.SaveAndLoad
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        [SerializeField] ScriptableSaveAndLoadManager scriptableSaveAndLoadManager;

        void Start()
        {
            if (scriptableSaveAndLoadManager != null)
            {
                scriptableSaveAndLoadManager.LoadAllDataOnStart();
            }
        }

        [MenuItem("Tools/OfcaFramework/FindSaveableScriptableData")]
        public static void FindSaveableScriptableData()
        {
            string assetPath = "Assets/#OfcaFramework/#SaveAndLoadManager/ScriptableSaveAndLoadManager.asset";
            var dynamicScriptableSaveAndLoadManager = AssetDatabase.LoadAssetAtPath<ScriptableSaveAndLoadManager>(assetPath);

            if (dynamicScriptableSaveAndLoadManager != null)
            {
                dynamicScriptableSaveAndLoadManager.DebugFindSaveableScriptableData();
            }
            else
            {
                Debug.LogError("Nie znaleziono ScriptableObject w œcie¿ce: " + assetPath);
            }
        }
    }
}
