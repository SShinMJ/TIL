using TMPro;
using UnityEngine;

// 월드 포지션의 타일 현재 위치를 표시
// ExecuteAlways : 에디터 모드 플레이모드 상관없이 실행됨을 보장한다.
[ExecuteAlways]
public class CoordianteLabeler : MonoBehaviour
{
    // 타워를 놓을 수 있는 지 표시하는 색
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;

    void Start()
    {
        label = GetComponent<TextMeshPro>();
        wayPoint = GetComponentInParent<WayPoint>();
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

        SetLabelColor();

        ToggleLabels();
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

    void SetLabelColor()
    {
        if(wayPoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockColor;
        }
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
