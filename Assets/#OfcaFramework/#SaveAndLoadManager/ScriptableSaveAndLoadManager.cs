using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using OfcaFramework.ScriptableWorkflow;
using Unity.VisualScripting;
using System;
using OfcaFramework.SaveAndLoad;
using OfcaFramework.Utilities;
using OfcaFramework.TraitsWorkflow;
using System.IO;

namespace OfcaFramework.SaveAndLoad
{
    [Serializable]
    [CreateAssetMenu(fileName = "ScriptableSaveAndLoadManager", menuName = "OfcaFramework/SaveAndLoad/SaveAndLoadManager")]
    public class ScriptableSaveAndLoadManager : ScriptableObject
    {
        [SerializeField] bool loadAllDataOnStart = true;

        [SerializeField] ScriptableCurrentSaveDataSlot scriptableCurrentSaveDataSlot;

        [SerializeField] List<SaveAndLoadPacket> saveAndLoadPackets = new List<SaveAndLoadPacket>();


        

        
        [SerializeField] List<List<string>>  debugLoadedData = new List<List<string>>();
        public void LoadAllDataOnStart()
        {
            if (loadAllDataOnStart)
            {
                LoadAllData();
            }
        }

        private void SaveAllData()
        {
            foreach (var packet in saveAndLoadPackets)
            {
                packet.SaveData(scriptableCurrentSaveDataSlot.Value);
            }
        }

        private void LoadAllData()
        {
            foreach (var packet in saveAndLoadPackets)
            {
                packet.LoadData(scriptableCurrentSaveDataSlot.Value);
            }
        }

        public void SavePacketZero()
        {
            saveAndLoadPackets[0].SaveData(scriptableCurrentSaveDataSlot.Value);
        }

        //DEBUG SECTION
        [Button("DebugSaveData()")]
        public void DebugSaveData()
        {

            string[,] data = new string[4, 4] { { "valueName", "valueTrait", "value", "valueType" },
                { "valueName1", "valueTrait1", "value1", "valueType1" },
                { "valueName2", "valueTrait2", "value2", "valueType2" },
                { "valueName3", "valueTrait3", "value3", "valueType3" } };

            string dataPath = Application.persistentDataPath + "/savefile.of.csv";


            OFCSVWriter.SaveToOFCSV(data, dataPath);
        }

        [Button("DebugLoadData()")]
        public void DebugLoadData()
        {
            string dataPath = Application.persistentDataPath + "/savefile.of.csv";
            debugLoadedData = OFCSVReader.LoadFromOFCSV(dataPath);

            int line = 0;
            foreach (List<string> stringList in debugLoadedData)
            {
                Debug.Log($"debugLoadedData, line[{line}]: {stringList[0]}, {stringList[1]}, {stringList[2]}, {stringList[3]}.");
                line++;
            }
        }

        [Button("ResetDebugLoadedData()")]
        public void ResetDebugLoadedData()
        {
            debugLoadedData = new List<List<string>>();
        }

        public void DebugFindSaveableScriptableData()
        {
            Debug.Log($"FindSaveableScriptableData();");
        }
    }
}

[Serializable]
public class SaveAndLoadPacket
{
    [SerializeField] SaveAndLoadTraitBase saveAndLoadTrait;
    [SerializeField] List<ScriptableVariableBase> saveAndLoadableVariables;
    [Button("Find scriptable variables")]
    public void FindScriptableVariables()
    {
        var tempVariableList = ScriptableObjectFinder.FindAllAssetsOfType<ScriptableVariableBase>();

        saveAndLoadableVariables = new List<ScriptableVariableBase>();

        foreach (ScriptableVariableBase variable in tempVariableList)
        {
            if (variable is ISaveAndLoad saveAndLoad)
            {
                if (saveAndLoad.GetSaveAndLoadTrait() == saveAndLoadTrait)
                {
                    saveAndLoadableVariables.Add(variable);
                }
            }

        }
    }

    [Button("Save data")]
    public void SaveData(string savePath)
    {
        List<List<string>> saveList = new List<List<string>>();
        List<string> firstLine = new List<string>();
        firstLine.Add("valueName");
        firstLine.Add("valueTrait");
        firstLine.Add("value");
        firstLine.Add("valueType");

        saveList.Add(firstLine);

        foreach (var variable in saveAndLoadableVariables)
        {
            saveList.Add(((ISaveAndLoad)variable).GetVariableData());
        }
        
        EnsureFolderExists(savePath);

        savePath = $"{savePath}{saveAndLoadTrait.TraitName}.of.csv";

        Debug.Log($"savePath: {savePath}");

        OFCSVWriter.SaveToOFCSV(ConvertListTo2DArray(saveList), savePath);
    }

    public void LoadData(string savePath)
    {
        List<List<string>> saveList = new List<List<string>>();

        EnsureFolderExists(savePath);
        savePath = $"{savePath}{saveAndLoadTrait.TraitName}.of.csv";
        Debug.Log($"savePath: {savePath}");

        saveList = OFCSVReader.LoadFromOFCSV(savePath);
        saveList.RemoveAt(0);

        foreach (var line in saveList)
        {
            foreach (var variable in saveAndLoadableVariables)
            {
                if (line[0] == ((ISaveAndLoad)variable).GetVariableData()[0])
                {
                    ((ISaveAndLoad)variable).SetVariableData(line);
                }
            }
        }
    }

    public static void EnsureFolderExists(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        
        var dirInfo = new DirectoryInfo(folderPath);
        if ((dirInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
        {
            dirInfo.Attributes &= ~FileAttributes.ReadOnly;
        }
    }

    public static string[,] ConvertListTo2DArray(List<List<string>> listOfLists)
    {
        if (listOfLists == null || listOfLists.Count == 0)
            return new string[0, 0];

        int rows = listOfLists.Count;
        int cols = 0;

        cols = listOfLists[0].Count;

        string[,] array2D = new string[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var innerList = listOfLists[i];
            for (int j = 0; j < cols; j++)
            {
                array2D[i, j] = j < innerList.Count ? innerList[j] : null;
            }
        }

        return array2D;
    }


}