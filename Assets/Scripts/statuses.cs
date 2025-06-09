using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class statuses : MonoBehaviour
{

    [SerializeField] public GameObject EffectsLayout;
    stats player;
    public EffectSlot[] childrenOfLayout;
    public static statuses instance;

    public delegate void OnEffectsChange();
    public OnEffectsChange OnEffectsChangeCallback;

    public List<statusEffect> effects = new List<statusEffect>();
    public List<int> timerList = new List<int>();
    private void Awake()
    {
        //I remembered how to make instances of shit
        if (instance != null)
        {
            Debug.LogWarning("You fucked up status instance");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        player = stats.instanceStats;

        childrenOfLayout = EffectsLayout.GetComponentsInChildren<EffectSlot>();
        int i = 0;
        foreach (statusEffect effect in effects)
        {
            effect.AddEffect(player);
            childrenOfLayout[i].AppendEffect(effect, i, 0);
            Debug.Log(childrenOfLayout[i].GimmeMyTime());

            timerList.Add(childrenOfLayout[i].GimmeMyTime());

            Debug.Log(timerList.Count);
            i++;
        }

        if (OnEffectsChangeCallback != null)
            OnEffectsChangeCallback.Invoke();
    }

    public void CheckYourTime(int time)
    {
        int updates = 0;
        int index = 0;
        foreach (EffectSlot slot in childrenOfLayout.ToList())
        {
            if (slot.effectInSlot != null)
            {
                if (slot.IsItTimeToGo(time, index))
                {
                    effects.Remove(slot.effectInSlot);
                    slot.ClearEffect();
                    updates++;
                }
            }
            index++;
        }
        if (updates != 0) 
        {
            if (OnEffectsChangeCallback != null)
                OnEffectsChangeCallback.Invoke();
        }
        
    }

    public void changingTime(int index, int time)
    {
        if (time == 0)
        {

            Debug.Log("Removing " + index);
            timerList.RemoveAt(index);
        }
        else
        {
            Debug.Log(index);
            timerList[index] = time;
        }
            
    }

}