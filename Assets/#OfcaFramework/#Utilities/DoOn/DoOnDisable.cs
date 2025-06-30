using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.Utilities
{
    public class DoOnDisable : MonoBehaviour
    {
        [SerializeField] List<UnityEvent> listOfEventsOnDisable = new List<UnityEvent>();
        private void OnDisable()
        {
            foreach (UnityEvent e in listOfEventsOnDisable)
            {
                e.Invoke();
            }
        }
    }
}