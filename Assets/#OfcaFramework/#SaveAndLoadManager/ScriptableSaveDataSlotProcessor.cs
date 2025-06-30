using OfcaFramework.ScriptableWorkflow;
using OfcaFramework.Utilities;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace OfcaFramework.SaveAndLoad
{
    [CreateAssetMenu(fileName = "ScriptableSaveDataSlotProcessor", menuName = "OfcaFramework/SaveAndLoad/SaveDataSlotProcessor")]
    public class ScriptableSaveDataSlotProcessor : ScriptableVariableValueProcessor<string>
    {
        [SerializeField] List<ScriptableSaveDataSlot> saveDataSlotsList;
        [SerializeField] int currentSaveDataSlotIndex = 0;
        [SerializeField] string currentSaveDataSlotName;

        [Button("Find all SaveDataSlots")]
        public void FindAllSaveDataSlots()
        {
            saveDataSlotsList = ScriptableObjectFinder.FindAllAssetsOfType<ScriptableSaveDataSlot>();
            if (saveDataSlotsList.Count > 0)
            {
                SetSaveDataSlot(0);
            }
        }

        [Button("Reset saveDataSlotsList")]
        public void ResetSaveDataSlotsList()
        {
            saveDataSlotsList = new List<ScriptableSaveDataSlot>();
            currentSaveDataSlotIndex = 0;
        }

        [Button("Set next SaveDataSlot")]
        public void SetNextSaveDataSlot()
        {
            if (currentSaveDataSlotIndex < saveDataSlotsList.Count - 1)
            {
                currentSaveDataSlotIndex++;
                currentSaveDataSlotName = saveDataSlotsList[currentSaveDataSlotIndex].Value;
            }
        }

        [Button("Set previous SaveDataSlot")]
        public void SetPreviousSaveDataSlot()
        {
            if (currentSaveDataSlotIndex != 0 && saveDataSlotsList.Count > 1)
            {
                currentSaveDataSlotIndex--;
                currentSaveDataSlotName = saveDataSlotsList[currentSaveDataSlotIndex].Value;
            }
        }


        public void SetSaveDataSlot(int index)
        {
            if (index < saveDataSlotsList.Count - 1)
            {
                currentSaveDataSlotName = saveDataSlotsList[index].Value;
            }
        }

        public override string Process(string value)
        {
            return Application.persistentDataPath + "/" + currentSaveDataSlotName + "/";
        }
    }
}
