
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
    public bool stackable = false;
    public int numberOfItems = 1;

    //for the future
    public bool enchantable = false;
    public bool brewable = false;

    [Space(10), Header("Food setup")]
    [Space(10)]
    public bool edable = false;
    public string taste = "";
    public string smell = "";
    //На время внедрения эффектов некоторые рофлы закоменчены
    public int hungerReplenish = 0;
    public int hpReplenish = 0;
    public int manaReplenish = 0;


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
    public DamageTypes mainTypeOfDamage;
    public ElementalTypes element;
    public AttackTypes[] additionalAttacks;
    [Space(10), Header("Cloth setup")]
    [Space(10)]
    public bool canBeWorn = false;
    public int attraction = 0;
    public int sexApeal = 0;
    public int ergonomic = 0;
    public int armor = 0;
    public int magic = 0;
    public int spiked = 0;
    public EquimpentSlot partOfBody;


    [Space(10), Header("passive setup")]
    [Space(10)]
    //Need to be done after basic setup would be done
    //public Enchantments[] enchantmets;
    public Effect[] effects;
    public string color = "";
    // public string material = ""
}

public enum EquimpentSlot { Head, eyes, face, ears, neck, overTorso, torso, wings,
    wrists, gloves, rightHand, leftHand, rightHand2, leftHand2, rightHand3, leftHand3,
    fingers, hips, tail, legs, ankles, feet, feetAcessories, calves }


public enum DamageTypes { Physic, magic }

//Cultivation simulator feng shui
public enum ElementalTypes { metal, water, wood, fire, earth }


public enum AttackTypes { slashing, blunt, distant, magic, fints, shielding, unarmed }

//Here for a time being
//public enum Enchantments { test, test1 }

//public enum Effects { test, test1 }
