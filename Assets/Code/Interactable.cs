using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent InteractableEvent;
    
    public void ActivateInteractable()
    {
        InteractableEvent.Invoke();
    }
}
