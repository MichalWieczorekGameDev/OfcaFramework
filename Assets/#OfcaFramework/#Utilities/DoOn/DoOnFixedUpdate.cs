using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.Utilities
{
    public class DoOnFixedUpdate : MonoBehaviour
    {
        [SerializeField] List<UnityEvent> listOfEventsOnFixedUpdate = new List<UnityEvent>();
        private void FixedUpdate()
        {
            foreach (UnityEvent e in listOfEventsOnFixedUpdate)
            {
                e.Invoke();
            }
        }
    }
}