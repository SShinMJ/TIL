using TMPro;
using UnityEngine;

// 월드 포지션의 타일 현재 위치를 표시
// ExecuteAlways : 에디터 모드 플레이모드 상관없이 실행됨을 보장한다.
[ExecuteAlways]
public class CoordianteLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Start()
    {
        label = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        // 플레이 모드가 아닐 때,
        if (!Application.isPlaying)
        {
            // 현재 좌표를 보여준다.
            DisplayCoordinates();

            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z);
        label.text = coordinates.ToString();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
