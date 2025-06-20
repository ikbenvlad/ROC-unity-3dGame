using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] public string promptMessage;
    // add or remove an InteractionEvent component to this GameObject.
    public bool useEvents;

    // function will be called by the Player scripts
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact()
    {
        // no code here, this is meant to be overridden by subclasses
    }
}
