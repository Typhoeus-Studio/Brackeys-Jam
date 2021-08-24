using UnityEngine;

public class LookMouse : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerAnimator animator;

    void Update()
    {
        LookToMouse();
    }

    void LookToMouse()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
        Vector3 deltaPos = Input.mousePosition - screenPos;
        var final = Mathf.Atan2(deltaPos.x, deltaPos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, final, 0));
        animator.UpdateMe(final);
    }

    void LookToAxis()
    {
        var h = Input.GetAxis("Pitch");
        var v = Input.GetAxis("Row");
        if (Mathf.Abs(h) > 0.05 || Mathf.Abs(v) > 0.05)
        {
            var angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            animator.UpdateMe(angle);
        }
    }
}