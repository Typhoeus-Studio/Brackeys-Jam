using System.Collections;
using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperGameObject;
using UnityEngine;

public class SampleDumpInteractable : HyperInteractable
{
    public override void Initialize()
    {
    }

    public override void Interact()
    {
        if (isInteracted) return;
        base.Interact();
        
        gameObject.SetActive(false);
    }
}