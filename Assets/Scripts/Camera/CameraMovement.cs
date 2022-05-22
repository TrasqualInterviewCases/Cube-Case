using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float xLimit;

    Vector3 velocity;
    Vector3 offset;

    private void Start()
    {
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        var targetPos = target.position - offset;
        targetPos.x = Mathf.Clamp(targetPos.x, -xLimit, xLimit);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
    }
}
