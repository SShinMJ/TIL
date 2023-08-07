using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ����� �Է�(Space)�� �޾� �Ѿ��� �����Ѵ�.
public class PlayerShot : MonoBehaviour
{
    public GameObject Bullet;

    void Update()
    {
        // 'Space' �Է��� �޴´�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �Ѿ��� ���� (Instantiate)
            GameObject bulletObject = Instantiate(Bullet);

            // �Ѿ��� �÷��̾� ��ġ�� ����
            bulletObject.transform.position = transform.position;
        }
    }
}
