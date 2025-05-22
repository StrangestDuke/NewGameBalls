using UnityEngine;

[CreateAssetMenu(fileName = "statusEffect", menuName = "Scriptable Objects/statusEffect")]
public class statusEffect : ScriptableObject
{
    new public string name = "testing rose";
    public Sprite icon = null;
    public float duration;
    public string effect;
    public int buildUp;
}
