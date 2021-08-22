using System.Collections;
using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperGameObject;
using UnityEngine;

public class SampleDollar : HyperInteractable
{
    public override void Interact()
    {
        base.Interact();
        gameObject.SetActive(false);
    }
}