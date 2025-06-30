using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.Utilities
{
    public class DoOnEnable : MonoBehaviour
    {
        [SerializeField] List<UnityEvent> listOfEventsOnEnable = new List<UnityEvent>();
        private void OnEnable()
        {
            foreach (UnityEvent e in listOfEventsOnEnable)
            {
                e.Invoke();
            }
        }
    }
}
