
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Inventory/item")]
public class item : ScriptableObject
{
    [Header("Object setup")]
    
    new public string name = "testing rose";
    public Sprite icon = null;
    public string description = "";
    public string material = "";
    public string examineText = "";
    //for the future
    public bool enchantable = false;
    public bool brewable = false;
    public bool stackable = false;
    public int numberOfItems = 1;

    [Space(10), Header("Food setup")]
    [Space(10)]
    public bool edable = false;
    public string taste = "";
    public string smell = "";
    //На время внедрения эффектов некоторые рофлы закоменчены
    //public string effect = "";
    int hungerReplenish = 0;

    [Space(10), Header("Weapon setup")]
    [Space(10)]
    public bool usableAsAWeapon = false;
    public bool concevable = false;
    public bool breakable = false;
    public bool throwable = false;
    public bool ranged = false;
    public bool returnable = false;
    public bool canParry = false;

    public int hpOfItem = 1;
    public int danger = 0;
    public int basicDamage = 1;
    public float size = 0.2f;

    //public string mainTypeOfDamage = "";  
    //public string element = "";

    [Space(10), Header("Cloth setup")]
    [Space(10)]
    public bool canBeWorn = false;
    // public string material = "";
    public string effect = "";
    // public string enchantmets = "";
    public string color = "";
    public int attraction = 0;
    public int sexApeal = 0;
    public int ergonomic = 0;
    public int armor = 0;
    public int magic = 0;
    public float spiked = 0;
    public EquimpentSlot partOfBody;
   

}

public enum EquimpentSlot { Head, eyes, face, ears, neck, overTorso, torso, wings,
    wrists, gloves, rightHand, leftHand, rightHand2, leftHand2, rightHand3, leftHand3,
    fingers, hips, tail, legs, ankles, feet, feetAcessories, calves}
