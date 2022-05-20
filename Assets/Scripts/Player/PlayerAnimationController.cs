using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] AnimatorMoveHandler animMoveHandler;
    Animator anim;

    public Vector3 DeltaPos => anim.deltaPosition;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void PlayMoveAnim(float moveAmount)
    {
        anim.SetFloat("move", moveAmount, 0.05f, Time.deltaTime);
    }

    public void StopMoveAnim()
    {
        anim.SetFloat("move", 0);
    }

    public void PlayWinAnim()
    {
        anim.SetBool("win", true);
    }

    public void PlayHitAnim()
    {
        anim.SetTrigger("fallback");
        animMoveHandler.DoHitMotion();
    }

    public void StopHitAnim()
    {
        animMoveHandler.StopHitMotion();
    }
}
