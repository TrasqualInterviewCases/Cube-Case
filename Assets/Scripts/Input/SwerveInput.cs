using UnityEngine;

public class SwerveInput : InputBase
{

    private float prevHor;
    private float swipeDelta;
    [HideInInspector]
    public float horizontalValue;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevHor = Input.mousePosition.x;

            OnInputPressed?.Invoke();
        }

        else if (Input.GetMouseButton(0))
        {
            swipeDelta = Input.mousePosition.x - prevHor;

            prevHor = Input.mousePosition.x;

            OnInputDrag?.Invoke(new Vector2(UpdateHorizontalValue(), 1));
        }

        else if (Input.GetMouseButtonUp(0))
        {
            swipeDelta = 0f;

            UpdateHorizontalValue();

            OnInputReleased?.Invoke();
        }
    }

    private float UpdateHorizontalValue()
    {
        var current = horizontalValue;

        var target = (Mathf.Lerp(0, 1, Mathf.Abs(swipeDelta) / Screen.width)) * Mathf.Sign(swipeDelta);

        horizontalValue = Vector2.MoveTowards(new Vector2(current, 0), new Vector2(target, 0), Time.deltaTime).x;

        return horizontalValue;
    }
}
