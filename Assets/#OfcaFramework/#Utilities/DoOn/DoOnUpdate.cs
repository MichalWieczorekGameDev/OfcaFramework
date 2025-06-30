using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.Utilities
{
    public class DoOnUpdate
    {
        [SerializeField] List<UnityEvent> listOfEventsOnUpdate = new List<UnityEvent>();
        private void Update()
        {
            foreach (UnityEvent e in listOfEventsOnUpdate)
            {
                e.Invoke();
            }
        }
    }
}