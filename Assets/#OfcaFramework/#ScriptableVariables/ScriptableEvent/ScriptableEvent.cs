using OfcaFramework.TraitsWorkflow;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.InputSystem; // <-- Dodane

namespace OfcaFramework.ScriptableWorkflow
{
    public interface IEventable
    {
        event Action OnEventInvoke;
    }

    [CreateAssetMenu(fileName = "NewScriptableEvent", menuName = "OfcaFramework/ScriptableEvents/ScriptableEvent", order = 1)]
    public class ScriptableEvent : ScriptableEventBase, IForceInvokeable, IEventable, ITraitContainer<ScriptableEventTrait>
    {
        public event Action OnEventInvoke;

        public void ForceInvokeOnValueChanged()
        {
            OnEventInvoke?.Invoke();
#if UNITY_EDITOR
            Debug.Log(Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this)) + ": Event invoked");
#endif
        }

        // Nowa metoda do odczytu inputu
        public void ReadInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnEventInvoke?.Invoke();
#if UNITY_EDITOR
                Debug.Log(Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this)) + ": Input started - event invoked");
#endif
            }
        }

        public event Action<ScriptableEventTrait> OnTraitAdded;
        public event Action<ScriptableEventTrait> OnTraitRemoved;

        [SerializeField] private List<ScriptableEventTrait> scriptableEventTrait = new List<ScriptableEventTrait>();

        public void AddTrait(ScriptableEventTrait trait)
        {
            if (!scriptableEventTrait.Contains(trait))
            {
                scriptableEventTrait.Add(trait);
                OnTraitAdded?.Invoke(trait);
            }
        }

        public List<ScriptableEventTrait> GetAllTraits()
        {
            return scriptableEventTrait;
        }

        public bool HasTrait(ScriptableEventTrait trait)
        {
            return scriptableEventTrait.Contains(trait);
        }

        public void RemoveTrait(ScriptableEventTrait trait)
        {
            if (scriptableEventTrait.Contains(trait))
            {
                scriptableEventTrait.Remove(trait);
                OnTraitRemoved?.Invoke(trait);
            }
        }
    }
}
