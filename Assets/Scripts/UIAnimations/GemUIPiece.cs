using System.Collections;
using UnityEngine;

public class GemUIPiece : MonoBehaviour
{
    public void LocalMoveTo(Vector2 pos)
    {
        StartCoroutine(LocalMoveToCo(pos));
    }

    IEnumerator LocalMoveToCo(Vector2 pos)
    {
        while(Vector2.Distance(transform.localPosition, pos) > 50f)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos, Time.deltaTime * 2f);
            yield return null;
        }
        ObjectPooler.Instance.RequeuePiece(gameObject);
    }
}
