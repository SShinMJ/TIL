using TMPro;
using UnityEngine;

// ���� �������� Ÿ�� ���� ��ġ�� ǥ��
// ExecuteAlways : ������ ��� �÷��̸�� ������� ������� �����Ѵ�.
[ExecuteAlways]
public class CoordianteLabeler : MonoBehaviour
{
    // Ÿ���� ���� �� �ִ� �� ǥ���ϴ� ��
    [Tooltip("Ÿ���� ���� �� ���� �� ǥ�� ��")]
    [SerializeField] Color defaultColor = Color.white;
    [Tooltip("Ÿ���� ���� �� ���� �� ǥ�� ��")]
    [SerializeField] Color blockColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;

    void Start()
    {
        label = GetComponent<TextMeshPro>();
        wayPoint = GetComponentInParent<WayPoint>();

        // ���� ��ǥ�� �����ش�.
        DisplayCoordinates();
        // ���� ��ǥ�� �̸����� �ٲ۴�.
        UpdateObjectName();
        // ���� ��ǥ�� Ÿ���� ���� �� �ִ� �� ���ο� ���� ���� �ٲ۴�.
        SetLabelColor();
        // ó���� �������� �ʴ´�.
        label.enabled = false;
    }

    void Update()
    {
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
            SetLabelColor();
            label.enabled = !label.IsActive();
        }
    }
}
