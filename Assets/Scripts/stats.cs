using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class stats : MonoBehaviour
{

    public static stats instance;

    public int lvl = 1;

    [Space(10), Header("Counters")]
    [Space(10)]
    public float maxHealth = 100f;
    public float СurrentHealth = 100f;
    public float maxMana = 100f;
    public float СurrentMana = 100f;
    public float maxHunger = 100f;
    public float СurrentHunger = 100f;


    [Space(10), Header("Stats Base")]
    [Space(10)]
    public int strength = 10;
    public int dexterity = 10;
    public int vitality = 10;
    public int intelligence = 10;
    public int wisdow = 10;
    public int charisma = 10;

    [Space(10), Header("Stats Current")]
    [Space(10)]
    public int strengthCurrent = 10;
    public int dexterityCurrent = 10;
    public int vitalityCurrent = 10;
    public int intelligenceCurrent = 10;
    public int wisdowCurrent = 10;
    public int charismaCurrent = 10;

    //for the future systems
    public int maxDamage = 0;
    public int peacefullConfResolf = 0;
    public int agressiveConfResolf = 0;
    public int questsClosed = 0;
    public int ammountOfFood = 0;
    public int daysSurvived = 0;

    [Space(10), Header("Outfit")]
    [Space(10)]
    public float danger = 0;
    public float attraction = 0;
    public float sexApeal = 0;
    public float ergonomic = 0;
    public float armor = 0;
    public float magic = 0;
    public float spikes = 0;

    [Space(10), Header("Combat")]
    [Space(10)]

    public float CurrentCrit = 100f;
    public Dictionary<string, float> characterAbbilities = new Dictionary<string, float>();

    public Dictionary<string, float> characterWrongDoings = new Dictionary<string, float>();
    private void Start()
    {
        characterAbbilities.Add(nameof(danger), danger);
        characterAbbilities.Add(nameof(attraction), attraction);
        characterAbbilities.Add(nameof(sexApeal), sexApeal);
        characterAbbilities.Add(nameof(ergonomic) + "s", ergonomic);
        characterAbbilities.Add(nameof(armor), armor);
        characterAbbilities.Add(nameof(magic), magic);
        characterAbbilities.Add(nameof(spikes), spikes);
        characterAbbilities.Add(nameof(CurrentCrit), CurrentCrit);

        characterWrongDoings.Add(nameof(maxDamage), maxDamage);
        characterWrongDoings.Add(nameof(peacefullConfResolf), peacefullConfResolf);
        characterWrongDoings.Add(nameof(agressiveConfResolf), agressiveConfResolf);
        characterWrongDoings.Add(nameof(questsClosed), questsClosed);
        characterWrongDoings.Add(nameof(ammountOfFood), ammountOfFood);
        characterWrongDoings.Add(nameof(daysSurvived), daysSurvived);
    }
    public void takeDamageMana(float damage)
    {
        //Ñîáñòâåííî ñàìà ìåõàíèêà óðîíà
        if (maxMana >= СurrentMana + damage)
        {
            СurrentMana += damage;

        }
    }

    public void takeDamageHunger(float damage)
    {
        //Ñîáñòâåííî ñàìà ìåõàíèêà óðîíà
        if (maxHunger >= СurrentHunger + damage)
        {
            СurrentHunger += damage;

        }
    }

    public void takeDamageHp(float damage)
    {
        //Ñîáñòâåííî ñàìà ìåõàíèêà óðîíà
        if (maxMana >= СurrentHealth + damage)
        {
            СurrentHealth += damage;
        }
    }


}
