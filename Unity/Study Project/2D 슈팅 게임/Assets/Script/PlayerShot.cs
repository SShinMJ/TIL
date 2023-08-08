using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ����� �Է�(Space)�� �޾� �Ѿ��� �����Ѵ�.

// ��ǥ2: �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
// �Ӽ�: ��ų����
// �ܰ�1. �������� �Ծ��ٸ�
// �ܰ�2. ��ų������ 1 �ö󰣴�.
// �ܰ�3. �������� �ı��Ѵ�.
// �ܰ�4. ������ ����Ʈ�� �����Ѵ�.
public class PlayerShot : MonoBehaviour
{
    public GameObject Bullet;

    public int skillLevel = 0;
    public int degree = 15;


    void Update()
    {
        // 'Space' �Է��� �޴´�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��ų ���뿡 ���� �߻�� �Ѿ��� ������ ������ ��������.
            ExcuteSkill(skillLevel);
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch (_skillLevel)
        {
            case 0:
                ExcuteSkill0();
                break;
            case 1:
                ExcuteSkill1();
                break;
            case 2:
                ExcuteSkill2();
                break;
            case 3:
                ExcuteSkill3(degree);
                break;
        }

        // �Ѱ��� �Ѿ��� �߻�ȴ�.
        void ExcuteSkill0()
        {
            // �Ѿ��� ���� (Instantiate)
            GameObject bulletObject = Instantiate(Bullet);

            // �Ѿ��� �÷��̾� ��ġ�� ����
            bulletObject.transform.position = transform.position;
        }

        // �ΰ��� �Ѿ��� �߻�ȴ�.
        void ExcuteSkill1()
        {
            // �Ѿ��� ���� (Instantiate)
            GameObject bulletGO = Instantiate(Bullet);
            GameObject bulletGO1 = Instantiate(Bullet);

            // �Ѿ��� �÷��̾� ��ġ�� ����, �� �������� �߻�ǵ��� ��ġ ����.
            bulletGO.transform.position = transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO1.transform.position = transform.position + new Vector3(0.3f, 0, 0);
        }

        // ������ �Ѿ��� �߻�ȴ�.
        // 1, 2, 3 �Ѿ� �� 1, 3 �Ѿ��� ���� Z������ -30��, 30�� ȸ�� �� �߻�ȴ�.
        void ExcuteSkill2()
        {
            // �Ѿ��� ���� (Instantiate)
            GameObject bulletGO = Instantiate(Bullet);

            // �Ѿ��� �÷��̾� ��ġ�� ����.
            bulletGO.transform.position = transform.position;

            // ������ �Ѿ��� ���� (Instantiate)
            GameObject bulletGO2 = Instantiate(Bullet);
            GameObject bulletGO3 = Instantiate(Bullet);

            // �Ѿ��� �÷��̾� ��ġ���� �� ���������� ����, ���ʴ밢��(-30��)�� ������ ����.
            bulletGO2.transform.position = transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO2.transform.rotation = Quaternion.Euler(0, 0, 30);
            bulletGO2.GetComponent<PlayerBullet>().dir = bulletGO2.transform.up;

            // �Ѿ��� �÷��̾� ��ġ���� ���� ���������� ����, �����ʴ밢��(30��)�� ������ ����.
            bulletGO3.transform.position = transform.position + new Vector3(0.3f, 0, 0);
            bulletGO3.transform.rotation = Quaternion.Euler(0, 0, -30);
            bulletGO3.GetComponent<PlayerBullet>().dir = bulletGO3.transform.up;
        }


        // _degree�� 15�̹Ƿ� �� 24���� �Ѿ��� 360���� �߻��Ѵ�.
        void ExcuteSkill3(int _degree)
        {
            int numOfBullet = 360 / degree;

            // 24���� �Ѿ��� 15���� ������ ȸ���Ͽ� �����ȴ�.
            for (int i = 0; i < numOfBullet; i++)
            {
                // �Ѿ��� ���� (Instantiate)
                GameObject bulletGO = Instantiate(Bullet);

                // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
                bulletGO.transform.position = transform.position;
                bulletGO.transform.rotation = Quaternion.Euler(0, 0, i * degree);
                bulletGO.GetComponent<PlayerBullet>().dir = bulletGO.transform.up;
            }
        }
    }

    // ��ǥ2: �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
    private void OnTriggerEnter(Collider other)
    {
        // �ܰ�1. �������� �Ծ��ٸ�
        if (other.gameObject.tag == "Item")
        {
            // �ܰ�2. ��ų������ 1 �ö󰣴�.
            if(skillLevel < 3)
                skillLevel++;

            // �ܰ�3. �������� �ı��Ѵ�.
            Destroy(other.gameObject);
        }
    }
}