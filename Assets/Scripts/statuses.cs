using System.Collections.Generic;
using UnityEngine;

public class statuses : MonoBehaviour
{
    public static statuses instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("You fucked up with inventory singletone");
            return;
        }
        instance = this;
    }
    public List<statusEffect> effects = new List<statusEffect>();

    public void AddItem(statusEffect status) { effects.Add(status); }
    public void RemoveItem(statusEffect status) { effects.Remove(status); }
}
