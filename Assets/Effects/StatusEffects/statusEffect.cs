using System.Runtime.InteropServices;
using UnityEngine;

public abstract class statusEffect : ScriptableObject
{
    public Sprite icon = null;
    public int duration;
    //Non-constant effects - we check their time every change of time
    //Constant effects - we don`t do that, just make tag, that it`s constant shit and change that shit, only if nedeed
    public abstract bool IsItTimeToGo(stats player, int time);
    public abstract void AddEffect(stats player);
    public abstract void RemoveEffect(stats player);
}
