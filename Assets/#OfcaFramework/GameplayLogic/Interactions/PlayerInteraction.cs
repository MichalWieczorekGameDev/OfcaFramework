using OfcaFramework.ScriptableWorkflow;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteraction : ScriptableEventObserver
{
    [SerializeField] float playerReach = 3f;
    [SerializeField] Interactable interactable;

    public void OnInteractionInputClicked()
    {
        if(interactable != null)
        {
            interactable.Interact();
        }
    }

    private void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach) && hit.collider.GetComponent<Interactable>() != null)
        {
            Interactable newInteractable = hit.collider.GetComponent<Interactable>();
            if (interactable && newInteractable != interactable)
            {
                interactable.DisableOutline();
            }
            if (newInteractable.enabled)
            {
                SetNewCurrentInteractable(newInteractable);
            }
            else
            {
                DisableCurrentInreractable();
            }
        }
        else
        {
            DisableCurrentInreractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        interactable = newInteractable;
        interactable.SetInteractionMessage();
        interactable.EnableOutline();
        
    }
    
    void DisableCurrentInreractable()
    {
        if (interactable)
        {
            interactable.ResetInteractionMessage();
            interactable.DisableOutline();
            interactable = null;
        }
    }
}
