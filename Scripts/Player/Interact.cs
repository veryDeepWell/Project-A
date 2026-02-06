using System;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool canInteract = false;
    private GameObject _interactionObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        
        if (other.GetComponent<Interactable_Box>() != null)
        {
            Debug.Log("Interaction avalible");
            canInteract = true;
            _interactionObject =  other.gameObject;
        }
    }

    public void MakeInterraction()
    {
        canInteract = false;
        _interactionObject.GetComponent<Interactable_Box>().Interact();
    }
}
