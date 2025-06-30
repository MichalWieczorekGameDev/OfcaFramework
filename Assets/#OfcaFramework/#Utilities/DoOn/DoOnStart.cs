using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.Utilities
{
    public class DoOnStart : MonoBehaviour
    {
        [SerializeField] List<UnityEvent> listOfEventsOnStart = new List<UnityEvent>();
        private void Start()
        {
            foreach (UnityEvent e in listOfEventsOnStart)
            {
                e.Invoke();
            }
        }
    }
}