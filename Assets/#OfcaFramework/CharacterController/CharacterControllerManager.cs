using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

namespace OfcaFramework
{
    namespace CharacterController
    {
        public class CharacterControllerManager : MonoBehaviour
        {
            [SerializeField] List<CharacterControllerProcessor> characterControllerProcessors;
            [SerializeField] List<ICharacterControllerOnAwake> onAwakeProcessors = new();
            [SerializeField] List<ICharacterControllerOnStart> onStartProcessors = new();
            [SerializeField] List<ICharacterControllerOnUpdate> onUpdateProcessors = new();
            [SerializeField] List<ICharacterControllerOnFixedUpdate> onFixedUpdateProcessors = new();
            [SerializeField] List<ICharacterControllerOnEnable> onEnableProcessors = new();
            [SerializeField] List<ICharacterControllerOnDisable> onDisableProcessors = new();
            [SerializeField] List<ICharacterControllerOnDestroy> onDestroyProcessors = new();

            //public SideViewCharacterControllerPlayerInput playerInput;
            public CharacterControllerProcessor GetProcessorByName(string name)
            {
                CharacterControllerProcessor processorToReturn = null;
                foreach (CharacterControllerProcessor processor in characterControllerProcessors)
                {
                    if (processor.GetProcessorName() == name)
                    {
                        processorToReturn = processor;
                        break;
                    }
                }
                return processorToReturn;
            }

            [ContextMenu("Update Processors List")]
            void UpdateProcessorLists()
            {
                onStartProcessors.Clear();
                onAwakeProcessors.Clear();
                onDisableProcessors.Clear();
                onDestroyProcessors.Clear();
                onFixedUpdateProcessors.Clear();
                onEnableProcessors.Clear();
                onUpdateProcessors.Clear();

                foreach (CharacterControllerProcessor processor in characterControllerProcessors)
                {
                    if (processor is ICharacterControllerOnAwake)
                    {
                        onAwakeProcessors.Add(processor.GetComponent<ICharacterControllerOnAwake>());
                    }

                    if (processor is ICharacterControllerOnStart)
                    {
                        onStartProcessors.Add(processor.GetComponent<ICharacterControllerOnStart>());
                    }

                    if (processor is ICharacterControllerOnUpdate)
                    {
                        onUpdateProcessors.Add(processor.GetComponent<ICharacterControllerOnUpdate>());
                    }

                    if (processor is ICharacterControllerOnFixedUpdate)
                    {
                        onFixedUpdateProcessors.Add(processor.GetComponent<ICharacterControllerOnFixedUpdate>());
                    }

                    if (processor is ICharacterControllerOnEnable)
                    {
                        onEnableProcessors.Add(processor.GetComponent<ICharacterControllerOnEnable>());
                    }

                    if (processor is ICharacterControllerOnDisable)
                    {
                        onDisableProcessors.Add(processor.GetComponent<ICharacterControllerOnDisable>());
                    }

                    if (processor is ICharacterControllerOnDestroy)
                    {
                        onDestroyProcessors.Add(processor.GetComponent<ICharacterControllerOnDestroy>());
                    }
                }
            }

            private void OnValidate()
            {
                UpdateProcessorLists();
            }

            private void Awake()
            {
                foreach (var processor in onAwakeProcessors)
                {
                    processor.OnAwakeInvoke();
                }
            }
            private void Start()
            {
                foreach (var processor in onStartProcessors)
                {
                    processor.OnStartInvoke();
                }
            }

            private void Update()
            {
                foreach (var processor in onUpdateProcessors)
                {
                    processor.OnUpdateInvoke();
                }
            }

            private void FixedUpdate()
            {
                foreach (var processor in onFixedUpdateProcessors)
                {
                    processor.OnFixedUpdateInvoke();
                }
            }

            private void OnEnable()
            {
                foreach (var processor in onEnableProcessors)
                {
                    processor.OnEnableInvoke();
                }
            }

            private void OnDisable()
            {
                foreach (var processor in onDisableProcessors)
                {
                    processor.OnDisableInvoke();
                }
            }

            private void OnDestroy()
            {
                foreach (var processor in onDestroyProcessors)
                {
                    processor.OnDestroyInvoke();
                }
            }

            [ContextMenu("DebugArray()")]
            void DebugArray()
            {
                Debug.Log(onUpdateProcessors.Count.ToString());
            }
        }

        interface ICharacterControllerOnAwake
        {
            void OnAwakeInvoke();
        }

        interface ICharacterControllerOnStart
        {
            void OnStartInvoke();
        }

        interface ICharacterControllerOnUpdate
        {
            void OnUpdateInvoke();
        }

        interface ICharacterControllerOnFixedUpdate
        {
            void OnFixedUpdateInvoke();
        }

        interface ICharacterControllerOnEnable
        {
            void OnEnableInvoke();
        }

        interface ICharacterControllerOnDisable
        {
            void OnDisableInvoke();
        }

        interface ICharacterControllerOnDestroy
        {
            void OnDestroyInvoke();
        }
    }
}


