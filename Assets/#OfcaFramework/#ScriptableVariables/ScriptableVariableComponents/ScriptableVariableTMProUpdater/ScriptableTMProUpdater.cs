using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OfcaFramework
{
    namespace ScriptableWorkflow
    {
        public class ScriptableTMProUpdater<T> : ScriptableVariableListener<T>
        {
            [SerializeField] TMP_Text textToChange;
            [SerializeField] bool usePrefix = false;
            [TextArea]
            [SerializeField] string textPrefix = "";

            [SerializeField] bool useSuffix = false;
            [TextArea]
            [SerializeField] string textSuffix = "";

            [SerializeField] bool addSpaceAfterPrefix = false;
            [SerializeField] bool addSpaceBeforeSuffix = false;

            private void Start()
            {
                if (textToChange == null)
                {
                    textToChange = GetComponent<TMP_Text>();
                    if (variable != null)
                    {
                        //UpdateText(variable.Value.ToString());
                    }
                }

            }
            protected override void OnEnable()
            {
                base.OnEnable();
                if (textToChange != null && variable != null)
                {
                    UpdateText(variable.Value.ToString());
                }
            }

            [ContextMenu("UpdateText()")]
            private void UpdateText()
            {
                string spaceAfterPrefix = "";
                string spaceBeforePrefix = "";
                string prefixValue = "";
                string suffixValue = "";
                if (usePrefix)
                {
                    prefixValue = textPrefix;

                    if (addSpaceAfterPrefix)
                    {
                        spaceAfterPrefix = " ";
                    }
                }
                
                if (useSuffix)
                {
                    suffixValue = textSuffix;

                    if (addSpaceBeforeSuffix)
                    {
                        spaceBeforePrefix = " ";
                    }
                }
                

                if (textToChange != null && variable != null)
                {
                    textToChange.text = prefixValue + spaceAfterPrefix + variable.Value + spaceBeforePrefix + suffixValue;
                }
            }

            private void UpdateText(string newText)
            {
                string spaceAfterPrefix = "";
                string spaceBeforePrefix = "";
                string prefixValue = "";
                string suffixValue = "";
                if (usePrefix)
                {
                    prefixValue = textPrefix;

                    if (addSpaceAfterPrefix)
                    {
                        spaceAfterPrefix = " ";
                    }
                }

                if (useSuffix)
                {
                    suffixValue = textSuffix;

                    if (addSpaceBeforeSuffix)
                    {
                        spaceBeforePrefix = " ";
                    }
                }


                if (textToChange != null && variable != null)
                {
                    textToChange.text = prefixValue + spaceAfterPrefix + newText + spaceBeforePrefix + suffixValue;
                }
            }
            protected override void OnValueChanged(T newValue)
            {
                UpdateText(newValue.ToString());
            }

            protected virtual void OnValidate()
            {
                UpdateText();
            }
        }
    }
}
