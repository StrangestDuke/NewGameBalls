using System;
using Ink.Parsed;
using UnityEngine;

public class EffectsUI : MonoBehaviour
{
    statuses statusManager;
    [SerializeField] Transform effectsTransform;
    EffectSlot[] effectsSlots;
    EffectSlot effects;
    int indexer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        statusManager = statuses.instance;
        statusManager.OnEffectsChangeCallback += UpdateUIEffects;
        effectsSlots = statusManager.childrenOfLayout.ToArray();
        UpdateUIEffects();
    }


    void UpdateUIEffects()
    {
        Debug.Log("We are doing effects");
        //Индексер идет к нулю, т.к. при его не обнулении - игра начинает хуево обращаться к ячейкам инвентаря
        indexer = 0;
        int timeNeeded = 0;
        for (int i = 0; i < effectsSlots.Length; i++)
        {
            if (i < statusManager.effects.Count)
            {

                effectsSlots[i].AppendEffect(statusManager.effects[i], indexer, timeNeeded);
                indexer++;
            }
            else
            {
                effectsSlots[i].ClearEffect();
            }
        }
    }
}
