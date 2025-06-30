using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework.SaveAndLoad
{
    public class SaveableVariablesList : MonoBehaviour
    {
        [SerializeField] SaveAndLoadTraitBase trait;
        [SerializeField] List<iScriptableSaveData> scriptableVariablesToSaveAndLoad;

        public void LoadData()
        {
            foreach (iScriptableSaveData variableToLoadData in scriptableVariablesToSaveAndLoad)
            {
                //variableToLoadData.LoadData();
            }
        }

        public void SaveData()
        {
            foreach (iScriptableSaveData variableToSaveData in scriptableVariablesToSaveAndLoad)
            {
                variableToSaveData.SaveData();
            }
        }
    }
}