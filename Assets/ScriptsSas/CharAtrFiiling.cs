using System;
using UnityEngine;
using TMPro;

public class CharAtrFiiling : MonoBehaviour
{

    [SerializeField] public GameObject Strength;
    [SerializeField] public GameObject dexterity;
    [SerializeField] public GameObject vitality;
    [SerializeField] public GameObject intelligence;
    [SerializeField] public GameObject wisdow;
    [SerializeField] public GameObject charisma;

    [SerializeField] public stats statistic;

    [SerializeField] public GameObject[] abilities;

    [SerializeField] public GameObject[] wrongDoings;
    private void Start()
    {
    }

    public void FillStrength()
    {
        TextMeshProUGUI[] numbers = Strength.GetComponentsInChildren<TextMeshProUGUI>();
        numbers[0].text = nameof(statistic.strength);
        numbers[1].text = "" + statistic.strength.ToString() + " | " + statistic.strengthCurrent.ToString();    
    }

    public void Filldexterity()
    {
        TextMeshProUGUI[] numbers = dexterity.GetComponentsInChildren<TextMeshProUGUI>();
        numbers[0].text = nameof(statistic.dexterity);
        numbers[1].text = "" + statistic.dexterity.ToString() + " | " + statistic.dexterityCurrent.ToString();
    }
    public void Fillvitality()
    {
        TextMeshProUGUI[] numbers = vitality.GetComponentsInChildren<TextMeshProUGUI>();
        numbers[0].text = nameof(statistic.vitality);
        numbers[1].text = "" + statistic.vitality.ToString() + " | " + statistic.vitalityCurrent.ToString();
    }
    public void Fillintelligence()
    {
        TextMeshProUGUI[] numbers = intelligence.GetComponentsInChildren<TextMeshProUGUI>();
        numbers[0].text = nameof(statistic.intelligence);
        numbers[1].text = "" + statistic.vitality.ToString() + " | " + statistic.intelligenceCurrent.ToString();
    }
    public void Fillwisdow()
    {
        TextMeshProUGUI[] numbers = wisdow.GetComponentsInChildren<TextMeshProUGUI>();
        numbers[0].text = nameof(statistic.vitality);
        numbers[1].text = "" + statistic.vitality.ToString() + " | " + statistic.wisdowCurrent.ToString();
    }
    public void Fillcharisma()
    {
        TextMeshProUGUI[] numbers = charisma.GetComponentsInChildren<TextMeshProUGUI>();
        numbers[0].text = nameof(statistic.charisma);
        numbers[1].text = "" + statistic.charisma.ToString() + " | " + statistic.charismaCurrent.ToString();
    }

    public void FillAbbilities()
    {
        int i = 0;
        foreach (var statChar in statistic.characterAbbilities)
        {
            TextMeshProUGUI[] numbers = abilities[i].GetComponentsInChildren<TextMeshProUGUI>();
            numbers[0].text = statChar.Key;
            numbers[1].text = "" + "0" + " | " + statChar.Value;
            i++;
        }
    }

    public void FillWrongDoings()
    {
        int i = 0;
        foreach (var statChar in statistic.characterWrongDoings)
        {
            TextMeshProUGUI[] numbers = wrongDoings[i].GetComponentsInChildren<TextMeshProUGUI>();
            numbers[0].text = statChar.Key;
            numbers[1].text = "" + statChar.Value;
            i++;
        }
    }


    public void FillingEverything()
    {
        statistic.collectDataFromStats();
        FillStrength();
        Filldexterity();
        Fillwisdow();
        Fillcharisma();
        Fillintelligence();
        Fillvitality();
        FillAbbilities();
        FillWrongDoings();
    }
}
