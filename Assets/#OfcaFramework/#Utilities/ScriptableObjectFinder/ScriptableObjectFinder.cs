using OfcaFramework.TraitsWorkflow;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace OfcaFramework.Utilities
{
    public static class ScriptableObjectFinder
    {
        public static List<T> FindAllAssetsOfType<T>() where T : ScriptableObject
        {
#if UNITY_EDITOR
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            List<T> assets = new List<T>();

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                T asset = AssetDatabase.LoadAssetAtPath<T>(path);
                if (asset != null)
                {
                    assets.Add(asset);
                }
            }

            return assets;
#else
        Debug.LogWarning("FindAllAssetsOfType can only be used in the Unity Editor.");
        return new List<T>();
#endif
        }
    }
}