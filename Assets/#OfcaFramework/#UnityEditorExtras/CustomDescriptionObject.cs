using UnityEngine;

namespace OfcaFramework.CustomDescription
{
    [System.Serializable]
    public class CustomDescriptionObject
    {
        [TextArea(3, 10)]
        public string description;

        public CustomDescriptionObject()
        {
            description = "Edit me, please.";
        }
    }
}