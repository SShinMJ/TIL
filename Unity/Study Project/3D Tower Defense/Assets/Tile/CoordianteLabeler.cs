using TMPro;
using UnityEngine;

// ���� �������� Ÿ�� ���� ��ġ�� ǥ��
// ExecuteAlways : ������ ��� �÷��̸�� ������� ������� �����Ѵ�.
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
        // �÷��� ��尡 �ƴ� ��,
        if (!Application.isPlaying)
        {
            // ���� ��ǥ�� �����ش�.
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
