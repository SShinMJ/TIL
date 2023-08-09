using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ1 : ��ų�������� Ư���ð����� �����.
//�ʿ�  : ��ų������, Ư�� ���� �ð�(�ּҽð�, �ִ�ð�), ����ð�

//�ܰ�1.�ð��� �帥��
//�ܰ�2. ����ð��� Ư�� ���� �ð�(�ּҽð�, �ִ�ð�)�� ������
//�ܰ�3. ��ų�������� �����Ѵ�.
//�ܰ�4. ��ų������ ��ġ�� ��ų�Ŵ����� ��ġ�� �����Ѵ�.
//�ܰ�5. �ð��� �ٽ� �������ش�.
public class ItemManager : MonoBehaviour
{
    public GameObject item;

    float creatTime;
    public float minCreateTime;
    public float maxCreateTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ���� �ð��� �����Ѵ�.
        creatTime = Random.Range(minCreateTime, maxCreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� �帥��. ���� �ð� Ž��
        currentTime += Time.deltaTime;

        if (currentTime > creatTime)
        {
            // ������ ������Ʈ ����
            GameObject skillItem = Instantiate(item);
            // ���� ��ġ ����
            skillItem.transform.position = transform.position;

            currentTime = 0;

            // �ð� �缳��
            creatTime = Random.Range(minCreateTime, maxCreateTime);
        }
    }
}
