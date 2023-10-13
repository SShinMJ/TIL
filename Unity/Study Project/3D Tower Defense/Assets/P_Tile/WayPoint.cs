using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Tooltip("������ Ÿ�� ������")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("�ش� Ÿ�Ͽ� ��ġ ������ �� ����")]
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
