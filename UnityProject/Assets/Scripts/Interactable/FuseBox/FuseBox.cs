using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FuseBox : MonoBehaviour
{
    public List<Fuse> Fuses;
    public int BrokenFuses = 0;
    public int ReplacedFuses = 0;

    private void Awake()
    {
        foreach (Fuse f in Fuses)
        {
            Random.seed = (int)DateTime.Now.Ticks;
        }
    }

    public void BreakFuses()
    {
        
    }
    
    public void WinCondition()
    {
        if (ReplacedFuses == Fuses.Count)
        {
            transform.parent.gameObject.GetComponent<InteractBehaviour>().ReturnControl();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        BreakFuses();
    }
}
