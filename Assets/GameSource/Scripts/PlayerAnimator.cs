using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] float animationSmoothTime = 0.1f;

    Vector2 currentAnimationBlendVector;
    private Vector2 animationVelocity;

    public void UpdateMe(float deg)
    {
        float x = 0;
        float y = 0;
        if (deg > -45 && deg < 45)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }

        else if (deg < -45 && deg > -135)
        {
            x = -Input.GetAxis("Vertical");
            y = -Input.GetAxis("Horizontal");
        }

        else if (deg > 45 && deg < 135)
        {
            x = Input.GetAxis("Vertical");
            y = Input.GetAxis("Horizontal");
        }

        else if (deg > 135 || deg > -180)
        {
            x = -Input.GetAxis("Horizontal");
            y = -Input.GetAxis("Vertical");
        }


        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, new Vector2(x, y),
            ref animationVelocity, animationSmoothTime);
        animator.SetFloat("MoveX", currentAnimationBlendVector.x);
        animator.SetFloat("MoveZ", currentAnimationBlendVector.y);
    }
}