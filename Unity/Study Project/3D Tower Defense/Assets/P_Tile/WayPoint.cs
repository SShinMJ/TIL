using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Tooltip("생성할 타워 프리팹")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("해당 타일에 설치 가능한 지 여부")]
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            isPlaceable = !towerPrefab.CreateTower(towerPrefab, transform.position);
        }
    }
}
