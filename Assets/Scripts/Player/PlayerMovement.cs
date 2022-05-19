using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 8f;
    [SerializeField] float horizontalSpeed = 8f;
    [SerializeField] float positionLimit = 3.5f;
    [SerializeField] bool useConstantForward = true;

    private bool isMovementEnabled = true; //TODO remove true
    private bool isInputPressed;

    private Vector2 direction;

    private void Update()
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
    }

    private bool CanMove()
    {
        return (isMovementEnabled && (isInputPressed || useConstantForward));
    }

    private void Move()
    {
        var hor = direction.x * horizontalSpeed;
        var ver = useConstantForward? forwardSpeed * Time.deltaTime : direction.y * forwardSpeed * Time.deltaTime;
        var newPos = transform.position + new Vector3(hor, 0f, ver);
        newPos.x = Mathf.Clamp(newPos.x, -positionLimit, positionLimit);
        transform.position = newPos;
    }

    private void OnPressed()
    {
        isInputPressed = true;
    }

    private void OnReleased()
    {
        isInputPressed = false;
        direction = Vector2.zero;
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
    }

    private void OnDisable()
    {
        InputBase.OnInputPressed -= OnPressed;
        InputBase.OnInputReleased -= OnReleased;
        InputBase.OnInputDrag -= OnDrag;
    }
}
