using System;
using System.Collections;
using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperGameObject;
using UnityEngine;

public class JumpTrigger : HyperInteractable
{
    [SerializeField] private JumpDrop jumpDrop;

    public override void Interact()
    {
        base.Interact();
    }
}