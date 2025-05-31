using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class status : MonoBehaviour
{
    [SerializeField] private statusEffect data;
    [SerializeField] enemyBar enemyhp;
    [SerializeField] stats enemystats;

    
    public void OnClick()
    {
        var effectable = GetComponent<IEffectable>();

        // ������ ������� �� effectname �������
        // ����� ������ ������ ��������, ��� � ����� ��������, ������� �� ��������
        if (data.effectname == "Fire")
        {
            enemyhp.health -= data.amount;
        }
        if (data.effectname == "Horny")
        {
            enemystats.intelligence -= (int)data.amount;
        }
        Debug.Log("������ ������");
    }
}
