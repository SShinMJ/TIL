using UnityEngine;

public class Tower : MonoBehaviour
{
    [Tooltip("Ÿ�� ���� ���")]
    [SerializeField] int cost = 30;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null ) { return false; }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.WithDraw(cost);
            return true;
        }
        else
            return false;
    }
}
