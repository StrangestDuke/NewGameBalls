using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;


public class EffectSlot : MonoBehaviour
{
    public int indexer = 0;
    statusEffect effect;
    public Image icon;

    public int time;
    public statusEffect effectInSlot;
    public statuses statusesList;

    public void Start()
    {
        statusesList = statuses.instance;
    }

    public void AppendEffect(statusEffect newEffect, int index, int timeOfPrevSlot)
    {
        effectInSlot = newEffect;

        if (timeOfPrevSlot == 0)
        {
            time = effectInSlot.duration;
        }
        else
        {
            time = timeOfPrevSlot;
        }

            indexer = index;
        effect = newEffect;
        icon.sprite = effect.icon;
        icon.enabled = true;

    }
    public void ClearEffect()
    {
        effect = null;
        icon.sprite = null;
        effectInSlot = null;
        time = 0;
        indexer = 0;
        icon.enabled = false;

    }

    public bool IsItTimeToGo(int timeThatTook, int indexOfTime)
    {
        if (time - timeThatTook < 0)
        {
            Debug.Log("В ПИЗДУ");
            time = 0;
            statusesList.changingTime(indexOfTime, 0);
            return true;

        }
        else
        {
            time = time - timeThatTook;

            statusesList.changingTime(indexOfTime, time);
            return false;
        }
    }

    public int GimmeMyTime()
    {
        return time;
    }
}
