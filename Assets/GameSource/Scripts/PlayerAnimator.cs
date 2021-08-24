using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
     animator.SetFloat("MoveX",Input.GetAxis("Horizontal"));
     animator.SetFloat("MoveZ",Input.GetAxis("Vertical"));
    }
}
