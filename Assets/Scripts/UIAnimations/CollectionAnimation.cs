using UnityEngine;

public class CollectionAnimation : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform parent;
    [SerializeField] Transform gemText;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void Play()
    {
        var GemUIpiece = ObjectPooler.Instance.SpawnFromPool(PoolableObjectType.GemUI, Vector3.zero, Quaternion.identity);
        GemUIpiece.transform.SetParent(parent);
        GemUIpiece.transform.position = GetRandomPosition();
        GemUIpiece.GetComponent<GemUIPiece>().LocalMoveTo(gemText.localPosition);
    }

    private Vector2 GetRandomPosition()
    {
        var playerScreenPos = cam.WorldToScreenPoint(player.position);
        return new Vector2(playerScreenPos.x, playerScreenPos.y) + (Random.insideUnitCircle * Random.Range(0, 100));
    }
}
