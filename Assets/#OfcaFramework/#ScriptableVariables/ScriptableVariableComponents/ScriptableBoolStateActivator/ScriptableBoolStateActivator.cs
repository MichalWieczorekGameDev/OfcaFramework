using NUnit.Framework;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableBoolStateActivator : ScriptableVariableListener<bool>
        {
            [SerializeField] private List<GameObject> gmaeObjectsToActivateOnTrue;
            [SerializeField] private List<GameObject> gmaeObjectsToActivateOnFalse;
            [SerializeField] private bool SetActiveStateOfObjectsOnStart = false;

            protected override void OnValueChanged(bool newValue)
            {
                EnableAndDisableGameObjects(newValue);
            }
            private void Start()
            {
                if (SetActiveStateOfObjectsOnStart)
                {
                    EnableAndDisableGameObjects(variable.Value);
                }
            }
            private void EnableAndDisableGameObjects(bool newValue)
            {
                if(newValue)
                {
                    foreach (GameObject obj in gmaeObjectsToActivateOnTrue)
                    {
                        obj.SetActive(true);
                    }
                    foreach (GameObject obj in gmaeObjectsToActivateOnFalse)
                    {
                        obj.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("Ustawiono na false!");
                    foreach (GameObject obj in gmaeObjectsToActivateOnTrue)
                    {
                        obj.SetActive(false);
                    }
                    foreach (GameObject obj in gmaeObjectsToActivateOnFalse)
                    {
                        obj.SetActive(true);
                    }
                }
            }
        }
    }
}
