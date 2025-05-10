using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Interactable actualInteractableObject;
    [SerializeField] private GameObject interactVisual;
    public void Interact() 
    {
        actualInteractableObject?.ActivateInteractable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable))
        {
            actualInteractableObject = interactable;
            interactVisual.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable == actualInteractableObject)
        {
            actualInteractableObject = null;
            interactVisual.SetActive(false);
        }
    }
}
