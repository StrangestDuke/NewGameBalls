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

        // Ёффект зависит от effectname статуса
        //  акой статус эффект закинишь, тот и будет работать, костыль но работает
        if (data.effectname == "Fire")
        {
            enemyhp.health -= data.amount;
        }
        if (data.effectname == "Horny")
        {
            enemystats.intelligence -= (int)data.amount;
        }
        Debug.Log(" нопка нажата");
    }
}
