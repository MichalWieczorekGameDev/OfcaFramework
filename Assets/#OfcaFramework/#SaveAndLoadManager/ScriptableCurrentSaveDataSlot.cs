using UnityEngine;
using OfcaFramework.ScriptableWorkflow;
using NUnit.Framework;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using OfcaFramework.Utilities;

namespace OfcaFramework.SaveAndLoad
{
    [CreateAssetMenu(fileName = "ScriptableSaveDataSlot", menuName = "OfcaFramework/SaveAndLoad/CurrentSaveDataSlot")]
    public class ScriptableCurrentSaveDataSlot : ScriptableVariable<string>
    {
        
    }
}