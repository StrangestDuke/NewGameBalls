using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "statusEffect", menuName = "Scriptable Objects/statusEffect")]
public class statusEffect : ScriptableObject
{
    // Шаблон для статусов Scriptable Object
    public Sprite icon = null;
    public string effectname = "testing rose";   
    public float duration;
    public string effect;
    public float amount;
    public int buildUp;
}
