using System;
using UnityEngine;

public class Interactable_Box : MonoBehaviour, IInterractable
{
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
