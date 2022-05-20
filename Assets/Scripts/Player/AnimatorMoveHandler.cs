using UnityEngine;

public class AnimatorMoveHandler : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Animator anim;

    bool doHitMotion;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DoHitMotion()
    {
        doHitMotion = true;
    }

    public void StopHitMotion()
    {
        doHitMotion = false;
    }

    private void OnAnimatorMove()
    {
        if(doHitMotion)
        {
            rb.MovePosition(rb.position + anim.deltaPosition);
        }
    }
}
