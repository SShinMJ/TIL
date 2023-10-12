using TMPro;
using UnityEngine;

// ���� �������� Ÿ�� ���� ��ġ�� ǥ��
// ExecuteAlways : ������ ��� �÷��̸�� ������� ������� �����Ѵ�.
[ExecuteAlways]
public class CoordianteLabeler : MonoBehaviour
{
    // Ÿ���� ���� �� �ִ� �� ǥ���ϴ� ��
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
        // �÷��� ��尡 �ƴ� ��,
        if (!Application.isPlaying)
        {
            // ���� ��ǥ�� �����ش�.
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
