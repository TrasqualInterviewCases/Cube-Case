using System.Collections;
using UnityEngine;

public class LoopMovingObject : MonoBehaviour
{
    [SerializeField] Vector3 endPos;
    [SerializeField] float moveTime;

    Vector3 startPos;

    bool shouldStop;

    private void Start()
    {
        endPos += transform.position;
        StartCoroutine(MoveCo());
    }

    IEnumerator MoveCo()
    {
        var t = 0f;
        startPos = transform.position;
        while (t < 1)
        {
            if (shouldStop) yield break;
            t += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
        transform.position = endPos;
        endPos = startPos;
        StartCoroutine(MoveCo());
    }

    public void StopMovement()
    {
        shouldStop = true;
    }
}
