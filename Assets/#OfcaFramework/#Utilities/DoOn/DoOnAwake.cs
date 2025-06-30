using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.Utilities
{
    public class DoOnAwake : MonoBehaviour
    {
        [SerializeField] List<UnityEvent> listOfEventsOnAwake = new List<UnityEvent>();
        private void Awake()
        {
            foreach (UnityEvent e in listOfEventsOnAwake)
            {
                e.Invoke();
            }
        }
    }
}
