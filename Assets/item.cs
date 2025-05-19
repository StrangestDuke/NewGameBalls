using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Inventory/item")]
public class item : ScriptableObject
{
    new public string name = "testing rose";
    public Sprite icon = null;
}
