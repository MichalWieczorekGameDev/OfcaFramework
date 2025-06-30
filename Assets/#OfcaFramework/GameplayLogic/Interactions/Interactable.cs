using OfcaFramework.ScriptableWorkflow;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] Outline outline;
    [SerializeField] string message;
    [SerializeField] ScriptableStringVariable interactionMessageVariable;
    [SerializeField] UnityEvent onInteraction;
    [SerializeField] float cooldown = 0F;
    [SerializeField] float cooldownTimer = 0F;
    

    private void Start()
    {
        if(outline == null)
        {
            outline = GetComponent<Outline>();
        }
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    public void SetCooldown(float newCooldown)
    {
        cooldown = newCooldown;
    }

    public float GetCooldown()
    {
        return cooldown;
    }

    public void Interact()
    {
        if (cooldownTimer <= 0f)
        {
            cooldownTimer = cooldown;
            onInteraction.Invoke();
        }
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void DisableOutline()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    public void EnableOutline()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    public void SetInteractionMessage()
    {
        interactionMessageVariable.Value = message;
    }

    public void ResetInteractionMessage()
    {
        interactionMessageVariable.Value = "";
    }
}
