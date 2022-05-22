using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 8f;
    [SerializeField] float horizontalSpeed = 8f;
    [SerializeField] float positionLimit = 3.5f;
    [SerializeField] bool useConstantForward = true;

    Rigidbody rb;
    PlayerAnimationController anim;

    private bool isMovementEnabled;
    private bool isInputPressed;

    private Vector2 direction;
    private float minVer = 0;
    private float maxVer => forwardSpeed * Time.deltaTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimationController>();
    }

    private void FixedUpdate()
    {
        if (CanMove())
            Move();
    }

    public void EnableMovement()
    {
        isMovementEnabled = true;
    }

    public void DisableMovement()
    {
        isMovementEnabled = false;
        anim.StopMoveAnim();
    }

    private bool CanMove()
    {
        return (isMovementEnabled && (isInputPressed || useConstantForward));
    }

    private void Move()
    {
        var hor = direction.x * horizontalSpeed;
        var ver = useConstantForward? maxVer : direction.y * forwardSpeed * Time.deltaTime;
        var newPos = transform.position + new Vector3(hor, 0f, ver);
        newPos.x = Mathf.Clamp(newPos.x, -positionLimit, positionLimit);
        rb.MovePosition(newPos);
        anim.PlayMoveAnim(CalculateMoveAnimationValue(ver));
    }

    private float CalculateMoveAnimationValue(float ver)
    {
        return Mathf.InverseLerp(minVer, maxVer, ver);
    }

    public void ApplyHitMotion()
    {
        DisableMovement();
        rb.AddForce(transform.forward * -4f, ForceMode.Impulse);
        anim.PlayHitAnim();
    }

    public void StopHitMotion()
    {
        anim.StopHitAnim();
        EnableMovement();
    }

    private void OnPressed()
    {
        isInputPressed = true;
    }

    private void OnReleased()
    {
        isInputPressed = false;
        direction = Vector2.zero;
        if (!CanMove()) anim.StopMoveAnim();
    }

    private void OnDrag(Vector2 dir)
    {
        direction = dir;
    }

    private void OnEnable()
    {
        InputBase.OnInputPressed += OnPressed;
        InputBase.OnInputReleased += OnReleased;
        InputBase.OnInputDrag += OnDrag;

        GameManager.OnStart += EnableMovement;
    }

    private void OnDisable()
    {
        InputBase.OnInputPressed -= OnPressed;
        InputBase.OnInputReleased -= OnReleased;
        InputBase.OnInputDrag -= OnDrag;

        GameManager.OnStart -= EnableMovement;
    }
}
