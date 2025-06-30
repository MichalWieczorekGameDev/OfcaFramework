using NUnit.Framework;
using OfcaFramework.TraitsWorkflow;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEditor;


namespace OfcaFramework.ScriptableWorkflow
{
    public static class ScriptableVariablesFinder
    {
        public static List<ScriptableObject> FindAllScriptableVariablesWithTrait(ScriptableVariableTrait trait)
        {
            var results = new List<ScriptableObject>();
            string[] guids = AssetDatabase.FindAssets("t:ScriptableObject");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ScriptableObject asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

                if (asset == null)
                    continue;

                Type type = asset.GetType();

                
                if (!InheritsFromOpenGeneric(type, typeof(ScriptableVariable<>)))
                    continue;

                
                if (asset is ITraitContainer<ScriptableVariableTrait> traitContainer)
                {
                    
                    if (traitContainer.HasTrait(trait))
                    {
                        results.Add(asset);
                    }
                }
            }

            return results;
        }

        private static bool InheritsFromOpenGeneric(Type type, Type openGeneric)
        {
            while (type != null && type != typeof(object))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == openGeneric)
                    return true;

                type = type.BaseType;
            }
            return false;
        }
    }
}

