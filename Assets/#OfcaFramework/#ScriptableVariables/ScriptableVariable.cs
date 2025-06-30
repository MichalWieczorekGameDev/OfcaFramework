using OfcaFramework.ScriptableWorkflow;
using OfcaFramework.TraitsWorkflow;
using System;
using System.Collections.Generic;
using UnityEngine;
using OfcaFramework.CustomDescription;
using UnityEditor;
using System.IO;
using Unity.VisualScripting;
using OfcaFramework.SaveAndLoad;
using Sirenix.OdinInspector;



#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif



namespace OfcaFramework.ScriptableWorkflow
{
    public interface IVariable<T>
    {
        T Value { get; set; }
        event Action<T> OnValueChanged;
    }

    public interface ISaveAndLoad
    {
        SaveAndLoadTraitBase saveAndLoadTrait {  get; set; }
        SaveAndLoadTraitBase GetSaveAndLoadTrait();
        List<string> GetVariableData();
        void SetVariableData(List<string> variableData);
        void SetStringValue(string newValue);

    }

    [CreateAssetMenu(fileName = "NewVariable", menuName = "OfcaFramework/ScriptableVariable", order = 1)]
    public class ScriptableVariable<T> : ScriptableVariableBase, IVariable<T>, ITraitContainer<ScriptableVariableTrait>, IForceInvokeable, ISaveAndLoad
    {
        [SerializeField]
        [ReadOnly]
        string variableName
        {
            get
            {
                return GetAssetFileName();
            }
            set
            {
                value = GetAssetFileName();
            }
        }
        [SerializeField] CustomDescriptionObject customDescription;

        [Header("Value section:")]
        [SerializeField] private T value;
        [SerializeField] private T defaultValue;
        [SerializeField][ReadOnly] private T lastPostProcessorValue;
        [Space]

        [SerializeField] private bool updateValueOnValidate = false;

        [SerializeField] private List<ScriptableVariableTrait> scriptableVariableTraits = new List<ScriptableVariableTrait>();
        [SerializeField] SaveAndLoadTraitBase saveAndLoadTrait;


        [SerializeField] private bool callEventEveryValueChangeTry = false;

        [Header("Scriptable Variable Processors")]
        [SerializeField] private List<ScriptableVariableValueProcessor<T>> scriptableVariableManualCallValueProcessors; //GIT
        [SerializeField] private ScriptableVariableValueProcessor<T> scriptableVariableOnEnableValueProcessor;
        [SerializeField] private ScriptableVariableValueProcessor<T> scriptableVariableStaticValueProcessor;


        public T Value
        {
            get
            {
                var valueToReturn = value;
                if (scriptableVariableStaticValueProcessor != null)
                {
                    valueToReturn = scriptableVariableStaticValueProcessor.Process(value);
                    lastPostProcessorValue = valueToReturn;
                }
                return valueToReturn;
            }
            set
            {
                bool isSameValue = EqualityComparer<T>.Default.Equals(this.value, value);
                bool shouldInvokeEvent = !isSameValue || callEventEveryValueChangeTry;

                if (shouldInvokeEvent)
                {
                    if (scriptableVariableStaticValueProcessor == null)
                    {
                        this.value = value;
                        OnValueChanged?.Invoke(this.value);
                    }
                    else
                    {
                        this.value = value;
                        var valuePostProccess = scriptableVariableStaticValueProcessor.Process(value);
                        OnValueChanged?.Invoke(valuePostProccess);
                    }
                        
                }
            }
        }

        #if UNITY_EDITOR
        public string GetAssetFileName()
        {
            string path = AssetDatabase.GetAssetPath(this);
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }
        #endif



        SaveAndLoadTraitBase ISaveAndLoad.saveAndLoadTrait { get => saveAndLoadTrait; set => saveAndLoadTrait = value; }

        public T GetTrueValue()
        {
            return value;
        }

        //Maybe to delete
        public void scriptableVariableManualCallProcessorProcess(ScriptableVariableValueProcessor<T> processor)
        {
            foreach(ScriptableVariableValueProcessor<T> processorToFind in scriptableVariableManualCallValueProcessors)
            {
                if (processorToFind == processor)
                {
                    value = processorToFind.Process(value);
                }
            }
        }

        void OnEnable()
        {
            ForceProccessingOfScriptableVariableOnEnableValueProcessor();
        }

        public void ForceProccessingOfScriptableVariableOnEnableValueProcessor()
        {
            var tempValue = value;
            if (scriptableVariableOnEnableValueProcessor != null)
            {
                tempValue = scriptableVariableOnEnableValueProcessor.Process(value);
                lastPostProcessorValue = tempValue;
            }
        }
        public void ForceInvokeOnValueChanged()
        {
            OnValueChanged?.Invoke(value);
#if UNITY_EDITOR
            Debug.Log(Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this)) + ": Event invoked");
#endif
        }

        protected virtual void OnValidate()
        {
            if (updateValueOnValidate) { OnValueChanged?.Invoke(value); }
        }

        public override string ToString()
        {
            return this.value + "";
        }


        public event Action<T> OnValueChanged;


        //TRAITS
        public event Action<ScriptableVariableTrait> OnTraitAdded;
        public event Action<ScriptableVariableTrait> OnTraitRemoved;

        public void AddTrait(ScriptableVariableTrait trait)
        {
            if (!scriptableVariableTraits.Contains(trait))
            {
                scriptableVariableTraits.Add(trait);
                OnTraitAdded?.Invoke(trait);
            }
        }

        public void RemoveTrait(ScriptableVariableTrait trait)
        {
            if (scriptableVariableTraits.Contains(trait))
            {
                scriptableVariableTraits.Remove(trait);
                OnTraitRemoved?.Invoke(trait);
            }
        }

        public bool HasTrait(ScriptableVariableTrait trait)
        {
            return scriptableVariableTraits.Contains(trait);
        }

        public List<ScriptableVariableTrait> GetAllTraits()
        {
            return scriptableVariableTraits;
        }

        



#if ENABLE_INPUT_SYSTEM
        public virtual void ReadInput(InputAction.CallbackContext context)
        {
            Debug.LogWarning($"{name}: ReadInput not implemented for type {typeof(T)}");
        }
#endif


        //SAVE AND LOAD
        public SaveAndLoadTraitBase GetSaveAndLoadTrait()
        {
            if (saveAndLoadTrait == null)
            {
                return null;
            }
            else
            {
                return saveAndLoadTrait;
            }
        }

        public List<string> GetVariableData()
        {
            List<string> result = new List<string>();
            result.Add(variableName); //name of this scriptable variable

            if (saveAndLoadTrait != null) //name of this SaveAndLoadTrait
            {
                result.Add(saveAndLoadTrait.TraitName);
            }
            else
            {
                result.Add("NoSpeciefiedSaveDataType");
            }

            result.Add(value.ToString()); //value as string
            result.Add(typeof(T).Name); //type T's name as string


            return result;
        }

        public void SetVariableData(List<string> variableData)
        {
            if (variableData[0] == variableName && variableData[3] == typeof(T).Name && variableData[1] == saveAndLoadTrait.TraitName)
            {
                SetStringValue(variableData[2]);
            }
        }

        public virtual void SetStringValue(string newValue)
        {
            //Example:
            //T Value = (T)newValue;
            Debug.Log("The SetStringValue() function is not overridden in the inheriting class.");
        }

    }
}
