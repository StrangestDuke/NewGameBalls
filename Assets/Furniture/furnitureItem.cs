using UnityEngine;

[CreateAssetMenu(fileName = "furnitureItem", menuName = "Scriptable Objects/furnitureItem")]
public class furnitureItem : ScriptableObject
{
    new public string name = "testing rose";
    public string description = "";
    public string material = "";
    public FurnitureType type;
    public NPCTags functionality;

}

public enum FurnitureType { Storage, chairs, beds, tables, functional }

public enum NPCTags { forTheFuture }