using UnityEngine;
using UnityEngine.Events;

namespace OfcaFramework.ScriptableWorkflow
{
    public class ScriptableEventObserver : MonoBehaviour
    {
        [SerializeField] private ScriptableEvent observedEvent; // Obserwowany ScriptableEvent
        [SerializeField] private UnityEvent onEventTriggered;   // UnityEvent, kt�ry zostanie wywo�any

        private void OnEnable()
        {
            if (observedEvent != null)
            {
                observedEvent.OnEventInvoke += HandleEventInvoked;
            }
        }

        private void OnDisable()
        {
            if (observedEvent != null)
            {
                observedEvent.OnEventInvoke -= HandleEventInvoked;
            }
        }

        private void HandleEventInvoked()
        {
            onEventTriggered?.Invoke(); // Wywo�anie UnityEvent
        }
    }
}
