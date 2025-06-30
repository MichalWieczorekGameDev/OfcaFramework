using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OfcaFramework.SceneWorkflow
{
    [CreateAssetMenu(fileName = "NewSceneManager", menuName = "OfcaFramework/SceneWorkflow/SceneManager", order = 1)]
    public class SceneManager : ScriptableObject
    {

        [HideInInspector][SerializeField] private List<string> scenePaths = new List<string>();

#if UNITY_EDITOR
        [SerializeField] private List<SceneAsset> scenes = new List<SceneAsset>();
#endif
    }
}

