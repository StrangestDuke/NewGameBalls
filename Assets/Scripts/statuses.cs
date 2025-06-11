using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class statuses : MonoBehaviour
{

    [SerializeField] public GameObject EffectsLayout;
    stats player;
    public List<EffectSlot> childrenOfLayout;
    public static statuses instance;

    public delegate void OnEffectsChange();
    public OnEffectsChange OnEffectsChangeCallback;

    public List<statusEffect> effects = new List<statusEffect>();
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

        childrenOfLayout = EffectsLayout.GetComponentsInChildren<EffectSlot>().ToList();
        int i = 0;
        foreach (statusEffect effect in effects)
        {
            effect.AddEffect(player);
            childrenOfLayout[i].AppendEffect(effect, i, 0);

            i++;
        }

        if (OnEffectsChangeCallback != null)
            OnEffectsChangeCallback.Invoke();
    }

    public void CheckYourTime(int time)
    {
        int updates = 0;
        int index = 0;

        //childrenOfLayout = EffectsLayout.GetComponentsInChildren<EffectSlot>();
        foreach (EffectSlot slot in childrenOfLayout.ToList())
        {
            if (slot.effectInSlot != null)
            {
                if (slot.IsItTimeToGo(time, index))
                {

                    effects.Remove(slot.effectInSlot);
                    Debug.Log("Getting rid of " + slot.effectInSlot);
                    slot.effectInSlot.RemoveEffect(player);
                    slot.ClearEffect();
                    childrenOfLayout.Remove(slot);
                    childrenOfLayout.Add(slot);
                    slot.transform.SetAsLastSibling();
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

}